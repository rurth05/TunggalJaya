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
    public partial class FrPelunasanAdd : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtDibayar.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrPelunasanAdd(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrPelunasanAdd_Load(object sender, EventArgs e)
        {
            var query = from a in context.TRX_PENJUALANs
                        where a.ID_PENJUALAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtTotal.Text = Convert.ToDecimal(a.JUMLAH).ToString("N0");
                txtTelahDibayar.Text = Convert.ToDecimal(a.DP).ToString("N0");
                txtSisa.Text = Convert.ToDecimal(a.SISA).ToString("N0");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtDibayar, errorProvider1, "Dibayar harus diisi.");

                return;
            }

            var query = from a in context.TRX_PENJUALANs
                        where a.ID_PENJUALAN == Convert.ToInt32(txtId.Text)
                        select a;
            var histori = new TRX_HISTORI_TRANSAKSI();
            Random rdm = new Random();
            foreach (var a in query)
            {
                histori.NO_TRANSAKSI = rdm.Next(100000000,999999999).ToString();
                histori.TGL = DateTime.Now;
                histori.JML_TAGIH = a.SISA;
                histori.ID_PENJUALAN = a.ID_PENJUALAN;

                var dibayar = Convert.ToDecimal(txtDibayar.Text);
                if (dibayar >= a.SISA)
                {
                    histori.DIBAYAR = a.SISA;
                    histori.SISA = 0;
                    a.DP = a.DP + a.SISA;
                    a.SISA = 0;
                }
                else if (dibayar < a.SISA)
                {
                    histori.DIBAYAR = dibayar;
                    histori.SISA = a.SISA - dibayar;
                    a.SISA = a.SISA - dibayar;
                    a.DP = a.DP + dibayar;
                }
            }
            context.TRX_HISTORI_TRANSAKSIs.InsertOnSubmit(histori);
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtDibayar_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender,errorProvider1,"Dibayar harus diisi.");
        }

        private void txtDibayar_Leave(object sender, EventArgs e)
        {
            var dibayar = Convert.ToDouble(txtDibayar.Text);
            var sisa = Convert.ToDouble(txtSisa.Text);
            var kembali = dibayar - sisa;
            if (kembali > 0)
                txtKembali.Text = kembali.ToString("N0");
            else
                txtKembali.Text = "0";
        }

        private void txtDibayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }

        private void FrPelunasanAdd_Activated(object sender, EventArgs e)
        {
            txtDibayar.Focus();
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
