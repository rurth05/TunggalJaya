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

namespace TicketSystem.Transactions
{
    public partial class FrPembatalanAdd : Form
    {

        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        public FrPembatalanAdd(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrPembatalanAdd_Load(object sender, EventArgs e)
        {
            var query = from a in context.TRX_PENJUALANs
                        where a.ID_PENJUALAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtTotal.Text = Convert.ToDecimal(a.JUMLAH).ToString("N0");
                txtTotalBayar.Text = Convert.ToDecimal(a.DP).ToString("N0");
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrPembatalanAdd_Activated(object sender, EventArgs e)
        {
            txtPersenKembali.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Batalkan reservasi ini ?", "Konfirmasi", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var query = from a in context.TRX_PENJUALANs
                                where a.ID_PENJUALAN == Convert.ToInt32(txtId.Text)
                                select a;
                    foreach (var a in query)
                    {
                        a.STATUS = "BATAL";
                    }
                    Random rdm = new Random();
                    var fee = Convert.ToDecimal(txtTotal.Text) - Convert.ToDecimal(txtRpKembali.Text);
                    var histori = new TRX_HISTORI_TRANSAKSI();
                    histori.NO_TRANSAKSI = rdm.Next(100000000, 999999999).ToString();
                    histori.TGL = DateTime.Now;
                    histori.JML_TAGIH = fee;
                    histori.DIBAYAR = fee;
                    histori.SISA = 0;
                    histori.ID_PENJUALAN = Convert.ToInt32(txtId.Text);
                    histori.INFO = "FEE BATAL";
                    context.TRX_HISTORI_TRANSAKSIs.InsertOnSubmit(histori);
                    context.SubmitChanges();
                    Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Pembatalan reservasi gagal.", "Peringatan", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void txtPersenKembali_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Persentase pengembalian harus terisi.");
        }

        private void txtRpKembali_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Rp pengembalian harus terisi.");
        }

        private void txtPersenKembali_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtRpKembali_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void txtPersenKembali_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersenKembali.Text))
            {
                var persen = Convert.ToDouble(txtPersenKembali.Text);
                var bayar = Convert.ToDouble(txtTotal.Text);
                var hasil = (bayar*persen)/100;
                txtRpKembali.Text = hasil.ToString("N0");
            }
        }

        private void txtRpKembali_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRpKembali.Text))
            {
                var rp = Convert.ToDouble(txtRpKembali.Text);
                var bayar = Convert.ToDouble(txtTotal.Text);
                var hasil = (rp / bayar) * 100;
                txtPersenKembali.Text = hasil.ToString("N0");
            }
        }

        private void txtRpKembali_TextChanged(object sender, EventArgs e)
        {
            if (txtRpKembali.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtRpKembali.Text);
                txtRpKembali.Text = money.ToString("N0");
                txtRpKembali.SelectionStart = txtRpKembali.TextLength;
            }
        }
    }
}
