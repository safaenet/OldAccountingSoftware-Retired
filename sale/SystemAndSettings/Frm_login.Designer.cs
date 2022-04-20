namespace SafaShop
{
    partial class Frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRemPassword = new System.Windows.Forms.CheckBox();
            this.chkRemUsername = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnLogin.Location = new System.Drawing.Point(6, 70);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLogin.Size = new System.Drawing.Size(283, 48);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ورود";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(101, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsername.Size = new System.Drawing.Size(125, 21);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(101, 43);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPassword.Size = new System.Drawing.Size(125, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            this.txtPassword.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(232, 17);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(57, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "نام کاربری";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(233, 44);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "کلمه عبور";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRemPassword);
            this.groupBox1.Controls.Add(this.chkRemUsername);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(295, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ورود";
            // 
            // chkRemPassword
            // 
            this.chkRemPassword.AutoSize = true;
            this.chkRemPassword.Enabled = false;
            this.chkRemPassword.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.chkRemPassword.Location = new System.Drawing.Point(6, 45);
            this.chkRemPassword.Name = "chkRemPassword";
            this.chkRemPassword.Size = new System.Drawing.Size(97, 18);
            this.chkRemPassword.TabIndex = 5;
            this.chkRemPassword.Text = "به خاطر بسپار";
            this.chkRemPassword.UseVisualStyleBackColor = true;
            // 
            // chkRemUsername
            // 
            this.chkRemUsername.AutoSize = true;
            this.chkRemUsername.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.chkRemUsername.Location = new System.Drawing.Point(6, 18);
            this.chkRemUsername.Name = "chkRemUsername";
            this.chkRemUsername.Size = new System.Drawing.Size(97, 18);
            this.chkRemUsername.TabIndex = 5;
            this.chkRemUsername.Text = "به خاطر بسپار";
            this.chkRemUsername.UseVisualStyleBackColor = true;
            this.chkRemUsername.CheckedChanged += new System.EventHandler(this.chkRemUsername_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 210);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "احراز هویت";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox chkRemPassword;
        private System.Windows.Forms.CheckBox chkRemUsername;
    }
}