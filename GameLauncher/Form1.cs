using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace GameLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LaunchGame("isleofeline");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadGame("isleofeline");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckForUpdates("isleofeline");
        }

        private void LaunchGame(string gameName)
        {
            try
            {
                string savedPath = Properties.Settings.Default.GameExecutables?.ToString();

                // If a saved path exists and the file still exists, launch the game
                if (!string.IsNullOrEmpty(savedPath) && File.Exists(savedPath))
                {
                    Process.Start(savedPath);
                }
                else
                {
                    // Prompt the user to select the game executable
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                        openFileDialog.Title = $"Select the {gameName} executable file";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedFilePath = openFileDialog.FileName;

                            // Launch the selected game executable
                            Process.Start(selectedFilePath);

                            // Save the selected file path for future launches
                            Properties.Settings.Default.GameExecutables = selectedFilePath;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DownloadGame(string gameName)
        {
            try
            {
                // Open a SaveFileDialog to allow the user to select the download location
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "ZIP files (*.zip)|*.zip";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Construct the URL for the game download
                        string downloadUrl = "https://www.dropbox.com/scl/fi/bivi3cns8b4swl2f0ia33/Windows.zip?rlkey=t7vdos3lh8yw75p3m35vft3nr&st=foqjox0c&dl=1";

                        // Specify the download path
                        string downloadPath = saveDialog.FileName;

                        // Initialize WebClient for downloading
                        using (WebClient client = new WebClient())
                        {
                            // Subscribe to the DownloadProgressChanged event to update the progress bar
                            client.DownloadProgressChanged += (sender, e) =>
                            {
                                // Update the progress bar with the current progress
                                progressBar1.Value = e.ProgressPercentage;
                            };

                            // Download the game file asynchronously
                            client.DownloadFileAsync(new Uri(downloadUrl), downloadPath);

                            // Wait for the download to complete
                            client.DownloadFileCompleted += (sender, e) =>
                            {
                                // Extract the downloaded ZIP file
                                string extractPath = Path.Combine(Path.GetDirectoryName(downloadPath), gameName);
                                ZipFile.ExtractToDirectory(downloadPath, extractPath);

                                // Delete the ZIP file
                                File.Delete(downloadPath);

                                // Show completion message
                                MessageBox.Show($"Download and extraction complete for {gameName}.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to download and extract the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void CheckForUpdates(string gameName)
        {
            try
            {
                string installedVersion = GetInstalledVersion(gameName);
                string availableVersion = GetAvailableVersionFromManifest(gameName);

                if (IsVersionGreater(availableVersion, installedVersion))
                {
                    MessageBox.Show($"Update available for {gameName}: Version {availableVersion}. Download and install now?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"No updates available for {gameName}.", "No Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for updates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetGameDirectory(string gameName)
        {
            // Specify the directory where the game is expected to be installed
            string expectedDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), gameName);

            // Check if the expected directory exists
            if (Directory.Exists(expectedDirectory))
            {
                return expectedDirectory;
            }

            // If the expected directory does not exist, return a default message
            return $"Game directory not found for {gameName}.";
        }


        private string GetInstalledVersion(string gameName)
        {
            // Default installed version (if unable to retrieve actual version)
            string installedVersion = "1.0.0";

            try
            {
                // Logic to retrieve the installed version of the game
                // For example, you can read the version from a file named "version.txt" within the game directory
                string versionFilePath = Path.Combine(GetGameDirectory(gameName), "version.txt");

                if (File.Exists(versionFilePath))
                {
                    installedVersion = File.ReadAllText(versionFilePath).Trim();
                }
                else
                {
                    // Handle case where version file does not exist or cannot be accessed
                    MessageBox.Show($"Version file not found for {gameName}. Using default version: {installedVersion}", "Version File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during version retrieval
                MessageBox.Show($"Error retrieving installed version for {gameName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return installedVersion;
        }

        private string GetAvailableVersionFromManifest(string gameName)
        {
            // Retrieve the available version from an update manifest or repository
            // For demonstration purposes, let's assume a hard-coded version
            return "1.2.0";
        }

        private bool IsVersionGreater(string version1, string version2)
        {
            // Split version strings into individual components
            string[] parts1 = version1.Split('.');
            string[] parts2 = version2.Split('.');

            // Parse version components as integers
            int major1 = int.Parse(parts1[0]);
            int minor1 = int.Parse(parts1[1]);
            int patch1 = int.Parse(parts1[2]);

            int major2 = int.Parse(parts2[0]);
            int minor2 = int.Parse(parts2[1]);
            int patch2 = int.Parse(parts2[2]);

            // Compare version components
            if (major1 > major2)
            {
                return true;
            }
            else if (major1 == major2)
            {
                if (minor1 > minor2)
                {
                    return true;
                }
                else if (minor1 == minor2)
                {
                    if (patch1 > patch2)
                    {
                        return true;
                    }
                }
            }

            // If none of the above conditions are met, version1 is not greater than version2
            return false;
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            DownloadGame("");
        }
    }
}
