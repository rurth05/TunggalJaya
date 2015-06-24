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
    public partial class FrPelunasan : Form
    {
        #region Declaration
        
        private int SelectedId = 0;
        private string conString = DbConnection.GetConnection();
        
        #endregion

        public FrPelunasan()
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
                    RefreshGrid();
                }
            }catch
            {
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            var frPelunasan = new FrPelunasanAdd(SelectedId);
            frPelunasan.FormClosed += HandleFormClosed;
            frPelunasan.ShowDialog();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvPelunasan_SelectionChanged(object sender, EventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv != null && gv.RowCount > 0)
                if (gv.CurrentRow != null) SelectedId = Convert.ToInt32(gv.CurrentRow.Cells[0].Value);
        }

        private void HandleFormClosed(Object sender, FormClosedEventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            string query = "SELECT  TRX_PENJUALAN.ID_PENJUALAN, ADM_KONSUMEN.NO_IDENTITAS, " +
                      "ADM_KONSUMEN.NAMA, TRX_PENJUALAN.TGL_PENJUALAN, TRX_PENJUALAN.QTY_PENUMPANG, TRX_PENJUALAN.ONGKOS, " +
                      "TRX_PENJUALAN.JUMLAH, TRX_PENJUALAN.DP, TRX_PENJUALAN.SISA " +
                      "FROM TRX_PENJUALAN INNER JOIN " +
                      "ADM_KONSUMEN ON TRX_PENJUALAN.ID_KONSUMEN = ADM_KONSUMEN.ID_KONSUMEN " +
                      "WHERE TRX_PENJUALAN.SISA > 0";
            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrPelunasan)Application.OpenForms["FrPelunasan"];
            var dgv = (DataGridView)form.Controls["pnlMiddle"].Controls["dgvPelunasan"];
            dgv.DataSource = table;

            dgvPelunasan.Columns[0].Visible = false;
            dgvPelunasan.Columns[1].HeaderText = "No Identitas";
            dgvPelunasan.Columns[2].HeaderText = "Nama";
            dgvPelunasan.Columns[3].HeaderText = "Tgl";
            dgvPelunasan.Columns[4].HeaderText = "Jumlah Penumpang";
            dgvPelunasan.Columns[5].HeaderText = "Ongkos";
            dgvPelunasan.Columns[6].HeaderText = "Total";
            dgvPelunasan.Columns[7].HeaderText = "Dibayar";
            dgvPelunasan.Columns[8].HeaderText = "Sisa";
            dgvPelunasan.Columns[1].MinimumWidth = 120;
            dgvPelunasan.Columns[2].MinimumWidth = 200;
            dgvPelunasan.Columns[3].MinimumWidth = 100;
            dgvPelunasan.Columns[4].MinimumWidth = 130;
            dgvPelunasan.Columns[5].MinimumWidth = 100;
            dgvPelunasan.Columns[6].MinimumWidth = 100;
            dgvPelunasan.Columns[7].MinimumWidth = 100;
            dgvPelunasan.Columns[8].MinimumWidth = 100;
            dgvPelunasan.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPelunasan.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPelunasan.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPelunasan.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPelunasan.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPelunasan.Columns[4].DefaultCellStyle.Format = "N0";
            dgvPelunasan.Columns[5].DefaultCellStyle.Format = "N0";
            dgvPelunasan.Columns[6].DefaultCellStyle.Format = "N0";
            dgvPelunasan.Columns[7].DefaultCellStyle.Format = "N0";
            dgvPelunasan.Columns[8].DefaultCellStyle.Format = "N0";
            
            bool act = table.Rows.Count != 0;
            btnBayar.Enabled = act;
        }

        private void FrPelunasan_Load(object sender, EventArgs e)
        {
            dtpTgl_ValueChanged(sender, e);
        }
    }
}
