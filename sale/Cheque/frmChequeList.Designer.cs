namespace Avazeh.Cheque
{
    partial class frmChequeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChequeList));
            this.lvChequeList = new System.Windows.Forms.ListView();
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbBuyer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkStatusBar = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNewCheque = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFromSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslToSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotalBalance = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmsRightClick.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvChequeList
            // 
            this.lvChequeList.ContextMenuStrip = this.cmsRightClick;
            this.lvChequeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChequeList.HideSelection = false;
            this.lvChequeList.Location = new System.Drawing.Point(0, 58);
            this.lvChequeList.MultiSelect = false;
            this.lvChequeList.Name = "lvChequeList";
            this.lvChequeList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvChequeList.RightToLeftLayout = true;
            this.lvChequeList.Size = new System.Drawing.Size(1009, 546);
            this.lvChequeList.TabIndex = 6;
            this.lvChequeList.UseCompatibleStateImageBehavior = false;
            this.lvChequeList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvChequeList_ColumnClick);
            this.lvChequeList.DoubleClick += new System.EventHandler(this.lvChequeList_DoubleClick);
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.tsmDelete});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(107, 48);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(106, 22);
            this.tsmOpen.Text = "نمایش";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(106, 22);
            this.tsmDelete.Text = "حذف";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.chkStatusBar);
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.btnNewCheque);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.panel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1009, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbBankName);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(277, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 39);
            this.panel4.TabIndex = 20;
            // 
            // cmbBankName
            // 
            this.cmbBankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Items.AddRange(new object[] {
            "همه",
            "وصول نشده",
            "وصول شده",
            "فروخته شده",
            "برگشت خورده"});
            this.cmbBankName.Location = new System.Drawing.Point(0, 16);
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.Size = new System.Drawing.Size(207, 21);
            this.cmbBankName.TabIndex = 15;
            this.cmbBankName.SelectedIndexChanged += new System.EventHandler(this.cmbBankName_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(207, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "نام بانک";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cmbBuyer);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(484, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(174, 39);
            this.panel5.TabIndex = 20;
            // 
            // cmbBuyer
            // 
            this.cmbBuyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBuyer.FormattingEnabled = true;
            this.cmbBuyer.Location = new System.Drawing.Point(0, 16);
            this.cmbBuyer.Name = "cmbBuyer";
            this.cmbBuyer.Size = new System.Drawing.Size(174, 21);
            this.cmbBuyer.TabIndex = 9;
            this.cmbBuyer.SelectedIndexChanged += new System.EventHandler(this.cmbBuyer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "خریدار چک";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbStatus);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(166, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 39);
            this.panel3.TabIndex = 20;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "همه",
            "وصول نشده",
            "وصول شده",
            "فروخته شده",
            "برگشت شده",
            "امروز به بعد"});
            this.cmbStatus.Location = new System.Drawing.Point(0, 16);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(111, 21);
            this.cmbStatus.TabIndex = 13;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "وضعیت";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkStatusBar
            // 
            this.chkStatusBar.AutoSize = true;
            this.chkStatusBar.Location = new System.Drawing.Point(12, 0);
            this.chkStatusBar.Name = "chkStatusBar";
            this.chkStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkStatusBar.Size = new System.Drawing.Size(78, 17);
            this.chkStatusBar.TabIndex = 20;
            this.chkStatusBar.Text = "نوار وضعیت";
            this.chkStatusBar.UseVisualStyleBackColor = true;
            this.chkStatusBar.CheckedChanged += new System.EventHandler(this.chkStatusBar_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbTo);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(658, 16);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(174, 39);
            this.panel6.TabIndex = 20;
            // 
            // cmbTo
            // 
            this.cmbTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(0, 16);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(174, 21);
            this.cmbTo.TabIndex = 9;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "مقصد";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnNewCheque
            // 
            this.btnNewCheque.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewCheque.Image = ((System.Drawing.Image)(resources.GetObject("btnNewCheque.Image")));
            this.btnNewCheque.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewCheque.Location = new System.Drawing.Point(97, 16);
            this.btnNewCheque.Name = "btnNewCheque";
            this.btnNewCheque.Size = new System.Drawing.Size(69, 39);
            this.btnNewCheque.TabIndex = 2;
            this.btnNewCheque.Text = "جدید";
            this.btnNewCheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewCheque.UseVisualStyleBackColor = true;
            this.btnNewCheque.Click += new System.EventHandler(this.btnNewCheque_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(3, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 39);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "بروزرسانی";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cmbFrom);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(832, 16);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(174, 39);
            this.panel7.TabIndex = 20;
            // 
            // cmbFrom
            // 
            this.cmbFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(0, 16);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(174, 21);
            this.cmbFrom.TabIndex = 7;
            this.cmbFrom.SelectedIndexChanged += new System.EventHandler(this.cmbFrom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "مبدا";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslFromSum,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.tsslToSum,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel3,
            this.tsslTotalBalance});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(14, 0, 2, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(1009, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatusLabel1.Text = "جمع چک های پرداختی:";
            // 
            // tsslFromSum
            // 
            this.tsslFromSum.Name = "tsslFromSum";
            this.tsslFromSum.Size = new System.Drawing.Size(14, 17);
            this.tsslFromSum.Text = "0";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel6.Text = "وصول نشده";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel4.Text = "||";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel2.Text = "جمع چک های دریافتی:";
            // 
            // tsslToSum
            // 
            this.tsslToSum.Name = "tsslToSum";
            this.tsslToSum.Size = new System.Drawing.Size(14, 17);
            this.tsslToSum.Text = "0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel7.Text = "وصول نشده";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(17, 17);
            this.toolStripStatusLabel5.Text = "||";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel3.Text = "تراز کل:";
            // 
            // tsslTotalBalance
            // 
            this.tsslTotalBalance.Name = "tsslTotalBalance";
            this.tsslTotalBalance.Size = new System.Drawing.Size(14, 17);
            this.tsslTotalBalance.Text = "0";
            // 
            // frmChequeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 604);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvChequeList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmChequeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست چک ها";
            this.Load += new System.EventHandler(this.frmChequeList_Load);
            this.Shown += new System.EventHandler(this.frmChequeList_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChequeList_KeyDown);
            this.cmsRightClick.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvChequeList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNewCheque;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslFromSum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslToSum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotalBalance;
        private System.Windows.Forms.CheckBox chkStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ComboBox cmbBuyer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
    }
}