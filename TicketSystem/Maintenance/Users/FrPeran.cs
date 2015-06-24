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

namespace TicketSystem.Maintenance.Users
{
    public partial class FrPeran : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtKode.Text.Trim() == String.Empty)
                return true;
            if (txtPeran.Text.Trim() == String.Empty)
                return true;
            return false;
        }

        public FrPeran(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrPeran_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_PERANs
                        where a.ID_PERAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtKode.Text = a.KODE_PERAN;
                txtPeran.Text = a.PERAN;
            }
        }

        private void FrPeran_Activated(object sender, EventArgs e)
        {
            txtKode.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtKode, errorProvider1, "Kode harus diisi.");
                val.validateTextBox(txtPeran, errorProvider1, "Peran harus diisi.");
               
                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var peran = new REF_PERAN();
                peran.KODE_PERAN = txtKode.Text;
                peran.PERAN = txtPeran.Text;
                context.REF_PERANs.InsertOnSubmit(peran);
            }
            else
            {
                var query = from a in context.REF_PERANs
                            where a.ID_PERAN == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.KODE_PERAN = txtKode.Text;
                    a.PERAN = txtPeran.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtKode_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kode harus diisi.");
        }

        private void txtPeran_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Peran harus diisi.");
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtPeran_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }
    }
}
