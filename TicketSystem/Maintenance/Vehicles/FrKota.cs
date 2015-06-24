using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TJ.DAL;
using TicketSystem.Common;

namespace TicketSystem.Maintenance.Vehicles
{
    public partial class FrKota : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtKode.Text.Trim() == String.Empty)
                return true;
            if (txtNamaKota.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrKota(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrKota_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_KOTAs
                        where a.ID_KOTA == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtKode.Text = a.KODE_KOTA;
                txtNamaKota.Text = a.NAMA_KOTA;
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtKode, errorProvider1, "Kode harus diisi.");
                val.validateTextBox(txtNamaKota, errorProvider1, "Nama kota harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var kota = new REF_KOTA();
                kota.KODE_KOTA = txtKode.Text;
                kota.NAMA_KOTA = txtNamaKota.Text;
                context.REF_KOTAs.InsertOnSubmit(kota);
            }
            else
            {
                var query = from a in context.REF_KOTAs
                            where a.ID_KOTA == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.KODE_KOTA = txtKode.Text;
                    a.NAMA_KOTA = txtNamaKota.Text;
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrKota_Activated(object sender, EventArgs e)
        {
            txtKode.Focus();
        }

        private void txtKode_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Kode harus diisi.");
        }

        private void txtNamaKota_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Nama kota harus diisi.");
        }

        private void txtKode_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }

        private void txtNamaKota_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.goNextControl(this, sender, e);
        }
    }
}
