using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBiz
{
    /// <summary>Lightweight description of one backup file stored on Google Drive.</summary>
    public class DriveBackupInfo
    {
        public string FileId { get; set; } = "";
        public string FileName { get; set; } = "";
        public long SizeBytes { get; set; }
        public DateTime CreatedUtc { get; set; }
    }

    /// <summary>
    /// Handles authenticating with Google Drive and uploading/downloading
    /// EasyBiz database backups. Uses the narrow "drive.file" scope, so the
    /// app can only see files it created itself — not the user's whole Drive.
    /// </summary>
    public static class GoogleDriveBackupService
    {
        private const string ApplicationName = "EasyBiz Backup";
        private static readonly string[] Scopes = { DriveService.Scope.DriveFile };

        // OAuth tokens are cached here between runs so the user isn't asked
        // to sign in to Google every single time.
        private static readonly string TokenStoreFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "EasyBiz", "GoogleTokens");

        // OAuth "Desktop app" client file downloaded from Google Cloud Console.
        // See README-GoogleDriveBackup.md for how to generate this.
        private static readonly string ClientSecretPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "client_secret.json");

        private const string BackupFolderName = "EasyBiz Backups";

        private static DriveService _service;
        private static string _backupFolderId;

        public static bool IsConfigured => File.Exists(ClientSecretPath);

        private static async Task<DriveService> GetServiceAsync(CancellationToken ct = default)
        {
            if (_service != null) return _service;

            if (!IsConfigured)
                throw new InvalidOperationException(
                    "Google Drive is not configured yet.\n\n" +
                    $"Place your OAuth 'client_secret.json' file here:\n{ClientSecretPath}\n\n" +
                    "See README-GoogleDriveBackup.md for setup steps.");

            UserCredential credential;
            using (var stream = new FileStream(ClientSecretPath, FileMode.Open, FileAccess.Read))
            {
                Directory.CreateDirectory(TokenStoreFolder);

                // This opens the user's browser for consent the first time,
                // then silently reuses the cached token on later runs.
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "easybiz-user",
                    ct,
                    new FileDataStore(TokenStoreFolder, true));
            }

            _service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });

            return _service;
        }

        private static async Task<string> GetOrCreateBackupFolderIdAsync(DriveService service)
        {
            if (_backupFolderId != null) return _backupFolderId;

            var listRequest = service.Files.List();
            listRequest.Q = $"name = '{BackupFolderName}' and mimeType = 'application/vnd.google-apps.folder' and trashed = false";
            listRequest.Spaces = "drive";
            listRequest.Fields = "files(id, name)";

            var result = await listRequest.ExecuteAsync();
            var existing = result.Files?.FirstOrDefault();
            if (existing != null)
            {
                _backupFolderId = existing.Id;
                return _backupFolderId;
            }

            var folderMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = BackupFolderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            var createRequest = service.Files.Create(folderMetadata);
            createRequest.Fields = "id";
            var folder = await createRequest.ExecuteAsync();
            _backupFolderId = folder.Id;
            return _backupFolderId;
        }

        /// <summary>
        /// Uploads a timestamped copy of the local database to the
        /// "EasyBiz Backups" folder on Google Drive.
        /// </summary>
        public static async Task<DriveBackupInfo> BackupNowAsync(IProgress<string> progress = null, CancellationToken ct = default)
        {
            progress?.Report("Connecting to Google Drive...");
            var service = await GetServiceAsync(ct);

            progress?.Report("Preparing local database copy...");
            string dbPath = GetLocalDbPath();
            if (!File.Exists(dbPath))
                throw new FileNotFoundException("Could not find the EasyBiz database file.", dbPath);

            // Copy to a temp file first so we never upload a file mid-write.
            string tempCopy = Path.Combine(Path.GetTempPath(), $"easybiz_backup_{Guid.NewGuid():N}.db");
            File.Copy(dbPath, tempCopy, overwrite: true);

            try
            {
                progress?.Report("Locating backup folder on Drive...");
                string folderId = await GetOrCreateBackupFolderIdAsync(service);

                string fileName = $"EasyBiz_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.db";

                var fileMetadata = new Google.Apis.Drive.v3.Data.File
                {
                    Name = fileName,
                    Parents = new List<string> { folderId }
                };

                progress?.Report("Uploading backup...");
                using (var stream = new FileStream(tempCopy, FileMode.Open, FileAccess.Read))
                {
                    var uploadRequest = service.Files.Create(fileMetadata, stream, "application/x-sqlite3");
                    uploadRequest.Fields = "id, name, size, createdTime";
                    var uploadStatus = await uploadRequest.UploadAsync(ct);

                    if (uploadStatus.Status != Google.Apis.Upload.UploadStatus.Completed)
                        throw uploadStatus.Exception ?? new Exception("Upload did not complete.");

                    var uploaded = uploadRequest.ResponseBody;
                    progress?.Report("Backup complete.");

                    return new DriveBackupInfo
                    {
                        FileId = uploaded.Id,
                        FileName = uploaded.Name,
                        SizeBytes = uploaded.Size ?? 0,
                        CreatedUtc = uploaded.CreatedTimeDateTimeOffset?.UtcDateTime ?? DateTime.UtcNow
                    };
                }
            }
            finally
            {
                try { File.Delete(tempCopy); } catch { /* best effort cleanup */ }
            }
        }

        /// <summary>Lists available backups on Drive, most recent first.</summary>
        public static async Task<List<DriveBackupInfo>> ListBackupsAsync(CancellationToken ct = default)
        {
            var service = await GetServiceAsync(ct);
            string folderId = await GetOrCreateBackupFolderIdAsync(service);

            var listRequest = service.Files.List();
            listRequest.Q = $"'{folderId}' in parents and trashed = false";
            listRequest.Fields = "files(id, name, size, createdTime)";
            listRequest.OrderBy = "createdTime desc";
            listRequest.PageSize = 100;

            var result = await listRequest.ExecuteAsync();

            return (result.Files ?? new List<Google.Apis.Drive.v3.Data.File>())
                .Select(f => new DriveBackupInfo
                {
                    FileId = f.Id,
                    FileName = f.Name,
                    SizeBytes = f.Size ?? 0,
                    CreatedUtc = f.CreatedTimeDateTimeOffset?.UtcDateTime ?? DateTime.MinValue
                })
                .ToList();
        }

        /// <summary>
        /// Downloads the chosen backup and replaces the local database file.
        /// The existing local database is saved as a timestamped ".bak" file
        /// first, so a bad restore can always be undone manually.
        /// </summary>
        public static async Task RestoreAsync(string fileId, IProgress<string> progress = null, CancellationToken ct = default)
        {
            var service = await GetServiceAsync(ct);

            progress?.Report("Downloading backup...");
            string dbPath = GetLocalDbPath();
            string tempDownload = Path.Combine(Path.GetTempPath(), $"easybiz_restore_{Guid.NewGuid():N}.db");

            using (var output = new FileStream(tempDownload, FileMode.Create, FileAccess.Write))
            {
                var request = service.Files.Get(fileId);
                await request.DownloadAsync(output, ct);
            }

            progress?.Report("Verifying downloaded file...");
            var fileInfo = new FileInfo(tempDownload);
            if (fileInfo.Length == 0)
                throw new Exception("Downloaded backup is empty — restore aborted, original database left untouched.");

            progress?.Report("Backing up current database before overwrite...");
            if (File.Exists(dbPath))
            {
                string safetyCopy = dbPath + $".before-restore-{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                File.Copy(dbPath, safetyCopy, overwrite: true);
            }

            progress?.Report("Replacing local database...");
            File.Copy(tempDownload, dbPath, overwrite: true);

            try { File.Delete(tempDownload); } catch { /* best effort cleanup */ }

            progress?.Report("Restore complete. Please restart EasyBiz.");
        }

        private static string GetLocalDbPath()
        {
            // Matches DatabaseHelper's connection string ("Data Source=easybiz.db"),
            // which SQLite resolves relative to the process's working directory —
            // normally the same folder as EasyBiz.exe.
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "easybiz.db");
        }

        /// <summary>Forgets the cached OAuth token, forcing sign-in again next time.</summary>
        public static void SignOut()
        {
            _service = null;
            _backupFolderId = null;
            try
            {
                if (Directory.Exists(TokenStoreFolder))
                    Directory.Delete(TokenStoreFolder, recursive: true);
            }
            catch { /* best effort cleanup */ }
        }
    }
}
