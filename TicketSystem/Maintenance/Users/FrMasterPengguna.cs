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

namespace TicketSystem.Maintenance.Users
{
    public partial class FrMasterPengguna : Form
    {
        #region Declaration
        private string conString = DbConnection.GetConnection();
        private string menu;
        private int SelectedId = 0;
        #endregion

        public FrMasterPengguna()
        {
            InitializeComponent();
        }

        private void SwitchMenu(int tag)
        {
            mnPengguna.Font = tag == 1 ? new Font(mnPengguna.Font, FontStyle.Bold) : new Font(mnPengguna.Font, FontStyle.Regular);
            mnPeran.Font = tag == 2 ? new Font(mnPeran.Font, FontStyle.Bold) : new Font(mnPeran.Font, FontStyle.Regular);
            pnlCari.Visible = false;
        }

        public void SwitchGrid(string flag)
        {
            string query = "";
            switch (flag)
            {
                case "Pengguna":
                    query = "SELECT REF_PENGGUNA.ID_PENGGUNA, REF_PENGGUNA.NAMA_PENGGUNA, REF_PENGGUNA.SANDI, REF_PENGGUNA.NAMA_LENGKAP, REF_PENGGUNA.ALAMAT, "+
                      "REF_PENGGUNA.TELP, REF_PERAN.PERAN FROM REF_PERAN INNER JOIN "+
                      "REF_PENGGUNA ON REF_PERAN.ID_PERAN = REF_PENGGUNA.ID_PERAN ORDER BY ID_PENGGUNA";
                    break;
                case "Peran":
                    query = "SELECT * FROM REF_PERAN ORDER BY ID_PERAN";
                    break;
            }

            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrMasterPengguna)Application.OpenForms["FrMasterPengguna"];
            var dgv = (DataGridView)form.Controls["dgvMasterPengguna"];
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
                case "Pengguna":
                    var frPengguna = new FrPengguna(Id);
                    frPengguna.FormClosed += HandleFormClosed;
                    frPengguna.ShowDialog();
                    break;
                case "Peran":
                    var frPeran = new FrPeran(Id);
                    frPeran.FormClosed += HandleFormClosed;
                    frPeran.ShowDialog();
                    break;
            }
        }

        private void FrMasterPengguna_Load(object sender, EventArgs e)
        {
            mnPengguna_Click(sender, e);
        }

        private void mnPengguna_Click(object sender, EventArgs e)
        {
            menu = mnPengguna.Text;
            SwitchMenu(1);
            dgvMasterPengguna.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterPengguna.Columns[0].Visible = false;
            dgvMasterPengguna.Columns[1].HeaderText = "Nama Pengguna";
            dgvMasterPengguna.Columns[2].HeaderText = "Sandi";
            dgvMasterPengguna.Columns[3].HeaderText = "Nama Lengkap";
            dgvMasterPengguna.Columns[4].HeaderText = "Alamat";
            dgvMasterPengguna.Columns[5].HeaderText = "Telp";
            dgvMasterPengguna.Columns[6].HeaderText = "Peran";
            dgvMasterPengguna.Columns[1].MinimumWidth = 120;
            dgvMasterPengguna.Columns[2].MinimumWidth = 120;
            dgvMasterPengguna.Columns[3].MinimumWidth = 150;
            dgvMasterPengguna.Columns[4].MinimumWidth = 250;
            dgvMasterPengguna.Columns[5].MinimumWidth = 100;
            dgvMasterPengguna.Columns[6].MinimumWidth = 130;
        }

        private void mnPeran_Click(object sender, EventArgs e)
        {
            menu = mnPeran.Text;
            SwitchMenu(2);
            dgvMasterPengguna.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterPengguna.Columns[0].Visible = false;
            dgvMasterPengguna.Columns[1].HeaderText = "Kode";
            dgvMasterPengguna.Columns[2].HeaderText = "Peran";
            dgvMasterPengguna.Columns[1].MinimumWidth = 120;
            dgvMasterPengguna.Columns[2].MinimumWidth = 130;
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
                        case "Pengguna":
                            query = "DELETE FROM REF_PENGGUNA WHERE ID_PENGGUNA = @Id";
                            break;
                        case "Peran":
                            query = "DELETE FROM REF_PERAN WHERE ID_PERAN = @Id";
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

        private void FrMasterPengguna_Resize(object sender, EventArgs e)
        {
            btnTutupCari.Left = this.Width - 45;
        }

        private void dgvMasterPengguna_SelectionChanged(object sender, EventArgs e)
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
                    case "Pengguna":
                        query = "SELECT REF_PENGGUNA.ID_PENGGUNA, REF_PENGGUNA.NAMA_PENGGUNA, REF_PENGGUNA.SANDI, REF_PENGGUNA.NAMA_LENGKAP, REF_PENGGUNA.ALAMAT, " +
                      "REF_PENGGUNA.TELP, REF_PERAN.PERAN FROM REF_PERAN INNER JOIN " +
                      "REF_PENGGUNA ON REF_PERAN.ID_PERAN = REF_PENGGUNA.ID_PERAN " +
                      "WHERE REF_PENGGUNA.ID_PENGGUNA LIKE '%{0}%' OR REF_PENGGUNA.NAMA_PENGGUNA LIKE '%{0}%' OR REF_PENGGUNA.SANDI LIKE '%{0}%' OR REF_PENGGUNA.NAMA_LENGKAP LIKE '%{0}%' OR REF_PENGGUNA.ALAMAT LIKE '%{0}%' OR " +
                      "REF_PENGGUNA.TELP LIKE '%{0}%' OR REF_PERAN.PERAN LIKE '%{0}%' ORDER BY ID_PENGGUNA";
                        break;
                    case "Peran":
                        query = "SELECT * FROM REF_PERAN WHERE KODE_PERAN LIKE '%{0}%' OR PERAN LIKE '%{0}%' ORDER BY ID_PERAN";
                        break;
                }
                query = string.Format(query, txtCari.Text);
                var dtAdapter = new SqlDataAdapter(query, conString);

                var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
                dtAdapter.Fill(table);
                var form = (FrMasterPengguna)Application.OpenForms["FrMasterPengguna"];
                var dgv = (DataGridView)form.Controls["dgvMasterPengguna"];
                dgv.DataSource = table;

                bool act = table.Rows.Count != 0;
                btnUbah.Enabled = act;
                btnHapus.Enabled = act;
                btnCari.Enabled = act;
            }
        }
    }
}
