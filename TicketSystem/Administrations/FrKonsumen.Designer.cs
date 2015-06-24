namespace TicketSystem.Administrations
{
    partial class FrKonsumen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrKonsumen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.cbJenisIdentitas = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoIdentitas = new System.Windows.Forms.TextBox();
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
            this.panel1.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Konsumen";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.label6);
            this.gbTipeKendaraan.Controls.Add(this.txtTelp);
            this.gbTipeKendaraan.Controls.Add(this.label4);
            this.gbTipeKendaraan.Controls.Add(this.txtAlamat);
            this.gbTipeKendaraan.Controls.Add(this.label3);
            this.gbTipeKendaraan.Controls.Add(this.txtNama);
            this.gbTipeKendaraan.Controls.Add(this.cbJenisIdentitas);
            this.gbTipeKendaraan.Controls.Add(this.txtId);
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Controls.Add(this.txtNoIdentitas);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 54);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 174);
            this.gbTipeKendaraan.TabIndex = 27;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Telp";
            // 
            // txtTelp
            // 
            this.txtTelp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelp.Location = new System.Drawing.Point(132, 142);
            this.txtTelp.MaxLength = 15;
            this.txtTelp.Name = "txtTelp";
            this.txtTelp.Size = new System.Drawing.Size(128, 20);
            this.txtTelp.TabIndex = 5;
            this.txtTelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelp_KeyPress);
            this.txtTelp.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelp_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Alamat";
            // 
            // txtAlamat
            // 
            this.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlamat.Location = new System.Drawing.Point(132, 95);
            this.txtAlamat.MaxLength = 250;
            this.txtAlamat.Multiline = true;
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(269, 41);
            this.txtAlamat.TabIndex = 4;
            this.txtAlamat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlamat_KeyPress);
            this.txtAlamat.Validating += new System.ComponentModel.CancelEventHandler(this.txtAlamat_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Nama";
            // 
            // txtNama
            // 
            this.txtNama.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNama.Location = new System.Drawing.Point(132, 69);
            this.txtNama.MaxLength = 30;
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(182, 20);
            this.txtNama.TabIndex = 3;
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);
            this.txtNama.Validating += new System.ComponentModel.CancelEventHandler(this.txtNama_Validating);
            // 
            // cbJenisIdentitas
            // 
            this.cbJenisIdentitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenisIdentitas.FormattingEnabled = true;
            this.cbJenisIdentitas.Location = new System.Drawing.Point(132, 17);
            this.cbJenisIdentitas.Name = "cbJenisIdentitas";
            this.cbJenisIdentitas.Size = new System.Drawing.Size(171, 21);
            this.cbJenisIdentitas.TabIndex = 1;
            this.cbJenisIdentitas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbJenisIdentitas_KeyPress);
            this.cbJenisIdentitas.Validating += new System.ComponentModel.CancelEventHandler(this.cbJenisIdentitas_Validating);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(309, 17);
            this.txtId.MaxLength = 3;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 8;
            this.txtId.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Identitas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Jenis Identitas";
            // 
            // txtNoIdentitas
            // 
            this.txtNoIdentitas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNoIdentitas.Location = new System.Drawing.Point(132, 43);
            this.txtNoIdentitas.MaxLength = 16;
            this.txtNoIdentitas.Name = "txtNoIdentitas";
            this.txtNoIdentitas.Size = new System.Drawing.Size(128, 20);
            this.txtNoIdentitas.TabIndex = 2;
            this.txtNoIdentitas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoIdentitas_KeyPress);
            this.txtNoIdentitas.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoIdentitas_Validating);
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimpan.Location = new System.Drawing.Point(396, 251);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 55);
            this.btnSimpan.TabIndex = 6;
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
            this.btnBatal.TabIndex = 7;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrKonsumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrKonsumen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrKonsumen";
            this.Activated += new System.EventHandler(this.FrKonsumen_Activated);
            this.Load += new System.EventHandler(this.FrKonsumen_Load);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoIdentitas;
        private System.Windows.Forms.ComboBox cbJenisIdentitas;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtTelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.Label label6;
    }
}