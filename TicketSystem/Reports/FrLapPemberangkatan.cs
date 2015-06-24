using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TicketSystem.Common;
using System.Data.SqlClient;
using TicketSystem.dsLapPemberangkatanTableAdapters;

namespace TicketSystem.Reports
{
    public partial class FrLapPemberangkatan : Form
    {
        string conString = DbConnection.GetConnection();
        public FrLapPemberangkatan()
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

                    if (!string.IsNullOrEmpty(txtIdJadwal.Text))
                    {
                        string appPath = Application.StartupPath + "\\Reports\\ReportTemplates\\Pemberangkatan.rdlc";
                        appPath = appPath.Replace("\\bin\\Debug", "");

                        rv.LocalReport.ReportPath = appPath;
                        rv.ProcessingMode = ProcessingMode.Local;

                        var ta = new taPemberangkatan();
                        var dt = new dsLapPemberangkatan.dtPemberangkatanDataTable();

                        var cn = new SqlConnection(conString);
                        ta.Connection = cn;
                        ta.Fill(dt, Convert.ToInt32(txtIdJadwal.Text));

                        rv.LocalReport.DataSources.Clear();
                        rv.LocalReport.DataSources.Add(new ReportDataSource("dsPemberangkatan", dt as DataTable));
                        rv.RefreshReport();
                    }
                }
            }
            catch
            {
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrLapPemberangkatan_Load(object sender, EventArgs e)
        {
            dtpTgl_ValueChanged(sender, e);
        }
    }
}
