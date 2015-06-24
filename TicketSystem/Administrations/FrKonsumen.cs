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

namespace TicketSystem.Administrations
{
    public partial class FrKonsumen : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (cbJenisIdentitas.Text.Trim() == "--Pilih--")
                return true;
            if (txtNoIdentitas.Text.Trim() == String.Empty)
                return true;
            if (txtAlamat.Text.Trim() == String.Empty)
                return true;
            if (txtTelp.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrKonsumen(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrKonsumen_Load(object sender, EventArgs e)
        {
            string q1 = "SELECT 0 AS ID_JENIS_IDENTITAS, '--Pilih--' AS JENIS_IDENTITAS UNION SELECT ID_JENIS_IDENTITAS, JENIS_IDENTITAS FROM ADM_JENIS_IDENTITAS";

            var dtAdapter1 = new SqlDataAdapter(q1, DbConnection.GetConnection());

            var table1 = new DataTable();
            table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter1.Fill(table1);
            cbJenisIdentitas.DataSource = table1;
            cbJenisIdentitas.DisplayMember = "JENIS_IDENTITAS";
            cbJenisIdentitas.ValueMember = "ID_JENIS_IDENTITAS";

            var query = from a in context.ADM_KONSUMENs
                        where a.ID_KONSUMEN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                cbJenisIdentitas.SelectedValue = a.ID_JENIS_IDENTITAS;
                txtNoIdentitas.Text = a.NO_IDENTITAS;
                txtAlamat.Text = a.ALAMAT;
                txtTelp.Text = a.TELP;
            }
        }

        private void FrKonsumen_Activated(object sender, EventArgs e)
        {
            cbJenisIdentitas.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateComboBox(cbJenisIdentitas, errorProvider1, "Jenis identitas harus dipilih.");
                val.validateTextBox(txtNoIdentitas, errorProvider1, "No identitas harus diisi.");
                val.validateTextBox(txtAlamat, errorProvider1, "Alamat harus diisi.");
                val.validateTextBox(txtTelp, errorProvider1, "Telp harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var konsumen = new ADM_KONSUMEN();
                konsumen.ID_JENIS_IDENTITAS = Convert.ToInt32(cbJenisIdentitas.SelectedValue);
                konsumen.NO_IDENTITAS = txtNoIdentitas.Text;
                konsumen.NAMA = txtNama.Text;
                konsumen.ALAMAT = txtAlamat.Text;
                konsumen.TELP = txtTelp.Text;
                context.ADM_KONSUMENs.InsertOnSubmit(konsumen);
            }
            else
            {
                var query = from a in context.ADM_KONSUMENs
                            where a.ID_KONSUMEN == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.ID_JENIS_IDENTITAS = Convert.ToInt32(cbJenisIdentitas.SelectedValue);
                    a.NO_IDENTITAS = txtNoIdentitas.Text;
                    a.NAMA = txtNama.Text;
                    a.ALAMAT = txtAlamat.Text;
                    a.TELP = txtTelp.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbJenisIdentitas_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender,errorProvider1,"Jenis identitas harus dipilih.");
        }

        private void txtNoIdentitas_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender,errorProvider1,"No identitas harus diisi.");
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
            val.validateTextBox(sender, errorProvider1, "Telp harus diisi.");
        }

        private void cbJenisIdentitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtNoIdentitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
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
    }
}
