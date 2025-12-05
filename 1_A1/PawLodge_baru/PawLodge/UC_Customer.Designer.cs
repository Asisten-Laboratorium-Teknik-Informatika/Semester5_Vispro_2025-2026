using System.Windows.Forms;

namespace PawLodge
{
    partial class UC_Customer
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvCustomers;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(200, 120, 180);
            this.lblTitle.Location = new System.Drawing.Point(40, 40);
            this.lblTitle.Text = "👩‍ Data Customer PawLodge";

            // dgvCustomers (SEMUA KOLOM DIHAPUS — AUTO GENERATE!)
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(255, 240, 250);
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.Location = new System.Drawing.Point(40, 120);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.Size = new System.Drawing.Size(1300, 300);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.AutoGenerateColumns = true;                    // Kunci utama!
            this.dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.RowHeadersVisible = false;

            // Header style
            headerStyle.BackColor = System.Drawing.Color.MistyRose;
            headerStyle.ForeColor = System.Drawing.Color.DarkMagenta;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvCustomers.EnableHeadersVisualStyles = false;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(255, 200, 220);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Location = new System.Drawing.Point(40, 450);
            this.btnAdd.Size = new System.Drawing.Size(110, 35);
            this.btnAdd.Text = "Tambah";
            this.btnAdd.UseVisualStyleBackColor = false;

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(255, 220, 235);
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Location = new System.Drawing.Point(170, 450);
            this.btnEdit.Size = new System.Drawing.Size(110, 35);
            this.btnEdit.Text = "Edit";

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(255, 180, 200);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Location = new System.Drawing.Point(300, 450);
            this.btnDelete.Size = new System.Drawing.Size(110, 35);
            this.btnDelete.Text = "Hapus";

            // UC_Customer
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Name = "UC_Customer";
            this.Size = new System.Drawing.Size(1396, 617);
            this.Load += new System.EventHandler(this.UC_Customer_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}