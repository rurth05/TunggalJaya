namespace TicketSystem.Maintenance.Driver
{
    partial class FrMasterSupir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrMasterSupir));
            this.dgvMasterSupir = new System.Windows.Forms.DataGridView();
            this.pnlCari = new System.Windows.Forms.Panel();
            this.gbCari = new System.Windows.Forms.GroupBox();
            this.btnTutupCari = new System.Windows.Forms.Button();
            this.lblCari = new System.Windows.Forms.Label();
            this.txtCari = new System.Windows.Forms.TextBox();
            this.pnlTopMenu = new System.Windows.Forms.Panel();
            this.mnIndex = new System.Windows.Forms.Button();
            this.mnSupir = new System.Windows.Forms.Button();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnBaru = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnCari = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterSupir)).BeginInit();
            this.pnlCari.SuspendLayout();
            this.gbCari.SuspendLayout();
            this.pnlTopMenu.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMasterSupir
            // 
            this.dgvMasterSupir.AllowUserToAddRows = false;
            this.dgvMasterSupir.AllowUserToDeleteRows = false;
            this.dgvMasterSupir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMasterSupir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMasterSupir.Location = new System.Drawing.Point(0, 140);
            this.dgvMasterSupir.Name = "dgvMasterSupir";
            this.dgvMasterSupir.ReadOnly = true;
            this.dgvMasterSupir.Size = new System.Drawing.Size(621, 252);
            this.dgvMasterSupir.TabIndex = 9;
            this.dgvMasterSupir.SelectionChanged += new System.EventHandler(this.dgvMasterSupir_SelectionChanged);
            // 
            // pnlCari
            // 
            this.pnlCari.Controls.Add(this.gbCari);
            this.pnlCari.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCari.Location = new System.Drawing.Point(0, 70);
            this.pnlCari.Name = "pnlCari";
            this.pnlCari.Size = new System.Drawing.Size(621, 70);
            this.pnlCari.TabIndex = 11;
            this.pnlCari.Visible = false;
            // 
            // gbCari
            // 
            this.gbCari.Controls.Add(this.btnTutupCari);
            this.gbCari.Controls.Add(this.lblCari);
            this.gbCari.Controls.Add(this.txtCari);
            this.gbCari.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCari.Location = new System.Drawing.Point(0, 0);
            this.gbCari.Name = "gbCari";
            this.gbCari.Size = new System.Drawing.Size(621, 64);
            this.gbCari.TabIndex = 0;
            this.gbCari.TabStop = false;
            this.gbCari.Text = "Cari";
            // 
            // btnTutupCari
            // 
            this.btnTutupCari.FlatAppearance.BorderSize = 0;
            this.btnTutupCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTutupCari.Image = ((System.Drawing.Image)(resources.GetObject("btnTutupCari.Image")));
            this.btnTutupCari.Location = new System.Drawing.Point(487, 8);
            this.btnTutupCari.Name = "btnTutupCari";
            this.btnTutupCari.Size = new System.Drawing.Size(25, 23);
            this.btnTutupCari.TabIndex = 2;
            this.btnTutupCari.UseVisualStyleBackColor = true;
            this.btnTutupCari.Click += new System.EventHandler(this.btnTutupCari_Click);
            // 
            // lblCari
            // 
            this.lblCari.AutoSize = true;
            this.lblCari.Location = new System.Drawing.Point(12, 31);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(59, 13);
            this.lblCari.TabIndex = 1;
            this.lblCari.Text = "Kata Kunci";
            // 
            // txtCari
            // 
            this.txtCari.Location = new System.Drawing.Point(77, 28);
            this.txtCari.Name = "txtCari";
            this.txtCari.Size = new System.Drawing.Size(169, 20);
            this.txtCari.TabIndex = 0;
            this.txtCari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCari_KeyPress);
            // 
            // pnlTopMenu
            // 
            this.pnlTopMenu.Controls.Add(this.mnIndex);
            this.pnlTopMenu.Controls.Add(this.mnSupir);
            this.pnlTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTopMenu.Name = "pnlTopMenu";
            this.pnlTopMenu.Size = new System.Drawing.Size(621, 70);
            this.pnlTopMenu.TabIndex = 8;
            // 
            // mnIndex
            // 
            this.mnIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.mnIndex.Image = ((System.Drawing.Image)(resources.GetObject("mnIndex.Image")));
            this.mnIndex.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mnIndex.Location = new System.Drawing.Point(90, 0);
            this.mnIndex.Name = "mnIndex";
            this.mnIndex.Size = new System.Drawing.Size(90, 70);
            this.mnIndex.TabIndex = 1;
            this.mnIndex.Tag = "2";
            this.mnIndex.Text = "Index";
            this.mnIndex.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mnIndex.UseVisualStyleBackColor = true;
            this.mnIndex.Click += new System.EventHandler(this.mnIndex_Click);
            // 
            // mnSupir
            // 
            this.mnSupir.Dock = System.Windows.Forms.DockStyle.Left;
            this.mnSupir.Image = ((System.Drawing.Image)(resources.GetObject("mnSupir.Image")));
            this.mnSupir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.mnSupir.Location = new System.Drawing.Point(0, 0);
            this.mnSupir.Name = "mnSupir";
            this.mnSupir.Size = new System.Drawing.Size(90, 70);
            this.mnSupir.TabIndex = 0;
            this.mnSupir.Tag = "1";
            this.mnSupir.Text = "Supir";
            this.mnSupir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mnSupir.UseVisualStyleBackColor = true;
            this.mnSupir.Click += new System.EventHandler(this.mnSupir_Click);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnBaru);
            this.pnlBtn.Controls.Add(this.btnUbah);
            this.pnlBtn.Controls.Add(this.btnHapus);
            this.pnlBtn.Controls.Add(this.btnCari);
            this.pnlBtn.Controls.Add(this.btnTutup);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(0, 392);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(621, 60);
            this.pnlBtn.TabIndex = 10;
            // 
            // btnBaru
            // 
            this.btnBaru.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBaru.Image = ((System.Drawing.Image)(resources.GetObject("btnBaru.Image")));
            this.btnBaru.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBaru.Location = new System.Drawing.Point(246, 0);
            this.btnBaru.Name = "btnBaru";
            this.btnBaru.Size = new System.Drawing.Size(75, 60);
            this.btnBaru.TabIndex = 4;
            this.btnBaru.Text = "&Baru";
            this.btnBaru.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBaru.UseVisualStyleBackColor = true;
            this.btnBaru.Click += new System.EventHandler(this.btnBaru_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUbah.Image = ((System.Drawing.Image)(resources.GetObject("btnUbah.Image")));
            this.btnUbah.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUbah.Location = new System.Drawing.Point(321, 0);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(75, 60);
            this.btnUbah.TabIndex = 3;
            this.btnUbah.Text = "&Ubah";
            this.btnUbah.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHapus.Image = ((System.Drawing.Image)(resources.GetObject("btnHapus.Image")));
            this.btnHapus.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnHapus.Location = new System.Drawing.Point(396, 0);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(75, 60);
            this.btnHapus.TabIndex = 2;
            this.btnHapus.Text = "&Hapus";
            this.btnHapus.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnCari
            // 
            this.btnCari.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCari.Image = ((System.Drawing.Image)(resources.GetObject("btnCari.Image")));
            this.btnCari.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCari.Location = new System.Drawing.Point(471, 0);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 60);
            this.btnCari.TabIndex = 1;
            this.btnCari.Text = "&Cari";
            this.btnCari.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // btnTutup
            // 
            this.btnTutup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTutup.Image = ((System.Drawing.Image)(resources.GetObject("btnTutup.Image")));
            this.btnTutup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTutup.Location = new System.Drawing.Point(546, 0);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 60);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "&Tutup";
            this.btnTutup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // FrMasterSupir
            // 
            this.ClientSize = new System.Drawing.Size(621, 452);
            this.ControlBox = false;
            this.Controls.Add(this.dgvMasterSupir);
            this.Controls.Add(this.pnlCari);
            this.Controls.Add(this.pnlTopMenu);
            this.Controls.Add(this.pnlBtn);
            this.Name = "FrMasterSupir";
            this.Text = "Master Supir";
            this.Load += new System.EventHandler(this.FrMasterSupir_Load);
            this.Resize += new System.EventHandler(this.FrMasterSupir_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMasterSupir)).EndInit();
            this.pnlCari.ResumeLayout(false);
            this.gbCari.ResumeLayout(false);
            this.gbCari.PerformLayout();
            this.pnlTopMenu.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMasterSupir;
        private System.Windows.Forms.Panel pnlCari;
        private System.Windows.Forms.GroupBox gbCari;
        private System.Windows.Forms.Button btnTutupCari;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.TextBox txtCari;
        private System.Windows.Forms.Panel pnlTopMenu;
        private System.Windows.Forms.Button mnIndex;
        private System.Windows.Forms.Button mnSupir;
        private System.Windows.Forms.Panel pnlBtn;
        private System.Windows.Forms.Button btnBaru;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Button btnTutup;
    }
}