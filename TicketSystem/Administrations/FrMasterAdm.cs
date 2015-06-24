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
using TicketSystem.Maintenance.Users;

namespace TicketSystem.Administrations
{
    public partial class FrMasterAdm : Form
    {
        #region Declaration
        private string conString = DbConnection.GetConnection();
        private string menu;
        private int SelectedId = 0;
        #endregion

        public FrMasterAdm()
        {
            InitializeComponent();
        }

        private void SwitchMenu(int tag)
        {
            mnJadwal.Font = tag == 1 ? new Font(mnJadwal.Font, FontStyle.Bold) : new Font(mnJadwal.Font, FontStyle.Regular);
            mnTarif.Font = tag == 2 ? new Font(mnTarif.Font, FontStyle.Bold) : new Font(mnTarif.Font, FontStyle.Regular);
            mnKonsumen.Font = tag == 3 ? new Font(mnKonsumen.Font, FontStyle.Bold) : new Font(mnKonsumen.Font, FontStyle.Regular);
            mnJenisIdentitas.Font = tag == 4 ? new Font(mnJenisIdentitas.Font, FontStyle.Bold) : new Font(mnJenisIdentitas.Font, FontStyle.Regular);
            pnlCari.Visible = false;
        }

        public void SwitchGrid(string flag)
        {
            string query = "";
            switch (flag)
            {
                case "Jadwal":
                    query = "SELECT ADM_JADWAL.ID_JADWAL, ADM_JADWAL.TGL_BERANGKAT, ADM_JADWAL.JAM, REF_KOTA.NAMA_KOTA AS ASAL, REF_KOTA_1.NAMA_KOTA AS TUJUAN, "+
                      "REF_KENDARAAN.NO_ARMADA, REF_SUPIR.NAMA AS NAMA_SUPIR, ADM_JADWAL.CARTER, REF_STATUS.STATUS "+
                      "FROM ADM_JADWAL INNER JOIN "+
                      "REF_KOTA ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA.ID_KOTA INNER JOIN "+
                      "REF_KOTA AS REF_KOTA_1 ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA_1.ID_KOTA INNER JOIN "+
                      "REF_SUPIR ON ADM_JADWAL.ID_SUPIR = REF_SUPIR.ID_SUPIR INNER JOIN "+
                      "REF_KENDARAAN ON ADM_JADWAL.ID_KENDARAAN = REF_KENDARAAN.ID_KENDARAAN INNER JOIN "+
                      "REF_TIPE_KENDARAAN ON REF_KENDARAAN.ID_TIPE_KENDARAAN = REF_TIPE_KENDARAAN.ID_TIPE_KENDARAAN LEFT OUTER JOIN "+
                      "REF_STATUS ON ADM_JADWAL.ID_STATUS = REF_STATUS.ID_STATUS "+
                      "ORDER BY ADM_JADWAL.ID_JADWAL";
                    break;
                case "Tarif":
                    query = "SELECT * FROM ADM_TARIF ORDER BY ID_TARIF";
                    break;
                case "Konsumen":
                    query = "SELECT ADM_KONSUMEN.ID_KONSUMEN, ADM_JENIS_IDENTITAS.JENIS_IDENTITAS, ADM_KONSUMEN.NO_IDENTITAS, ADM_KONSUMEN.NAMA, "+
                      "ADM_KONSUMEN.ALAMAT, ADM_KONSUMEN.TELP "+
                      "FROM ADM_KONSUMEN INNER JOIN "+
                      "ADM_JENIS_IDENTITAS ON ADM_KONSUMEN.ID_JENIS_IDENTITAS = ADM_JENIS_IDENTITAS.ID_JENIS_IDENTITAS ORDER BY ADM_KONSUMEN.ID_KONSUMEN";
                    break;
                case "Jenis Identitas":
                    query = "SELECT * FROM ADM_JENIS_IDENTITAS ORDER BY ID_JENIS_IDENTITAS";
                    break;
            }

            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrMasterAdm)Application.OpenForms["FrMasterAdm"];
            var dgv = (DataGridView)form.Controls["dgvMasterAdm"];
            dgv.DataSource = table;

            bool act = table.Rows.Count != 0;
            btnUbah.Enabled = act;
            btnHapus.Enabled = act;
            btnCari.Enabled = act;
        }

        private void HandleFormClosed(Object sender, FormClosedEventArgs e)
        {
            SwitchGrid(menu);
        }

        private void OpenDialog(int Id)
        {
            switch (menu)
            {
                case "Jadwal":
                    var frJadwal = new FrJadwal(Id);
                    frJadwal.FormClosed += HandleFormClosed;
                    frJadwal.ShowDialog();
                    break;
                case "Tarif":
                    var frTarif = new FrTarif(Id);
                    frTarif.FormClosed += HandleFormClosed;
                    frTarif.ShowDialog();
                    break;
                case "Konsumen":
                    var frKonsumen = new FrKonsumen(Id);
                    frKonsumen.FormClosed += HandleFormClosed;
                    frKonsumen.ShowDialog();
                    break;
                case "Jenis Identitas":
                    var frJenisIdentitas = new FrJenisIdentitas(Id);
                    frJenisIdentitas.FormClosed += HandleFormClosed;
                    frJenisIdentitas.ShowDialog();
                    break;
            }
        }

        private void mnJadwal_Click(object sender, EventArgs e)
        {
            menu = mnJadwal.Text;
            SwitchMenu(1);
            dgvMasterAdm.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterAdm.Columns[0].Visible = false;
            dgvMasterAdm.Columns[1].HeaderText = "Tgl Berangkat";
            dgvMasterAdm.Columns[2].HeaderText = "Jam";
            dgvMasterAdm.Columns[3].HeaderText = "Asal";
            dgvMasterAdm.Columns[4].HeaderText = "Tujuan";
            dgvMasterAdm.Columns[5].HeaderText = "No Armada";
            dgvMasterAdm.Columns[6].HeaderText = "Supir";
            dgvMasterAdm.Columns[7].HeaderText = "Carter";
            dgvMasterAdm.Columns[8].HeaderText = "Status";
            dgvMasterAdm.Columns[1].MinimumWidth = 100;
            dgvMasterAdm.Columns[2].MinimumWidth = 100;
            dgvMasterAdm.Columns[3].MinimumWidth = 120;
            dgvMasterAdm.Columns[4].MinimumWidth = 120;
            dgvMasterAdm.Columns[5].MinimumWidth = 100;
            dgvMasterAdm.Columns[6].MinimumWidth = 150;
            dgvMasterAdm.Columns[7].MinimumWidth = 100;
            dgvMasterAdm.Columns[8].MinimumWidth = 100;
            dgvMasterAdm.Columns[2].DefaultCellStyle.Format = @"hh\:mm";
        }

        private void mnTarif_Click(object sender, EventArgs e)
        {
            menu = mnTarif.Text;
            SwitchMenu(2);
            dgvMasterAdm.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterAdm.Columns[0].Visible = false;
            dgvMasterAdm.Columns[1].HeaderText = "Golongan";
            dgvMasterAdm.Columns[2].HeaderText = "Tarif";
            dgvMasterAdm.Columns[1].MinimumWidth = 100;
            dgvMasterAdm.Columns[2].MinimumWidth = 100;
            dgvMasterAdm.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMasterAdm.Columns[2].DefaultCellStyle.Format = "N0";
        }

        private void btnBaru_Click(object sender, EventArgs e)
        {
            OpenDialog(0);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            OpenDialog(SelectedId);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin akan menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string query = "";
                    var con = new SqlConnection(DbConnection.GetConnection());
                    switch (menu)
                    {
                        case "Jadwal":
                            query = "DELETE FROM ADM_JADWAL WHERE ID_JADWAL = @Id";
                            break;
                        case "Tarif":
                            query = "DELETE FROM ADM_TARIF WHERE ID_TARIF = @Id";
                            break;
                        case "Konsumen":
                            query = "DELETE FROM ADM_KONSUMEN WHERE ID_KONSUMEN = @Id";
                            break;
                        case "Jenis Identitas":
                            query = "DELETE FROM ADM_JENIS_IDENTITAS WHERE ID_JENIS_IDENTITAS = @Id";
                            break;
                    }

                    var com = new SqlCommand(query, con);

                    com.Parameters.Add("@Id", SqlDbType.Int).Value = SelectedId;

                    con.Open();
                    com.ExecuteNonQuery();
                    con.Close();
                    SwitchGrid(menu);
                }
                catch { MessageBox.Show("Gagal menghapus, data sedang digunakan.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            pnlCari.Visible = true;
            txtCari.Text = string.Empty;
            txtCari.Focus();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrMasterAdm_Resize(object sender, EventArgs e)
        {
            btnTutupCari.Left = this.Width - 45;
        }

        private void dgvMasterAdm_SelectionChanged(object sender, EventArgs e)
        {
            var gv = sender as DataGridView;
            if (gv != null && gv.RowCount > 0)
                if (gv.CurrentRow != null) SelectedId = Convert.ToInt32(gv.CurrentRow.Cells[0].Value);
        }

        private void btnTutupCari_Click(object sender, EventArgs e)
        {
            pnlCari.Visible = false;
            SwitchGrid(menu);
        }

        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string query = "";
                switch (menu)
                {
                    case "Jadwal":
                        query =
                            "SELECT ADM_JADWAL.ID_JADWAL, ADM_JADWAL.TGL_BERANGKAT, ADM_JADWAL.JAM, REF_KOTA.NAMA_KOTA AS ASAL, REF_KOTA_1.NAMA_KOTA AS TUJUAN, "+
                            "REF_KENDARAAN.NO_ARMADA, REF_SUPIR.NAMA AS NAMA_SUPIR, ADM_JADWAL.CARTER, REF_STATUS.STATUS "+
                            "FROM ADM_JADWAL INNER JOIN "+
                            "REF_KOTA ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA.ID_KOTA INNER JOIN "+
                            "REF_KOTA AS REF_KOTA_1 ON ADM_JADWAL.KOTA_TUJUAN = REF_KOTA_1.ID_KOTA INNER JOIN "+
                            "REF_SUPIR ON ADM_JADWAL.ID_SUPIR = REF_SUPIR.ID_SUPIR INNER JOIN "+
                            "REF_KENDARAAN ON ADM_JADWAL.ID_KENDARAAN = REF_KENDARAAN.ID_KENDARAAN INNER JOIN "+
                            "REF_TIPE_KENDARAAN ON REF_KENDARAAN.ID_TIPE_KENDARAAN = REF_TIPE_KENDARAAN.ID_TIPE_KENDARAAN LEFT OUTER JOIN "+
                            "REF_STATUS ON ADM_JADWAL.ID_STATUS = REF_STATUS.ID_STATUS "+
                            "WHERE "+
                            "ADM_JADWAL.TGL_BERANGKAT LIKE '%{0}%' OR ADM_JADWAL.JAM LIKE '%{0}%' OR REF_KOTA.NAMA_KOTA LIKE '%{0}%' OR REF_KOTA_1.NAMA_KOTA LIKE '%{0}%' OR " +
                            "REF_KENDARAAN.NO_ARMADA LIKE '%{0}%' OR REF_SUPIR.NAMA LIKE '%{0}%' OR ADM_JADWAL.CARTER LIKE '%{0}%' OR REF_STATUS.STATUS LIKE '%{0}%' "+
                            "ORDER BY ADM_JADWAL.ID_JADWAL";
                        break;
                    case "Tarif":
                        query = "SELECT * FROM ADM_TARIF WHERE GOLONGAN LIKE '%{0}%' OR TARIF LIKE '%{0}%' ORDER BY ID_TARIF";
                        break;
                    case "Konsumen":
                        query = "SELECT ADM_KONSUMEN.ID_KONSUMEN, ADM_JENIS_IDENTITAS.JENIS_IDENTITAS, ADM_KONSUMEN.NO_IDENTITAS, ADM_KONSUMEN.NAMA, " +
                          "ADM_KONSUMEN.ALAMAT, ADM_KONSUMEN.TELP " +
                          "FROM ADM_KONSUMEN INNER JOIN " +
                          "ADM_JENIS_IDENTITAS ON ADM_KONSUMEN.ID_JENIS_IDENTITAS = ADM_JENIS_IDENTITAS.ID_JENIS_IDENTITAS "+
                          "WHERE ADM_JENIS_IDENTITAS.JENIS_IDENTITAS LIKE '%{0}%' OR ADM_KONSUMEN.NO_IDENTITAS LIKE '%{0}%' OR ADM_KONSUMEN.NAMA LIKE '%{0}%' OR " +
                          "ADM_KONSUMEN.ALAMAT LIKE '%{0}%' OR ADM_KONSUMEN.TELP LIKE '%{0}%' ORDER BY  ADM_KONSUMEN.ID_KONSUMEN";
                        break;
                    case "Jenis Identitas":
                        query = "SELECT * FROM ADM_JENIS_IDENTITAS WHERE KODE LIKE '%{0}%' OR JENIS_IDENTITAS LIKE '%{0}%' ORDER BY ID_JENIS_IDENTITAS";
                        break;
                }
                query = string.Format(query, txtCari.Text);
                var dtAdapter = new SqlDataAdapter(query, conString);

                var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
                dtAdapter.Fill(table);
                var form = (FrMasterAdm)Application.OpenForms["FrMasterAdm"];
                var dgv = (DataGridView)form.Controls["dgvMasterAdm"];
                dgv.DataSource = table;

                bool act = table.Rows.Count != 0;
                btnUbah.Enabled = act;
                btnHapus.Enabled = act;
                btnCari.Enabled = act;
            }
        }

        private void FrMasterAdm_Load(object sender, EventArgs e)
        {
            switch (UserInfo.Role)
            {
                case "ADM":
                    mnJadwal.Visible = true;
                    mnTarif.Visible = true;
                    mnKonsumen.Visible = true;
                    mnJenisIdentitas.Visible = true;
                    break;
                case "SPV":
                    mnJadwal.Visible = true;
                    mnTarif.Visible = false;
                    mnKonsumen.Visible = true;
                    mnJenisIdentitas.Visible = false;
                    break;
                case "OPR":
                    mnJadwal.Visible = true;
                    mnTarif.Visible = false;
                    mnKonsumen.Visible = true;
                    mnJenisIdentitas.Visible = false;
                    btnUbah.Visible = false;
                    btnHapus.Visible = false;
                    break;
            }
            mnJadwal_Click(sender, e);
        }

        private void mnJenisIdentitas_Click(object sender, EventArgs e)
        {
            menu = mnJenisIdentitas.Text;
            SwitchMenu(4);
            dgvMasterAdm.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterAdm.Columns[0].Visible = false;
            dgvMasterAdm.Columns[1].HeaderText = "Kode";
            dgvMasterAdm.Columns[2].HeaderText = "Jenis Identitas";
            dgvMasterAdm.Columns[1].MinimumWidth = 100;
            dgvMasterAdm.Columns[2].MinimumWidth = 150;
        }

        private void mnKonsumen_Click(object sender, EventArgs e)
        {
            menu = mnKonsumen.Text;
            SwitchMenu(3);
            dgvMasterAdm.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterAdm.Columns[0].Visible = false;
            dgvMasterAdm.Columns[1].HeaderText = "Jenis Identitas";
            dgvMasterAdm.Columns[2].HeaderText = "No Identitas";
            dgvMasterAdm.Columns[3].HeaderText = "Nama";
            dgvMasterAdm.Columns[4].HeaderText = "Alamat";
            dgvMasterAdm.Columns[5].HeaderText = "Telp";
            dgvMasterAdm.Columns[1].MinimumWidth = 150;
            dgvMasterAdm.Columns[2].MinimumWidth = 120;
            dgvMasterAdm.Columns[3].MinimumWidth = 200;
            dgvMasterAdm.Columns[4].MinimumWidth = 350;
            dgvMasterAdm.Columns[5].MinimumWidth = 100;
        }
    }
}
