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
    public partial class FrTipeKendaraan : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtKode.Text.Trim() == String.Empty)
                return true;
            if (txtTipe.Text.Trim() == String.Empty)
                return true;
            if (txtKas.Text.Trim() == String.Empty)
                return true;
            if (txtSetorWajib.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrTipeKendaraan(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtIdTipe.Text = Id.ToString();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtKode, errorProvider1, "Kode tipe kendaraan harus diisi.");
                val.validateTextBox(txtTipe, errorProvider1, "Tipe kendaraan harus diisi.");
                val.validateTextBox(txtKas, errorProvider1, "Kas harus diisi.");
                val.validateTextBox(txtSetorWajib, errorProvider1, "Setor wajib harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtIdTipe.Text) == 0)
            {
                var tipe = new REF_TIPE_KENDARAAN();
                tipe.KODE_TIPE = txtKode.Text;
                tipe.TIPE_KENDARAAN = txtTipe.Text;
                tipe.KAS = Convert.ToDecimal(txtKas.Text);
                tipe.SETOR_WAJIB = Convert.ToDecimal(txtSetorWajib.Text);
                context.REF_TIPE_KENDARAANs.InsertOnSubmit(tipe);
            }
            else
            {
                var query = from a in context.REF_TIPE_KENDARAANs
                            where a.ID_TIPE_KENDARAAN == Convert.ToInt32(txtIdTipe.Text)
                            select a;
                foreach (var a in query)
                {
                    a.KODE_TIPE = txtKode.Text;
                    a.TIPE_KENDARAAN = txtTipe.Text;
                    a.KAS = Convert.ToDecimal(txtKas.Text);
                    a.SETOR_WAJIB = Convert.ToDecimal(txtSetorWajib.Text);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void FrTipeKendaraan_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_TIPE_KENDARAANs
                        where a.ID_TIPE_KENDARAAN == Convert.ToInt32(txtIdTipe.Text)
                        select a;
            foreach (var a in query)
            {
                txtKode.Text = a.KODE_TIPE;
                txtTipe.Text = a.TIPE_KENDARAAN;
                txtKas.Text = a.KAS.ToString();
                txtSetorWajib.Text = a.SETOR_WAJIB.ToString();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtKode_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kode tipe kendaraan harus diisi.");  
        }

        private void txtTipe_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Tipe kendaraan harus diisi.");  
        }

        private void txtKas_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kas harus diisi.");  
        }

        private void txtSetorWajib_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Setor wajib harus diisi.");  
        }

        private void txtKas_Leave(object sender, EventArgs e)
        {
            val.numberFormat(sender, txtKas.Text);
        }

        private void txtSetorWajib_Leave(object sender, EventArgs e)
        {
            val.numberFormat(sender, txtSetorWajib.Text);
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtTipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtKas_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtSetorWajib_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void FrTipeKendaraan_Activated(object sender, EventArgs e)
        {
            txtKode.Focus();
        }
    }
}
