using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private FlowLayoutPanel flowStats;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.flowStats = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(180, 100, 200);
            this.lblTitle.Location = new System.Drawing.Point(40, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🐾 Dashboard PawLodge";
            // 
            // flowStats
            // 
            this.flowStats.AutoScroll = true;
            this.flowStats.Location = new System.Drawing.Point(40, 110);
            this.flowStats.Name = "flowStats";
            this.flowStats.Size = new System.Drawing.Size(1300, 480);
            this.flowStats.TabIndex = 1;
            this.flowStats.WrapContents = true;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flowStats);
            this.Controls.Add(this.lblTitle);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1396, 617);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
