using System.Windows.Forms;

namespace CinemaTix
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFilms = new DataGridView();
            labelCinematix = new Label();
            labelWelcome = new Label();
            menuStrip1 = new MenuStrip();
            homeToolStripMenuItem = new ToolStripMenuItem();
            miKeluar = new ToolStripMenuItem();
            miPesan = new ToolStripMenuItem();
            historyToolStripMenuItem = new ToolStripMenuItem();
            aboutCinemaTixToolStripMenuItem = new ToolStripMenuItem();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFilms).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFilms
            // 
            dgvFilms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilms.Location = new Point(128, 157);
            dgvFilms.Margin = new Padding(3, 4, 3, 4);
            dgvFilms.Name = "dgvFilms";
            dgvFilms.RowHeadersWidth = 100;
            dgvFilms.RowTemplate.Height = 24;
            dgvFilms.Size = new Size(714, 292);
            dgvFilms.TabIndex = 0;
            dgvFilms.CellClick += dgvFilms_CellClick;
            dgvFilms.CellContentClick += dgvFilms_CellContentClick;
            // 
            // labelCinematix
            // 
            labelCinematix.AutoSize = true;
            labelCinematix.BackColor = SystemColors.ActiveCaptionText;
            labelCinematix.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelCinematix.ForeColor = SystemColors.ButtonHighlight;
            labelCinematix.Location = new Point(418, 48);
            labelCinematix.Name = "labelCinematix";
            labelCinematix.Size = new Size(128, 26);
            labelCinematix.TabIndex = 1;
            labelCinematix.Text = "CinemaTix";
            labelCinematix.Click += label1_Click;
            // 
            // labelWelcome
            // 
            labelWelcome.Anchor = AnchorStyles.Right;
            labelWelcome.AutoSize = true;
            labelWelcome.BackColor = SystemColors.ActiveCaptionText;
            labelWelcome.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelWelcome.ForeColor = SystemColors.ButtonHighlight;
            labelWelcome.Location = new Point(714, 126);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(116, 17);
            labelWelcome.TabIndex = 2;
            labelWelcome.Text = "Selamat datang, ";
            labelWelcome.Click += labelWelcome_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ControlText;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { homeToolStripMenuItem, historyToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(972, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // homeToolStripMenuItem
            // 
            homeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { miKeluar, miPesan });
            homeToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            homeToolStripMenuItem.Size = new Size(56, 24);
            homeToolStripMenuItem.Text = "Main";
            // 
            // miKeluar
            // 
            miKeluar.BackColor = SystemColors.ActiveCaptionText;
            miKeluar.ForeColor = SystemColors.ButtonFace;
            miKeluar.Name = "miKeluar";
            miKeluar.Size = new Size(224, 26);
            miKeluar.Text = "Logout";
            miKeluar.Click += keluarToolStripMenuItem_Click;
            // 
            // miPesan
            // 
            miPesan.BackColor = SystemColors.ActiveCaptionText;
            miPesan.ForeColor = SystemColors.ButtonFace;
            miPesan.Name = "miPesan";
            miPesan.Size = new Size(224, 26);
            miPesan.Text = "History";
            miPesan.Click += miPesan_Click;
            // 
            // historyToolStripMenuItem
            // 
            historyToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutCinemaTixToolStripMenuItem });
            historyToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            historyToolStripMenuItem.Size = new Size(55, 24);
            historyToolStripMenuItem.Text = "Help";
            historyToolStripMenuItem.Click += historyToolStripMenuItem_Click;
            // 
            // aboutCinemaTixToolStripMenuItem
            // 
            aboutCinemaTixToolStripMenuItem.BackColor = SystemColors.ActiveCaptionText;
            aboutCinemaTixToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            aboutCinemaTixToolStripMenuItem.Name = "aboutCinemaTixToolStripMenuItem";
            aboutCinemaTixToolStripMenuItem.Size = new Size(206, 26);
            aboutCinemaTixToolStripMenuItem.Text = "About CinemaTix";
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(440, 491);
            label1.Name = "label1";
            label1.Size = new Size(121, 17);
            label1.TabIndex = 0;
            label1.Text = "Design by Eazy-G";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(128, 122);
            label2.Name = "label2";
            label2.Size = new Size(227, 17);
            label2.TabIndex = 5;
            label2.Text = "Klik pada film yang anda ingin pesan ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaptionText;
            ClientSize = new Size(972, 517);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Controls.Add(labelWelcome);
            Controls.Add(labelCinematix);
            Controls.Add(dgvFilms);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "CinemaTix - Pilih Film";
            Load += FormUtama_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFilms).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        // Deklarasi kontrol yang harus ada di sini:
        private System.Windows.Forms.DataGridView dgvFilms;
        private Label labelCinematix;
        private Label labelWelcome;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem homeToolStripMenuItem;
        private ToolStripMenuItem historyToolStripMenuItem;
        private ToolStripMenuItem loginToolStripMenuItem;
        private ToolStripMenuItem keluarToolStripMenuItem;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private ToolStripMenuItem aboutCinemaTixToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem pesanTiketToolStripMenuItem;
        private ToolStripMenuItem miKeluar;
        private ToolStripMenuItem miPesan;
        private Label label1;
        private Label label2;
    }
}