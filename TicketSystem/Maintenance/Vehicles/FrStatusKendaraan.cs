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

namespace TicketSystem.Maintenance.Vehicles
{
    public partial class FrStatusKendaraan : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtKode.Text.Trim() == String.Empty)
                return true;
            if (txtStatus.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrStatusKendaraan(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrStatusKendaraan_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_STATUS
                        where a.ID_STATUS == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtKode.Text = a.KODE_STATUS;
                txtStatus.Text = a.STATUS;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtKode, errorProvider1, "Kode harus diisi.");
                val.validateTextBox(txtStatus, errorProvider1, "Status harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var status = new REF_STATUS();
                status.KODE_STATUS = txtKode.Text;
                status.STATUS = txtStatus.Text;
                context.REF_STATUS.InsertOnSubmit(status);
            }
            else
            {
                var query = from a in context.REF_STATUS
                            where a.ID_STATUS == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.KODE_STATUS = txtKode.Text;
                    a.STATUS = txtStatus.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrStatusKendaraan_Activated(object sender, EventArgs e)
        {
            txtKode.Focus();
        }

        private void txtKode_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kode harus diisi.");
        }

        private void txtStatus_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Status harus diisi.");
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }
    }
}
