using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicketSystem.Common;

namespace TicketSystem.Transactions
{
    public partial class FrPembatalan : Form
    {
        #region Declaration

        private int SelectedId = 0;
        private string conString = DbConnection.GetConnection();

        #endregion
        
        public FrPembatalan()
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
                }
                RefreshGrid();
            }
            catch
            {
            }
        }

        private void RefreshGrid()
        {
            int IdJadwal = 0;
            try
            {
                IdJadwal = Convert.ToInt32(cbJadwal.SelectedValue);
            }
            catch (Exception)
            {
                IdJadwal = 0;
            }
                
           
            string query = "SELECT  TRX_PENJUALAN.ID_PENJUALAN, ADM_KONSUMEN.NO_IDENTITAS, " +
                           "ADM_KONSUMEN.NAMA, TRX_PENJUALAN.TGL_PENJUALAN, TRX_PENJUALAN.QTY_PENUMPANG, TRX_PENJUALAN.ONGKOS, " +
                           "TRX_PENJUALAN.JUMLAH, TRX_PENJUALAN.DP, TRX_PENJUALAN.SISA " +
                           "FROM TRX_PENJUALAN INNER JOIN " +
                           "ADM_KONSUMEN ON TRX_PENJUALAN.ID_KONSUMEN = ADM_KONSUMEN.ID_KONSUMEN " +
                           "WHERE (TRX_PENJUALAN.[STATUS] <> 'BATAL' OR TRX_PENJUALAN.[STATUS] IS NULL) AND TRX_PENJUALAN.ID_JADWAL =" +
                           IdJadwal;
            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrPembatalan)Application.OpenForms["FrPembatalan"];
            var dgv = (DataGridView)form.Controls["pnlMiddle"].Controls["dgvPembatalan"];
            dgv.DataSource = table;

            dgvPembatalan.Columns[0].Visible = false;
            dgvPembatalan.Columns[1].HeaderText = "No Identitas";
            dgvPembatalan.Columns[2].HeaderText = "Nama";
            dgvPembatalan.Columns[3].HeaderText = "Tgl";
            dgvPembatalan.Columns[4].HeaderText = "Jumlah Penumpang";
            dgvPembatalan.Columns[5].HeaderText = "Ongkos";
            dgvPembatalan.Columns[6].HeaderText = "Total";
            dgvPembatalan.Columns[7].HeaderText = "Dibayar";
            dgvPembatalan.Columns[8].HeaderText = "Sisa";
            dgvPembatalan.Columns[1].MinimumWidth = 120;
            dgvPembatalan.Columns[2].MinimumWidth = 200;
            dgvPembatalan.Columns[3].MinimumWidth = 100;
            dgvPembatalan.Columns[4].MinimumWidth = 130;
            dgvPembatalan.Columns[5].MinimumWidth = 100;
            dgvPembatalan.Columns[6].MinimumWidth = 100;
            dgvPembatalan.Columns[7].MinimumWidth = 100;
            dgvPembatalan.Columns[8].MinimumWidth = 100;
            dgvPembatalan.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPembatalan.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPembatalan.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPembatalan.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPembatalan.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPembatalan.Columns[4].DefaultCellStyle.Format = "N0";
            dgvPembatalan.Columns[5].DefaultCellStyle.Format = "N0";
            dgvPembatalan.Columns[6].DefaultCellStyle.Format = "N0";
            dgvPembatalan.Columns[7].DefaultCellStyle.Format = "N0";
            dgvPembatalan.Columns[8].DefaultCellStyle.Format = "N0";

            bool act = table.Rows.Count != 0;
            btnBatal.Enabled = act;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            var batal = new  FrPembatalanAdd(SelectedId);
            batal.FormClosed += HandleFormClosed;
            batal.ShowDialog();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPembatalan_SelectionChanged(object sender, EventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv != null && gv.RowCount > 0)
                if (gv.CurrentRow != null) SelectedId = Convert.ToInt32(gv.CurrentRow.Cells[0].Value);
        }

        private void HandleFormClosed(Object sender, FormClosedEventArgs e)
        {
            RefreshGrid();
        }

        private void FrPembatalan_Load(object sender, EventArgs e)
        {
            dtpTgl_ValueChanged(sender, e);
        }
    }
}
