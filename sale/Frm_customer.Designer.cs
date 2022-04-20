namespace SafaShop
{
    partial class Frm_customer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_customer));
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTell1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTell2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCustomer
            // 
            this.lvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lvCustomer.Location = new System.Drawing.Point(0, 103);
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvCustomer.RightToLeftLayout = true;
            this.lvCustomer.Size = new System.Drawing.Size(796, 452);
            this.lvCustomer.TabIndex = 0;
            this.lvCustomer.TabStop = false;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCustomer_ColumnClick);
            this.lvCustomer.DoubleClick += new System.EventHandler(this.lvCustomer_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(796, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشتری";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtcustomer);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(557, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 40);
            this.panel3.TabIndex = 14;
            // 
            // txtcustomer
            // 
            this.txtcustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcustomer.Location = new System.Drawing.Point(0, 16);
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(236, 23);
            this.txtcustomer.TabIndex = 0;
            this.txtcustomer.TextChanged += new System.EventHandler(this.txtcustomer_TextChanged);
            this.txtcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell2_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "نام مشتری";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtNickName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(431, 19);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(126, 40);
            this.panel4.TabIndex = 15;
            // 
            // txtNickName
            // 
            this.txtNickName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNickName.Location = new System.Drawing.Point(0, 16);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(126, 23);
            this.txtNickName.TabIndex = 1;
            this.txtNickName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell2_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "شهرت";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtTell1);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(331, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(100, 40);
            this.panel5.TabIndex = 15;
            // 
            // txtTell1
            // 
            this.txtTell1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTell1.Location = new System.Drawing.Point(0, 16);
            this.txtTell1.Name = "txtTell1";
            this.txtTell1.Size = new System.Drawing.Size(100, 23);
            this.txtTell1.TabIndex = 2;
            this.txtTell1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell2_KeyPress);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "شماره تماس 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtTell2);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(231, 19);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 40);
            this.panel6.TabIndex = 15;
            // 
            // txtTell2
            // 
            this.txtTell2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTell2.Location = new System.Drawing.Point(0, 16);
            this.txtTell2.Name = "txtTell2";
            this.txtTell2.Size = new System.Drawing.Size(100, 23);
            this.txtTell2.TabIndex = 3;
            this.txtTell2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell2_KeyPress);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "شماره تماس 2";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtAddress);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(68, 19);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(163, 40);
            this.panel7.TabIndex = 15;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(0, 16);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(163, 23);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTell2_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "آدرس";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(65, 40);
            this.panel2.TabIndex = 18;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(65, 23);
            this.txtCode.TabIndex = 555;
            this.txtCode.TabStop = false;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "کد مشتری";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(882, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "کد مشتری";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 41);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(174, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 41);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ثبت";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnNew.Image = global::Avazeh.Properties.Resources.New_Contact;
            this.btnNew.Location = new System.Drawing.Point(87, 0);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(87, 41);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "جدید";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 41);
            this.panel1.TabIndex = 1;
            // 
            // Frm_customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 555);
            this.Controls.Add(this.lvCustomer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_customer";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست مشتریان";
            this.Load += new System.EventHandler(this.Frm_customer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_customer_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtTell2;
        private System.Windows.Forms.TextBox txtTell1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel2;
    }
}