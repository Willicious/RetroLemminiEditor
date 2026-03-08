using System;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
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
                return new Version(0, 0);

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
                return new Version(0, 0);
            }
        }

        private Version GetRemoteVersion()
        {
            try
            {
                using (var wc = new WebClient())
                {
                    wc.Headers.Add("User-Agent", "RetroLemmini");
                    string versionText = wc.DownloadString(RemoteVersionUrl).Trim();
                    return Version.Parse(versionText);
                }
            }
            catch
            {
                return new Version(0, 0);
            }
        }

        private bool ShouldCheckForUpdate()
        {
            try
            {
                return (DateTime.Now - curSettings.LastLPCUpdateCheck).TotalDays > 7;
            }
            catch
            {
                return true;
            }
        }

        public void UpdateLevelPackCompiler(bool userLaunched = false)
        {
            if (!ShouldCheckForUpdate() && !userLaunched)
                return;

            string exePath = GetExePath();
            if (exePath == null)
            {
                curSettings.LastLPCUpdateCheck = DateTime.Now;
                curSettings.WriteSettingsToFile();
                return;
            }

            try
            {
                Version localVersion = GetLocalVersion(exePath);
                Version remoteVersion = GetRemoteVersion();

                if (remoteVersion > localVersion)
                {
                    if (infoLabel != null && userLaunched)
                    {
                        infoLabel.Text = "Updating Level Pack Compiler...";
                        infoLabel.ForeColor = Color.DarkBlue;
                        infoLabel.Visible = true;
                        infoLabel.Refresh();
                    }

                    string tempPath = Path.Combine(Path.GetTempPath(), LevelPackCompilerExeName);
                    try
                    {
                        using (var wc = new WebClient())
                        {
                            wc.Headers.Add("User-Agent", "RetroLemminiEditor");
                            wc.DownloadFile(RemoteExeUrl, tempPath);
                        }

                        File.Replace(tempPath, exePath, null);
                    }
                    catch (Exception ex)
                    {
                        if (infoLabel != null && userLaunched)
                        {
                            infoLabel.Text = "Level Pack Compiler update failed";
                            infoLabel.ForeColor = Color.DarkRed;
                            infoLabel.Visible = true;
                            infoLabel.Refresh();
                        }
                        return; // Keep label visible, don't update last time checked
                    }
                }

                if (infoLabel != null && userLaunched)
                    infoLabel.Visible = false;

                curSettings.LastLPCUpdateCheck = DateTime.Now;
                curSettings.WriteSettingsToFile();
            }
            catch
            {
                // Fail silently
            }
        }

        public void LaunchLevelPackCompiler()
        {
            UpdateLevelPackCompiler(true);

            string exePath = GetExePath();
            if (exePath != null)
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
                    MessageBox.Show($"Failed to launch {LevelPackCompilerExeName}:\n{ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"{LevelPackCompilerExeName} could not be found in the application folders.\n\n" +
                    "Would you like to download it now?",
                    "Not Found",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string savePath = Path.Combine(C.AppPath, LevelPackCompilerExeName);
                    try
                    {
                        using (var wc = new WebClient())
                        {
                            wc.Headers.Add("User-Agent", "RetroLemminiEditor");
                            wc.DownloadFile(RemoteExeUrl, savePath);
                        }

                        MessageBox.Show($"{LevelPackCompilerExeName} was downloaded to:\n{savePath}",
                                        "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Launch the downloaded exe
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = savePath,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to download {LevelPackCompilerExeName}:\n{ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}