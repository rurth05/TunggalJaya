using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using TicketSystem.Common;

namespace TicketSystem.Maintenance.Vehicles
{
    public partial class FrMasterKendaraan : Form
    {
        #region Declaration
        private string conString = DbConnection.GetConnection();
        private string menu;
        private int SelectedId = 0;
        #endregion

        public FrMasterKendaraan()
        {
            InitializeComponent();
        }

        private void SwitchMenu(int tag)
        {
            mnTipeKendaraan.Font = tag == 1 ? new Font(mnTipeKendaraan.Font, FontStyle.Bold) : new Font(mnTipeKendaraan.Font, FontStyle.Regular);
            mnKendaraan.Font = tag == 2 ? new Font(mnKendaraan.Font, FontStyle.Bold) : new Font(mnKendaraan.Font, FontStyle.Regular);
            mnKota.Font = tag == 3 ? new Font(mnKota.Font, FontStyle.Bold) : new Font(mnKota.Font, FontStyle.Regular);
            mnStatus.Font = tag == 4 ? new Font(mnStatus.Font, FontStyle.Bold) : new Font(mnStatus.Font, FontStyle.Regular);
            pnlCari.Visible = false;
        }

        public void SwitchGrid(string flag)
        {
            string query = "";
            switch (flag)
            {
                case "Tipe Kendaraan":
                    query = "SELECT * FROM REF_TIPE_KENDARAAN ORDER BY ID_TIPE_KENDARAAN";
                    break;
                case "Kendaraan":
                    query = "SELECT REF_KENDARAAN.ID_KENDARAAN, REF_KENDARAAN.NO_ARMADA, REF_KENDARAAN.NO_POLISI, REF_KENDARAAN.JML_KURSI, "+
                      "REF_TIPE_KENDARAAN.TIPE_KENDARAAN FROM REF_KENDARAAN INNER JOIN "+
                      "REF_TIPE_KENDARAAN ON REF_KENDARAAN.ID_TIPE_KENDARAAN = REF_TIPE_KENDARAAN.ID_TIPE_KENDARAAN";
                    break;
                case "Kota":
                    query = "SELECT * FROM REF_KOTA ORDER BY ID_KOTA";
                    break;
                case "Status":
                    query = "SELECT * FROM REF_STATUS ORDER BY ID_STATUS";
                    break;
            }

            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable {Locale = System.Globalization.CultureInfo.InvariantCulture};
            dtAdapter.Fill(table);
            var form = (FrMasterKendaraan)Application.OpenForms["FrMasterKendaraan"];
            var dgv = (DataGridView)form.Controls["dgvMaintenance"];
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
                case "Tipe Kendaraan":
                    var frTipeKendaraan = new FrTipeKendaraan(Id);
                    frTipeKendaraan.FormClosed += HandleFormClosed;
                    frTipeKendaraan.ShowDialog();
                    break;
                case "Kendaraan":
                    var frKendaraan = new FrKendaraan(Id);
                    frKendaraan.FormClosed += HandleFormClosed;
                    frKendaraan.ShowDialog();
                    break;
                case "Kota":
                    var frKota = new FrKota(Id);
                    frKota.FormClosed += HandleFormClosed;
                    frKota.ShowDialog();
                    break;
                case "Status":
                    var frStatus = new FrStatusKendaraan(Id);
                    frStatus.FormClosed += HandleFormClosed;
                    frStatus.ShowDialog();
                    break;
            }
        }

        private void FrMasterKendaraan_Load(object sender, EventArgs e)
        {
            mnTipeKendaraan_Click(sender, e);
        }

        private void mnTipeKendaraan_Click(object sender, EventArgs e)
        {
            menu = mnTipeKendaraan.Text;
            SwitchMenu(1);
            dgvMaintenance.Columns.Clear();
            SwitchGrid(menu);
            dgvMaintenance.Columns[0].Visible = false;
            dgvMaintenance.Columns[1].HeaderText = "Kode";
            dgvMaintenance.Columns[2].HeaderText = "Tipe Kendaraan";
            dgvMaintenance.Columns[3].HeaderText = "Kas";
            dgvMaintenance.Columns[4].HeaderText = "Setor Wajib";
            dgvMaintenance.Columns[1].MinimumWidth = 100;
            dgvMaintenance.Columns[2].MinimumWidth = 120;
            dgvMaintenance.Columns[3].MinimumWidth = 100;
            dgvMaintenance.Columns[4].MinimumWidth = 100;
            dgvMaintenance.Columns[3].DefaultCellStyle.Format = "N0";
            dgvMaintenance.Columns[4].DefaultCellStyle.Format = "N0";
            dgvMaintenance.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMaintenance.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void mnKendaraan_Click(object sender, EventArgs e)
        {
            menu = mnKendaraan.Text;
            SwitchMenu(2);
            dgvMaintenance.Columns.Clear();
            SwitchGrid(menu);
            dgvMaintenance.Columns[0].Visible = false;
            dgvMaintenance.Columns[1].HeaderText = "No Armada ";
            dgvMaintenance.Columns[2].HeaderText = "No Polisi";
            dgvMaintenance.Columns[3].HeaderText = "Jml Kursi";
            dgvMaintenance.Columns[4].HeaderText = "Tipe Kendaraan";
            dgvMaintenance.Columns[1].MinimumWidth = 100;
            dgvMaintenance.Columns[2].MinimumWidth = 100;
            dgvMaintenance.Columns[3].MinimumWidth = 100;
            dgvMaintenance.Columns[4].MinimumWidth = 120;
            dgvMaintenance.Columns[3].DefaultCellStyle.Format = "N0";
            dgvMaintenance.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void mnKota_Click(object sender, EventArgs e)
        {
            menu = mnKota.Text;
            SwitchMenu(3);
            dgvMaintenance.Columns.Clear();
            SwitchGrid(menu);
            dgvMaintenance.Columns[0].Visible = false;
            dgvMaintenance.Columns[1].HeaderText = "Kode";
            dgvMaintenance.Columns[2].HeaderText = "Nama Kota";
            dgvMaintenance.Columns[1].MinimumWidth = 100;
            dgvMaintenance.Columns[2].MinimumWidth = 150;
        }

        private void mnStatus_Click(object sender, EventArgs e)
        {
            menu = mnStatus.Text;
            SwitchMenu(4);
            dgvMaintenance.Columns.Clear();
            SwitchGrid(menu);
            dgvMaintenance.Columns[0].Visible = false;
            dgvMaintenance.Columns[1].HeaderText = "Kode";
            dgvMaintenance.Columns[2].HeaderText = "Status";
            dgvMaintenance.Columns[1].MinimumWidth = 100;
            dgvMaintenance.Columns[2].MinimumWidth = 150;
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
                        case "Tipe Kendaraan":
                            query = "DELETE FROM REF_TIPE_KENDARAAN WHERE ID_TIPE_KENDARAAN = @Id";
                            break;
                        case "Kendaraan":
                            query = "DELETE FROM REF_KENDARAAN WHERE ID_KENDARAAN = @Id";
                            break;
                        case "Kota":
                            query = "DELETE FROM REF_KOTA WHERE ID_KOTA = @Id";
                            break;
                        case "Status":
                            query = "DELETE FROM REF_STATUS WHERE ID_STATUS = @Id";
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

        private void FrMasterKendaraan_Resize(object sender, EventArgs e)
        {
            btnTutupCari.Left = this.Width - 45;
        }

        private void dgvMaintenance_SelectionChanged(object sender, EventArgs e)
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
                    case "Tipe Kendaraan":
                        query ="SELECT * FROM REF_TIPE_KENDARAAN WHERE KODE_TIPE LIKE '%{0}%' OR TIPE_KENDARAAN LIKE '%{0}%' OR " +
                            "KAS LIKE '%{0}%' OR SETOR_WAJIB LIKE '%{0}%'";
                        break;
                    case "Kendaraan":
                        query = "SELECT REF_KENDARAAN.ID_KENDARAAN, REF_KENDARAAN.NO_ARMADA, REF_KENDARAAN.NO_POLISI, REF_KENDARAAN.JML_KURSI, " +
                            "REF_TIPE_KENDARAAN.TIPE_KENDARAAN FROM REF_KENDARAAN INNER JOIN REF_TIPE_KENDARAAN ON REF_KENDARAAN.ID_TIPE_KENDARAAN = REF_TIPE_KENDARAAN.ID_TIPE_KENDARAAN " +
                            "WHERE (REF_KENDARAAN.NO_ARMADA LIKE '%{0}%') OR (REF_KENDARAAN.NO_POLISI LIKE '%{0}%') OR (REF_KENDARAAN.JML_KURSI LIKE '%{0}%') OR " +
                            "(REF_TIPE_KENDARAAN.TIPE_KENDARAAN LIKE '%{0}%')";
                        break;
                    case "Kota":
                        query = "SELECT * FROM REF_KOTA WHERE KODE_KOTA LIKE '%{0}%' OR NAMA_KOTA LIKE '%{0}%'";
                        break;
                    case "Status":
                        query = "SELECT * FROM REF_STATUS WHERE KODE_STATUS LIKE '%{0}%' OR STATUS LIKE '%{0}%'";
                        break;
                }
                query = string.Format(query, txtCari.Text);
                var dtAdapter = new SqlDataAdapter(query, conString);

                var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
                dtAdapter.Fill(table);
                var form = (FrMasterKendaraan)Application.OpenForms["FrMasterKendaraan"];
                var dgv = (DataGridView)form.Controls["dgvMaintenance"];
                dgv.DataSource = table;

                bool act = table.Rows.Count != 0;
                btnUbah.Enabled = act;
                btnHapus.Enabled = act;
                btnCari.Enabled = act;
            }
        }
    }
}
