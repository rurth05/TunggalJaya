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
using System.Data.SqlClient;

namespace TicketSystem.Transactions
{
    public partial class FrTrx : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        int psgCount = 0;
        int max = 0;
        private string seatCol = string.Empty;
        private bool IsFirstTime = false;
        #endregion

        private bool WithErrors()
        {
            if (txtNoIdentitas.Text.Trim() == String.Empty)
                return true;
            if (txtNama.Text.Trim() == String.Empty)
                return true;
            if (txtTelp.Text.Trim() == String.Empty)
                return true;
            if (txtJmlPenumpang.Text.Trim() == String.Empty)
                return true;
            if (txtOngkos.Text.Trim() == String.Empty)
                return true;
            if (txtDibayar.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrTrx()
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            IsFirstTime = true;
        }

        private void dtpTgl_ValueChanged(object sender, EventArgs e)
        {
            string q1 = "SELECT 0 AS ID_JADWAL, '--Pilih--' AS KODE UNION "+
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

        private void FrTrx_Load(object sender, EventArgs e)
        {
            dtpTgl_ValueChanged(sender, e);
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

                    txtIdKonsumen.Text = "";
                    txtNoIdentitas.Text = "";
                    txtNama.Text = "";
                    txtTelp.Text = "";
                    txtJmlPenumpang.Text = "";
                    txtOngkos.Text = "";
                    txtJumlah.Text = "";
                    txtDibayar.Text = "";
                    txtSisa.Text = "";
                    gbLayoutKursi3_4.Visible = false;
                    gbLayoutKursi33.Visible = false;
                    gbLayoutKursi.Visible = false;
                    btnCariPemesan.Enabled = false;
                    btnBatal.Enabled = false;
                    btnOk.Enabled = false;
                    dgvList.DataSource = null;
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

                    var quota = (from a in context.ADM_JADWALs
                                 join b in context.REF_KENDARAANs on a.ID_KENDARAAN equals b.ID_KENDARAAN
                                 where a.ID_JADWAL == Convert.ToInt32(txtIdJadwal.Text)
                                 select new
                                 {
                                     b.JML_KURSI
                                 }).ToList();
                    foreach (var q in quota)
                    {
                        max = Convert.ToInt32(q.JML_KURSI);
                    }

                    #region Visible layout kursi sesuai max kursi
                    switch(max)
                    {
                        case 31:
                            gbLayoutKursi3_4.Visible = true;
                            gbLayoutKursi33.Visible = false;
                            gbLayoutKursi.Visible = false;
                            break;
                        case 33:
                            gbLayoutKursi3_4.Visible = false;
                            gbLayoutKursi33.Visible = true;
                            gbLayoutKursi.Visible = false;
                            break;
                        case 60:
                            gbLayoutKursi3_4.Visible = false;
                            gbLayoutKursi33.Visible = false;
                            gbLayoutKursi.Visible = true;
                            break;
                    }

                    #endregion

                    if (chkCarter.Checked)
                    {
                        var q = from a in context.ADM_TARIFs where a.GOLONGAN == "CARTER" select a;
                        foreach (var a in q)
                        {
                            txtOngkos.Text = Convert.ToDecimal(a.TARIF).ToString("N0");
                        }
                        txtJmlPenumpang.Text = max.ToString();
                        txtJmlPenumpang.Enabled = false;
                        txtOngkos.Focus();
                    }
                    else
                    {
                        var q = from a in context.ADM_TARIFs where a.GOLONGAN == "REGULER" select a;
                        foreach (var a in q)
                        {
                            txtOngkos.Text = Convert.ToDecimal(a.TARIF).ToString("N0");
                            //txtJmlPenumpang.Text = "";
                            //txtJmlPenumpang.Enabled = true;
                            //txtJmlPenumpang.Focus();
                        }
                    }
                    PopulateList();
                    btnCariPemesan.Enabled = true;
                }
                #region Linq Query
                //var result = from a in context.ADM_JADWALs
                //              join b in context.REF_KENDARAANs on a.ID_KENDARAAN equals b.ID_KENDARAAN
                //              join c in context.REF_KOTAs on a.KOTA_ASAL equals c.ID_KOTA
                //              join d in context.REF_KOTAs on a.KOTA_TUJUAN equals d.ID_KOTA
                //              join f in context.REF_SUPIRs on a.ID_SUPIR equals f.ID_SUPIR
                //              join g in context.REF_TIPE_KENDARAANs on b.ID_TIPE_KENDARAAN equals g.ID_TIPE_KENDARAAN
                //              where a.ID_KENDARAAN == Convert.ToInt32(cbJadwal.SelectedValue)
                //              select new
                //              {
                //                  a.ID_JADWAL,
                //                  ASAL = c.NAMA_KOTA,
                //                  TUJUAN = d.NAMA_KOTA,
                //                  a.JAM,
                //                  f.NAMA,
                //                  g.KODE_TIPE
                //              };
                //foreach (var r in result)
                //{
                //    txtIdJadwal.Text = r.ID_JADWAL.ToString();
                //    txtJam.Text = r.JAM.ToString().Substring(0, 5);
                //    txtAsal.Text = r.ASAL;
                //    txtTujuan.Text = r.TUJUAN;
                //    txtSupir.Text = r.NAMA;
                //    txtKodeTipe.Text = r.KODE_TIPE;  
                //}
                #endregion
            }
            catch
            {}
        }

        private void txtKodeTipe_TextChanged(object sender, EventArgs e)
        {
            //switch (txtKodeTipe.Text)
            //{
            //    case "B34":
            //        gbLayoutKursi3_4.Visible = true;
            //        gbLayoutKursi.Visible = false;
            //        break;
            //    case "BUS":
            //        gbLayoutKursi3_4.Visible = false;
            //        gbLayoutKursi.Visible = true;
            //        break;
            //}
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCariPemesan_Click(object sender, EventArgs e)
        {
            txtCariKonsumen.Text = "";
            dgvCariKonsumen.Columns.Clear();
            pnlCari.Visible = true;
            txtCariKonsumen.Focus();
        }

        private void btnTutupCari_Click(object sender, EventArgs e)
        {
            pnlCari.Visible = false;
        }

        private void txtCariKonsumen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string query = "SELECT ID_KONSUMEN, NO_IDENTITAS, NAMA, TELP FROM ADM_KONSUMEN " +
                               "WHERE NO_IDENTITAS LIKE '%{0}%' OR NAMA LIKE '%{0}%' ORDER BY ID_KONSUMEN";

                query = string.Format(query, txtCariKonsumen.Text);
                var dtAdapter = new SqlDataAdapter(query, DbConnection.GetConnection());

                var table = new DataTable {Locale = System.Globalization.CultureInfo.InvariantCulture};
                dtAdapter.Fill(table);
                dgvCariKonsumen.DataSource = table;

                dgvCariKonsumen.Columns[0].Visible = false;
                dgvCariKonsumen.Columns[1].HeaderText = "No Identitas";
                dgvCariKonsumen.Columns[2].HeaderText = "Nama Konsumen";
                dgvCariKonsumen.Columns[3].Visible = false;
                dgvCariKonsumen.Columns[1].MinimumWidth = 110;
                dgvCariKonsumen.Columns[2].MinimumWidth = 150;

                e.Handled = true;
            }

            val.goNextControl(this, sender, e);
        }

        private void dgvCariKonsumen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvCariKonsumen.CurrentRow.Selected = true;
                e.Handled = true;

                var dgv = sender as DataGridView;

                txtIdKonsumen.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                txtNoIdentitas.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtNama.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                txtTelp.Text = dgv.CurrentRow.Cells[3].Value.ToString();

                pnlCari.Visible = false;
                txtJmlPenumpang.Focus();
            }
        }

        private void txtOngkos_Leave(object sender, EventArgs e)
        {
            double money = 0;
            double jml = 0;
            if (txtOngkos.Text.Trim().Length > 0)
            {
                if (!string.IsNullOrEmpty(txtOngkos.Text.Trim()))
                    money = Convert.ToDouble(txtOngkos.Text.Trim());
                txtOngkos.Text = money.ToString("N0");
                txtOngkos.SelectionStart = txtOngkos.TextLength;
            }

            if (txtJmlPenumpang.Text.Trim().Length > 0 && !chkCarter.Checked)
            {
                if (!string.IsNullOrEmpty(txtJmlPenumpang.Text.Trim()))
                    jml = Convert.ToDouble(txtJmlPenumpang.Text.Trim());
                txtJmlPenumpang.Text = jml.ToString("N0");
                txtJmlPenumpang.SelectionStart = txtJmlPenumpang.TextLength;
                txtJumlah.Text = (money * jml).ToString("N0");
            }
            else
                txtJumlah.Text = money.ToString("N0");
            
        }

        private void txtDP_Leave(object sender, EventArgs e)
        {
            double jml = 0;
            double dp = 0;
            if (txtJumlah.Text.Trim().Length > 0)
            {
                if (!string.IsNullOrEmpty(txtJumlah.Text.Trim()))
                    jml = Convert.ToDouble(txtJumlah.Text.Trim());
                txtJumlah.Text = jml.ToString("N0");
                txtJumlah.SelectionStart = txtJumlah.TextLength;
            }

            if (txtDibayar.Text.Trim().Length > 0)
            {
                if (!string.IsNullOrEmpty(txtDibayar.Text.Trim()))
                    dp = Convert.ToDouble(txtDibayar.Text.Trim());
                txtDibayar.Text = dp.ToString("N0");
                txtDibayar.SelectionStart = txtDibayar.TextLength;
            }
            txtSisa.Text = (jml - dp).ToString("N0");
        }

        private void txtJmlPenumpang_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtOngkos_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtJumlah_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtDP_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtSisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

            if (WithErrors())
            {
                val.validateTextBox(txtNoIdentitas, errorProvider1, "No identitas harus terisi.");
                val.validateTextBox(txtNama, errorProvider1, "Nama harus terisi.");
                val.validateTextBox(txtTelp, errorProvider1, "Telp harus terisi.");
                val.validateTextBox(txtJmlPenumpang, errorProvider1, "Jumlah penumpang harus terisi.");
                val.validateTextBox(txtOngkos, errorProvider1, "Ongkos harus terisi.");
                val.validateTextBox(txtDibayar, errorProvider1, "Dibayar harus terisi.");
            }
            else
            {
                int cnt = 0;
                int av = 0;
                int booked = 0;
                IsFirstTime = false;
                int trxId;
                val.validateReset(errorProvider1);

                var qry = (from a in context.TRX_PENJUALANs
                           where a.ID_JADWAL == Convert.ToInt32(txtIdJadwal.Text)
                           select new {a.QTY_PENUMPANG}).ToList();
                booked = Convert.ToInt32(qry.Select(b => b.QTY_PENUMPANG).Sum());
                cnt = booked + Convert.ToInt32(txtJmlPenumpang.Text);
                av = max - booked;
                if (cnt <= max)
                {
                    var jual = new TRX_PENJUALAN();
                    jual.TGL_PENJUALAN = DateTime.Now;
                    jual.ID_KONSUMEN = Convert.ToInt32(txtIdKonsumen.Text);
                    jual.ID_JADWAL = Convert.ToInt32(cbJadwal.SelectedValue);
                    jual.QTY_PENUMPANG = Convert.ToInt32(txtJmlPenumpang.Text);
                    jual.ONGKOS = Convert.ToDecimal(txtOngkos.Text);
                    jual.JUMLAH = Convert.ToDecimal(txtJumlah.Text);
                    jual.DP = Convert.ToDecimal(txtDibayar.Text);
                    jual.SISA = Convert.ToDecimal(txtSisa.Text);
                    if (rbUloYa.Checked)
                        jual.ID_KOMISI = 2;
                    else
                        jual.ID_KOMISI = 1;
                    context.TRX_PENJUALANs.InsertOnSubmit(jual);
                    context.SubmitChanges();
                    int currentId = jual.ID_PENJUALAN;

                    string[] seat = seatCol.Split(',');

                    for (int i = 0; i < seat.Count() - 1; i++)
                    {
                        var detail = new TRX_PENJUALAN_DETAIL();
                        detail.ID_PENJUALAN = currentId;
                        detail.NAMA_PENUMPANG = txtNama.Text;
                        detail.NO_KURSI = Convert.ToInt32(seat[i]);
                        context.TRX_PENJUALAN_DETAILs.InsertOnSubmit(detail);
                        context.SubmitChanges();
                    }

                    var histori = new TRX_HISTORI_TRANSAKSI();
                    Random rdm = new Random();
                    histori.NO_TRANSAKSI = rdm.Next(100000000, 999999999).ToString();
                    histori.TGL = DateTime.Now;
                    histori.JML_TAGIH = Convert.ToDecimal(txtJumlah.Text);
                    histori.DIBAYAR = Convert.ToDecimal(txtDibayar.Text);
                    histori.SISA = Convert.ToDecimal(txtSisa.Text);
                    histori.ID_PENJUALAN = currentId;
                    context.TRX_HISTORI_TRANSAKSIs.InsertOnSubmit(histori);
                    context.SubmitChanges();
                    trxId = histori.ID_TRANSAKSI;
                    //trxId = 2;

                    string query =
                        "SELECT ID_PENJUALAN_DETAIL, ID_PENJUALAN, NAMA_PENUMPANG, NO_KURSI FROM TRX_PENJUALAN_DETAIL " +
                        "WHERE ID_PENJUALAN = {0}";

                    query = string.Format(query, currentId);
                    var dtAdapter = new SqlDataAdapter(query, DbConnection.GetConnection());

                    var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
                    dtAdapter.Fill(table);
                    dgvKonsumen.DataSource = table;
                    dgvKonsumen.Columns[0].Visible = false;
                    dgvKonsumen.Columns[1].Visible = false;
                    dgvKonsumen.Columns[2].HeaderText = "Nama";
                    dgvKonsumen.Columns[3].HeaderText = "No Kursi";
                    dgvKonsumen.Columns[1].MinimumWidth = 100;
                    dgvKonsumen.Columns[2].MinimumWidth = 150;
                    dgvKonsumen.Columns[3].MinimumWidth = 100;
                    PopulateList();
                    MessageBox.Show("Berhasil disimpan.", "Transaksi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBatal_Click(sender, e);
                    
                    var rpt = new FrPrintReceipt(trxId);
                    rpt.ShowDialog();

                }
                else
                {
                    if (chkCarter.Checked)
                        MessageBox.Show("Jadwal carter ini sudah dipesan.", "Transaksi", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Sisa kursi yang tersedia " + av + " kursi.", "Transaksi", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
                
            }
        }

        private void dgvKonsumen_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvKonsumen.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void PopulateList()
        {
            string query ="SELECT TRX_PENJUALAN_DETAIL.ID_PENJUALAN_DETAIL, TRX_PENJUALAN_DETAIL.ID_PENJUALAN, TRX_PENJUALAN_DETAIL.NAMA_PENUMPANG, "+
                      "TRX_PENJUALAN_DETAIL.NO_KURSI "+
                      "FROM TRX_PENJUALAN INNER JOIN "+
                      "TRX_PENJUALAN_DETAIL ON TRX_PENJUALAN.ID_PENJUALAN = TRX_PENJUALAN_DETAIL.ID_PENJUALAN "+
                      "WHERE TRX_PENJUALAN.ID_JADWAL = {0} AND (TRX_PENJUALAN.STATUS <> 'BATAL' OR TRX_PENJUALAN.STATUS IS NULL)";

            query = string.Format(query, cbJadwal.SelectedValue);
            var dtAdapter = new SqlDataAdapter(query, DbConnection.GetConnection());

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            dgvList.DataSource = table;

            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].Visible = false;
            dgvList.Columns[2].HeaderText = "Nama";
            dgvList.Columns[3].HeaderText = "No Kursi";
            dgvList.Columns[1].MinimumWidth = 100;
            dgvList.Columns[2].MinimumWidth = 150;
            dgvList.Columns[3].MinimumWidth = 100;

            List<Label> ctls = new List<Label>();
            if (gbLayoutKursi3_4.Visible)
                ctls = gbLayoutKursi3_4.Controls.OfType<Label>().ToList();
            else if (gbLayoutKursi.Visible)
                ctls = gbLayoutKursi.Controls.OfType<Label>().ToList();
             else if (gbLayoutKursi33.Visible)
                ctls = gbLayoutKursi33.Controls.OfType<Label>().ToList();

            List<DataRow> list = table.Rows.Cast<DataRow>().ToList();

            if (!chkCarter.Checked)
            {
                foreach (var ctl in ctls) 
                {
                    if (!ctl.Text.Equals("D")) // Exclude label dengan teks 'D'
                        ctl.BackColor = Color.ForestGreen; //Set semua control ke hijau dahulu
                    foreach (DataRow row in list)
                    {
                        if (ctl.Text.Equals(row.ItemArray[3].ToString()))
                            ctl.BackColor = Color.Red; //Tandai merah di kontrol jika sama
                    }
                    if (IsFirstTime) // Cek apakah pertama kali load
                        ctl.MouseUp += new MouseEventHandler(OnMouseUp);
                }
            }/*else
            {
                foreach (var ctl in ctls)
                {
                    if (!ctl.Text.Equals("D"))
                    {
                        ctl.BackColor = Color.Red;
                        ctl.MouseUp -= OnMouseUp;
                    }
                }
            }*/
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            List<Label> ctls = new List<Label>();
            if (gbLayoutKursi3_4.Visible)
                ctls = gbLayoutKursi3_4.Controls.OfType<Label>().ToList();
            else if (gbLayoutKursi.Visible)
                ctls = gbLayoutKursi.Controls.OfType<Label>().ToList();
            else if (gbLayoutKursi33.Visible)
                ctls = gbLayoutKursi33.Controls.OfType<Label>().ToList();
            var ths = sender as Label;
            foreach (var ctl in ctls)
            {
                if (ctl.Text == ths.Text)
                {
                    string clr = ctl.BackColor.Name;
                    switch (clr)
                    {
                        case "ForestGreen":
                            if (psgCount < Convert.ToInt32(txtJmlPenumpang.Text))
                            {
                                ths.BackColor = Color.Yellow;
                                psgCount++; // tambah jumlah penumpang yang telah memilih
                                seatCol += ths.Text + ","; //kumpulan no kursi yang akan di save
                            }
                            else
                                MessageBox.Show("Sudah " + txtJmlPenumpang.Text + " tempat duduk dipesan.", "Penjualan",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                            break;
                        case "Yellow":
                            ths.BackColor = Color.ForestGreen;
                            psgCount--; // kurangi jumlah penumpang yang telah memilih
                            seatCol = seatCol.Replace(ths.Text + ",",""); // kurangi no kursi yang akan disave
                            break;
                        case "Red":
                            ths.BackColor = Color.Red;
                            MessageBox.Show("Tempat duduk sudah dipesan.", "Penjualan", MessageBoxButtons.OK,
                                            MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }
        }

        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvList.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            txtIdKonsumen.Text = "";
            txtNoIdentitas.Text = "";
            txtNama.Text = "";
            txtTelp.Text = "";
            txtJmlPenumpang.Text = "";
            //txtOngkos.Text = "";
            txtJumlah.Text = "";
            txtDibayar.Text = "";
            txtSisa.Text = "";
            dgvKonsumen.DataSource = null;
            psgCount = 0;
            seatCol = "";

            btnCariPemesan.Enabled = true;
            btnBatal.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtJmlPenumpang.Enabled = false;
            txtOngkos.Enabled = false;
            txtJumlah.Enabled = false;
            txtDibayar.Enabled = false;
            btnCariPemesan.Enabled = false;
            rbUloYa.Enabled = false;
            rbUloTidak.Enabled = false;
            btnOk.Enabled = false;
            if (!chkCarter.Checked)
                MessageBox.Show("Silakan pilih no tempat duduk yang tersedia !", "Reservasi", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            else
            {
                List<Label> ctls = new List<Label>();

                
                if (gbLayoutKursi3_4.Visible)
                    ctls = gbLayoutKursi3_4.Controls.OfType<Label>().ToList();
                else if(gbLayoutKursi.Visible)
                    ctls = gbLayoutKursi.Controls.OfType<Label>().ToList();
                else if(gbLayoutKursi33.Visible)
                    ctls = gbLayoutKursi33.Controls.OfType<Label>().ToList();

                foreach (var ctl in ctls)
                {
                    if (!ctl.Text.Equals("D"))
                    {
                        ctl.BackColor = Color.Red;
                        ctl.MouseUp -= OnMouseUp;
                    }
                }
            }
        }

        private void txtIdKonsumen_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdKonsumen.Text))
            {
                txtJmlPenumpang.Enabled = true;
                txtOngkos.Enabled = true;
                txtJumlah.Enabled = true;
                txtDibayar.Enabled = true;
                btnBatal.Enabled = true;
                btnOk.Enabled = true;
            }
        }

        private void txtOngkos_TextChanged(object sender, EventArgs e)
        {
            if (txtOngkos.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtOngkos.Text.Replace(".", ""));
                txtOngkos.Text = money.ToString("N0");
                txtOngkos.SelectionStart = txtOngkos.TextLength;
            }
        }

        private void txtJumlah_TextChanged(object sender, EventArgs e)
        {
            if (txtJumlah.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtJumlah.Text.Replace(".", ""));
                txtJumlah.Text = money.ToString("N0");
                txtJumlah.SelectionStart = txtJumlah.TextLength;
            }
        }

        private void txtDibayar_TextChanged(object sender, EventArgs e)
        {
            if (txtDibayar.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtDibayar.Text);
                txtDibayar.Text = money.ToString("N0");
                txtDibayar.SelectionStart = txtDibayar.TextLength;
            }
        }
    }
}
