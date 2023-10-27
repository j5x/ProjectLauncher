using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Configuration;

namespace GameLauncher
{
    public partial class Form1 : Form
    {
        private string gameDirectory;

        public Form1()
        {
            InitializeComponent();
            gameDirectory = Properties.Settings.Default.GameDirectory;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "ZIP files (*.zip)|*.zip";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string downloadPath = saveDialog.FileName;
                        string githubLink = "https://github.com/MikeHuijgen/BO-TowerDefends/releases/download/Version1.1/Bloonz.Version.1.1.zip"; // Specify the GitHub release link here

                        try
                        {
                            client.DownloadProgressChanged += (s, args) =>
                            {
                                // Update the progress bar while downloading
                                progressBar1.Value = args.ProgressPercentage;
                            };

                            client.DownloadFileCompleted += (s, args) =>
                            {
                                MessageBox.Show("Download complete!");
                                // Reset the progress bar after download is complete
                                progressBar1.Value = 0;

                                // Extract the downloaded ZIP file
                                if (File.Exists(downloadPath))
                                {
                                    System.IO.Compression.ZipFile.ExtractToDirectory(downloadPath, Path.Combine(Path.GetDirectoryName(downloadPath), "ExtractedFiles"));
                                    MessageBox.Show("Extraction complete!");
                                }
                                else
                                {
                                    MessageBox.Show("Downloaded file not found!");
                                }
                            };

                            // Start the download asynchronously
                            await client.DownloadFileTaskAsync(githubLink, downloadPath);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(gameDirectory) || !File.Exists(gameDirectory))
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Executable files|*.exe";
                        openFileDialog.Title = "Select the game executable file";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            gameDirectory = openFileDialog.FileName;
                            Properties.Settings.Default.GameDirectory = gameDirectory;
                            Properties.Settings.Default.Save();
                            Process.Start(gameDirectory);
                        }
                        else
                        {
                            MessageBox.Show("No file selected. Please choose the game executable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Process.Start(gameDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }       
    }
}
