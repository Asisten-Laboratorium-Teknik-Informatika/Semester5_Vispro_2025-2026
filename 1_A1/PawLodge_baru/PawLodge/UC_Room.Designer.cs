using System.Drawing;
using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Room
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvRooms;
        private Button btnAddRoom;
        private Button btnEditRoom;
        private Button btnDeleteRoom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.dgvRooms = new DataGridView();
            this.btnAddRoom = new Button();
            this.btnEditRoom = new Button();
            this.btnDeleteRoom = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.SuspendLayout();

            // Background
            this.BackColor = Color.White;
            this.Size = new System.Drawing.Size(1396, 617);

            // Title
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(190, 80, 170);
            this.lblTitle.Location = new Point(60, 50);
            this.lblTitle.Text = "🐕 Data Kamar Penitipan";

            // DataGridView
            this.dgvRooms.BackgroundColor = Color.FromArgb(255, 245, 252);
            this.dgvRooms.BorderStyle = BorderStyle.None;
            this.dgvRooms.Location = new Point(60, 120);
            this.dgvRooms.Size = new Size(1280, 300);
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.MultiSelect = false;
            this.dgvRooms.AutoGenerateColumns = true;
            this.dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.EnableHeadersVisualStyles = false;
            this.dgvRooms.ColumnHeadersHeight = 40;
            this.dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
            this.dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.DarkMagenta;
            this.dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.dgvRooms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 250);

            // Buttons
            this.btnAddRoom.Text = "Tambah Kamar";
            this.btnAddRoom.BackColor = Color.FromArgb(255, 182, 193);
            this.btnAddRoom.FlatStyle = FlatStyle.Flat;
            this.btnAddRoom.Location = new Point(60, 460);
            this.btnAddRoom.Size = new Size(180, 50);
            this.btnAddRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            this.btnEditRoom.Text = "Edit Kamar";
            this.btnEditRoom.BackColor = Color.FromArgb(255, 204, 229);
            this.btnEditRoom.FlatStyle = FlatStyle.Flat;
            this.btnEditRoom.Location = new Point(260, 460);
            this.btnEditRoom.Size = new Size(180, 50);
            this.btnEditRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            this.btnDeleteRoom.Text = "Hapus Kamar";
            this.btnDeleteRoom.BackColor = Color.FromArgb(255, 105, 180);
            this.btnDeleteRoom.ForeColor = Color.White;
            this.btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            this.btnDeleteRoom.Location = new Point(460, 460);
            this.btnDeleteRoom.Size = new Size(180, 50);
            this.btnDeleteRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Add Controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvRooms);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnEditRoom);
            this.Controls.Add(this.btnDeleteRoom);

            this.Load += UC_Room_Load;

            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.ResumeLayout(false);
        }
    }
}