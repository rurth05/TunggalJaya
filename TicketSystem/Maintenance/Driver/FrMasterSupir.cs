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

namespace TicketSystem.Maintenance.Driver
{
    public partial class FrMasterSupir : Form
    {
        #region Declaration
        private string conString = DbConnection.GetConnection();
        private string menu;
        private int SelectedId = 0;
        #endregion

        public FrMasterSupir()
        {
            InitializeComponent();
        }

        private void SwitchMenu(int tag)
        {
            mnSupir.Font = tag == 1 ? new Font(mnSupir.Font, FontStyle.Bold) : new Font(mnSupir.Font, FontStyle.Regular);
            mnIndex.Font = tag == 2 ? new Font(mnIndex.Font, FontStyle.Bold) : new Font(mnIndex.Font, FontStyle.Regular);
            pnlCari.Visible = false;
        }

        public void SwitchGrid(string flag)
        {
            string query = "";
            switch (flag)
            {
                case "Supir":
                    query = "SELECT REF_SUPIR.ID_SUPIR, REF_SUPIR.NAMA, REF_SUPIR.ALAMAT, REF_SUPIR.TELP, REF_SUPIR.NO_SIM, REF_INDEX_GAJI.INDEX_GAJI "+
                        "FROM REF_INDEX_GAJI INNER JOIN "+
                        "REF_SUPIR ON REF_INDEX_GAJI.ID_INDEX_GAJI = REF_SUPIR.ID_INDEX_GAJI ORDER BY ID_SUPIR";
                    break;
                case "Index":
                    query = "SELECT * FROM REF_INDEX_GAJI ORDER BY ID_INDEX_GAJI";
                    break;
            }

            var dtAdapter = new SqlDataAdapter(query, conString);

            var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
            dtAdapter.Fill(table);
            var form = (FrMasterSupir)Application.OpenForms["FrMasterSupir"];
            var dgv = (DataGridView)form.Controls["dgvMasterSupir"];
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
                case "Supir":
                    var frSupir = new FrSupir(Id);
                    frSupir.FormClosed += HandleFormClosed;
                    frSupir.ShowDialog();
                    break;
                case "Index":
                    var frIndexGaji = new FrIndexGaji(Id);
                    frIndexGaji.FormClosed += HandleFormClosed;
                    frIndexGaji.ShowDialog();
                    break;
            }
        }

        private void FrMasterSupir_Load(object sender, EventArgs e)
        {
            mnSupir_Click(sender, e);
        }

        private void mnSupir_Click(object sender, EventArgs e)
        {
            menu = mnSupir.Text;
            SwitchMenu(1);
            dgvMasterSupir.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterSupir.Columns[0].Visible = false;
            dgvMasterSupir.Columns[1].HeaderText = "Nama";
            dgvMasterSupir.Columns[2].HeaderText = "Alamat";
            dgvMasterSupir.Columns[3].HeaderText = "Telp";
            dgvMasterSupir.Columns[4].HeaderText = "No. SIM";
            dgvMasterSupir.Columns[5].HeaderText = "Index Gaji (%)";
            dgvMasterSupir.Columns[1].MinimumWidth = 150;
            dgvMasterSupir.Columns[2].MinimumWidth = 250;
            dgvMasterSupir.Columns[3].MinimumWidth = 100;
            dgvMasterSupir.Columns[4].MinimumWidth = 100;
            dgvMasterSupir.Columns[5].MinimumWidth = 100;
            dgvMasterSupir.Columns[5].DefaultCellStyle.Format = "N0";
            dgvMasterSupir.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void mnIndex_Click(object sender, EventArgs e)
        {
            menu = mnIndex.Text;
            SwitchMenu(2);
            dgvMasterSupir.Columns.Clear();
            SwitchGrid(menu);
            dgvMasterSupir.Columns[0].Visible = false;
            dgvMasterSupir.Columns[1].HeaderText = "Index (%)";
            dgvMasterSupir.Columns[1].MinimumWidth = 100;
            dgvMasterSupir.Columns[1].DefaultCellStyle.Format = "N0";
            dgvMasterSupir.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                            query = "DELETE FROM REF_SUPIR WHERE ID_SUPIR = @Id";
                            break;
                        case "Kendaraan":
                            query = "DELETE FROM REF_INDEX_GAJI WHERE ID_INDEX_GAJI = @Id";
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

        private void FrMasterSupir_Resize(object sender, EventArgs e)
        {
            btnTutupCari.Left = this.Width - 45;
        }

        private void dgvMasterSupir_SelectionChanged(object sender, EventArgs e)
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
                    case "Supir":
                        query ="SELECT REF_SUPIR.ID_SUPIR, REF_SUPIR.NAMA, REF_SUPIR.ALAMAT, REF_SUPIR.TELP, REF_SUPIR.NO_SIM, REF_INDEX_GAJI.INDEX_GAJI " +
                            "FROM REF_INDEX_GAJI INNER JOIN REF_SUPIR ON REF_INDEX_GAJI.ID_INDEX_GAJI = REF_SUPIR.ID_INDEX_GAJI " +
                            " WHERE REF_SUPIR.NAMA LIKE '%{0}%' OR REF_SUPIR.ALAMAT LIKE '%{0}%' OR REF_SUPIR.TELP LIKE '%{0}%' "+
                            "OR REF_SUPIR.NO_SIM LIKE '%{0}%' OR REF_INDEX_GAJI.INDEX_GAJI LIKE '%{0}%' ORDER BY ID_SUPIR";
                        break;
                    case "Index":
                        query = "SELECT * FROM REF_INDEX_GAJI WHERE INDEX_GAJI LIKE '%{0}%' ORDER BY ID_INDEX_GAJI";
                        break;
                }
                query = string.Format(query, txtCari.Text);
                var dtAdapter = new SqlDataAdapter(query, conString);

                var table = new DataTable { Locale = System.Globalization.CultureInfo.InvariantCulture };
                dtAdapter.Fill(table);
                var form = (FrMasterSupir)Application.OpenForms["FrMasterSupir"];
                var dgv = (DataGridView)form.Controls["dgvMasterSupir"];
                dgv.DataSource = table;

                bool act = table.Rows.Count != 0;
                btnUbah.Enabled = act;
                btnHapus.Enabled = act;
                btnCari.Enabled = act;
            }
        }
    }
}
