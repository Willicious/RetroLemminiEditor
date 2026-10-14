using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RLEditor
{
    internal class LevelPackCompilerManager
    {
        private static string LevelPackCompilerExeName = "LemminiLevelPackCompiler.exe";
        private static string RemoteVersionUrl = "https://raw.githubusercontent.com/Willicious/RetroLemmini/refs/heads/main/src/apps/Lemmini%20Level%20Pack%20Compiler/LemminiLevelPackCompiler.version.txt";
        private static string RemoteExeUrl = "https://williciousmedia.short.gy/RLLevelPackCompiler";

        private Settings curSettings;
        private Label infoLabel;

        private const int minCheckDays = 7;

        public LevelPackCompilerManager(Settings settings, Label label)
        {
            curSettings = settings;
            infoLabel = label;
        }

        private string GetExePath()
        {
            string[] searchPaths = { C.AppPath, C.AppPathResources };
            foreach (var path in searchPaths)
            {
                if (string.IsNullOrEmpty(path)) continue;

                string fullPath = Path.Combine(path, LevelPackCompilerExeName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        private Version GetLocalVersion(string exePath)
        {
            if (!File.Exists(exePath))
                return null;

            try
            {
                var info = FileVersionInfo.GetVersionInfo(exePath);
                var parts = info.ProductVersion.Split('.');
                int major = int.Parse(parts[0]);
                int minor = int.Parse(parts[1]);
                return new Version(major, minor);
            }
            catch
            {
                return null;
            }
        }

        private async Task<Version> GetRemoteVersion()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "RetroLemmini");
                    string versionText = (await wc.DownloadStringTaskAsync(RemoteVersionUrl)).Trim();

                    return Version.Parse(versionText);
                }
            }
            catch
            {
                return null;
            }
        }

        private bool ShouldCheckForUpdate()
        {
            return curSettings.LastLPCUpdateCheck == DateTime.MinValue ||
                   (DateTime.Now - curSettings.LastLPCUpdateCheck).TotalDays >= minCheckDays;
        }

        public async Task UpdateLevelPackCompiler(bool userLaunched = false)
        {
            if (!ShouldCheckForUpdate() && !userLaunched)
                return;

            string exePath = GetExePath();

            if (string.IsNullOrEmpty(exePath))
                return;

            try
            {
                Version localVersion = GetLocalVersion(exePath);
                Version remoteVersion = await GetRemoteVersion();

                if (remoteVersion == null || localVersion == null ||
                    remoteVersion > localVersion)
                {
                    if (infoLabel != null && userLaunched)
                    {
                        infoLabel.Text = "Updating Level Pack Compiler...";
                        infoLabel.ForeColor = Color.DarkBlue;
                        infoLabel.Visible = true;
                        infoLabel.Refresh();
                    }

                    // Keep the temporary file beside the existing executable
                    string tempPath = exePath + ".download";

                    try
                    {
                        if (File.Exists(tempPath))
                            File.Delete(tempPath);

                        using (var wc = new WebClient())
                        {
                            wc.Headers.Add("User-Agent", "RetroLemminiEditor");
                            await wc.DownloadFileTaskAsync(new Uri(RemoteExeUrl), tempPath);
                        }

                        File.Replace(tempPath, exePath, null);
                    }
                    catch
                    {
                        try
                        {
                            if (File.Exists(tempPath))
                                File.Delete(tempPath);
                        }
                        catch
                        {
                            // Fail silently
                        }

                        if (infoLabel != null && userLaunched)
                        {
                            infoLabel.Text = "Level Pack Compiler update failed";
                            infoLabel.ForeColor = Color.DarkRed;
                            infoLabel.Visible = true;
                            infoLabel.Refresh();
                        }

                        return;
                    }
                }

                if (infoLabel != null && userLaunched)
                    infoLabel.Visible = false;
            }
            catch
            {
                // Fail silently
            }
        }

        public async Task LaunchLevelPackCompiler()
        {
            await UpdateLevelPackCompiler(true);

            string exePath = GetExePath();

            if (!string.IsNullOrEmpty(exePath) && File.Exists(exePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = exePath,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Failed to launch {LevelPackCompilerExeName}:\n{ex.Message}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                return;
            }

            DialogResult result = MessageBox.Show(
                $"{LevelPackCompilerExeName} could not be found in the application folders.\n\n" +
                "Would you like to download it now?",
                "Not Found",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string savePath = Path.Combine(C.AppPath, LevelPackCompilerExeName);
            string tempPath = savePath + ".download";

            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "RetroLemminiEditor");
                    await wc.DownloadFileTaskAsync(new Uri(RemoteExeUrl), tempPath);
                }

                if (!File.Exists(tempPath) || new FileInfo(tempPath).Length == 0)
                    throw new IOException("The downloaded file is empty or missing.");

                if (File.Exists(savePath))
                    File.Delete(savePath);

                File.Move(tempPath, savePath);

                MessageBox.Show(
                    $"{LevelPackCompilerExeName} was downloaded to:\n{savePath}",
                    "Download Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Process.Start(new ProcessStartInfo
                {
                    FileName = savePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                try
                {
                    if (File.Exists(tempPath))
                        File.Delete(tempPath);
                }
                catch
                {
                    // Fail silently
                }

                MessageBox.Show(
                    $"Failed to download or launch {LevelPackCompilerExeName}:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}