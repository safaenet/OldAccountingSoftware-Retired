namespace SafaShop
{
    partial class Frm_AddNewOrRenameTransactionFile
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
            this.txtFileSubject = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFileSubject
            // 
            this.txtFileSubject.Location = new System.Drawing.Point(77, 26);
            this.txtFileSubject.Name = "txtFileSubject";
            this.txtFileSubject.Size = new System.Drawing.Size(228, 20);
            this.txtFileSubject.TabIndex = 1;
            this.txtFileSubject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileSubject_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Avazeh.Properties.Resources.Add_16x16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(12, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(59, 26);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "عنوان فایل را وارد کنید";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Frm_AddNewOrRenameTransactionFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 58);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtFileSubject);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AddNewOrRenameTransactionFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فایل جدید";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AddNewTransactionFile_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AddNewOrRenameTransactionFile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_AddNewTransactionFile_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFileSubject;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}