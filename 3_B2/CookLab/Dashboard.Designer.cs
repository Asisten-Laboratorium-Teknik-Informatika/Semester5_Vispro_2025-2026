namespace CookLab
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.title = new System.Windows.Forms.Label();
            this.viewRecipes = new System.Windows.Forms.Button();
            this.addRecipe = new System.Windows.Forms.Button();
            this.quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.MediumPurple;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.title.Location = new System.Drawing.Point(239, 26);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(297, 73);
            this.title.TabIndex = 0;
            this.title.Text = "CookLab";
            // 
            // viewRecipes
            // 
            this.viewRecipes.BackColor = System.Drawing.Color.MediumPurple;
            this.viewRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewRecipes.ForeColor = System.Drawing.Color.White;
            this.viewRecipes.Location = new System.Drawing.Point(252, 148);
            this.viewRecipes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewRecipes.Name = "viewRecipes";
            this.viewRecipes.Size = new System.Drawing.Size(284, 55);
            this.viewRecipes.TabIndex = 1;
            this.viewRecipes.Text = "Lihat Daftar Resep";
            this.viewRecipes.UseVisualStyleBackColor = false;
            this.viewRecipes.Click += new System.EventHandler(this.viewRepices_Click);
            // 
            // addRecipe
            // 
            this.addRecipe.BackColor = System.Drawing.Color.GhostWhite;
            this.addRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRecipe.Location = new System.Drawing.Point(252, 208);
            this.addRecipe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addRecipe.Name = "addRecipe";
            this.addRecipe.Size = new System.Drawing.Size(284, 55);
            this.addRecipe.TabIndex = 2;
            this.addRecipe.Text = "Tambah Resep Baru";
            this.addRecipe.UseVisualStyleBackColor = false;
            this.addRecipe.Click += new System.EventHandler(this.addRecipe_Click);
            // 
            // quit
            // 
            this.quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit.Location = new System.Drawing.Point(355, 331);
            this.quit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(71, 41);
            this.quit.TabIndex = 3;
            this.quit.Text = "Keluar";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.quit);
            this.Controls.Add(this.addRecipe);
            this.Controls.Add(this.viewRecipes);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button viewRecipes;
        private System.Windows.Forms.Button addRecipe;
        private System.Windows.Forms.Button quit;
    }
}

