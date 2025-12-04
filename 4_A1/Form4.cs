using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budgetplanner
{
    public partial class Form4 : Form
    {
        private Form1 mainForm;

        public Form4(Form1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Shown += Form4_Shown;

        }

        public List<Transaksi> Riwayat = new List<Transaksi>();

        private Label GetLabel(Panel panel, string name)
        {
            foreach (Control c in panel.Controls)
                if (c is Label && c.Name == name)
                    return (Label)c;

            return null; // kalau tidak ketemu
        }


        private Panel ClonePanel(Panel template)
        {
            Panel newPanel = new Panel();

            // Copy semua basic property
            newPanel.Size = template.Size;
            newPanel.BackColor = template.BackColor;
            newPanel.ForeColor = template.ForeColor;
            newPanel.Padding = template.Padding;
            newPanel.Margin = template.Margin;
            newPanel.BorderStyle = template.BorderStyle;
            newPanel.AutoSize = template.AutoSize;
            newPanel.AutoSizeMode = template.AutoSizeMode;
            newPanel.Font = template.Font;

            // Copy custom panel (VERY IMPORTANT)
            if (template is CustomRoundedPanel oriCustom)
            {
                CustomRoundedPanel cp = new CustomRoundedPanel
                {
                    Size = oriCustom.Size,
                    BackColor = oriCustom.BackColor,
                    BorderColor = oriCustom.BorderColor,
                    BorderRadius = oriCustom.BorderRadius,
                    BorderThickness = oriCustom.BorderThickness,
                    FillColor = oriCustom.FillColor,
                    Margin = oriCustom.Margin,
                    Padding = oriCustom.Padding
                };

                newPanel = cp;
            }

            // Clone semua label di dalamnya
            foreach (Control ctrl in template.Controls)
            {
                if (ctrl is Label ori)
                {
                    Label copy = new Label
                    {
                        Name = ori.Name,
                        Text = ori.Text,
                        Font = ori.Font,
                        ForeColor = ori.ForeColor,
                        BackColor = ori.BackColor,
                        AutoSize = ori.AutoSize,
                        Size = ori.Size,
                        Location = ori.Location,
                        TextAlign = ori.TextAlign
                    };

                    newPanel.Controls.Add(copy);
                }
            }

            return newPanel;
        }

        public void LoadRiwayatFromDatabase()
        {
            flowLayoutPanel1.Controls.Clear();

            Database db = new Database();
            MySqlConnection conn = db.GetConnection();

            db.OpenConnection();

            string query = "SELECT * FROM transaksi WHERE user_id = @user ORDER BY tanggal DESC";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@user", mainForm.currentUserId);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Transaksi t = new Transaksi
                {
                    Jenis = reader["jenis"].ToString(),
                    Jumlah = reader["jumlah"].ToString(),
                    Kategori = reader["kategori"].ToString(),
                    Deskripsi = reader["deskripsi"].ToString(),
                    Tanggal = Convert.ToDateTime(reader["tanggal"])
                };

                AddCardToUI(t);
            }

            reader.Close();
            db.CloseConnection();
        }




        public void AddCardToUI(Transaksi t)
        {
            Riwayat.Add(t);

            // ======== PEMASUKAN ========
            if (t.Jenis == "Pemasukan")
            {
                Panel card = ClonePanel(CardPemasukan);

                GetLabel(card, "lblPemasukan").Text = "+ Rp " + t.Jumlah;
                GetLabel(card, "TanggalPemasukan").Text = t.Tanggal.ToString("dd MMM yyyy");
                GetLabel(card, "DeskripsiPemasukan").Text = t.Deskripsi;

                flowLayoutPanel1.Controls.Add(card);



            }


            // ======== PENGELUARAN ========
            else
            {
                Panel card = ClonePanel(CardPengeluaran);

                GetLabel(card, "lblPengeluaran").Text = "- Rp " + t.Jumlah;
                GetLabel(card, "TanggalPengeluaran").Text = t.Tanggal.ToString("dd MMM yyyy");
                GetLabel(card, "DeskripsiPengeluaran").Text = t.Deskripsi;
                GetLabel(card, "KategoriPengeluaran").Text = t.Kategori;

                flowLayoutPanel1.Controls.Add(card);

            }
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            CardPemasukan.Visible = false;
            CardPengeluaran.Visible = false;
            LoadRiwayatFromDatabase();

        }



        private void CardPemasukan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPemasukan_Click(object sender, EventArgs e)
        {

        }

        private void TanggalPemasukan_Click(object sender, EventArgs e)
        {

        }

        private void DeskripsiPemasukan_Click(object sender, EventArgs e)
        {

        }

        private void CardPengeluaran_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPengeluaran_Click(object sender, EventArgs e)
        {

        }

        private void TanggalPengeluaran_Click(object sender, EventArgs e)
        {

        }

        private void DeskripsiPengeluaran_Click(object sender, EventArgs e)
        {

        }

        private void KategoriPengeluaran_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            this.Hide();

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            mainForm.form3.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            mainForm.form5.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
