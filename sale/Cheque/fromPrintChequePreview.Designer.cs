namespace SafaShop
{
    partial class fromPrintChequePreview
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
            this.CRV = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRV
            // 
            this.CRV.ActiveViewIndex = -1;
            this.CRV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV.Location = new System.Drawing.Point(0, 0);
            this.CRV.Name = "CRV";
            this.CRV.SelectionFormula = "";
            this.CRV.ShowCloseButton = false;
            this.CRV.ShowGotoPageButton = false;
            this.CRV.ShowGroupTreeButton = false;
            this.CRV.ShowPageNavigateButtons = false;
            this.CRV.ShowTextSearchButton = false;
            this.CRV.ShowZoomButton = false;
            this.CRV.Size = new System.Drawing.Size(963, 433);
            this.CRV.TabIndex = 0;
            this.CRV.ViewTimeSelectionFormula = "";
            // 
            // fromPrintChequePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 433);
            this.Controls.Add(this.CRV);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.KeyPreview = true;
            this.Name = "fromPrintChequePreview";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fromPrintChequePreview";
            this.Load += new System.EventHandler(this.fromPrintChequePreview_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fromPrintChequePreview_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV;

    }
}