namespace SafaShop
{
    partial class frmFactorPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFactorPayments));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbPayDesc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnWholeFactorAmount = new System.Windows.Forms.Button();
            this.lvPayments = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFactorDetail = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalBalance = new System.Windows.Forms.TextBox();
            this.btnTotalBalanceAmount = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFactorBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPaymentTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtFactorTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtFactorNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.gbFactorDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.groupBox1.Location = new System.Drawing.Point(0, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(878, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ثبت پرداخت";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cmbPayDesc);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(123, 17);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(566, 39);
            this.panel7.TabIndex = 3;
            // 
            // cmbPayDesc
            // 
            this.cmbPayDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPayDesc.FormattingEnabled = true;
            this.cmbPayDesc.Items.AddRange(new object[] {
            "پرداخت نقدی"});
            this.cmbPayDesc.Location = new System.Drawing.Point(0, 16);
            this.cmbPayDesc.Name = "cmbPayDesc";
            this.cmbPayDesc.Size = new System.Drawing.Size(566, 21);
            this.cmbPayDesc.TabIndex = 2;
            this.cmbPayDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPayDesc_KeyPress);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "توضیحات";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtPayAmount);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(689, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(186, 39);
            this.panel6.TabIndex = 3;
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPayAmount.Location = new System.Drawing.Point(0, 16);
            this.txtPayAmount.MaxLength = 18;
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(186, 21);
            this.txtPayAmount.TabIndex = 1;
            this.txtPayAmount.Text = "0";
            this.txtPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPayAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayAmount_KeyPress);
            this.txtPayAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPayAmount_KeyUp);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "مبلغ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(3, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 39);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "S";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnWholeFactorAmount
            // 
            this.btnWholeFactorAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnWholeFactorAmount.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnWholeFactorAmount.Location = new System.Drawing.Point(163, 16);
            this.btnWholeFactorAmount.Name = "btnWholeFactorAmount";
            this.btnWholeFactorAmount.Size = new System.Drawing.Size(29, 24);
            this.btnWholeFactorAmount.TabIndex = 8;
            this.btnWholeFactorAmount.Text = "V";
            this.btnWholeFactorAmount.UseVisualStyleBackColor = true;
            this.btnWholeFactorAmount.Click += new System.EventHandler(this.btnWholeFactorAmount_Click);
            // 
            // lvPayments
            // 
            this.lvPayments.ContextMenuStrip = this.contextMenuStrip1;
            this.lvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPayments.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lvPayments.Location = new System.Drawing.Point(0, 119);
            this.lvPayments.Name = "lvPayments";
            this.lvPayments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvPayments.RightToLeftLayout = true;
            this.lvPayments.Size = new System.Drawing.Size(878, 336);
            this.lvPayments.TabIndex = 1;
            this.lvPayments.UseCompatibleStateImageBehavior = false;
            this.lvPayments.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPayments_ColumnClick);
            this.lvPayments.DoubleClick += new System.EventHandler(this.lvPayments_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 26);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(95, 22);
            this.tsmDelete.Text = "حذف";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // gbFactorDetail
            // 
            this.gbFactorDetail.Controls.Add(this.panel1);
            this.gbFactorDetail.Controls.Add(this.panel2);
            this.gbFactorDetail.Controls.Add(this.panel3);
            this.gbFactorDetail.Controls.Add(this.panel4);
            this.gbFactorDetail.Controls.Add(this.panel5);
            this.gbFactorDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFactorDetail.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.gbFactorDetail.Location = new System.Drawing.Point(0, 0);
            this.gbFactorDetail.Name = "gbFactorDetail";
            this.gbFactorDetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbFactorDetail.Size = new System.Drawing.Size(878, 60);
            this.gbFactorDetail.TabIndex = 2;
            this.gbFactorDetail.TabStop = false;
            this.gbFactorDetail.Text = "وضعیت فاکتور";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTotalBalance);
            this.panel1.Controls.Add(this.btnTotalBalanceAmount);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 40);
            this.panel1.TabIndex = 3;
            // 
            // txtTotalBalance
            // 
            this.txtTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotalBalance.Location = new System.Drawing.Point(29, 16);
            this.txtTotalBalance.Name = "txtTotalBalance";
            this.txtTotalBalance.ReadOnly = true;
            this.txtTotalBalance.Size = new System.Drawing.Size(202, 21);
            this.txtTotalBalance.TabIndex = 19;
            this.txtTotalBalance.TabStop = false;
            this.txtTotalBalance.Text = "0";
            this.txtTotalBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTotalBalanceAmount
            // 
            this.btnTotalBalanceAmount.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTotalBalanceAmount.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnTotalBalanceAmount.Location = new System.Drawing.Point(231, 16);
            this.btnTotalBalanceAmount.Name = "btnTotalBalanceAmount";
            this.btnTotalBalanceAmount.Size = new System.Drawing.Size(29, 24);
            this.btnTotalBalanceAmount.TabIndex = 22;
            this.btnTotalBalanceAmount.Text = "V";
            this.btnTotalBalanceAmount.UseVisualStyleBackColor = true;
            this.btnTotalBalanceAmount.Click += new System.EventHandler(this.btnTotalBalanceAmount_Click);
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label10.Location = new System.Drawing.Point(0, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 24);
            this.label10.TabIndex = 21;
            this.label10.Text = "ریال";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(260, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "تراز فاکتور";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFactorBalance);
            this.panel2.Controls.Add(this.btnWholeFactorAmount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(263, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 40);
            this.panel2.TabIndex = 3;
            // 
            // txtFactorBalance
            // 
            this.txtFactorBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactorBalance.Location = new System.Drawing.Point(29, 16);
            this.txtFactorBalance.Name = "txtFactorBalance";
            this.txtFactorBalance.ReadOnly = true;
            this.txtFactorBalance.Size = new System.Drawing.Size(134, 21);
            this.txtFactorBalance.TabIndex = 16;
            this.txtFactorBalance.TabStop = false;
            this.txtFactorBalance.Text = "0";
            this.txtFactorBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(0, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "ریال";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "مبلغ باقیمانده فاکتور";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPaymentTotal);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(455, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(178, 40);
            this.panel3.TabIndex = 3;
            // 
            // txtPaymentTotal
            // 
            this.txtPaymentTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPaymentTotal.Location = new System.Drawing.Point(29, 16);
            this.txtPaymentTotal.Name = "txtPaymentTotal";
            this.txtPaymentTotal.ReadOnly = true;
            this.txtPaymentTotal.Size = new System.Drawing.Size(149, 21);
            this.txtPaymentTotal.TabIndex = 13;
            this.txtPaymentTotal.TabStop = false;
            this.txtPaymentTotal.Text = "0";
            this.txtPaymentTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaymentTotal.TextChanged += new System.EventHandler(this.txtPaymentTotal_TextChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label8.Location = new System.Drawing.Point(0, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "ریال";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "مبلغ کل پرداخت شده";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtFactorTotal);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(633, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(175, 40);
            this.panel4.TabIndex = 3;
            // 
            // txtFactorTotal
            // 
            this.txtFactorTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactorTotal.Location = new System.Drawing.Point(29, 16);
            this.txtFactorTotal.Name = "txtFactorTotal";
            this.txtFactorTotal.ReadOnly = true;
            this.txtFactorTotal.Size = new System.Drawing.Size(146, 21);
            this.txtFactorTotal.TabIndex = 10;
            this.txtFactorTotal.TabStop = false;
            this.txtFactorTotal.Text = "0";
            this.txtFactorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label6.Location = new System.Drawing.Point(0, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "ریال";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "مبلغ کل فاکتور";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtFactorNum);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(808, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(67, 40);
            this.panel5.TabIndex = 3;
            // 
            // txtFactorNum
            // 
            this.txtFactorNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactorNum.Location = new System.Drawing.Point(0, 16);
            this.txtFactorNum.Name = "txtFactorNum";
            this.txtFactorNum.ReadOnly = true;
            this.txtFactorNum.Size = new System.Drawing.Size(67, 21);
            this.txtFactorNum.TabIndex = 8;
            this.txtFactorNum.TabStop = false;
            this.txtFactorNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "شماره فاکتور";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmFactorPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 455);
            this.Controls.Add(this.lvPayments);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFactorDetail);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmFactorPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست پرداخت ها";
            this.Load += new System.EventHandler(this.frmFactorPayments_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFactorPayments_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbFactorDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnWholeFactorAmount;
        private System.Windows.Forms.ListView lvPayments;
        private System.Windows.Forms.GroupBox gbFactorDetail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFactorTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFactorNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPaymentTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtFactorBalance;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalBalance;
        private System.Windows.Forms.Button btnTotalBalanceAmount;
        private System.Windows.Forms.ComboBox cmbPayDesc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
    }
}