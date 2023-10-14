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
        private const string GamePath = @"D:\VBS\Launcher\Build\MyProject.exe";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Perform any additional initialization tasks
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(GamePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch the game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = "j5x"; // Replace with the GitHub username
            string repository = "Unreal-Ensemble"; // Replace with the repository name
            string releaseTag = "testrelease"; // Replace with the specific release tag
            string assetName = "Unreal-Ensemble-main.zip"; // Replace with the name of the asset to be downloaded

            using (var client = new WebClient())
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.FileName = assetName;
                    saveDialog.Filter = "ZIP files (*.zip)|*.zip";
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string downloadPath = saveDialog.FileName;

                        client.Headers.Add("User-Agent", "request");
                        client.DownloadFile(new Uri($"https://github.com/{username}/{repository}/releases/download/{releaseTag}/{assetName}"), downloadPath);
                        MessageBox.Show("Download complete!");

                        // Extract the downloaded ZIP file
                        if (File.Exists(downloadPath))
                        {
                            var extractPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ExtractedFiles"); // Customize the extraction path
                            if (!Directory.Exists(extractPath))
                            {
                                Directory.CreateDirectory(extractPath);
                            }
                            ZipFile.ExtractToDirectory(downloadPath, extractPath);
                            MessageBox.Show("Extraction complete!");
                        }
                        else
                        {
                            MessageBox.Show("Downloaded file not found!");
                        }
                    }
                }
            }
        }
    }
}
