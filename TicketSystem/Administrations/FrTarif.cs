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
    public partial class FrTarif : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtGolongan.Text.Trim() == String.Empty)
                return true;
            if (txtTarif.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrTarif(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrTarif_Load(object sender, EventArgs e)
        {
            var query = from a in context.ADM_TARIFs
                        where a.ID_TARIF == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtGolongan.Text = a.GOLONGAN;
                txtTarif.Text = a.TARIF.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtGolongan, errorProvider1, "Golongan harus diisi.");
                val.validateTextBox(txtTarif, errorProvider1, "Tarif harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var tarif = new ADM_TARIF();
                tarif.GOLONGAN = txtGolongan.Text;
                tarif.TARIF = Convert.ToDecimal(txtTarif.Text);
                context.ADM_TARIFs.InsertOnSubmit(tarif);
            }
            else
            {
                var query = from a in context.ADM_TARIFs
                            where a.ID_TARIF == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.GOLONGAN = txtGolongan.Text;
                    a.TARIF = Convert.ToDecimal(txtTarif.Text);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrTarif_Activated(object sender, EventArgs e)
        {
            txtGolongan.Focus();
        }

        private void txtGolongan_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender,errorProvider1,"Golongan harus diisi.");
        }

        private void txtTarif_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Tarif harus diisi.");
        }

        private void txtGolongan_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtTarif_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtTarif_Leave(object sender, EventArgs e)
        {
            val.numberFormat(sender, txtTarif.Text);
        }
    }
}
