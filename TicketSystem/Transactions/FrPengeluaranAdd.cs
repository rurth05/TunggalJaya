using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TicketSystem.Common;
using TJ.DAL;

namespace TicketSystem.Transactions
{
    public partial class FrPengeluaranAdd : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        public FrPengeluaranAdd(int Id, int idJadwal)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
            txtIdJadwal.Text = idJadwal.ToString();
        }

        private bool WithErrors()
        {
            if (txtPengeluaran.Text.Trim() == String.Empty)
                return true;
            if (txtKeterangan.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        private void FrPengeluaranAdd_Load(object sender, EventArgs e)
        {
            var query = from a in context.TRX_PENGELUARANs
                        where a.ID_PENGELUARAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtPengeluaran.Text = Convert.ToDecimal(a.PENGELUARAN).ToString("N0");
                txtKeterangan.Text = a.KETERANGAN;
                txtIdJadwal.Text = a.ID_JADWAL.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtPengeluaran, errorProvider1, "Pengeluaran harus diisi.");
                val.validateTextBox(txtKeterangan, errorProvider1, "Keterangan harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                TRX_PENGELUARAN trx = new TRX_PENGELUARAN();
                trx.ID_JADWAL = Convert.ToInt32(txtIdJadwal.Text);
                trx.PENGELUARAN = Convert.ToDecimal(txtPengeluaran.Text);
                trx.KETERANGAN = txtKeterangan.Text;
                context.TRX_PENGELUARANs.InsertOnSubmit(trx);
            }
            else
            {
                var query = from a in context.TRX_PENGELUARANs
                            where a.ID_PENGELUARAN == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.ID_PENGELUARAN = Convert.ToInt32(txtId.Text);
                    a.ID_JADWAL = Convert.ToInt32(txtIdJadwal.Text);
                    a.PENGELUARAN = Convert.ToDecimal(txtPengeluaran.Text);
                    a.KETERANGAN = txtKeterangan.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPengeluaran_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Pengeluaran harus diisi.");
        }

        private void txtKeterangan_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Keterangan harus diisi.");
        }

        private void txtPengeluaran_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtKeterangan_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtPengeluaran_TextChanged(object sender, EventArgs e)
        {
            if (txtPengeluaran.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtPengeluaran.Text.Replace(".",""));
                txtPengeluaran.Text = money.ToString("N0");
                txtPengeluaran.SelectionStart = txtPengeluaran.TextLength;
            }
        }

        private void FrPengeluaranAdd_Activated(object sender, EventArgs e)
        {
            txtPengeluaran.Focus();
        }
    }
}
