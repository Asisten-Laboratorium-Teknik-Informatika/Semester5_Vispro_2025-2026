using System;
using System.Drawing;
using System.Windows.Forms;
namespace PawLodge
{
    public partial class FormMain : Form
    {
        private Button currentButton;
        private Panel panelSidebar, panelHeader, panelContainer;
        private Label lblAppName, lblTitle;
        private Button btnDashboard, btnCustomer, btnReservation, btnRoom, btnTransaction, btnSetting;
        public FormMain()
        {
            InitializeComponent();
            BuatSemuaKontrolManual();
            BukaHalaman(new UC_Dashboard(), btnDashboard, "Dashboard");
        }
        private void BuatSemuaKontrolManual()
        {
            this.Size = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(252, 245, 255);
            // Sidebar
            panelSidebar = new Panel { Dock = DockStyle.Left, Width = 240, BackColor = Color.FromArgb(255, 220, 230) };
            lblAppName = new Label
            {
                Text = "PawLodge",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.HotPink,
                Location = new Point(20, 30),
                AutoSize = true
            };
            // Header
            panelHeader = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = Color.FromArgb(255, 182, 193) };
            lblTitle = new Label
            {
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.DeepPink,
                Location = new Point(30, 25),
                AutoSize = true
            };
            panelHeader.Controls.Add(lblTitle);
            // Container
            panelContainer = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            // Tombol
            btnDashboard = BuatTombol("Dashboard", 120);
            btnCustomer = BuatTombol("Customer", 180);
            btnReservation = BuatTombol("Reservation", 240);
            btnRoom = BuatTombol("Room", 300);
            btnTransaction = BuatTombol("Transaction", 360);
            btnSetting = BuatTombol("Setting", 420);
            // Event
            btnDashboard.Click += (s, e) => BukaHalaman(new UC_Dashboard(), btnDashboard, "Dashboard");
            btnCustomer.Click += (s, e) => BukaHalaman(new UC_Customer(), btnCustomer, "Customer");
            btnReservation.Click += (s, e) => BukaHalaman(new UC_Reservation(), btnReservation, "Reservation");
            btnRoom.Click += (s, e) => BukaHalaman(new UC_Room(), btnRoom, "Room");
            btnTransaction.Click += (s, e) => BukaHalaman(new UC_Transaction(), btnTransaction, "Transaction");
            btnSetting.Click += (s, e) => BukaHalaman(new UC_Settings(), btnSetting, "Setting");
            panelSidebar.Controls.AddRange(new Control[] {
lblAppName, btnDashboard, btnCustomer, btnReservation, btnRoom, btnTransaction, btnSetting
});
            this.Controls.Add(panelContainer);
            this.Controls.Add(panelHeader);
            this.Controls.Add(panelSidebar);
        }
        private Button BuatTombol(string teks, int top)
        {
            var btn = new Button
            {
                Size = new Size(220, 50),
                Location = new Point(10, top),
                Text = " " + teks,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(130, 70, 130),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, MouseOverBackColor = Color.FromArgb(255, 105, 180) }
            };
            btn.MouseEnter += (s, e) => { if (btn != currentButton) btn.BackColor = Color.FromArgb(255, 182, 193); };
            btn.MouseLeave += (s, e) => { if (btn != currentButton) btn.BackColor = Color.Transparent; };
            return btn;
        }
        private void BukaHalaman(UserControl uc, Button btn, string judul)
        {
            if (currentButton != null && currentButton != btn)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.FromArgb(130, 70, 130);
            }
            currentButton = btn;
            btn.BackColor = Color.HotPink;
            btn.ForeColor = Color.White;
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            lblTitle.Text = judul;
        }
    }
}