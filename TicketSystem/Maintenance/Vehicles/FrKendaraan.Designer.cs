﻿namespace TicketSystem.Maintenance.Vehicles
{
    partial class FrKendaraan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrKendaraan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.gbTipeKendaraan = new System.Windows.Forms.GroupBox();
            this.cbTipeKendaraan = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJmlKursi = new System.Windows.Forms.TextBox();
            this.txtNoPolisi = new System.Windows.Forms.TextBox();
            this.txtNoArmada = new System.Windows.Forms.TextBox();
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
            this.panel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(494, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kendaraan";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // gbTipeKendaraan
            // 
            this.gbTipeKendaraan.Controls.Add(this.cbTipeKendaraan);
            this.gbTipeKendaraan.Controls.Add(this.txtId);
            this.gbTipeKendaraan.Controls.Add(this.label4);
            this.gbTipeKendaraan.Controls.Add(this.label3);
            this.gbTipeKendaraan.Controls.Add(this.label2);
            this.gbTipeKendaraan.Controls.Add(this.label1);
            this.gbTipeKendaraan.Controls.Add(this.txtJmlKursi);
            this.gbTipeKendaraan.Controls.Add(this.txtNoPolisi);
            this.gbTipeKendaraan.Controls.Add(this.txtNoArmada);
            this.gbTipeKendaraan.Cursor = System.Windows.Forms.Cursors.Default;
            this.gbTipeKendaraan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbTipeKendaraan.Location = new System.Drawing.Point(26, 58);
            this.gbTipeKendaraan.Name = "gbTipeKendaraan";
            this.gbTipeKendaraan.Size = new System.Drawing.Size(445, 174);
            this.gbTipeKendaraan.TabIndex = 9;
            this.gbTipeKendaraan.TabStop = false;
            // 
            // cbTipeKendaraan
            // 
            this.cbTipeKendaraan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipeKendaraan.FormattingEnabled = true;
            this.cbTipeKendaraan.Location = new System.Drawing.Point(132, 115);
            this.cbTipeKendaraan.Name = "cbTipeKendaraan";
            this.cbTipeKendaraan.Size = new System.Drawing.Size(148, 21);
            this.cbTipeKendaraan.TabIndex = 4;
            this.cbTipeKendaraan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTipeKendaraan_KeyPress);
            this.cbTipeKendaraan.Validating += new System.ComponentModel.CancelEventHandler(this.cbTipeKendaraan_Validating);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(215, 37);
            this.txtId.MaxLength = 3;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(48, 20);
            this.txtId.TabIndex = 8;
            this.txtId.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipe Kendaraan";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Jumlah Kursi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "No Polisi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "No Armada";
            // 
            // txtJmlKursi
            // 
            this.txtJmlKursi.Location = new System.Drawing.Point(132, 89);
            this.txtJmlKursi.MaxLength = 5;
            this.txtJmlKursi.Name = "txtJmlKursi";
            this.txtJmlKursi.Size = new System.Drawing.Size(49, 20);
            this.txtJmlKursi.TabIndex = 3;
            this.txtJmlKursi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJmlKursi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJmlKursi_KeyPress);
            this.txtJmlKursi.Leave += new System.EventHandler(this.txtJmlKursi_Leave);
            this.txtJmlKursi.Validating += new System.ComponentModel.CancelEventHandler(this.txtJmlKursi_Validating);
            // 
            // txtNoPolisi
            // 
            this.txtNoPolisi.Location = new System.Drawing.Point(132, 63);
            this.txtNoPolisi.MaxLength = 10;
            this.txtNoPolisi.Name = "txtNoPolisi";
            this.txtNoPolisi.Size = new System.Drawing.Size(86, 20);
            this.txtNoPolisi.TabIndex = 2;
            this.txtNoPolisi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoPolisi_KeyPress);
            this.txtNoPolisi.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoPolisi_Validating);
            // 
            // txtNoArmada
            // 
            this.txtNoArmada.Location = new System.Drawing.Point(132, 37);
            this.txtNoArmada.MaxLength = 10;
            this.txtNoArmada.Name = "txtNoArmada";
            this.txtNoArmada.Size = new System.Drawing.Size(77, 20);
            this.txtNoArmada.TabIndex = 1;
            this.txtNoArmada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoArmada_KeyPress);
            this.txtNoArmada.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoArmada_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrKendaraan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 325);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.gbTipeKendaraan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrKendaraan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrKendaraan";
            this.Activated += new System.EventHandler(this.FrKendaraan_Activated);
            this.Load += new System.EventHandler(this.FrKendaraan_Load);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJmlKursi;
        private System.Windows.Forms.TextBox txtNoPolisi;
        private System.Windows.Forms.TextBox txtNoArmada;
        private System.Windows.Forms.ComboBox cbTipeKendaraan;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}