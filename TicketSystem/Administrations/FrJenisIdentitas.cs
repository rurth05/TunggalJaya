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

namespace TicketSystem.Administrations
{
    public partial class FrJenisIdentitas : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtKode.Text.Trim() == String.Empty)
                return true;
            if (txtJenisIdentitas.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrJenisIdentitas(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrJenisIdentitas_Load(object sender, EventArgs e)
        {
            var query = from a in context.ADM_JENIS_IDENTITAS
                        where a.ID_JENIS_IDENTITAS == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtKode.Text = a.KODE;
                txtJenisIdentitas.Text = a.JENIS_IDENTITAS;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtKode, errorProvider1, "Kode harus diisi.");
                val.validateTextBox(txtJenisIdentitas, errorProvider1, "Jenis identitas harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var id = new ADM_JENIS_IDENTITAS();
                id.KODE = txtKode.Text;
                id.JENIS_IDENTITAS = txtJenisIdentitas.Text;
                context.ADM_JENIS_IDENTITAS.InsertOnSubmit(id);
            }
            else
            {
                var query = from a in context.ADM_JENIS_IDENTITAS
                            where a.ID_JENIS_IDENTITAS == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.KODE = txtKode.Text;
                    a.JENIS_IDENTITAS = txtJenisIdentitas.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void FrJenisIdentitas_Activated(object sender, EventArgs e)
        {
            txtKode.Focus();
        }

        private void txtKode_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kode harus diisi.");
        }

        private void txtJenisIdentitas_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Jenis identitas harus diisi.");
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtJenisIdentitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }
    }
}
