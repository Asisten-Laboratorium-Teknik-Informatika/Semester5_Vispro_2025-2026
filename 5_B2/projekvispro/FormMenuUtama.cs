using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace projekvispro
{
    public partial class FormMenuUtama : Form
    {
        FormMasterKasir frmKasir;
        FormMasterBarang frmBarang;
        FormTransaksiPenjualan frmJual;

        public static string KodeKasir;
        public static string NamaKasir;

        public FormMenuUtama(string kode, string nama)
        {
            InitializeComponent();
            toolStatus2.Text = kode;
            toolStatus4.Text = nama;

            MenuTerbuka();
        }

        void MenuTerkunci()
        {
            menuLogin.Enabled = true;
            menuLogout.Enabled = false;
            menuMaster.Enabled = false;
            menuTransaksi.Enabled = false;
        }

        public void MenuTerbuka()
        {
            menuLogin.Enabled = false;
            menuLogout.Enabled = true;
            menuMaster.Enabled = true;
            menuTransaksi.Enabled = true;
        }

        private void FormMenuUtama_Load(object sender, EventArgs e)
        {
            MenuTerbuka();
        }


        private void menuLog_Click(object sender, EventArgs e)
        {

        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            MenuTerkunci();
            MessageBox.Show("Anda telah logout");

            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void kasirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKasir == null)
            {
                frmKasir = new FormMasterKasir();
                frmKasir.FormClosed += (s, args) => frmKasir = null;
                frmKasir.Show();
            }
            else
            {
                frmKasir.Activate();
            }
        }

        private void barangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBarang == null)
            {
                frmBarang = new FormMasterBarang();
                frmBarang.FormClosed += (s, args) => frmBarang = null;
                frmBarang.Show();
            }
            else
            {
                frmBarang.Activate();
            }
        }

        private void penjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmJual == null)
            {
                frmJual = new FormTransaksiPenjualan();
                frmJual.FormClosed += (s, args) => frmJual = null;
                frmJual.Show();
            }
            else
            {
                frmJual.Activate();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void laporanDataPenjualanToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
