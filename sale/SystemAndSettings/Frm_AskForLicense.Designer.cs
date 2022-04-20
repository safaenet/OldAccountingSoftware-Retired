namespace Avazeh.SystemAndSettings
{
    partial class frmAskForLicense
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.txtActivationKey = new System.Windows.Forms.TextBox();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Activation Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Your License ID";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(101, 6);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.ReadOnly = true;
            this.txtLicenseID.Size = new System.Drawing.Size(243, 20);
            this.txtLicenseID.TabIndex = 9;
            this.txtLicenseID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtActivationKey
            // 
            this.txtActivationKey.Location = new System.Drawing.Point(93, 32);
            this.txtActivationKey.Name = "txtActivationKey";
            this.txtActivationKey.Size = new System.Drawing.Size(251, 20);
            this.txtActivationKey.TabIndex = 8;
            this.txtActivationKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(12, 58);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(369, 38);
            this.btnActivate.TabIndex = 7;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(350, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(31, 20);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "C";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(350, 32);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(31, 20);
            this.btnPaste.TabIndex = 13;
            this.btnPaste.Text = "P";
            this.btnPaste.UseVisualStyleBackColor = true;
            // 
            // frmAskForLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 104);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLicenseID);
            this.Controls.Add(this.txtActivationKey);
            this.Controls.Add(this.btnActivate);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAskForLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فعالسازی برنامه";
            this.Load += new System.EventHandler(this.frmAskForLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.TextBox txtActivationKey;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
    }
}