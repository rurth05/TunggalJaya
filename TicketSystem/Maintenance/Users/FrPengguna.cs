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

namespace TicketSystem.Maintenance.Users
{
    public partial class FrPengguna : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtNamaPengguna.Text.Trim() == String.Empty)
                return true;
            if (txtSandi.Text.Trim() == String.Empty)
                return true;
            if (txtNamaLengkap.Text.Trim() == String.Empty)
                return true;
            if (txtAlamat.Text.Trim() == String.Empty)
                return true;
            if (txtTelp.Text.Trim() == String.Empty)
                return true;
            if (cbPeran.Text.Trim() == "--Pilih--")
                return true;

            return false;
        }

        public FrPengguna(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrPengguna_Load(object sender, EventArgs e)
        {
            string cmbQuery = "SELECT 0 AS ID_PERAN, '--Pilih--' AS PERAN UNION SELECT ID_PERAN, PERAN FROM REF_PERAN";

            SqlDataAdapter dtAdapter = new SqlDataAdapter(cmbQuery, DbConnection.GetConnection());

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter.Fill(table);
            cbPeran.DataSource = table;
            cbPeran.DisplayMember = "PERAN";
            cbPeran.ValueMember = "ID_PERAN";

            var query = from a in context.REF_PENGGUNAs
                        where a.ID_PENGGUNA == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtNamaPengguna.Text = a.NAMA_PENGGUNA;
                txtSandi.Text = Encryption.Decrypt(a.SANDI, true);
                txtNamaLengkap.Text = a.NAMA_LENGKAP;
                txtAlamat.Text = a.ALAMAT;
                txtTelp.Text = a.TELP;
                cbPeran.SelectedValue = Convert.ToInt32(a.ID_PERAN);
            }
        }

        private void FrPengguna_Activated(object sender, EventArgs e)
        {
            txtNamaPengguna.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtNamaPengguna, errorProvider1, "Nama pengguna harus diisi.");
                val.validateTextBox(txtSandi, errorProvider1, "Sandi harus diisi.");
                val.validateTextBox(txtNamaLengkap, errorProvider1, "Nama lengkap harus diisi.");
                val.validateTextBox(txtAlamat, errorProvider1, "Alamat harus diisi.");
                val.validateTextBox(txtTelp, errorProvider1, "Telepon harus diisi.");
                val.validateComboBox(cbPeran,errorProvider1,"Peran harus dipilih.");
                return;
            }

            try
            {
                if (Convert.ToInt32(txtId.Text) == 0)
                {
                    var user = new REF_PENGGUNA();
                    user.NAMA_PENGGUNA = txtNamaPengguna.Text;
                    user.SANDI = Encryption.Encrypt(txtSandi.Text, true);
                    user.NAMA_LENGKAP = txtNamaLengkap.Text;
                    user.ALAMAT = txtAlamat.Text;
                    user.TELP = txtTelp.Text;
                    user.ID_PERAN = Convert.ToInt32(cbPeran.SelectedValue);
                    context.REF_PENGGUNAs.InsertOnSubmit(user);
                }
                else
                {
                    var query = from a in context.REF_PENGGUNAs
                                where a.ID_PENGGUNA == Convert.ToInt32(txtId.Text)
                                select a;
                    foreach (var a in query)
                    {
                        a.NAMA_PENGGUNA = txtNamaPengguna.Text;
                        a.SANDI = Encryption.Encrypt(txtSandi.Text, true);
                        a.NAMA_LENGKAP = txtNamaLengkap.Text;
                        a.ALAMAT = txtAlamat.Text;
                        a.TELP = txtTelp.Text;
                        a.ID_PERAN = Convert.ToInt32(cbPeran.SelectedValue);
                    }
                }
                context.SubmitChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNamaPengguna_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender,errorProvider1,"Nama pengguna harus diisi.");
        }

        private void txtSandi_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Sandi harus diisi.");
        }

        private void txtNamaLengkap_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Nama lengkap harus diisi.");
        }

        private void txtAlamat_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Alamat harus diisi.");
        }

        private void txtTelp_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Telepon harus diisi.");
        }

        private void cbPeran_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender, errorProvider1, "Peran harus dipilih.");
        }

        private void txtNamaPengguna_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtSandi_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtNamaLengkap_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cbPeran_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
            btnSimpan.Focus();
        }
    }
}
