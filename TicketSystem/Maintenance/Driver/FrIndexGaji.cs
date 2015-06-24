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

namespace TicketSystem.Maintenance.Driver
{
    public partial class FrIndexGaji : Form
    {
        #region Declaration
        private POTJDataContext context;
        Validasi val = new Validasi();
        #endregion

        private bool WithErrors()
        {
            if (txtIndex.Text.Trim() == String.Empty)
                return true;

            return false;
        }

        public FrIndexGaji(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            txtId.Text = Id.ToString();
        }

        private void FrIndexGaji_Load(object sender, EventArgs e)
        {
            var query = from a in context.REF_INDEX_GAJIs
                        where a.ID_INDEX_GAJI == Convert.ToInt32(txtId.Text)
                        select a;
            foreach (var a in query)
            {
                txtIndex.Text = a.INDEX_GAJI.ToString();
            }
        }

        private void FrIndexGaji_Activated(object sender, EventArgs e)
        {
            txtIndex.Focus();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (WithErrors())
            {
                val.validateTextBox(txtIndex, errorProvider1, "Index harus diisi.");

                return;
            }

            if (Convert.ToInt32(txtId.Text) == 0)
            {
                var index = new REF_INDEX_GAJI();
                index.INDEX_GAJI = Convert.ToDecimal(txtIndex.Text);
                context.REF_INDEX_GAJIs.InsertOnSubmit(index);
            }
            else
            {
                var query = from a in context.REF_INDEX_GAJIs
                            where a.ID_INDEX_GAJI == Convert.ToInt32(txtId.Text)
                            select a;
                foreach (var a in query)
                {
                    a.INDEX_GAJI = Convert.ToDecimal(txtIndex.Text);
                }
            }
            context.SubmitChanges();
            Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtIndex_Validating(object sender, CancelEventArgs e)
        {
            val.validateTextBox(sender, errorProvider1, "Index harus diisi.");
        }

        private void txtIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.numberFormat(sender, txtIndex.Text);
            val.numberOnly(sender,e);
            val.goNextControl(this, sender, e);
        }
    }
}
