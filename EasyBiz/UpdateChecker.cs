using System.Net.Http;
using System.Text.Json;

public static class UpdateChecker
{
    private const string ManifestUrl = "https://github.com/Shamsuddin45/easybiz-updates/blob/05bcbc8b762fecad77354cc9e737080010bc62c9/downloads/version.json";
    public static readonly Version CurrentVersion = new Version(1, 0, 0);

    public static async Task CheckForUpdateAsync(Form owner)
    {
        try
        {
            using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
            string json = await http.GetStringAsync(ManifestUrl);
            var info = JsonSerializer.Deserialize<UpdateInfo>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (info == null || !Version.TryParse(info.LatestVersion, out var latest))
                return;

            if (latest > CurrentVersion)
            {
                var result = MessageBox.Show(owner,
                    $"A new version of EasyBiz ({info.LatestVersion}) is available.\n\n" +
                    $"{info.ReleaseNotes}\n\nOpen the download page now?",
                    "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    System.Diagnostics.Process.Start(
                        new System.Diagnostics.ProcessStartInfo(info.DownloadUrl)
                        { UseShellExecute = true });
            }
        }
        catch
        {
            // Silent fail — don't block startup or nag on a bad network day
        }
    }

    private class UpdateInfo
    {
        public string LatestVersion { get; set; } = "";
        public string DownloadUrl { get; set; } = "";
        public string ReleaseNotes { get; set; } = "";
    }
}