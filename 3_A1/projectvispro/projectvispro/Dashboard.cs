using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;
using System.Globalization;

namespace projectvispro
{
    public partial class Dashboard : Form
    {
        private string currentUser;
        private string currentRole;

        public Dashboard(string username, string role)
        {
            InitializeComponent();
            currentUser = username;
            currentRole = role;

            string usernameHurufKapital = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currentUser);
            labelWelcome.Text = $"Selamat datang, {usernameHurufKapital}!";
            labelRole.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(currentRole);

            if(currentRole == "kasir")
            {
                btnKategori.Visible = false;
                btnUserManagement.Visible = false;
                btnSupplier.Visible = false;
                labelRole.Location = new Point(54, 102);
            }
        }

        private Button tombolAktif;
        private void TombolAktif(Button btn)
        {
            if (tombolAktif != null)
            {
                tombolAktif.Font = new Font(tombolAktif.Font, FontStyle.Regular);
                tombolAktif.ForeColor = Color.White;
                tombolAktif.BackColor = Color.FromArgb(255, 128, 0);
            }

            tombolAktif = btn;
            tombolAktif.Font = new Font(tombolAktif.Font, FontStyle.Bold);
            tombolAktif.ForeColor = Color.Black;
            tombolAktif.BackColor = Color.White;
        }

        private void LoadUserControl (UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadUserControl(new UC_Dashboard());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_Dashboard());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_Inventory());
            btnInventory.Font = new Font(btnInventory.Font, FontStyle.Bold);
        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_Penjualan());
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_Kategori());
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_UserManagement());
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            TombolAktif((Button)sender);
            LoadUserControl(new UC_Supplier());
        }
    }
}
