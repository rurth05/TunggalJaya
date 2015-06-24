using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TicketSystem.dsReceiptTableAdapters;
using TicketSystem.Common;
using TJ.DAL;

namespace TicketSystem.Transactions
{
    public partial class FrPrintReceipt : Form
    {
        string conString = DbConnection.GetConnection();
        private POTJDataContext context;
        private int _Id;
        private bool Carter;
        public FrPrintReceipt(int Id)
        {
            InitializeComponent();
            context = new POTJDataContext(DbConnection.GetConnection());
            _Id = Id;

            var query = from a in context.TRX_HISTORI_TRANSAKSIs
                        join b in context.TRX_PENJUALANs on a.ID_PENJUALAN equals b.ID_PENJUALAN
                        join c in context.ADM_JADWALs on b.ID_JADWAL equals  c.ID_JADWAL
                        where a.ID_TRANSAKSI == _Id
                        select new {c.CARTER};
            foreach (var a in query)
            {
                Carter = Convert.ToBoolean(a.CARTER);
            }
        }

        private void FrPrintReceipt_Load(object sender, EventArgs e)
        {

            string appPath = string.Empty;
            if (Carter)
                appPath = Application.StartupPath + "\\Transactions\\ReportTemplates\\KwitansiCarter.rdlc";
            else
                appPath = Application.StartupPath + "\\Transactions\\ReportTemplates\\Kwitansi.rdlc";
            appPath = appPath.Replace("\\bin\\Debug", "");

            rv.LocalReport.ReportPath = appPath;
            rv.ProcessingMode = ProcessingMode.Local;

            var ta = new taReceipt();
            var dt = new dsReceipt.dtReceiptDataTable();

            var cn = new SqlConnection(conString);
            ta.Connection = cn;
            ta.Fill(dt, _Id);
            rv.LocalReport.DataSources.Clear();
            rv.LocalReport.DataSources.Add(new ReportDataSource("dsReceipt", dt as DataTable));
            rv.RefreshReport();
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrPrintReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            rv.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
