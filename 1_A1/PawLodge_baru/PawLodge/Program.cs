using System;
using System.Windows.Forms;

namespace PawLodge
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // FORM CONTAINER untuk menempatkan UC_Login
            Form container = new Form
            {
                Text = "PawLodge Login",
                Size = new System.Drawing.Size(450, 620),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                MaximizeBox = false,
                BackColor = System.Drawing.Color.FromArgb(255, 240, 250)
            };

            // MASUKKAN USER CONTROL LOGIN
            UC_Login login = new UC_Login
            {
                Dock = DockStyle.Fill
            };

            container.Controls.Add(login);

            Application.Run(container);
        }
    }
}
