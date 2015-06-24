namespace TicketSystem.Maintenance.Vehicles
{
    partial class FrTipeKendaraan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrTipeKendaraan));
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.txtIdTipe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSetorWajib = new System.Windows.Forms.TextBox();
            this.txtKas = new System.Windows.Forms.TextBox();
            this.txtTipe = new System.Windows.Forms.TextBox();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbTipeKendaraan.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.txtIdTipe);
            this.gbTipeKendaraan.Controls.Add(this.label4);
            this.gbTipeKendaraan.Controls.Add(this.label3);
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Controls.Add(this.txtSetorWajib);
            this.gbTipeKendaraan.Controls.Add(this.txtKas);
            this.gbTipeKendaraan.Controls.Add(this.txtTipe);
            this.gbTipeKendaraan.Controls.Add(this.txtKode);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 58);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 174);
            this.gbTipeKendaraan.TabIndex = 0;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // txtIdTipe
            // 
            this.txtIdTipe.Location = new System.Drawing.Point(215, 37);
            this.txtIdTipe.MaxLength = 3;
            this.txtIdTipe.Name = "txtIdTipe";
            this.txtIdTipe.Size = new System.Drawing.Size(48, 20);
            this.txtIdTipe.TabIndex = 8;
            this.txtIdTipe.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Setor Wajib";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tipe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kode Tipe";
            // 
            // txtSetorWajib
            // 
            this.txtSetorWajib.Location = new System.Drawing.Point(132, 115);
            this.txtSetorWajib.MaxLength = 12;
            this.txtSetorWajib.Name = "txtSetorWajib";
            this.txtSetorWajib.Size = new System.Drawing.Size(131, 20);
            this.txtSetorWajib.TabIndex = 4;
            this.txtSetorWajib.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSetorWajib.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSetorWajib_KeyPress);
            this.txtSetorWajib.Leave += new System.EventHandler(this.txtSetorWajib_Leave);
            this.txtSetorWajib.Validating += new System.ComponentModel.CancelEventHandler(this.txtSetorWajib_Validating);
            // 
            // txtKas
            // 
            this.txtKas.Location = new System.Drawing.Point(132, 89);
            this.txtKas.MaxLength = 15;
            this.txtKas.Name = "txtKas";
            this.txtKas.Size = new System.Drawing.Size(131, 20);
            this.txtKas.TabIndex = 3;
            this.txtKas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKas_KeyPress);
            this.txtKas.Leave += new System.EventHandler(this.txtKas_Leave);
            this.txtKas.Validating += new System.ComponentModel.CancelEventHandler(this.txtKas_Validating);
            // 
            // txtTipe
            // 
            this.txtTipe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipe.Location = new System.Drawing.Point(132, 63);
            this.txtTipe.MaxLength = 15;
            this.txtTipe.Name = "txtTipe";
            this.txtTipe.Size = new System.Drawing.Size(131, 20);
            this.txtTipe.TabIndex = 2;
            this.txtTipe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipe_KeyPress);
            this.txtTipe.Validating += new System.ComponentModel.CancelEventHandler(this.txtTipe_Validating);
            // 
            // txtKode
            // 
            this.txtKode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKode.Location = new System.Drawing.Point(132, 37);
            this.txtKode.MaxLength = 3;
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(77, 20);
            this.txtKode.TabIndex = 1;
            this.txtKode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKode_KeyPress);
            this.txtKode.Validating += new System.ComponentModel.CancelEventHandler(this.txtKode_Validating);
            // 
            // btnBatal
            // 
            this.btnBatal.Image = ((System.Drawing.Image)(resources.GetObject("btnBatal.Image")));
            this.btnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBatal.Location = new System.Drawing.Point(26, 255);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 55);
            this.btnBatal.TabIndex = 6;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimpan.Location = new System.Drawing.Point(396, 255);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 55);
            this.btnSimpan.TabIndex = 5;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tipe Kendaraan";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 28);
            this.panel1.TabIndex = 8;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrTipeKendaraan
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrTipeKendaraan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipe Kendaraan";
            this.Activated += new System.EventHandler(this.FrTipeKendaraan_Activated);
            this.Load += new System.EventHandler(this.FrTipeKendaraan_Load);
            this.gbTipeKendaraan.ResumeLayout(false);
            this.gbTipeKendaraan.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTipeKendaraan;
        private System.Windows.Forms.TextBox txtSetorWajib;
        private System.Windows.Forms.TextBox txtKas;
        private System.Windows.Forms.TextBox txtTipe;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtIdTipe;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}