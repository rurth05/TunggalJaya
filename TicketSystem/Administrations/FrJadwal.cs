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
    public partial class FrJadwal : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (dtpTgl.Text.Trim() == String.Empty)
                return true;
            if (mTxtJam.Text.Trim() == String.Empty)
                return true;
            if (cbAsal.Text.Trim() == "--Pilih--")
                return true;
            if (cbTujuan.Text.Trim() == "--Pilih--")
                return true;
            if (cbArmada.Text.Trim() == "--Pilih--")
                return true;
            if (cbSupir.Text.Trim() == "--Pilih--")
                return true;

            return false;
        }

        public FrJadwal(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrJadwal_Load(object sender, EventArgs e)
        {
            string q1 = "SELECT 0 AS ID_KOTA, '--Pilih--' AS NAMA_KOTA UNION SELECT ID_KOTA, NAMA_KOTA FROM REF_KOTA";

            var dtAdapter1 = new SqlDataAdapter(q1, DbConnection.GetConnection());

            var table1 = new DataTable();
            table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter1.Fill(table1);
            cbAsal.DataSource = table1;
            cbAsal.DisplayMember = "NAMA_KOTA";
            cbAsal.ValueMember = "ID_KOTA";

            cbTujuan.DataSource = table1;
            cbTujuan.DisplayMember = "NAMA_KOTA";
            cbTujuan.ValueMember = "ID_KOTA";

            var dtAdapter1A = new SqlDataAdapter(q1, DbConnection.GetConnection());

            var table1A = new DataTable();
            table1A.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter1A.Fill(table1A);
            cbAsal.DataSource = table1A;
            cbAsal.DisplayMember = "NAMA_KOTA";
            cbAsal.ValueMember = "ID_KOTA";

            cbTujuan.DataSource = table1;
            cbTujuan.DisplayMember = "NAMA_KOTA";
            cbTujuan.ValueMember = "ID_KOTA";

            string q2 = "SELECT 0 AS ID_KENDARAAN, '--Pilih--' AS NO_ARMADA UNION SELECT ID_KENDARAAN, NO_ARMADA FROM REF_KENDARAAN";

            var dtAdapter2 = new SqlDataAdapter(q2, DbConnection.GetConnection());

            var table2 = new DataTable();
            table2.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter2.Fill(table2);
            cbArmada.DataSource = table2;
            cbArmada.DisplayMember = "NO_ARMADA";
            cbArmada.ValueMember = "ID_KENDARAAN";

            string q3 = "SELECT 0 AS ID_SUPIR, '--Pilih--' AS NAMA UNION SELECT ID_SUPIR, NAMA FROM REF_SUPIR";

            var dtAdapter3 = new SqlDataAdapter(q3, DbConnection.GetConnection());

            var table3 = new DataTable();
            table3.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter3.Fill(table3);
            cbSupir.DataSource = table3;
            cbSupir.DisplayMember = "NAMA";
            cbSupir.ValueMember = "ID_SUPIR";

            var query = from a in context.ADM_JADWALs
                        where a.ID_JADWAL == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                dtpTgl.Text = Convert.ToDateTime(a.TGL_BERANGKAT).ToString("dd/MM/yyyy");
                mTxtJam.Text = a.JAM.ToString();
                cbAsal.SelectedValue = a.KOTA_ASAL;
                cbTujuan.SelectedValue = a.KOTA_TUJUAN;
                cbArmada.SelectedValue = a.ID_KENDARAAN;
                cbSupir.SelectedValue = a.ID_SUPIR;
                chkCarter.Checked = Convert.ToBoolean(a.CARTER);
            }
        }

        private void FrJadwal_Activated(object sender, EventArgs e)
        {
            dtpTgl.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateMaskedTextBox(mTxtJam, errorProvider1, "Jam harus diisi.");
                val.validateComboBox(cbAsal,errorProvider1, "Kota asal harus dipilih.");
                val.validateComboBox(cbTujuan, errorProvider1, "Kota tujuan harus dipilih.");
                val.validateComboBox(cbArmada, errorProvider1, "Armada harus dipilih.");
                val.validateComboBox(cbSupir, errorProvider1, "Supir harus dipilih.");

                return;
            }
            else
            {
                if (Convert.ToInt32(txtId.Text) == 0)
                {
                    if ((from a in context.ADM_JADWALs where a.TGL_BERANGKAT == Convert.ToDateTime(dtpTgl.Text) && a.ID_KENDARAAN == Convert.ToInt32(cbArmada.SelectedValue) select a).Any())
                        MessageBox.Show("Jadwal untuk armada bersangkutan sudah ada.", "Jadwal", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    else
                    {
                        var jadwal = new ADM_JADWAL();
                        jadwal.TGL_BERANGKAT = Convert.ToDateTime(dtpTgl.Text);
                        jadwal.JAM = TimeSpan.Parse(mTxtJam.Text);
                        jadwal.KOTA_ASAL = Convert.ToInt32(cbAsal.SelectedValue);
                        jadwal.KOTA_TUJUAN = Convert.ToInt32(cbTujuan.SelectedValue);
                        jadwal.ID_KENDARAAN = Convert.ToInt32(cbArmada.SelectedValue);
                        jadwal.ID_SUPIR = Convert.ToInt32(cbSupir.SelectedValue);
                        jadwal.CARTER = chkCarter.Checked;
                        jadwal.ID_INDEX_GAJI = chkCarter.Checked ? 2 : 1;
                        context.ADM_JADWALs.InsertOnSubmit(jadwal);
                    }
                }
                else
                {
                    var query = from a in context.ADM_JADWALs
                                where a.ID_JADWAL == Convert.ToInt32(txtId.Text)
                                select a;
                    foreach (var a in query)
                    {
                        a.TGL_BERANGKAT = Convert.ToDateTime(dtpTgl.Text);
                        a.JAM = TimeSpan.Parse(mTxtJam.Text);
                        a.KOTA_ASAL = Convert.ToInt32(cbAsal.SelectedValue);
                        a.KOTA_TUJUAN = Convert.ToInt32(cbTujuan.SelectedValue);
                        a.ID_KENDARAAN = Convert.ToInt32(cbArmada.SelectedValue);
                        a.ID_SUPIR = Convert.ToInt32(cbSupir.SelectedValue);
                        a.CARTER = chkCarter.Checked;
                        a.ID_INDEX_GAJI = chkCarter.Checked ? 2 : 1;
                    }
                }
                context.SubmitChanges();
                Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mTxtJam_Validating(object sender, CancelEventArgs e)
        {
            val.validateMaskedTextBox(sender, errorProvider1,"Jam harus diisi.");
        }

        private void cbAsal_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender,errorProvider1, "Kota asal harus dipilih.");
        }

        private void cbTujuan_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender, errorProvider1, "Kota tujuan harus dipilih.");
        }

        private void cbArmada_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender, errorProvider1, "Armada harus dipilih.");
        }

        private void cbSupir_Validating(object sender, CancelEventArgs e)
        {
            val.validateComboBox(sender, errorProvider1, "Supir harus dipilih.");
        }

        private void dtpTgl_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void mTtxtJam_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void cbAsal_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void cbTujuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void cbArmada_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void cbSupir_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void chkCarter_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }
    }
}
