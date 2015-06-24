namespace TicketSystem.Transactions
{
    partial class FrPembatalanAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrPembatalanAdd));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalBayar = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRpKembali = new System.Windows.Forms.TextBox();
            this.txtPersenKembali = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
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
            this.panel1.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pembatalan";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.label4);
            this.gbTipeKendaraan.Controls.Add(this.txtTotalBayar);
            this.gbTipeKendaraan.Controls.Add(this.txtId);
            this.gbTipeKendaraan.Controls.Add(this.label3);
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Controls.Add(this.txtRpKembali);
            this.gbTipeKendaraan.Controls.Add(this.txtPersenKembali);
            this.gbTipeKendaraan.Controls.Add(this.txtTotal);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 54);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 174);
            this.gbTipeKendaraan.TabIndex = 19;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Total Dibayar";
            // 
            // txtTotalBayar
            // 
            this.txtTotalBayar.Enabled = false;
            this.txtTotalBayar.Location = new System.Drawing.Point(156, 70);
            this.txtTotalBayar.MaxLength = 20;
            this.txtTotalBayar.Name = "txtTotalBayar";
            this.txtTotalBayar.Size = new System.Drawing.Size(116, 20);
            this.txtTotalBayar.TabIndex = 9;
            this.txtTotalBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(295, 44);
            this.txtId.MaxLength = 3;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 8;
            this.txtId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pengembalian (Rp.)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pengembalian (%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Ongkos";
            // 
            // txtRpKembali
            // 
            this.txtRpKembali.Location = new System.Drawing.Point(156, 122);
            this.txtRpKembali.MaxLength = 20;
            this.txtRpKembali.Name = "txtRpKembali";
            this.txtRpKembali.Size = new System.Drawing.Size(116, 20);
            this.txtRpKembali.TabIndex = 2;
            this.txtRpKembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRpKembali.TextChanged += new System.EventHandler(this.txtRpKembali_TextChanged);
            this.txtRpKembali.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRpKembali_KeyPress);
            this.txtRpKembali.Leave += new System.EventHandler(this.txtRpKembali_Leave);
            this.txtRpKembali.Validating += new System.ComponentModel.CancelEventHandler(this.txtRpKembali_Validating);
            // 
            // txtPersenKembali
            // 
            this.txtPersenKembali.Location = new System.Drawing.Point(156, 96);
            this.txtPersenKembali.MaxLength = 3;
            this.txtPersenKembali.Name = "txtPersenKembali";
            this.txtPersenKembali.Size = new System.Drawing.Size(48, 20);
            this.txtPersenKembali.TabIndex = 1;
            this.txtPersenKembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPersenKembali.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersenKembali_KeyPress);
            this.txtPersenKembali.Leave += new System.EventHandler(this.txtPersenKembali_Leave);
            this.txtPersenKembali.Validating += new System.ComponentModel.CancelEventHandler(this.txtPersenKembali_Validating);
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(156, 44);
            this.txtTotal.MaxLength = 20;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(116, 20);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimpan.Location = new System.Drawing.Point(396, 251);
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
            this.btnBatal.Location = new System.Drawing.Point(26, 251);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 55);
            this.btnBatal.TabIndex = 5;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrPembatalanAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrPembatalanAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrPembatalanAdd";
            this.Activated += new System.EventHandler(this.FrPembatalanAdd_Activated);
            this.Load += new System.EventHandler(this.FrPembatalanAdd_Load);
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
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRpKembali;
        private System.Windows.Forms.TextBox txtPersenKembali;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalBayar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}