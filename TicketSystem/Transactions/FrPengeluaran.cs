using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicketSystem.Common;
using System.Data.SqlClient;

namespace TicketSystem.Transactions
{
    public partial class FrPengeluaran : Form
    {
        #region Declaration
        private string conString = DbConnection.GetConnection();
        private string menu;
        private int SelectedId = 0;
        #endregion

        public FrPengeluaran()
        {
            InitializeComponent();
        }

        private void dtpTgl_ValueChanged(object sender, EventArgs e)
        {
            string q1 = "SELECT 0 AS ID_JADWAL, '--Pilih--' AS KODE UNION " +
                        "SELECT ADM_JADWAL.ID_JADWAL, CONVERT(VARCHAR(5), ADM_JADWAL.JAM) " +
                        "+ '-' + REF_KOTA.KODE_KOTA + '-' + REF_KOTA_1.KODE_KOTA + '-' + REF_KENDARAAN.NO_ARMADA AS KODE " +
                        "FROM ADM_JADWAL INNER JOIN " +
                        "REF_KENDARAAN ON ADM_JADWAL.ID_KENDARAAN = REF_KENDARAAN.ID_KENDARAAN INNER JOIN " +
                        "REF_KOTA ON ADM_JADWAL.KOTA_ASAL = REF_KOTA.ID_KOTA INNER JOIN " +
                        "REF_KOTA AS REF_KOTA_1 ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA_1.ID_KOTA " +
                        "WHERE ADM_JADWAL.TGL_BERANGKAT = CONVERT(DATETIME,'" + dtpTgl.Text + "',103)";

            var dtAdapter1 = new SqlDataAdapter(q1, DbConnection.GetConnection());

            var table1 = new DataTable();
            table1.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dtAdapter1.Fill(table1);
            cbJadwal.DataSource = table1;
            cbJadwal.DisplayMember = "KODE";
            cbJadwal.ValueMember = "ID_JADWAL";
        }

        private void cbJadwal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbJadwal.Text == "--Pilih--")
                {
                    txtIdJadwal.Text = "";
                    txtJam.Text = "";
                    txtAsal.Text = "";
                    txtTujuan.Text = "";
                    txtSupir.Text = "";
                    txtKodeTipe.Text = "";
                    chkCarter.Checked = false;
                    btnBaru.Enabled = false;
                }
                else
                {
                    var query =
                        "SELECT ADM_JADWAL.ID_JADWAL, ADM_JADWAL.JAM, REF_KOTA.NAMA_KOTA AS ASAL, REF_KOTA_1.NAMA_KOTA AS TUJUAN, REF_SUPIR.NAMA, " +
                        "REF_TIPE_KENDARAAN.KODE_TIPE, ADM_JADWAL.CARTER " +
                        "FROM ADM_JADWAL INNER JOIN " +
                        "REF_KENDARAAN ON ADM_JADWAL.ID_KENDARAAN = REF_KENDARAAN.ID_KENDARAAN INNER JOIN " +
                        "REF_KOTA ON ADM_JADWAL.KOTA_ASAL = REF_KOTA.ID_KOTA INNER JOIN " +
                        "REF_KOTA AS REF_KOTA_1 ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA_1.ID_KOTA INNER JOIN " +
                        "REF_SUPIR ON ADM_JADWAL.ID_SUPIR = REF_SUPIR.ID_SUPIR INNER JOIN " +
                        "REF_TIPE_KENDARAAN ON REF_KENDARAAN.ID_TIPE_KENDARAAN = REF_TIPE_KENDARAAN.ID_TIPE_KENDARAAN " +
                        "WHERE ADM_JADWAL.ID_JADWAL = @Id";
                    var con = new SqlConnection(DbConnection.GetConnection());
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(cbJadwal.SelectedValue);
                    con.Open();
                    var rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            txtIdJadwal.Text = rd["ID_JADWAL"].ToString();
                            txtJam.Text = rd["JAM"].ToString().Substring(0, 5);
                            txtAsal.Text = rd["ASAL"].ToString();
                            txtTujuan.Text = rd["TUJUAN"].ToString();
                            txtSupir.Text = rd["NAMA"].ToString();
                            txtKodeTipe.Text = rd["KODE_TIPE"].ToString();
                            chkCarter.Checked = Convert.ToBoolean(rd["CARTER"]);
                        }
                    }
                    con.Close();
                    btnBaru.Enabled = true;
                }
                RefreshGrid();
            }
            catch
            {
            }
        }

        private void RefreshGrid()
        {
            string query = "SELECT ID_PENGELUARAN, PENGELUARAN, KETERANGAN "+
                    "FROM TRX_PENGELUARAN WHERE ID_JADWAL = " + cbJadwal.SelectedValue;
            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrPengeluaran)Application.OpenForms["FrPengeluaran"];
            var dgv = (DataGridView)form.Controls["pnlMiddle"].Controls["dgv"];
            dgv.DataSource = table;

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Pengeluaran";
            dgv.Columns[2].HeaderText = "Keterangan";
            dgv.Columns[1].MinimumWidth = 120;
            dgv.Columns[2].MinimumWidth = 200;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns[1].DefaultCellStyle.Format = "N0";

            bool act = table.Rows.Count != 0;
            btnUbah.Enabled = act;
            btnHapus.Enabled = act;
            //btnCari.Enabled = act;
        }

        private void HandleFormClosed(Object sender, FormClosedEventArgs e)
        {
            RefreshGrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv != null && gv.RowCount > 0)
                if (gv.CurrentRow != null) SelectedId = Convert.ToInt32(gv.CurrentRow.Cells[0].Value);
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            var frm = new FrPengeluaranAdd(0, Convert.ToInt32(txtIdJadwal.Text));
            frm.FormClosed += HandleFormClosed;
            frm.ShowDialog();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            var frm = new FrPengeluaranAdd(SelectedId, Convert.ToInt32(txtIdJadwal.Text));
            frm.FormClosed += HandleFormClosed;
            frm.ShowDialog();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin akan menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "";
                    var con = new SqlConnection(DbConnection.GetConnection());
                    query = "DELETE FROM TRX_PENGELUARAN WHERE ID_PENGELUARAN = @Id";

                    var com = new SqlCommand(query, con);

                    com.Parameters.Add("@Id", SqlDbType.Int).Value = SelectedId;

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    RefreshGrid();
                }
                catch { MessageBox.Show("Gagal menghapus, data sedang digunakan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrPengeluaran_Load(object sender, EventArgs e)
        {
            dtpTgl_ValueChanged(sender, e);
            switch (UserInfo.Role)
            {
                case "ADM":
                    btnBaru.Visible = true;
                    btnUbah.Visible = true;
                    btnHapus.Visible = true;
                    break;
                case "SPV":
                    btnBaru.Visible = true;
                    btnUbah.Visible = true;
                    btnHapus.Visible = true;
                    break;
                case "OPR":
                    btnBaru.Visible = true;
                    btnUbah.Visible = false;
                    btnHapus.Visible = false;
                    break;
            }
        }
    }
}
