using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PawLodge
{
    public partial class UC_Settings : UserControl
    {
        private readonly string dataFolder;
        private readonly string logoPath;
        private readonly string logPath;

        public UC_Settings()
        {
            // FIX DPI — Penting!
            this.AutoScaleMode = AutoScaleMode.None;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            InitializeComponent();

            // FIX DPI tambahan (mencegah control melebar acak)
            this.PerformAutoScale();

            dataFolder = Path.Combine(Application.StartupPath, "Data");
            logoPath = Path.Combine(dataFolder, "logo.png");
            logPath = Path.Combine(dataFolder, "error.log");

            try
            {
                BuatFolderData();
                IsiComboTema();
                LoadSetelan();
            }
            catch (Exception ex)
            {
                LogError("Ctor", ex);
                MessageBox.Show("Gagal memuat setelan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // FIX DPI — mencegah UserControl merusak posisi control saat runtime
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Scale(new SizeF(1f, 1f)); // Matikan scaling otomatis
        }

        private void BuatFolderData()
        {
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);
        }

        private void IsiComboTema()
        {
            comboTema.Items.Clear();
            comboTema.Items.Add("Pink Pastel");
            comboTema.Items.Add("Ungu Lembut");
            comboTema.Items.Add("Putih Polos");
        }

        private void LoadSetelan()
        {
            string nama = Properties.Settings.Default.NamaToko;
            txtNamaToko.Text = string.IsNullOrEmpty(nama) ? "PawLodge Pet Care" : nama;

            string tema = Properties.Settings.Default.TemaWarna;
            if (comboTema.Items.Contains(tema))
                comboTema.SelectedItem = tema;
            else
                comboTema.SelectedIndex = 0;

            this.BackColor = Properties.Settings.Default.WarnaBackground;

            if (File.Exists(logoPath))
            {
                using (var fs = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
                using (var tmp = Image.FromStream(fs))
                    picLogo.Image = new Bitmap(tmp);
            }
        }

        private void txtNamaToko_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NamaToko = txtNamaToko.Text;
            Properties.Settings.Default.Save();
        }

        private void btnPilihLogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Gambar|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(ofd.FileName, logoPath, true);

                    using (var fs = new FileStream(logoPath, FileMode.Open, FileAccess.Read))
                    using (var tmp = Image.FromStream(fs))
                        picLogo.Image = new Bitmap(tmp);

                    MessageBox.Show("Logo berhasil diganti!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LogError("btnPilihLogo", ex);
                MessageBox.Show("Gagal mengganti logo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerapkanTema_Click(object sender, EventArgs e)
        {
            if (comboTema.SelectedItem == null)
                return;

            string tema = comboTema.SelectedItem.ToString();
            Color bg;

            switch (tema)
            {
                case "Pink Pastel":
                    bg = Color.FromArgb(255, 245, 255);
                    break;
                case "Ungu Lembut":
                    bg = Color.FromArgb(245, 235, 255);
                    break;
                case "Putih Polos":
                    bg = Color.White;
                    break;
                default:
                    bg = Color.White;
                    break;
            }

            Properties.Settings.Default.TemaWarna = tema;
            Properties.Settings.Default.WarnaBackground = bg;
            Properties.Settings.Default.Save();

            foreach (Form f in Application.OpenForms)
            {
                if (!f.IsDisposed)
                    f.BackColor = bg;
            }

            this.BackColor = bg;

            MessageBox.Show("Tema berhasil diterapkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUbahPassword_Click(object sender, EventArgs e)
        {
            try
            {
                string passBaru = txtPassBaru.Text.Trim();
                string konfirmasi = txtKonfirmasi.Text.Trim();

                if (passBaru != konfirmasi)
                {
                    MessageBox.Show("Konfirmasi password tidak cocok!", "Peringatan");
                    return;
                }

                if (passBaru.Length < 4)
                {
                    MessageBox.Show("Password minimal 4 karakter!");
                    return;
                }

                string encrypted = Properties.Settings.Default.EncryptedPassword;

                if (string.IsNullOrEmpty(encrypted))
                {
                    Properties.Settings.Default.EncryptedPassword = Encrypt(passBaru);
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Password berhasil dibuat!", "Sukses");
                    ClearPass();
                    return;
                }

                string passLama = Decrypt(encrypted);

                if (txtPassLama.Text != passLama)
                {
                    MessageBox.Show("Password lama salah!", "Error");
                    return;
                }

                Properties.Settings.Default.EncryptedPassword = Encrypt(passBaru);
                Properties.Settings.Default.Save();

                MessageBox.Show("Password berhasil diubah!", "Sukses");
                ClearPass();
            }
            catch (Exception ex)
            {
                LogError("btnUbahPassword", ex);
                MessageBox.Show("Gagal mengubah password!", "Error");
            }
        }

        private void ClearPass()
        {
            txtPassLama.Clear();
            txtPassBaru.Clear();
            txtKonfirmasi.Clear();
        }

        private string Encrypt(string text)
        {
            try
            {
                return Convert.ToBase64String(
                    System.Text.Encoding.UTF8.GetBytes(text + "|pawlodge2025")
                );
            }
            catch
            {
                return "";
            }
        }

        private string Decrypt(string text)
        {
            try
            {
                string decoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(text));
                return decoded.Replace("|pawlodge2025", "");
            }
            catch
            {
                return "";
            }
        }

        private void LogError(string where, Exception ex)
        {
            try
            {
                string log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {where} | {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
                File.AppendAllText(logPath, log);
            }
            catch { }
        }
    }
}
