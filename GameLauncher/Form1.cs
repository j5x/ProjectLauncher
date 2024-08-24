using Newtonsoft.Json.Linq;
using System;
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

        private void LaunchGame(string gameName)
        {
            try
            {
                string savedPath = Properties.Settings.Default.GameExecutables?.ToString();

                if (!string.IsNullOrEmpty(savedPath) && File.Exists(savedPath))
                {
                    Process.Start(savedPath);
                }
                else
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                        openFileDialog.Title = $"Select the {gameName} executable file";

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedFilePath = openFileDialog.FileName;
                            Process.Start(selectedFilePath);

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
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "ZIP files (*.zip)|*.zip";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string downloadUrl = "https://www.dropbox.com/scl/fi/bivi3cns8b4swl2f0ia33/Windows.zip?rlkey=t7vdos3lh8yw75p3m35vft3nr&st=foqjox0c&dl=1";
                        string downloadPath = saveDialog.FileName;

                        using (WebClient client = new WebClient())
                        {
                            client.DownloadProgressChanged += (sender, e) =>
                            {
                                progressBar1.Value = e.ProgressPercentage;
                            };

                            client.DownloadFileAsync(new Uri(downloadUrl), downloadPath);

                            client.DownloadFileCompleted += (sender, e) =>
                            {
                                string extractPath = Path.Combine(Path.GetDirectoryName(downloadPath), gameName);
                                ZipFile.ExtractToDirectory(downloadPath, extractPath);

                                File.Delete(downloadPath);

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

        private string GetGameDirectory(string gameName)
        {
            string expectedDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), gameName);

            if (Directory.Exists(expectedDirectory))
            {
                return expectedDirectory;
            }

            return $"Game directory not found for {gameName}.";
        }

        private void btn_install_Click(object sender, EventArgs e)
        {
            DownloadGame("");
        }
    }
}
