namespace CookLab
{
    partial class Recipe
    {
     
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cookLabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.buatResepBaruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resepSayaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.berandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.flowPanelResep = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumPurple;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cookLabToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1074, 37);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cookLabToolStripMenuItem
            // 
            this.cookLabToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cookLabToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cookLabToolStripMenuItem.Name = "cookLabToolStripMenuItem";
            this.cookLabToolStripMenuItem.Size = new System.Drawing.Size(131, 33);
            this.cookLabToolStripMenuItem.Text = "CookLab";
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.White;
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buatResepBaruToolStripMenuItem,
            this.resepSayaToolStripMenuItem,
            this.berandaToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 37);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(1074, 36);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // buatResepBaruToolStripMenuItem
            // 
            this.buatResepBaruToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buatResepBaruToolStripMenuItem.ForeColor = System.Drawing.Color.MediumPurple;
            this.buatResepBaruToolStripMenuItem.Name = "buatResepBaruToolStripMenuItem";
            this.buatResepBaruToolStripMenuItem.Size = new System.Drawing.Size(167, 32);
            this.buatResepBaruToolStripMenuItem.Text = "Buat Resep Baru";
            this.buatResepBaruToolStripMenuItem.Click += new System.EventHandler(this.buatResepBaruToolStripMenuItem_Click);
            // 
            // resepSayaToolStripMenuItem
            // 
            this.resepSayaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resepSayaToolStripMenuItem.ForeColor = System.Drawing.Color.MediumPurple;
            this.resepSayaToolStripMenuItem.Name = "resepSayaToolStripMenuItem";
            this.resepSayaToolStripMenuItem.Size = new System.Drawing.Size(123, 32);
            this.resepSayaToolStripMenuItem.Text = "Resep Saya";
            // 
            // berandaToolStripMenuItem
            // 
            this.berandaToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.berandaToolStripMenuItem.ForeColor = System.Drawing.Color.MediumPurple;
            this.berandaToolStripMenuItem.Name = "berandaToolStripMenuItem";
            this.berandaToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4);
            this.berandaToolStripMenuItem.Size = new System.Drawing.Size(91, 32);
            this.berandaToolStripMenuItem.Text = "Beranda";
            this.berandaToolStripMenuItem.Click += new System.EventHandler(this.berandaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumPurple;
            this.label1.Location = new System.Drawing.Point(14, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "DAFTAR RESEP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumPurple;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(954, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(100, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kembali";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowPanelResep
            // 
            this.flowPanelResep.AutoScroll = true;
            this.flowPanelResep.BackColor = System.Drawing.Color.White;
            this.flowPanelResep.Location = new System.Drawing.Point(0, 174);
            this.flowPanelResep.Name = "flowPanelResep";
            this.flowPanelResep.Padding = new System.Windows.Forms.Padding(20);
            this.flowPanelResep.Size = new System.Drawing.Size(1067, 379);
            this.flowPanelResep.TabIndex = 5;
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1074, 554);
            this.Controls.Add(this.flowPanelResep);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Recipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recipes";
            this.Load += new System.EventHandler(this.Recipe_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cookLabToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem buatResepBaruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resepSayaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem berandaToolStripMenuItem;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelResep;
    }
}