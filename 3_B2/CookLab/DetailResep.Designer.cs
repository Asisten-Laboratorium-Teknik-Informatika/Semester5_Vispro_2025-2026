namespace CookLab
{
    partial class DetailResep
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
            this.txtNama = new System.Windows.Forms.TextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cookLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resepBaru = new System.Windows.Forms.Label();
            this.lblNamaResep = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtBahan = new System.Windows.Forms.TextBox();
            this.txtLangkah = new System.Windows.Forms.TextBox();
            this.lblLangkah = new System.Windows.Forms.Label();
            this.lblBahan = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Location = new System.Drawing.Point(19, 155);
            this.txtNama.Margin = new System.Windows.Forms.Padding(5);
            this.txtNama.Multiline = true;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(451, 36);
            this.txtNama.TabIndex = 9;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.MediumPurple;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cookLabToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(12, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(800, 39);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // cookLabToolStripMenuItem
            // 
            this.cookLabToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cookLabToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cookLabToolStripMenuItem.Name = "cookLabToolStripMenuItem";
            this.cookLabToolStripMenuItem.Size = new System.Drawing.Size(131, 33);
            this.cookLabToolStripMenuItem.Text = "CookLab";
            // 
            // resepBaru
            // 
            this.resepBaru.AutoSize = true;
            this.resepBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resepBaru.ForeColor = System.Drawing.Color.MediumPurple;
            this.resepBaru.Location = new System.Drawing.Point(14, 89);
            this.resepBaru.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.resepBaru.Name = "resepBaru";
            this.resepBaru.Size = new System.Drawing.Size(193, 26);
            this.resepBaru.TabIndex = 12;
            this.resepBaru.Text = "Buat Resep Baru";
            // 
            // lblNamaResep
            // 
            this.lblNamaResep.AutoSize = true;
            this.lblNamaResep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaResep.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblNamaResep.Location = new System.Drawing.Point(15, 130);
            this.lblNamaResep.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNamaResep.Name = "lblNamaResep";
            this.lblNamaResep.Size = new System.Drawing.Size(116, 20);
            this.lblNamaResep.TabIndex = 13;
            this.lblNamaResep.Text = "Nama Resep";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(703, 366);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(84, 45);
            this.cancelBtn.TabIndex = 19;
            this.cancelBtn.Text = "Batal";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.MediumPurple;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(519, 366);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 45);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "Ubah";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtBahan
            // 
            this.txtBahan.Location = new System.Drawing.Point(19, 222);
            this.txtBahan.Margin = new System.Windows.Forms.Padding(5);
            this.txtBahan.Multiline = true;
            this.txtBahan.Name = "txtBahan";
            this.txtBahan.Size = new System.Drawing.Size(451, 35);
            this.txtBahan.TabIndex = 17;
            // 
            // txtLangkah
            // 
            this.txtLangkah.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLangkah.Location = new System.Drawing.Point(19, 294);
            this.txtLangkah.Margin = new System.Windows.Forms.Padding(5);
            this.txtLangkah.Multiline = true;
            this.txtLangkah.Name = "txtLangkah";
            this.txtLangkah.Size = new System.Drawing.Size(451, 117);
            this.txtLangkah.TabIndex = 16;
            // 
            // lblLangkah
            // 
            this.lblLangkah.AutoSize = true;
            this.lblLangkah.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLangkah.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblLangkah.Location = new System.Drawing.Point(16, 271);
            this.lblLangkah.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLangkah.Name = "lblLangkah";
            this.lblLangkah.Size = new System.Drawing.Size(164, 20);
            this.lblLangkah.TabIndex = 15;
            this.lblLangkah.Text = "Langkah Memasak";
            // 
            // lblBahan
            // 
            this.lblBahan.AutoSize = true;
            this.lblBahan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBahan.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblBahan.Location = new System.Drawing.Point(16, 199);
            this.lblBahan.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBahan.Name = "lblBahan";
            this.lblBahan.Size = new System.Drawing.Size(119, 20);
            this.lblBahan.TabIndex = 14;
            this.lblBahan.Text = "Bahan-bahan";
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.Red;
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(611, 366);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(84, 45);
            this.btnHapus.TabIndex = 20;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // DetailResep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtBahan);
            this.Controls.Add(this.txtLangkah);
            this.Controls.Add(this.lblLangkah);
            this.Controls.Add(this.lblBahan);
            this.Controls.Add(this.lblNamaResep);
            this.Controls.Add(this.resepBaru);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.txtNama);
            this.Name = "DetailResep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailResep";
            this.Load += new System.EventHandler(this.DetailResep_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cookLabToolStripMenuItem;
        private System.Windows.Forms.Label resepBaru;
        private System.Windows.Forms.Label lblNamaResep;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtBahan;
        private System.Windows.Forms.TextBox txtLangkah;
        private System.Windows.Forms.Label lblLangkah;
        private System.Windows.Forms.Label lblBahan;
        private System.Windows.Forms.Button btnHapus;
    }
}