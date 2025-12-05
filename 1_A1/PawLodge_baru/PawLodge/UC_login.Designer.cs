using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Login
    {
        private System.ComponentModel.IContainer components = null;

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Label lblRegister;
        private Panel panelContainer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblRegister = new System.Windows.Forms.Label();

            // panelContainer
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(255, 240, 250);

            // pictureBox1
            this.pictureBox1.Image = PawLodge.Properties.Resources.logopet;
            this.pictureBox1.Location = new System.Drawing.Point(120, 40);
            this.pictureBox1.Size = new System.Drawing.Size(180, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.HotPink;
            this.label1.Location = new System.Drawing.Point(80, 230);
            this.label1.Text = "PawLodge Login";

            // label2
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(80, 290);
            this.label2.Text = "Username";

            // label3
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(80, 360);
            this.label3.Text = "Password";

            // txtUsername
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Location = new System.Drawing.Point(80, 315);
            this.txtUsername.Size = new System.Drawing.Size(260, 32);

            // txtPassword
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Location = new System.Drawing.Point(80, 385);
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(260, 32);

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.HotPink;
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(80, 440);
            this.btnLogin.Size = new System.Drawing.Size(120, 45);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.LightGray;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(220, 440);
            this.btnExit.Size = new System.Drawing.Size(120, 45);
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // lblRegister
            this.lblRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Underline);
            this.lblRegister.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblRegister.Location = new System.Drawing.Point(130, 500);
            this.lblRegister.Size = new System.Drawing.Size(180, 22);
            this.lblRegister.Text = "Belum punya akun?";
            this.lblRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRegister.Click += new System.EventHandler(this.lblRegister_Click);

            // Add Controls to Panel
            this.panelContainer.Controls.Add(this.pictureBox1);
            this.panelContainer.Controls.Add(this.label1);
            this.panelContainer.Controls.Add(this.label2);
            this.panelContainer.Controls.Add(this.label3);
            this.panelContainer.Controls.Add(this.txtUsername);
            this.panelContainer.Controls.Add(this.txtPassword);
            this.panelContainer.Controls.Add(this.btnLogin);
            this.panelContainer.Controls.Add(this.btnExit);
            this.panelContainer.Controls.Add(this.lblRegister);

            this.Controls.Add(this.panelContainer);
            this.Name = "UC_Login";
            this.Size = new System.Drawing.Size(420, 550);
        }
    }
}
