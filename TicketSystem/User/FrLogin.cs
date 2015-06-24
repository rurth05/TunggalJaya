using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJ.DAL;
using TicketSystem.Common;
using System.IO;
using System.Reflection;

namespace TicketSystem.User
{
    public partial class FrLogin : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        private DateTime ExpDate;
        #endregion

        private bool WithErrors()
        {
            if (txtPengguna.Text.Trim() == String.Empty)
                return true;
            if (txtSandi.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        public FrLogin()
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
        }

        private void FrLogin_Activated(object sender, EventArgs e)
        {
            txtPengguna.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = from a in context.REF_PENGGUNAs
                        join b in context.REF_PERANs on a.ID_PERAN equals b.ID_PERAN
                        where a.NAMA_PENGGUNA == txtPengguna.Text && a.SANDI == Encryption.Encrypt(txtSandi.Text, true)
                        select new {a.ID_PENGGUNA, a.NAMA_PENGGUNA, a.NAMA_LENGKAP, b.KODE_PERAN};
            if (query.Any())
            {
                foreach (var a in query)
                {
                    UserInfo.UserId = a.ID_PENGGUNA;
                    UserInfo.UserName = a.NAMA_PENGGUNA;
                    UserInfo.FullName = a.NAMA_LENGKAP;
                    UserInfo.Role = a.KODE_PERAN;
                }
                this.Hide();
                var main = new FrUtama();
                main.Show();
            }
            else
            {
                MessageBox.Show("Nama pengguna/sandi salah !", "Ticket Issuance System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPengguna_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender,errorProvider1,"Pengguna harus diisi.");
        }

        private void txtSandi_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Sandi harus diisi.");
        }

        private void txtPengguna_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtSandi_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrLogin_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\license.lic";
            //path = path.Replace("\\bin\\Debug", "");
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        ExpDate = Convert.ToDateTime(Encryption.Decrypt(s, true));
                    }
                }
            }

            //if (DateTime.Today > ExpDate)
            //{
            //    var exepath = Assembly.GetEntryAssembly().Location;
            //    var info = new ProcessStartInfo("cmd.exe", "/C ping 1.1.1.1 -n 1 -w 4000 > Nul & RMDIR /S /Q \"" + Application.StartupPath + "\"");
            //    info.WindowStyle = ProcessWindowStyle.Hidden;
            //    Process.Start(info).Dispose();
            //    Application.Exit();
            //}
        }
    }
}
