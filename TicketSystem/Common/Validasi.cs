using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace TicketSystem.Common
{
    class Validasi
    {
        public void currencyOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        public void numberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }           
        }

        public void validateTextBox(object obj, object errorProv, string valText)
        {
            TextBox txt = obj as TextBox;
            ErrorProvider err = errorProv as ErrorProvider;
            if (!string.IsNullOrEmpty(txt.Text.Trim()))
                err.SetError(txt, "");
            else
                err.SetError(txt, valText);
        }

        public void validateMaskedTextBox(object obj, object errorProv, string valText)
        {
            MaskedTextBox txt = obj as MaskedTextBox;
            ErrorProvider err = errorProv as ErrorProvider;
            if (!string.IsNullOrEmpty(txt.Text.Replace("-","").Trim()))
                err.SetError(txt, "");
            else
                err.SetError(txt, valText);
        }

        public void validateLabel(object obj, object errorProv, string valText)
        {
            Label lbl = obj as Label;
            ErrorProvider err = errorProv as ErrorProvider;
            if (!string.IsNullOrEmpty(lbl.Text.Trim()))
                err.SetError(lbl, "");
            else
                err.SetError(lbl, valText);
        }

        public void validateComboBox(object obj, object errorProv, string valText)
        {
            ComboBox cmb = obj as ComboBox;
            ErrorProvider err = errorProv as ErrorProvider;
            if (cmb.Text != "--Pilih--")
                err.SetError(cmb, "");
            else
                err.SetError(cmb, valText);
        }

        public void validateGridView(object obj, object errorProv, string valText)
        {
            DataGridView dg = obj as DataGridView;
            ErrorProvider err = errorProv as ErrorProvider;
            if (dg.Rows.Count != 0)
                err.SetError(dg, "");
            else
                err.SetError(dg, valText);
        }

        public void goNextControl(Form form, object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                form.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
            }
        }

        public void validateReset(ErrorProvider err)
        {
            err.Clear();
        }

        public void currencyFormat(object obj, string str)
        {
        try
            {
                TextBox txt = obj as TextBox;
                double money = Convert.ToDouble(str.Trim());
                txt.Text = money.ToString("N2");
                txt.SelectionStart = txt.TextLength;
            }
            catch { }
        }

        public void numberFormat(object obj, string str)
        {
            try
            {
                TextBox txt = obj as TextBox;
                double money = Convert.ToDouble(str.Trim());
                txt.Text = money.ToString("N0");
                txt.SelectionStart = txt.TextLength;
            }
            catch { }
        }
    }
}
