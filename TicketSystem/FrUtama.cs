using System;
using System.Linq;
using System.Windows.Forms;
using TicketSystem.About;
using TicketSystem.Common;
using TicketSystem.Maintenance.Driver;
using TicketSystem.Maintenance.Users;
using TicketSystem.Maintenance.Vehicles;
using TicketSystem.Reports;
using TicketSystem.Transactions;
using TicketSystem.User;
using TicketSystem.Administrations;

namespace TicketSystem
{
    public partial class FrUtama : Form
    {
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        public FrUtama()
        {
            InitializeComponent();
        }

        private void FrUtama_Resize(object sender, EventArgs e)
        {
            msMain.Left = (this.Width / 2) - (msMain.Width / 2);
            msMain.Top = (this.Height / 2) - (msMain.Height / 2);
        }

        private void gantiSandiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrGantiSandi frGantiSandi = new FrGantiSandi();
            frGantiSandi.MdiParent = this;
            frGantiSandi.Show();
        }

        private void FrUtama_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void kendaraanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrMasterKendaraan frm = null;
            if ((frm = (FrMasterKendaraan)IsFormAlreadyOpen(typeof(FrMasterKendaraan))) == null)
            {
                frm = new FrMasterKendaraan();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void supirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrMasterSupir frm = null;
            if ((frm = (FrMasterSupir)IsFormAlreadyOpen(typeof(FrMasterSupir))) == null)
            {
                frm = new FrMasterSupir();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrMasterPengguna frm = null;
            if ((frm = (FrMasterPengguna)IsFormAlreadyOpen(typeof(FrMasterPengguna))) == null)
            {
                frm = new FrMasterPengguna();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void admToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrMasterAdm frm = null;
            if ((frm = (FrMasterAdm)IsFormAlreadyOpen(typeof(FrMasterAdm))) == null)
            {
                frm = new FrMasterAdm();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form tmpForm = Application.OpenForms.Cast<Form>().FirstOrDefault(openForm => openForm.Name == "FrUtama");
            if (tmpForm != null) tmpForm.Dispose();
            var login = new FrLogin();
            login.Show();
        }

        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            logOutToolStripMenuItem_Click(sender, e);
        }

        private void reservasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrTrx frm = null;
            if ((frm = (FrTrx)IsFormAlreadyOpen(typeof(FrTrx))) == null)
            {
                frm = new FrTrx();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void pelunasanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrPelunasan frm = null;
            if ((frm = (FrPelunasan)IsFormAlreadyOpen(typeof(FrPelunasan))) == null)
            {
                frm = new FrPelunasan();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void PembatalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrPembatalan frm = null;
            if ((frm = (FrPembatalan)IsFormAlreadyOpen(typeof(FrPembatalan))) == null)
            {
                frm = new FrPembatalan();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void manifestPenumpangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrPrintManifest frm = null;
            if ((frm = (FrPrintManifest)IsFormAlreadyOpen(typeof(FrPrintManifest))) == null)
            {
                frm = new FrPrintManifest();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void pendapatanDatangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrPendapatanDatang frm = null;
            if ((frm = (FrPendapatanDatang)IsFormAlreadyOpen(typeof(FrPendapatanDatang))) == null)
            {
                frm = new FrPendapatanDatang();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void pemberangkatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrLapPemberangkatan frm = null;
            if ((frm = (FrLapPemberangkatan)IsFormAlreadyOpen(typeof(FrLapPemberangkatan))) == null)
            {
                frm = new FrLapPemberangkatan();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }

        private void bantuanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new FrTentang();
            about.ShowDialog();
        }

        private void FrUtama_Load(object sender, EventArgs e)
        {
            switch (UserInfo.Role)
            {
                case "ADM":
                    berkasToolStripMenuItem.Visible = true;
                    admToolStripMenuItem.Visible = true;
                    transaksiToolStripMenuItem.Visible = true;
                    laporanToolStripMenuItem.Visible = true;
                    masterToolStripMenuItem.Visible = true;
                    break;
                case "SPV":
                    berkasToolStripMenuItem.Visible = true;
                    admToolStripMenuItem.Visible = true;
                    transaksiToolStripMenuItem.Visible = true;
                    laporanToolStripMenuItem.Visible = true;
                    masterToolStripMenuItem.Visible = false;
                    break;
                case "OPR":
                    berkasToolStripMenuItem.Visible = true;
                    admToolStripMenuItem.Visible = true;
                    transaksiToolStripMenuItem.Visible = true;
                    laporanToolStripMenuItem.Visible = true;
                    masterToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void pengeluaranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrPengeluaran frm = null;
            if ((frm = (FrPengeluaran)IsFormAlreadyOpen(typeof(FrPengeluaran))) == null)
            {
                frm = new FrPengeluaran();
                frm.MdiParent = this;
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            else
                frm.Activate();
        }
    }
}
