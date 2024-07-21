namespace GameLauncher.UserControls
{
    partial class UC_Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Home));
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            panel10 = new Panel();
            panel11 = new Panel();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel9 = new Panel();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panel9);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1060, 620);
            panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = SystemColors.ActiveBorder;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = SystemColors.Window;
            richTextBox1.Location = new Point(508, 28);
            richTextBox1.Margin = new Padding(0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(488, 205);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            richTextBox1.ZoomFactor = 0.82F;
            // 
            // textBox1
            // 
            textBox1.AllowDrop = true;
            textBox1.BackColor = SystemColors.ActiveBorder;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.ForeColor = SystemColors.Window;
            textBox1.Location = new Point(508, 8);
            textBox1.Margin = new Padding(0);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(488, 20);
            textBox1.TabIndex = 9;
            textBox1.Text = "    Isle Of Eline 0.2 Released";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.urumabackground;
            pictureBox1.Location = new Point(8, 8);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(panel10);
            flowLayoutPanel2.Controls.Add(panel11);
            flowLayoutPanel2.Location = new Point(5, 343);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(750, 274);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Location = new Point(3, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(200, 250);
            panel10.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Location = new Point(209, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(200, 250);
            panel11.TabIndex = 1;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(5, 310);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(203, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Featured Content";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(844, 310);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 27);
            textBox3.TabIndex = 5;
            textBox3.Text = "Featured Screenshot";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(844, 445);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 27);
            textBox2.TabIndex = 4;
            textBox2.Text = "Weekly Spotlights";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Location = new Point(844, 476);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333359F));
            tableLayoutPanel2.Size = new Size(200, 130);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // panel9
            // 
            panel9.Controls.Add(pictureBox2);
            panel9.Location = new Point(844, 343);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 100);
            panel9.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Image = Properties.Resources.usp_banner;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(200, 100);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // UC_Home
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackColor = Color.FromArgb(72, 73, 85);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_Home";
            Size = new Size(1060, 620);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel9;
        private PictureBox pictureBox2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private FlowLayoutPanel flowLayoutPanel2;
        private Panel panel10;
        private Panel panel11;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private RichTextBox richTextBox1;
    }
}
