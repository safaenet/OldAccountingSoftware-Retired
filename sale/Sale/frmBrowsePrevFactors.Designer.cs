namespace SafaShop
{
    partial class frmBrowsePrevFactors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrowsePrevFactors));
            this.lvSale = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmnuSelectFactor = new System.Windows.Forms.ToolStripMenuItem();
            this.tmnuOpenFactor = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFactorNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbFinStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectAndClose = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvSale
            // 
            this.lvSale.ContextMenuStrip = this.contextMenuStrip1;
            this.lvSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSale.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lvSale.Location = new System.Drawing.Point(0, 58);
            this.lvSale.MultiSelect = false;
            this.lvSale.Name = "lvSale";
            this.lvSale.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvSale.RightToLeftLayout = true;
            this.lvSale.Size = new System.Drawing.Size(980, 463);
            this.lvSale.TabIndex = 10;
            this.lvSale.UseCompatibleStateImageBehavior = false;
            this.lvSale.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSale_ColumnClick);
            this.lvSale.DoubleClick += new System.EventHandler(this.lvSale_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmnuSelectFactor,
            this.tmnuOpenFactor});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 48);
            // 
            // tmnuSelectFactor
            // 
            this.tmnuSelectFactor.Name = "tmnuSelectFactor";
            this.tmnuSelectFactor.Size = new System.Drawing.Size(142, 22);
            this.tmnuSelectFactor.Text = "انتخاب فاکتور";
            this.tmnuSelectFactor.Click += new System.EventHandler(this.tmnuSelectFactor_Click);
            // 
            // tmnuOpenFactor
            // 
            this.tmnuOpenFactor.Name = "tmnuOpenFactor";
            this.tmnuOpenFactor.Size = new System.Drawing.Size(142, 22);
            this.tmnuOpenFactor.Text = "بازکردن فاکتور";
            this.tmnuOpenFactor.Click += new System.EventHandler(this.tmnuOpenFactor_Click);
            // 
            // txtFactorNum
            // 
            this.txtFactorNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactorNum.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtFactorNum.Location = new System.Drawing.Point(0, 16);
            this.txtFactorNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFactorNum.Name = "txtFactorNum";
            this.txtFactorNum.ReadOnly = true;
            this.txtFactorNum.Size = new System.Drawing.Size(130, 21);
            this.txtFactorNum.TabIndex = 16;
            this.txtFactorNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFactorNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFactorNum_KeyPress);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "شماره فاکتور جاری";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام مشتری";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(980, 58);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجوی فاکتور";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtCustomerName);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(494, 17);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(483, 38);
            this.panel7.TabIndex = 19;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(0, 16);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(483, 21);
            this.txtCustomerName.TabIndex = 18;
            this.txtCustomerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtFactorNum);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(364, 17);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(130, 38);
            this.panel6.TabIndex = 19;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbFinStatus);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(279, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(85, 38);
            this.panel5.TabIndex = 19;
            // 
            // cmbFinStatus
            // 
            this.cmbFinStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFinStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinStatus.Enabled = false;
            this.cmbFinStatus.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cmbFinStatus.FormattingEnabled = true;
            this.cmbFinStatus.Items.AddRange(new object[] {
            "همه",
            "تسویه",
            "بدهکار",
            "بستانکار"});
            this.cmbFinStatus.Location = new System.Drawing.Point(0, 16);
            this.cmbFinStatus.Name = "cmbFinStatus";
            this.cmbFinStatus.Size = new System.Drawing.Size(85, 21);
            this.cmbFinStatus.TabIndex = 0;
            this.cmbFinStatus.SelectedIndexChanged += new System.EventHandler(this.cmbFinStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "وضعیت فاکتور";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbDay);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(209, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(70, 38);
            this.panel4.TabIndex = 19;
            // 
            // cmbDay
            // 
            this.cmbDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDay.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Location = new System.Drawing.Point(0, 16);
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.Size = new System.Drawing.Size(70, 21);
            this.cmbDay.TabIndex = 5;
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "روز";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbMonth);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(73, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 38);
            this.panel3.TabIndex = 19;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "همه",
            "فروردین (ماه اول)",
            "اردیبهشت (ماه دوم)",
            "خرداد (ماه سوم)",
            "تیر (ماه چهارم)",
            "مرداد (ماه پنجم)",
            "شهریور (ماه ششم)",
            "مهر (ماه هفتم)",
            "آبان (ماه هشتم)",
            "آذر (ماه نهم)",
            "دی (ماه دهم)",
            "بهمن (ماه یازدهم)",
            "اسفند (ماه دوازدهم)"});
            this.cmbMonth.Location = new System.Drawing.Point(0, 16);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(136, 21);
            this.cmbMonth.TabIndex = 7;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "ماه";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbYear);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 38);
            this.panel2.TabIndex = 19;
            // 
            // cmbYear
            // 
            this.cmbYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(0, 16);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(70, 21);
            this.cmbYear.TabIndex = 9;
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "سال";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelectAndClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 521);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 53);
            this.panel1.TabIndex = 18;
            // 
            // btnSelectAndClose
            // 
            this.btnSelectAndClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSelectAndClose.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnSelectAndClose.Location = new System.Drawing.Point(800, 0);
            this.btnSelectAndClose.Name = "btnSelectAndClose";
            this.btnSelectAndClose.Size = new System.Drawing.Size(180, 53);
            this.btnSelectAndClose.TabIndex = 0;
            this.btnSelectAndClose.Text = "انتخاب";
            this.btnSelectAndClose.UseVisualStyleBackColor = true;
            this.btnSelectAndClose.Click += new System.EventHandler(this.btnSelectAndClose_Click);
            // 
            // frmBrowsePrevFactors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 574);
            this.Controls.Add(this.lvSale);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmBrowsePrevFactors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فاکتورهای معوق - ";
            this.Load += new System.EventHandler(this.frmBrowsePrevFactors_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrowsePrevFactors_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvSale;
        private System.Windows.Forms.TextBox txtFactorNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFinStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectAndClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tmnuOpenFactor;
        private System.Windows.Forms.ToolStripMenuItem tmnuSelectFactor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}