namespace TicketSystem.Transactions
{
    partial class FrPrintReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrPrintReceipt));
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.rv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.pnlMiddle.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.rv);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(0, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(921, 417);
            this.pnlMiddle.TabIndex = 23;
            // 
            // rv
            // 
            this.rv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rv.Location = new System.Drawing.Point(12, 12);
            this.rv.Name = "rv";
            this.rv.Size = new System.Drawing.Size(897, 399);
            this.rv.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnPrint);
            this.pnlBtn.Controls.Add(this.btnTutup);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(0, 417);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(921, 60);
            this.pnlBtn.TabIndex = 22;
            // 
            // btnPrint
            // 
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(771, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 60);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "&Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnTutup
            // 
            this.btnTutup.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTutup.Image = ((System.Drawing.Image)(resources.GetObject("btnTutup.Image")));
            this.btnTutup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTutup.Location = new System.Drawing.Point(846, 0);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(75, 60);
            this.btnTutup.TabIndex = 0;
            this.btnTutup.Text = "&Tutup";
            this.btnTutup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTutup.UseVisualStyleBackColor = true;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);
            // 
            // FrPrintReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 477);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlBtn);
            this.Name = "FrPrintReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrPrintReceipt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrPrintReceipt_FormClosed);
            this.Load += new System.EventHandler(this.FrPrintReceipt_Load);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Panel pnlBtn;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnTutup;
        private Microsoft.Reporting.WinForms.ReportViewer rv;
    }
}