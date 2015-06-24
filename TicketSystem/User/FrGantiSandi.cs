using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJ.DAL;
using TicketSystem.Common;

namespace TicketSystem.User
{
    public partial class FrGantiSandi : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtSandiLama.Text.Trim() == String.Empty)
                return true;
            if (txtSandiBaru.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        public FrGantiSandi()
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if ((from a in context.REF_PENGGUNAs
                 where a.ID_PENGGUNA == UserInfo.UserId && a.SANDI == Encryption.Encrypt(txtSandiLama.Text, true)
                 select a).Any())
            {

                if (WithErrors())
                {
                    val.validateTextBox(txtSandiLama, errorProvider1, "Sandi lama harus diisi.");
                    val.validateTextBox(txtSandiBaru, errorProvider1, "Sandi baru harus diisi.");

                    return;
                }

                if (txtSandiBaru.Text.Equals(txtKonfirm.Text))
                {
                    var query = from b in context.REF_PENGGUNAs
                                   where b.ID_PENGGUNA == UserInfo.UserId
                                   select b;
                    foreach (var b in query)
                    {
                        b.SANDI = Encryption.Encrypt(txtSandiBaru.Text, true);
                    }
                    context.SubmitChanges();
                }
                else
                    errorProvider1.SetError(txtKonfirm, "Password tidak cocok.");
               
            }
            else
            {
                errorProvider1.SetError(txtSandiLama,
                                        !string.IsNullOrEmpty(txtSandiLama.Text)
                                            ? "Sandi lama salah."
                                            : "Sandi lama harus diisi.");
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
