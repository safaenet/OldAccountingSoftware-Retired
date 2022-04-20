namespace SafaShop
{
    partial class frmPrintCheque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintCheque));
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbDay = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnToday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtBearer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumInChar = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMonthOfYear = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDayOfWeek = new System.Windows.Forms.Label();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.btnSetNextNDays = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChYear = new System.Windows.Forms.Label();
            this.lblChMonth = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblChBearer = new System.Windows.Forms.Label();
            this.lblChDay = new System.Windows.Forms.Label();
            this.lblChAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbDay
            // 
            this.cmbDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDay, "cmbDay");
            this.cmbDay.FormattingEnabled = true;
            this.cmbDay.Name = "cmbDay";
            this.cmbDay.SelectedIndexChanged += new System.EventHandler(this.cmbDay_SelectedIndexChanged);
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbMonth, "cmbMonth");
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            resources.GetString("cmbMonth.Items"),
            resources.GetString("cmbMonth.Items1"),
            resources.GetString("cmbMonth.Items2"),
            resources.GetString("cmbMonth.Items3"),
            resources.GetString("cmbMonth.Items4"),
            resources.GetString("cmbMonth.Items5"),
            resources.GetString("cmbMonth.Items6"),
            resources.GetString("cmbMonth.Items7"),
            resources.GetString("cmbMonth.Items8"),
            resources.GetString("cmbMonth.Items9"),
            resources.GetString("cmbMonth.Items10"),
            resources.GetString("cmbMonth.Items11")});
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbYear, "cmbYear");
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.SelectedIndexChanged += new System.EventHandler(this.cmbYear_SelectedIndexChanged);
            // 
            // btnToday
            // 
            resources.ApplyResources(this.btnToday, "btnToday");
            this.btnToday.Name = "btnToday";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtMoney
            // 
            resources.ApplyResources(this.txtMoney, "txtMoney");
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            this.txtMoney.Enter += new System.EventHandler(this.txtMoney_Enter);
            this.txtMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoney_KeyPress);
            this.txtMoney.Leave += new System.EventHandler(this.txtMoney_Leave);
            // 
            // txtBearer
            // 
            resources.ApplyResources(this.txtBearer, "txtBearer");
            this.txtBearer.Name = "txtBearer";
            this.txtBearer.TextChanged += new System.EventHandler(this.txtBearer_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtNumInChar
            // 
            resources.ApplyResources(this.txtNumInChar, "txtNumInChar");
            this.txtNumInChar.Name = "txtNumInChar";
            this.txtNumInChar.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMonthOfYear);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblDayOfWeek);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lblMonthOfYear
            // 
            resources.ApplyResources(this.lblMonthOfYear, "lblMonthOfYear");
            this.lblMonthOfYear.Name = "lblMonthOfYear";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblDayOfWeek
            // 
            resources.ApplyResources(this.lblDayOfWeek, "lblDayOfWeek");
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            // 
            // nudDays
            // 
            resources.ApplyResources(this.nudDays, "nudDays");
            this.nudDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSetNextNDays
            // 
            resources.ApplyResources(this.btnSetNextNDays, "btnSetNextNDays");
            this.btnSetNextNDays.Name = "btnSetNextNDays";
            this.btnSetNextNDays.UseVisualStyleBackColor = true;
            this.btnSetNextNDays.Click += new System.EventHandler(this.btnSetNextNDays_Click);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblChYear);
            this.groupBox2.Controls.Add(this.lblChMonth);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblChBearer);
            this.groupBox2.Controls.Add(this.lblChDay);
            this.groupBox2.Controls.Add(this.lblChAmount);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // lblChYear
            // 
            resources.ApplyResources(this.lblChYear, "lblChYear");
            this.lblChYear.Name = "lblChYear";
            // 
            // lblChMonth
            // 
            resources.ApplyResources(this.lblChMonth, "lblChMonth");
            this.lblChMonth.Name = "lblChMonth";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // lblChBearer
            // 
            resources.ApplyResources(this.lblChBearer, "lblChBearer");
            this.lblChBearer.Name = "lblChBearer";
            // 
            // lblChDay
            // 
            resources.ApplyResources(this.lblChDay, "lblChDay");
            this.lblChDay.Name = "lblChDay";
            // 
            // lblChAmount
            // 
            resources.ApplyResources(this.lblChAmount, "lblChAmount");
            this.lblChAmount.Name = "lblChAmount";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // frmPrintCheque
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSetNextNDays);
            this.Controls.Add(this.nudDays);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumInChar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBearer);
            this.Controls.Add(this.txtMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbDay);
            this.Controls.Add(this.btnPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPrintCheque";
            this.Load += new System.EventHandler(this.frmPrintCheque_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintCheque_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbDay;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtBearer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumInChar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDayOfWeek;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Button btnSetNextNDays;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblMonthOfYear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblChBearer;
        private System.Windows.Forms.Label lblChDay;
        private System.Windows.Forms.Label lblChAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblChYear;
        private System.Windows.Forms.Label lblChMonth;
        private System.Windows.Forms.Label label6;
    }
}