using System.Drawing;
using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Reservation
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblCustomer;
        private Label lblPet;
        private Label lblService;
        private Label lblDate;

        private ComboBox cmbCustomer;
        private ComboBox cmbPet;
        private ComboBox cmbService;
        private DateTimePicker dtpDate;
        private Button btnReserve;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblCustomer = new Label();
            this.lblPet = new Label();
            this.lblService = new Label();
            this.lblDate = new Label();

            this.cmbCustomer = new ComboBox();
            this.cmbPet = new ComboBox();
            this.cmbService = new ComboBox();
            this.dtpDate = new DateTimePicker();
            this.btnReserve = new Button();

            this.SuspendLayout();

            // UC Background
            this.BackColor = Color.White;
            this.Size = new System.Drawing.Size(1396, 617);

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(200, 80, 180);
            this.lblTitle.Location = new Point(60, 50);
            this.lblTitle.Text = "📋 Pemesanan Penitipan";

            // Labels
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new Font("Segoe UI", 10F);
            this.lblCustomer.Location = new Point(60, 140);
            this.lblCustomer.Text = "Pilih Customer:";

            this.lblPet.AutoSize = true;
            this.lblPet.Font = new Font("Segoe UI", 10F);
            this.lblPet.Location = new Point(60, 210);
            this.lblPet.Text = "Jenis Hewan:";

            this.lblService.AutoSize = true;
            this.lblService.Font = new Font("Segoe UI", 10F);
            this.lblService.Location = new Point(60, 280);
            this.lblService.Text = "Layanan:";

            this.lblDate.AutoSize = true;
            this.lblDate.Font = new Font("Segoe UI", 10F);
            this.lblDate.Location = new Point(60, 350);
            this.lblDate.Text = "Tanggal Check-in:";

            // ComboBoxes & DatePicker
            this.cmbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCustomer.Location = new Point(60, 165);
            this.cmbCustomer.Size = new Size(500, 35);
            this.cmbCustomer.Font = new Font("Segoe UI", 11F);

            this.cmbPet.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPet.Location = new Point(60, 235);
            this.cmbPet.Size = new Size(500, 35);
            this.cmbPet.Font = new Font("Segoe UI", 11F);

            this.cmbService.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbService.Location = new Point(60, 305);
            this.cmbService.Size = new Size(500, 35);
            this.cmbService.Font = new Font("Segoe UI", 11F);
            this.cmbService.Items.AddRange(new object[] { "Penitipan Harian", "Penitipan Mingguan" });

            this.dtpDate.Format = DateTimePickerFormat.Custom;
            this.dtpDate.CustomFormat = "dddd, dd MMMM yyyy";
            this.dtpDate.Location = new Point(60, 375);
            this.dtpDate.Size = new Size(500, 35);
            this.dtpDate.Font = new Font("Segoe UI", 11F);

            // Button
            this.btnReserve.Text = "Simpan Reservasi";
            this.btnReserve.BackColor = Color.FromArgb(255, 105, 180);
            this.btnReserve.ForeColor = Color.White;
            this.btnReserve.FlatStyle = FlatStyle.Flat;
            this.btnReserve.FlatAppearance.BorderSize = 0;
            this.btnReserve.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnReserve.Location = new Point(60, 450);
            this.btnReserve.Size = new Size(500, 55);

            // Add Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblPet);
            this.Controls.Add(this.cmbPet);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btnReserve);

            this.Load += UC_Reservation_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}