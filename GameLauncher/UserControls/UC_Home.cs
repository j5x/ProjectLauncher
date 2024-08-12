using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLauncher.UserControls
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }

        private void RedirectToHyperlink(string url)
        {
            try
            {
                // Use ProcessStartInfo to ensure the URL opens correctly in the default browser
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                };
         
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to open link: {url}. Error: {ex.Message}");
            }
        }

        private void FC_Container01_Click(object sender, EventArgs e)
        {
            RedirectToHyperlink("https://www.veldboomstudios.com/");
        }

        private void FC_Container02_Click(object sender, EventArgs e)
        {
            RedirectToHyperlink("https://www.veldboomstudios.com/");
        }
        private void FC_Container03_Click(object sender, EventArgs e)
        {
            RedirectToHyperlink("https://www.veldboomstudios.com/");
        }
        private void FC_Container04_Click(object sender, EventArgs e)
        {
            RedirectToHyperlink("https://www.veldboomstudios.com/");
        }
        private void FC_Container05_Click(object sender, EventArgs e)
        {
            RedirectToHyperlink("https://www.veldboomstudios.com/");
        }
    }
}
