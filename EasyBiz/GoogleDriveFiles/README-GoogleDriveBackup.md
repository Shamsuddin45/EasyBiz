# EasyBiz — Google Drive Backup & Restore Setup

This adds a "Backup Data" feature that uploads a timestamped copy of your
`easybiz.db` file to a folder called **"EasyBiz Backups"** in Google Drive,
and lets you restore any previous backup back down.

## Files included

- `GoogleDriveBackupService.cs` — talks to the Google Drive API (upload, list, download)
- `BackupRestoreForm.cs` — the dialog shown when you click "Backup Data"
- `MainForm.BackupWiring.patch.cs` — the 2 small edits needed in your existing `MainForm.cs`

Drop the two `.cs` files straight into your EasyBiz project folder, then apply
the two edits from the patch file to `MainForm.cs`.

## 1. Install NuGet packages

In Visual Studio: **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**,
or via the Package Manager Console:

```
Install-Package Google.Apis.Drive.v3
Install-Package Google.Apis.Auth
```

`Google.Apis.Drive.v3` pulls in the core Google API client libraries as
dependencies, so that's normally all you need.

## 2. Create a Google Cloud OAuth credential (one-time, ~5 minutes)

This lets your copies of EasyBiz talk to Google Drive on your users' behalf.
You only do this once per app, not once per user.

1. Go to <https://console.cloud.google.com/> and create a new project
   (or reuse an existing one) — e.g. "EasyBiz".
2. In the left menu: **APIs & Services → Library** → search for
   **"Google Drive API"** → click **Enable**.
3. **APIs & Services → OAuth consent screen**:
   - User type: **External** (unless you have a Google Workspace org, then Internal is fine)
   - Fill in an app name ("EasyBiz"), your support email, and developer contact email
   - Scopes: you don't need to add any here — the app requests
     `drive.file` at runtime, which only grants access to files it creates
   - Test users: while the app is in "Testing" mode, add the Google
     account(s) you'll sign in with (yourself, and anyone else testing it)
4. **APIs & Services → Credentials → + Create Credentials → OAuth client ID**:
   - Application type: **Desktop app**
   - Name: "EasyBiz Desktop"
   - Click **Create**, then **Download JSON**
5. Rename the downloaded file to **`client_secret.json`** and place it in
   the same folder as `EasyBiz.exe` (the build output folder — e.g.
   `bin\Debug\net8.0-windows\`). Make sure your build copies it there
   automatically by setting its file properties in Visual Studio:
   - Right-click `client_secret.json` in Solution Explorer → **Properties**
   - **Copy to Output Directory** → **Copy if newer**

> **Important:** `client_secret.json` identifies your *app*, not any one
> user's account — it's safe to ship with EasyBiz, but don't publish it
> publicly (e.g. don't commit it to a public GitHub repo) since anyone
> could technically use it to impersonate your app's identity, even though
> they'd still need each user's own Google sign-in to access that user's
> Drive.

## 3. First run

The first time someone clicks **Backup Now** (or opens the Backup/Restore
dialog with an existing backup already on Drive), their default browser
will open asking them to sign in to Google and approve access. After that,
EasyBiz remembers the approval locally (in
`%LocalAppData%\EasyBiz\GoogleTokens`) and won't ask again unless they use
the **Sign Out** button in the dialog.

## How it works

- **Backup Now** copies the local `easybiz.db` to a temp file, then uploads
  it to Drive as `EasyBiz_Backup_YYYYMMDD_HHMMSS.db` inside a
  **"EasyBiz Backups"** folder (created automatically the first time).
- **Restore Selected** downloads the chosen backup, saves your *current*
  database as a `.bak` file (so nothing is ever silently lost), then
  overwrites `easybiz.db` with the restored copy and asks you to restart
  EasyBiz.
- Only the `drive.file` scope is requested, so EasyBiz can only see/manage
  files it created (the backups themselves) — not your whole Google Drive.

## Notes / things to double check for your setup

- The backup/restore logic assumes `easybiz.db` lives in the same folder as
  `EasyBiz.exe` (matching `DatabaseHelper`'s `"Data Source=easybiz.db"`
  connection string, which SQLite resolves relative to the working
  directory). If you ever change where the database lives, update
  `GetLocalDbPath()` in `GoogleDriveBackupService.cs` to match.
- A restore requires no other part of the app to be writing to the database
  at that moment — that's why the form calls `Application.Exit()`
  immediately after a successful restore and asks the user to reopen
  EasyBiz, rather than trying to hot-swap the file while the app keeps running.
- Consider adding a scheduled/automatic daily backup later (e.g. a timer in
  `MainForm.Load` that calls `GoogleDriveBackupService.BackupNowAsync()` once
  a day) — the service is already async and safe to call from anywhere.
