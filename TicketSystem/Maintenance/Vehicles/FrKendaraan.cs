using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using TJ.DAL;
using TicketSystem.Common;

namespace TicketSystem.Maintenance.Vehicles
{
    public partial class FrKendaraan : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtNoArmada.Text.Trim() == String.Empty)
                return true;
            if (txtNoPolisi.Text.Trim() == String.Empty)
                return true;
            if (txtJmlKursi.Text.Trim() == String.Empty)
                return true;
            if (cbTipeKendaraan.Text.Trim() == "--Pilih--")
                return true;

            return false;
        }

        public FrKendaraan(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrKendaraan_Load(object sender, EventArgs e)
        {
            string cmbQuery = "SELECT 0 AS ID_TIPE_KENDARAAN, '--Pilih--' AS TIPE_KENDARAAN UNION SELECT ID_TIPE_KENDARAAN, TIPE_KENDARAAN FROM REF_TIPE_KENDARAAN";

            SqlDataAdapter dtAdapter = new SqlDataAdapter(cmbQuery, DbConnection.GetConnection());

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter.Fill(table);
            cbTipeKendaraan.DataSource = table;
            cbTipeKendaraan.DisplayMember = "TIPE_KENDARAAN";
            cbTipeKendaraan.ValueMember = "ID_TIPE_KENDARAAN";

            var query = from a in context.REF_KENDARAANs
                        where a.ID_TIPE_KENDARAAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtNoArmada.Text = a.NO_ARMADA;
                txtNoPolisi.Text = a.NO_POLISI;
                txtJmlKursi.Text = a.JML_KURSI.ToString();
                cbTipeKendaraan.SelectedValue = a.ID_TIPE_KENDARAAN;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtNoArmada, errorProvider1, "No armada harus diisi.");
                val.validateTextBox(txtNoPolisi, errorProvider1, "No polsi harus diisi.");
                val.validateTextBox(txtJmlKursi, errorProvider1, "Jumlah kursi harus diisi.");
                val.validateComboBox(cbTipeKendaraan, errorProvider1, "Tipe kendaraan harus dipilih.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var kendaraan = new REF_KENDARAAN();
                kendaraan.NO_ARMADA = txtNoArmada.Text;
                kendaraan.NO_POLISI = txtNoPolisi.Text;
                kendaraan.JML_KURSI = Convert.ToInt32(txtJmlKursi.Text);
                kendaraan.ID_TIPE_KENDARAAN = Convert.ToInt32(cbTipeKendaraan.SelectedValue);
                context.REF_KENDARAANs.InsertOnSubmit(kendaraan);
            }
            else
            {
                var query = from a in context.REF_KENDARAANs
                            where a.ID_KENDARAAN == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.NO_ARMADA = txtNoArmada.Text;
                    a.NO_POLISI = txtNoPolisi.Text;
                    a.JML_KURSI = Convert.ToInt32(txtJmlKursi.Text);
                    a.ID_TIPE_KENDARAAN = Convert.ToInt32(cbTipeKendaraan.SelectedValue);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNoArmada_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "No armada harus diisi.");
        }

        private void txtNoPolisi_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "No polisi harus diisi.");
        }

        private void txtJmlKursi_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Jumlah kursi harus diisi.");
        }

        private void cbTipeKendaraan_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender, errorProvider1, "Tipe kendaraan harus dipilih.");
        }

        private void txtNoArmada_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtNoPolisi_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtJmlKursi_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void cbTipeKendaraan_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtJmlKursi_Leave(object sender, EventArgs e)
        {
            val.numberFormat(sender, txtJmlKursi.Text);
        }

        private void FrKendaraan_Activated(object sender, EventArgs e)
        {
            txtNoArmada.Focus();
        }
    }
}
