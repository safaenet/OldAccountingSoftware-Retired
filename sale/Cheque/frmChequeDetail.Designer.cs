namespace Avazeh.Cheque
{
    partial class frmChequeDetail
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCashYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCashMonth = new System.Windows.Forms.ComboBox();
            this.cmbCashDay = new System.Windows.Forms.ComboBox();
            this.cmbIssueDay = new System.Windows.Forms.ComboBox();
            this.cmbIssueMonth = new System.Windows.Forms.ComboBox();
            this.cmbIssueYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSerialNum = new System.Windows.Forms.TextBox();
            this.cmbBankName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSaveAndClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnCashDateToday = new System.Windows.Forms.Button();
            this.btnIssueDateToday = new System.Windows.Forms.Button();
            this.chkFromMySelf = new System.Windows.Forms.CheckBox();
            this.chkToMySelf = new System.Windows.Forms.CheckBox();
            this.gbChequeStatus = new System.Windows.Forms.GroupBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.cmbAddToTransactions = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cmbStatusMonth = new System.Windows.Forms.ComboBox();
            this.cmbStatusYear = new System.Windows.Forms.ComboBox();
            this.cmbStatusDay = new System.Windows.Forms.ComboBox();
            this.cmbStatusToday = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.cmbStatusName = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.radStatusBounced = new System.Windows.Forms.RadioButton();
            this.radStatusForwarded = new System.Windows.Forms.RadioButton();
            this.radStatusCashed = new System.Windows.Forms.RadioButton();
            this.radStatusNone = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnSaveAndNew = new System.Windows.Forms.Button();
            this.gbChequeStatus.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(292, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "مبدا*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAmount
            // 
            this.txtAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAmount.Location = new System.Drawing.Point(0, 0);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(292, 20);
            this.txtAmount.TabIndex = 4;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyUp);
            // 
            // cmbFrom
            // 
            this.cmbFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(50, 0);
            this.cmbFrom.MaxLength = 50;
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbFrom.Size = new System.Drawing.Size(242, 21);
            this.cmbFrom.Sorted = true;
            this.cmbFrom.TabIndex = 1;
            this.cmbFrom.Leave += new System.EventHandler(this.cmbFrom_Leave);
            // 
            // cmbTo
            // 
            this.cmbTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(50, 0);
            this.cmbTo.MaxLength = 50;
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbTo.Size = new System.Drawing.Size(242, 21);
            this.cmbTo.Sorted = true;
            this.cmbTo.TabIndex = 2;
            this.cmbTo.Leave += new System.EventHandler(this.cmbTo_Leave);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(292, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "مقصد*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbFor
            // 
            this.cmbFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFor.FormattingEnabled = true;
            this.cmbFor.Location = new System.Drawing.Point(0, 0);
            this.cmbFor.MaxLength = 80;
            this.cmbFor.Name = "cmbFor";
            this.cmbFor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbFor.Size = new System.Drawing.Size(292, 21);
            this.cmbFor.Sorted = true;
            this.cmbFor.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(292, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "بابت";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbCashYear
            // 
            this.cmbCashYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbCashYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashYear.FormattingEnabled = true;
            this.cmbCashYear.Location = new System.Drawing.Point(26, 0);
            this.cmbCashYear.Name = "cmbCashYear";
            this.cmbCashYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCashYear.Size = new System.Drawing.Size(51, 21);
            this.cmbCashYear.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(248, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "تاریخ سررسید*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Location = new System.Drawing.Point(292, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "مبلغ*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbCashMonth
            // 
            this.cmbCashMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCashMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashMonth.FormattingEnabled = true;
            this.cmbCashMonth.Items.AddRange(new object[] {
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
            this.cmbCashMonth.Location = new System.Drawing.Point(77, 0);
            this.cmbCashMonth.Name = "cmbCashMonth";
            this.cmbCashMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCashMonth.Size = new System.Drawing.Size(127, 21);
            this.cmbCashMonth.TabIndex = 6;
            this.cmbCashMonth.SelectedIndexChanged += new System.EventHandler(this.cmbCashMonth_SelectedIndexChanged);
            // 
            // cmbCashDay
            // 
            this.cmbCashDay.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbCashDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCashDay.FormattingEnabled = true;
            this.cmbCashDay.Location = new System.Drawing.Point(204, 0);
            this.cmbCashDay.Name = "cmbCashDay";
            this.cmbCashDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbCashDay.Size = new System.Drawing.Size(44, 21);
            this.cmbCashDay.TabIndex = 5;
            // 
            // cmbIssueDay
            // 
            this.cmbIssueDay.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbIssueDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIssueDay.FormattingEnabled = true;
            this.cmbIssueDay.Location = new System.Drawing.Point(204, 0);
            this.cmbIssueDay.Name = "cmbIssueDay";
            this.cmbIssueDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIssueDay.Size = new System.Drawing.Size(44, 21);
            this.cmbIssueDay.TabIndex = 9;
            // 
            // cmbIssueMonth
            // 
            this.cmbIssueMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbIssueMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIssueMonth.FormattingEnabled = true;
            this.cmbIssueMonth.Items.AddRange(new object[] {
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
            this.cmbIssueMonth.Location = new System.Drawing.Point(77, 0);
            this.cmbIssueMonth.Name = "cmbIssueMonth";
            this.cmbIssueMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIssueMonth.Size = new System.Drawing.Size(127, 21);
            this.cmbIssueMonth.TabIndex = 10;
            this.cmbIssueMonth.SelectedIndexChanged += new System.EventHandler(this.cmbIssueMonth_SelectedIndexChanged);
            // 
            // cmbIssueYear
            // 
            this.cmbIssueYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbIssueYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIssueYear.FormattingEnabled = true;
            this.cmbIssueYear.Location = new System.Drawing.Point(26, 0);
            this.cmbIssueYear.Name = "cmbIssueYear";
            this.cmbIssueYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbIssueYear.Size = new System.Drawing.Size(51, 21);
            this.cmbIssueYear.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(248, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "تاریخ صدور";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.Location = new System.Drawing.Point(260, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 25);
            this.label8.TabIndex = 24;
            this.label8.Text = "شماره سریال";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtSerialNum
            // 
            this.txtSerialNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerialNum.Location = new System.Drawing.Point(0, 0);
            this.txtSerialNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSerialNum.MaxLength = 20;
            this.txtSerialNum.Name = "txtSerialNum";
            this.txtSerialNum.Size = new System.Drawing.Size(260, 20);
            this.txtSerialNum.TabIndex = 13;
            this.txtSerialNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbBankName
            // 
            this.cmbBankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBankName.FormattingEnabled = true;
            this.cmbBankName.Location = new System.Drawing.Point(0, 0);
            this.cmbBankName.MaxLength = 50;
            this.cmbBankName.Name = "cmbBankName";
            this.cmbBankName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBankName.Size = new System.Drawing.Size(260, 21);
            this.cmbBankName.Sorted = true;
            this.cmbBankName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Location = new System.Drawing.Point(260, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "نام بانک";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Location = new System.Drawing.Point(260, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 76);
            this.label9.TabIndex = 28;
            this.label9.Text = "توضیحات";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDesc
            // 
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.Location = new System.Drawing.Point(0, 0);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(260, 76);
            this.txtDesc.TabIndex = 15;
            this.txtDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 41);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveAndClose.Location = new System.Drawing.Point(156, 0);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(107, 41);
            this.btnSaveAndClose.TabIndex = 22;
            this.btnSaveAndClose.Text = "Save && &Close";
            this.btnSaveAndClose.UseVisualStyleBackColor = true;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Location = new System.Drawing.Point(292, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 25);
            this.label11.TabIndex = 37;
            this.label11.Text = "شناسه";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Location = new System.Drawing.Point(0, 0);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(292, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TabStop = false;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCashDateToday
            // 
            this.btnCashDateToday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCashDateToday.Location = new System.Drawing.Point(0, 0);
            this.btnCashDateToday.Name = "btnCashDateToday";
            this.btnCashDateToday.Size = new System.Drawing.Size(26, 25);
            this.btnCashDateToday.TabIndex = 8;
            this.btnCashDateToday.Text = "T";
            this.btnCashDateToday.UseVisualStyleBackColor = true;
            this.btnCashDateToday.Click += new System.EventHandler(this.btnCashDateToday_Click);
            // 
            // btnIssueDateToday
            // 
            this.btnIssueDateToday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnIssueDateToday.Location = new System.Drawing.Point(0, 0);
            this.btnIssueDateToday.Name = "btnIssueDateToday";
            this.btnIssueDateToday.Size = new System.Drawing.Size(26, 25);
            this.btnIssueDateToday.TabIndex = 12;
            this.btnIssueDateToday.Text = "T";
            this.btnIssueDateToday.UseVisualStyleBackColor = true;
            this.btnIssueDateToday.Click += new System.EventHandler(this.btnIssueDateToday_Click);
            // 
            // chkFromMySelf
            // 
            this.chkFromMySelf.AutoSize = true;
            this.chkFromMySelf.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkFromMySelf.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkFromMySelf.Location = new System.Drawing.Point(0, 0);
            this.chkFromMySelf.Name = "chkFromMySelf";
            this.chkFromMySelf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkFromMySelf.Size = new System.Drawing.Size(50, 25);
            this.chkFromMySelf.TabIndex = 38;
            this.chkFromMySelf.Text = "خودم";
            this.chkFromMySelf.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkFromMySelf.UseVisualStyleBackColor = true;
            this.chkFromMySelf.CheckedChanged += new System.EventHandler(this.chkFromMySelf_CheckedChanged);
            // 
            // chkToMySelf
            // 
            this.chkToMySelf.AutoSize = true;
            this.chkToMySelf.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.chkToMySelf.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkToMySelf.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkToMySelf.Location = new System.Drawing.Point(0, 0);
            this.chkToMySelf.Name = "chkToMySelf";
            this.chkToMySelf.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkToMySelf.Size = new System.Drawing.Size(50, 25);
            this.chkToMySelf.TabIndex = 39;
            this.chkToMySelf.Text = "خودم";
            this.chkToMySelf.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkToMySelf.UseVisualStyleBackColor = true;
            this.chkToMySelf.CheckedChanged += new System.EventHandler(this.chkToMySelf_CheckedChanged);
            // 
            // gbChequeStatus
            // 
            this.gbChequeStatus.Controls.Add(this.panel15);
            this.gbChequeStatus.Controls.Add(this.panel14);
            this.gbChequeStatus.Controls.Add(this.panel13);
            this.gbChequeStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbChequeStatus.Enabled = false;
            this.gbChequeStatus.Location = new System.Drawing.Point(0, 320);
            this.gbChequeStatus.Name = "gbChequeStatus";
            this.gbChequeStatus.Size = new System.Drawing.Size(342, 86);
            this.gbChequeStatus.TabIndex = 37;
            this.gbChequeStatus.TabStop = false;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.cmbAddToTransactions);
            this.panel15.Controls.Add(this.label14);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(3, 63);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(336, 24);
            this.panel15.TabIndex = 51;
            // 
            // cmbAddToTransactions
            // 
            this.cmbAddToTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAddToTransactions.FormattingEnabled = true;
            this.cmbAddToTransactions.Location = new System.Drawing.Point(0, 0);
            this.cmbAddToTransactions.Name = "cmbAddToTransactions";
            this.cmbAddToTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbAddToTransactions.Size = new System.Drawing.Size(228, 21);
            this.cmbAddToTransactions.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Right;
            this.label14.Location = new System.Drawing.Point(228, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 24);
            this.label14.TabIndex = 43;
            this.label14.Text = "اضافه به ریزحساب";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cmbStatusMonth);
            this.panel14.Controls.Add(this.cmbStatusYear);
            this.panel14.Controls.Add(this.cmbStatusDay);
            this.panel14.Controls.Add(this.cmbStatusToday);
            this.panel14.Controls.Add(this.label12);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(3, 39);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(336, 24);
            this.panel14.TabIndex = 50;
            // 
            // cmbStatusMonth
            // 
            this.cmbStatusMonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatusMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusMonth.FormattingEnabled = true;
            this.cmbStatusMonth.Items.AddRange(new object[] {
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
            this.cmbStatusMonth.Location = new System.Drawing.Point(77, 0);
            this.cmbStatusMonth.Name = "cmbStatusMonth";
            this.cmbStatusMonth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbStatusMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusMonth.TabIndex = 18;
            this.cmbStatusMonth.SelectedIndexChanged += new System.EventHandler(this.cmbStatusMonth_SelectedIndexChanged);
            // 
            // cmbStatusYear
            // 
            this.cmbStatusYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStatusYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusYear.FormattingEnabled = true;
            this.cmbStatusYear.Location = new System.Drawing.Point(26, 0);
            this.cmbStatusYear.Name = "cmbStatusYear";
            this.cmbStatusYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbStatusYear.Size = new System.Drawing.Size(51, 21);
            this.cmbStatusYear.TabIndex = 19;
            // 
            // cmbStatusDay
            // 
            this.cmbStatusDay.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbStatusDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusDay.FormattingEnabled = true;
            this.cmbStatusDay.Location = new System.Drawing.Point(198, 0);
            this.cmbStatusDay.Name = "cmbStatusDay";
            this.cmbStatusDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbStatusDay.Size = new System.Drawing.Size(44, 21);
            this.cmbStatusDay.TabIndex = 17;
            // 
            // cmbStatusToday
            // 
            this.cmbStatusToday.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmbStatusToday.Location = new System.Drawing.Point(0, 0);
            this.cmbStatusToday.Name = "cmbStatusToday";
            this.cmbStatusToday.Size = new System.Drawing.Size(26, 24);
            this.cmbStatusToday.TabIndex = 20;
            this.cmbStatusToday.Text = "T";
            this.cmbStatusToday.UseVisualStyleBackColor = true;
            this.cmbStatusToday.Click += new System.EventHandler(this.cmbStatusToday_Click);
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Right;
            this.label12.Location = new System.Drawing.Point(242, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 24);
            this.label12.TabIndex = 30;
            this.label12.Text = "تاریخ*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.cmbStatusName);
            this.panel13.Controls.Add(this.label13);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(3, 16);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(336, 23);
            this.panel13.TabIndex = 44;
            // 
            // cmbStatusName
            // 
            this.cmbStatusName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatusName.FormattingEnabled = true;
            this.cmbStatusName.Location = new System.Drawing.Point(0, 0);
            this.cmbStatusName.MaxLength = 50;
            this.cmbStatusName.Name = "cmbStatusName";
            this.cmbStatusName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbStatusName.Size = new System.Drawing.Size(295, 21);
            this.cmbStatusName.Sorted = true;
            this.cmbStatusName.TabIndex = 40;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(295, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 23);
            this.label13.TabIndex = 41;
            this.label13.Text = "گیرنده";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radStatusBounced
            // 
            this.radStatusBounced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radStatusBounced.Location = new System.Drawing.Point(0, 0);
            this.radStatusBounced.Name = "radStatusBounced";
            this.radStatusBounced.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radStatusBounced.Size = new System.Drawing.Size(128, 19);
            this.radStatusBounced.TabIndex = 31;
            this.radStatusBounced.Text = "برگشت خورد";
            this.radStatusBounced.UseVisualStyleBackColor = true;
            this.radStatusBounced.CheckedChanged += new System.EventHandler(this.radStatusBounced_CheckedChanged);
            // 
            // radStatusForwarded
            // 
            this.radStatusForwarded.Dock = System.Windows.Forms.DockStyle.Right;
            this.radStatusForwarded.Location = new System.Drawing.Point(128, 0);
            this.radStatusForwarded.Name = "radStatusForwarded";
            this.radStatusForwarded.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radStatusForwarded.Size = new System.Drawing.Size(86, 19);
            this.radStatusForwarded.TabIndex = 42;
            this.radStatusForwarded.Text = "فروخته شد";
            this.radStatusForwarded.UseVisualStyleBackColor = true;
            this.radStatusForwarded.CheckedChanged += new System.EventHandler(this.radStatusForwarded_CheckedChanged);
            // 
            // radStatusCashed
            // 
            this.radStatusCashed.Dock = System.Windows.Forms.DockStyle.Right;
            this.radStatusCashed.Location = new System.Drawing.Point(214, 0);
            this.radStatusCashed.Name = "radStatusCashed";
            this.radStatusCashed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radStatusCashed.Size = new System.Drawing.Size(79, 19);
            this.radStatusCashed.TabIndex = 43;
            this.radStatusCashed.Text = "وصول شد";
            this.radStatusCashed.UseVisualStyleBackColor = true;
            this.radStatusCashed.CheckedChanged += new System.EventHandler(this.radStatusCashed_CheckedChanged);
            // 
            // radStatusNone
            // 
            this.radStatusNone.Checked = true;
            this.radStatusNone.Dock = System.Windows.Forms.DockStyle.Right;
            this.radStatusNone.Location = new System.Drawing.Point(293, 0);
            this.radStatusNone.Name = "radStatusNone";
            this.radStatusNone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.radStatusNone.Size = new System.Drawing.Size(49, 19);
            this.radStatusNone.TabIndex = 44;
            this.radStatusNone.TabStop = true;
            this.radStatusNone.Text = "هیچ";
            this.radStatusNone.UseVisualStyleBackColor = true;
            this.radStatusNone.CheckedChanged += new System.EventHandler(this.radStatusNone_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(263, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 41);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 25);
            this.panel1.TabIndex = 46;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbFrom);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chkFromMySelf);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 25);
            this.panel2.TabIndex = 47;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbTo);
            this.panel3.Controls.Add(this.chkToMySelf);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 25);
            this.panel3.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbFor);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 25);
            this.panel4.TabIndex = 47;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtAmount);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(342, 25);
            this.panel5.TabIndex = 47;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cmbCashMonth);
            this.panel6.Controls.Add(this.cmbCashYear);
            this.panel6.Controls.Add(this.cmbCashDay);
            this.panel6.Controls.Add(this.btnCashDateToday);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 125);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(342, 25);
            this.panel6.TabIndex = 47;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cmbIssueMonth);
            this.panel7.Controls.Add(this.cmbIssueYear);
            this.panel7.Controls.Add(this.cmbIssueDay);
            this.panel7.Controls.Add(this.btnIssueDateToday);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 150);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(342, 25);
            this.panel7.TabIndex = 47;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtSerialNum);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 175);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(342, 25);
            this.panel8.TabIndex = 47;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cmbBankName);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 200);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(342, 25);
            this.panel9.TabIndex = 47;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtDesc);
            this.panel10.Controls.Add(this.label9);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 225);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(342, 76);
            this.panel10.TabIndex = 48;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.radStatusBounced);
            this.panel11.Controls.Add(this.radStatusForwarded);
            this.panel11.Controls.Add(this.radStatusCashed);
            this.panel11.Controls.Add(this.radStatusNone);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 301);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(342, 19);
            this.panel11.TabIndex = 49;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnSaveAndClose);
            this.panel12.Controls.Add(this.btnDelete);
            this.panel12.Controls.Add(this.btnSaveAndNew);
            this.panel12.Controls.Add(this.btnSave);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 406);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(342, 41);
            this.panel12.TabIndex = 50;
            // 
            // btnSaveAndNew
            // 
            this.btnSaveAndNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSaveAndNew.Location = new System.Drawing.Point(80, 0);
            this.btnSaveAndNew.Name = "btnSaveAndNew";
            this.btnSaveAndNew.Size = new System.Drawing.Size(76, 41);
            this.btnSaveAndNew.TabIndex = 46;
            this.btnSaveAndNew.Text = "&Save && New";
            this.btnSaveAndNew.UseVisualStyleBackColor = true;
            this.btnSaveAndNew.Click += new System.EventHandler(this.BtnSaveAndNew_Click);
            // 
            // frmChequeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 447);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.gbChequeStatus);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel12);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmChequeDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جزییات چک";
            this.Load += new System.EventHandler(this.frmChequeDetail_Load);
            this.Shown += new System.EventHandler(this.frmChequeDetail_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChequeDetail_KeyDown);
            this.gbChequeStatus.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCashYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCashMonth;
        private System.Windows.Forms.ComboBox cmbCashDay;
        private System.Windows.Forms.ComboBox cmbIssueDay;
        private System.Windows.Forms.ComboBox cmbIssueMonth;
        private System.Windows.Forms.ComboBox cmbIssueYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSerialNum;
        private System.Windows.Forms.ComboBox cmbBankName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveAndClose;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCashDateToday;
        private System.Windows.Forms.Button btnIssueDateToday;
        private System.Windows.Forms.CheckBox chkFromMySelf;
        private System.Windows.Forms.CheckBox chkToMySelf;
        private System.Windows.Forms.GroupBox gbChequeStatus;
        private System.Windows.Forms.Button cmbStatusToday;
        private System.Windows.Forms.ComboBox cmbStatusDay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbStatusYear;
        private System.Windows.Forms.ComboBox cmbStatusMonth;
        private System.Windows.Forms.ComboBox cmbStatusName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radStatusNone;
        private System.Windows.Forms.RadioButton radStatusCashed;
        private System.Windows.Forms.RadioButton radStatusForwarded;
        private System.Windows.Forms.RadioButton radStatusBounced;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbAddToTransactions;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnSaveAndNew;
    }
}