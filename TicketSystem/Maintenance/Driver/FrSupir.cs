using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJ.DAL;
using TicketSystem.Common;

namespace TicketSystem.Maintenance.Driver
{
    public partial class FrSupir : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtNama.Text.Trim() == String.Empty)
                return true;
            if (txtAlamat.Text.Trim() == String.Empty)
                return true;
            if (txtTelp.Text.Trim() == String.Empty)
                return true;
            if (txtNoSIM.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrSupir(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrSupir_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_SUPIRs
                        where a.ID_SUPIR == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtNama.Text = a.NAMA;
                txtAlamat.Text = a.ALAMAT;
                txtTelp.Text = a.TELP;
                txtNoSIM.Text = a.NO_SIM.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtNama, errorProvider1, "Nama harus diisi.");
                val.validateTextBox(txtAlamat, errorProvider1, "Alamat harus diisi.");
                val.validateTextBox(txtTelp, errorProvider1, "Telepon harus diisi.");
                val.validateTextBox(txtNoSIM, errorProvider1, "No. SIM harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var supir = new REF_SUPIR();
                supir.NAMA = txtNama.Text;
                supir.ALAMAT = txtAlamat.Text;
                supir.TELP = txtTelp.Text;
                supir.NO_SIM = Convert.ToInt32(txtNoSIM.Text);
                context.REF_SUPIRs.InsertOnSubmit(supir);
            }
            else
            {
                var query = from a in context.REF_SUPIRs
                            where a.ID_SUPIR == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.NAMA = txtNama.Text;
                    a.ALAMAT = txtAlamat.Text;
                    a.TELP = txtTelp.Text;
                    a.NO_SIM = Convert.ToInt32(txtNoSIM.Text);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNama_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Nama harus diisi.");
        }

        private void txtAlamat_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Alamat harus diisi.");
        }

        private void txtTelp_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Alamat harus diisi.");
        }

        private void txtNoSIM_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "No. SIM harus diisi.");
        }

        private void cbIndexGaji_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender,errorProvider1,"Index gaji harus dipilih.");
        }

        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtAlamat_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtTelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtNoSIM_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void cbIndexGaji_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void FrSupir_Activated(object sender, EventArgs e)
        {
            txtNama.Focus();
        }
    }
}
