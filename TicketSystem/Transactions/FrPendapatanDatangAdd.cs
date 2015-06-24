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
    public partial class FrPendapatanDatangAdd : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtPendapatanDatang.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrPendapatanDatangAdd(int Id, int IdJadwal, string Kode)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
            txtIdJadwal.Text = IdJadwal.ToString();
            txtKode.Text = Kode;
        }

        private void FrPendapatanDatangAdd_Load(object sender, EventArgs e)
        {
            var query = from a in context.TRX_PENDAPATAN_DATANGs
                        where a.ID_PENDAPATAN == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtPendapatanDatang.Text = Convert.ToDecimal(a.PENDAPATAN).ToString("N0");
                txtIdJadwal.Text = a.ID_JADWAL.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtPendapatanDatang, errorProvider1, "Pendapatan datang harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                TRX_PENDAPATAN_DATANG trx = new TRX_PENDAPATAN_DATANG();
                trx.ID_JADWAL = Convert.ToInt32(txtIdJadwal.Text);
                trx.PENDAPATAN = Convert.ToDecimal(txtPendapatanDatang.Text);
                context.TRX_PENDAPATAN_DATANGs.InsertOnSubmit(trx);
            }
            else
            {
                var query = from a in context.TRX_PENDAPATAN_DATANGs
                            where a.ID_PENDAPATAN == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.ID_PENDAPATAN = Convert.ToInt32(txtId.Text);
                    a.ID_JADWAL = Convert.ToInt32(txtIdJadwal.Text);
                    a.PENDAPATAN = Convert.ToDecimal(txtPendapatanDatang.Text);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrPendapatanDatangAdd_Activated(object sender, EventArgs e)
        {
            txtPendapatanDatang.Focus();
        }

        private void txtPendapatanDatang_TextChanged(object sender, EventArgs e)
        {
            if (txtPendapatanDatang.Text.Trim().Length > 0)
            {
                double money = Convert.ToDouble(txtPendapatanDatang.Text);
                txtPendapatanDatang.Text = money.ToString("N0");
                txtPendapatanDatang.SelectionStart = txtPendapatanDatang.TextLength;
            }
        }

        private void txtPendapatanDatang_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1,"Pendapatan datang harus diisi.");
        }

        private void txtPendapatanDatang_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.currencyOnly(sender, e);
            val.goNextControl(this, sender, e);
        }
    }
}
