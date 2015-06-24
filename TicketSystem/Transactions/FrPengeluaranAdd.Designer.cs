namespace TicketSystem.Transactions
{
    partial class FrPengeluaranAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrPengeluaranAdd));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPengeluaran = new System.Windows.Forms.TextBox();
            this.txtIdJadwal = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeterangan = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.gbTipeKendaraan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 28);
            this.panel1.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pengeluaran";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.txtPengeluaran);
            this.gbTipeKendaraan.Controls.Add(this.txtIdJadwal);
            this.gbTipeKendaraan.Controls.Add(this.txtId);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Controls.Add(this.txtKeterangan);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 54);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 174);
            this.gbTipeKendaraan.TabIndex = 24;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Pengeluaran";
            // 
            // txtPengeluaran
            // 
            this.txtPengeluaran.Location = new System.Drawing.Point(131, 42);
            this.txtPengeluaran.MaxLength = 20;
            this.txtPengeluaran.Name = "txtPengeluaran";
            this.txtPengeluaran.Size = new System.Drawing.Size(116, 20);
            this.txtPengeluaran.TabIndex = 1;
            this.txtPengeluaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPengeluaran.TextChanged += new System.EventHandler(this.txtPengeluaran_TextChanged);
            this.txtPengeluaran.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPengeluaran_KeyPress);
            this.txtPengeluaran.Validating += new System.ComponentModel.CancelEventHandler(this.txtPengeluaran_Validating);
            // 
            // txtIdJadwal
            // 
            this.txtIdJadwal.Location = new System.Drawing.Point(307, 45);
            this.txtIdJadwal.MaxLength = 3;
            this.txtIdJadwal.Name = "txtIdJadwal";
            this.txtIdJadwal.Size = new System.Drawing.Size(48, 20);
            this.txtIdJadwal.TabIndex = 9;
            this.txtIdJadwal.Visible = false;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(253, 45);
            this.txtId.MaxLength = 3;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 8;
            this.txtId.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Keterangan";
            // 
            // txtKeterangan
            // 
            this.txtKeterangan.Location = new System.Drawing.Point(131, 68);
            this.txtKeterangan.MaxLength = 250;
            this.txtKeterangan.Multiline = true;
            this.txtKeterangan.Name = "txtKeterangan";
            this.txtKeterangan.Size = new System.Drawing.Size(224, 46);
            this.txtKeterangan.TabIndex = 2;
            this.txtKeterangan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeterangan_KeyPress);
            this.txtKeterangan.Validating += new System.ComponentModel.CancelEventHandler(this.txtKeterangan_Validating);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimpan.Location = new System.Drawing.Point(396, 250);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 55);
            this.btnSimpan.TabIndex = 3;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Image = ((System.Drawing.Image)(resources.GetObject("btnBatal.Image")));
            this.btnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBatal.Location = new System.Drawing.Point(26, 250);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 55);
            this.btnBatal.TabIndex = 4;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrPengeluaranAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrPengeluaranAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrPengeluaranAdd";
            this.Activated += new System.EventHandler(this.FrPengeluaranAdd_Activated);
            this.Load += new System.EventHandler(this.FrPengeluaranAdd_Load);
            this.panel1.ResumeLayout(false);
            this.gbTipeKendaraan.ResumeLayout(false);
            this.gbTipeKendaraan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.GroupBox gbTipeKendaraan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPengeluaran;
        private System.Windows.Forms.TextBox txtIdJadwal;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeterangan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}