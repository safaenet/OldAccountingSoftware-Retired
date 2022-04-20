namespace SafaShop
{
    partial class FrmPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrint));
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
            this.CRV.Size = new System.Drawing.Size(818, 470);
            this.CRV.TabIndex = 0;
            this.CRV.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CRV.ViewTimeSelectionFormula = "";
            // 
            // FrmPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 470);
            this.Controls.Add(this.CRV);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmPrint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "چاپ فاکتور";
            this.Load += new System.EventHandler(this.FrmPrint_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrint_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV;
    }
}