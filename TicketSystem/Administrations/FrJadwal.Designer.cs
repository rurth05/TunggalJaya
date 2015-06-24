namespace TicketSystem.Administrations
{
    partial class FrJadwal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrJadwal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.chkCarter = new System.Windows.Forms.CheckBox();
            this.cbSupir = new System.Windows.Forms.ComboBox();
            this.cbArmada = new System.Windows.Forms.ComboBox();
            this.cbTujuan = new System.Windows.Forms.ComboBox();
            this.dtpTgl = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAsal = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mTxtJam = new System.Windows.Forms.MaskedTextBox();
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
            this.panel1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Jadwal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSimpan.Location = new System.Drawing.Point(396, 255);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(75, 55);
            this.btnSimpan.TabIndex = 8;
            this.btnSimpan.Text = "Simpan";
            this.btnSimpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.Image = global::TicketSystem.Properties.Resources.Cancel1;
            this.btnBatal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBatal.Location = new System.Drawing.Point(26, 255);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(75, 55);
            this.btnBatal.TabIndex = 9;
            this.btnBatal.Text = "Batal";
            this.btnBatal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.mTxtJam);
            this.gbTipeKendaraan.Controls.Add(this.chkCarter);
            this.gbTipeKendaraan.Controls.Add(this.cbSupir);
            this.gbTipeKendaraan.Controls.Add(this.cbArmada);
            this.gbTipeKendaraan.Controls.Add(this.cbTujuan);
            this.gbTipeKendaraan.Controls.Add(this.dtpTgl);
            this.gbTipeKendaraan.Controls.Add(this.label7);
            this.gbTipeKendaraan.Controls.Add(this.label6);
            this.gbTipeKendaraan.Controls.Add(this.cbAsal);
            this.gbTipeKendaraan.Controls.Add(this.txtId);
            this.gbTipeKendaraan.Controls.Add(this.label4);
            this.gbTipeKendaraan.Controls.Add(this.label3);
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 40);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 204);
            this.gbTipeKendaraan.TabIndex = 15;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // chkCarter
            // 
            this.chkCarter.AutoSize = true;
            this.chkCarter.Location = new System.Drawing.Point(132, 175);
            this.chkCarter.Name = "chkCarter";
            this.chkCarter.Size = new System.Drawing.Size(54, 17);
            this.chkCarter.TabIndex = 7;
            this.chkCarter.Text = "Carter";
            this.chkCarter.UseVisualStyleBackColor = true;
            this.chkCarter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkCarter_KeyPress);
            // 
            // cbSupir
            // 
            this.cbSupir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupir.FormattingEnabled = true;
            this.cbSupir.Location = new System.Drawing.Point(132, 147);
            this.cbSupir.Name = "cbSupir";
            this.cbSupir.Size = new System.Drawing.Size(191, 21);
            this.cbSupir.TabIndex = 6;
            this.cbSupir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSupir_KeyPress);
            this.cbSupir.Validating += new System.ComponentModel.CancelEventHandler(this.cbSupir_Validating);
            // 
            // cbArmada
            // 
            this.cbArmada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArmada.FormattingEnabled = true;
            this.cbArmada.Location = new System.Drawing.Point(132, 120);
            this.cbArmada.Name = "cbArmada";
            this.cbArmada.Size = new System.Drawing.Size(86, 21);
            this.cbArmada.TabIndex = 5;
            this.cbArmada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbArmada_KeyPress);
            this.cbArmada.Validating += new System.ComponentModel.CancelEventHandler(this.cbArmada_Validating);
            // 
            // cbTujuan
            // 
            this.cbTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTujuan.FormattingEnabled = true;
            this.cbTujuan.Location = new System.Drawing.Point(132, 93);
            this.cbTujuan.Name = "cbTujuan";
            this.cbTujuan.Size = new System.Drawing.Size(131, 21);
            this.cbTujuan.TabIndex = 4;
            this.cbTujuan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTujuan_KeyPress);
            this.cbTujuan.Validating += new System.ComponentModel.CancelEventHandler(this.cbTujuan_Validating);
            // 
            // dtpTgl
            // 
            this.dtpTgl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTgl.Location = new System.Drawing.Point(132, 15);
            this.dtpTgl.Name = "dtpTgl";
            this.dtpTgl.Size = new System.Drawing.Size(100, 20);
            this.dtpTgl.TabIndex = 1;
            this.dtpTgl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpTgl_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Supir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "No Armada";
            // 
            // cbAsal
            // 
            this.cbAsal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAsal.FormattingEnabled = true;
            this.cbAsal.Location = new System.Drawing.Point(132, 66);
            this.cbAsal.Name = "cbAsal";
            this.cbAsal.Size = new System.Drawing.Size(131, 21);
            this.cbAsal.TabIndex = 3;
            this.cbAsal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbAsal_KeyPress);
            this.cbAsal.Validating += new System.ComponentModel.CancelEventHandler(this.cbAsal_Validating);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(238, 14);
            this.txtId.MaxLength = 3;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 8;
            this.txtId.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tujuan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Asal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tanggal Berangkat";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mTxtJam
            // 
            this.mTxtJam.Location = new System.Drawing.Point(132, 41);
            this.mTxtJam.Mask = "00:00";
            this.mTxtJam.Name = "mTxtJam";
            this.mTxtJam.Size = new System.Drawing.Size(39, 20);
            this.mTxtJam.TabIndex = 2;
            this.mTxtJam.ValidatingType = typeof(System.DateTime);
            this.mTxtJam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mTtxtJam_KeyPress);
            this.mTxtJam.Validating += new System.ComponentModel.CancelEventHandler(this.mTxtJam_Validating);
            // 
            // FrJadwal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrJadwal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrJadwal";
            this.Activated += new System.EventHandler(this.FrJadwal_Activated);
            this.Load += new System.EventHandler(this.FrJadwal_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAsal;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTujuan;
        private System.Windows.Forms.DateTimePicker dtpTgl;
        private System.Windows.Forms.CheckBox chkCarter;
        private System.Windows.Forms.ComboBox cbSupir;
        private System.Windows.Forms.ComboBox cbArmada;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox mTxtJam;
    }
}