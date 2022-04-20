namespace SafaShop
{
    partial class Frm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_main));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbNormalSale = new System.Windows.Forms.ToolStripButton();
            this.tsbSearchNormalFactors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDayOfWeek = new System.Windows.Forms.TextBox();
            this.txtMonthOfYear = new System.Windows.Forms.TextBox();
            this.chkBlinkTsbChequeList = new System.Windows.Forms.CheckBox();
            this.tmrChequeListBlink = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tsSecond = new System.Windows.Forms.ToolStrip();
            this.tsbProduct = new System.Windows.Forms.ToolStripButton();
            this.tsbCustomer = new System.Windows.Forms.ToolStripButton();
            this.tsbChequeList = new System.Windows.Forms.ToolStripButton();
            this.tsbDetails = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenSpecialFile = new System.Windows.Forms.ToolStripButton();
            this.tsbDB = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tsMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tsSecond.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNormalSale,
            this.tsbSearchNormalFactors,
            this.toolStripSeparator1});
            this.tsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsMain.Location = new System.Drawing.Point(2, 17);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(410, 87);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbNormalSale
            // 
            this.tsbNormalSale.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbNormalSale.Image = ((System.Drawing.Image)(resources.GetObject("tsbNormalSale.Image")));
            this.tsbNormalSale.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbNormalSale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNormalSale.Name = "tsbNormalSale";
            this.tsbNormalSale.Size = new System.Drawing.Size(62, 84);
            this.tsbNormalSale.Text = "فاکتور جدید";
            this.tsbNormalSale.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbNormalSale.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbNormalSale.ToolTipText = "فاکتور عادی جدید\r\nCtrl + N";
            this.tsbNormalSale.Click += new System.EventHandler(this.tsbSale_Click);
            // 
            // tsbSearchNormalFactors
            // 
            this.tsbSearchNormalFactors.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbSearchNormalFactors.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearchNormalFactors.Image")));
            this.tsbSearchNormalFactors.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearchNormalFactors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearchNormalFactors.Name = "tsbSearchNormalFactors";
            this.tsbSearchNormalFactors.Size = new System.Drawing.Size(92, 84);
            this.tsbSearchNormalFactors.Text = "فاکتورهای پیشین";
            this.tsbSearchNormalFactors.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbSearchNormalFactors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbSearchNormalFactors.ToolTipText = "فاکتورهای عادی پیشین\r\nCtrl + F";
            this.tsbSearchNormalFactors.Click += new System.EventHandler(this.tsbSeatchFactor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 87);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDate
            // 
            this.txtDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDate.Location = new System.Drawing.Point(296, 19);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(116, 21);
            this.txtDate.TabIndex = 1;
            this.txtDate.Text = "Date";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTime.Location = new System.Drawing.Point(196, 19);
            this.txtTime.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(100, 21);
            this.txtTime.TabIndex = 2;
            this.txtTime.Text = "Time";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDayOfWeek
            // 
            this.txtDayOfWeek.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDayOfWeek.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDayOfWeek.Location = new System.Drawing.Point(2, 19);
            this.txtDayOfWeek.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtDayOfWeek.Name = "txtDayOfWeek";
            this.txtDayOfWeek.ReadOnly = true;
            this.txtDayOfWeek.Size = new System.Drawing.Size(94, 21);
            this.txtDayOfWeek.TabIndex = 3;
            this.txtDayOfWeek.Text = "DayOfWeek";
            this.txtDayOfWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMonthOfYear
            // 
            this.txtMonthOfYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMonthOfYear.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtMonthOfYear.Location = new System.Drawing.Point(96, 19);
            this.txtMonthOfYear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtMonthOfYear.Name = "txtMonthOfYear";
            this.txtMonthOfYear.ReadOnly = true;
            this.txtMonthOfYear.Size = new System.Drawing.Size(100, 21);
            this.txtMonthOfYear.TabIndex = 4;
            this.txtMonthOfYear.Text = "MonthOfYear";
            this.txtMonthOfYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBlinkTsbChequeList
            // 
            this.chkBlinkTsbChequeList.AutoSize = true;
            this.chkBlinkTsbChequeList.Checked = true;
            this.chkBlinkTsbChequeList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBlinkTsbChequeList.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkBlinkTsbChequeList.Location = new System.Drawing.Point(168, 193);
            this.chkBlinkTsbChequeList.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkBlinkTsbChequeList.Name = "chkBlinkTsbChequeList";
            this.chkBlinkTsbChequeList.Size = new System.Drawing.Size(15, 14);
            this.chkBlinkTsbChequeList.TabIndex = 5;
            this.chkBlinkTsbChequeList.UseVisualStyleBackColor = true;
            // 
            // tmrChequeListBlink
            // 
            this.tmrChequeListBlink.Enabled = true;
            this.tmrChequeListBlink.Interval = 500;
            this.tmrChequeListBlink.Tick += new System.EventHandler(this.tmrChequeListBlink_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tsMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(414, 108);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فروش";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tsSecond);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox3.Location = new System.Drawing.Point(0, 108);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox3.Size = new System.Drawing.Size(414, 108);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // tsSecond
            // 
            this.tsSecond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsSecond.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbProduct,
            this.tsbCustomer,
            this.tsbChequeList,
            this.tsbDetails,
            this.tsbOpenSpecialFile,
            this.tsbDB,
            this.tsbAbout});
            this.tsSecond.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsSecond.Location = new System.Drawing.Point(2, 19);
            this.tsSecond.Name = "tsSecond";
            this.tsSecond.Size = new System.Drawing.Size(410, 85);
            this.tsSecond.TabIndex = 0;
            this.tsSecond.Text = "toolStrip1";
            // 
            // tsbProduct
            // 
            this.tsbProduct.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbProduct.Image = ((System.Drawing.Image)(resources.GetObject("tsbProduct.Image")));
            this.tsbProduct.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProduct.Name = "tsbProduct";
            this.tsbProduct.Size = new System.Drawing.Size(52, 82);
            this.tsbProduct.Text = "کالاها";
            this.tsbProduct.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbProduct.Click += new System.EventHandler(this.tsbProduct_Click);
            // 
            // tsbCustomer
            // 
            this.tsbCustomer.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbCustomer.Image = ((System.Drawing.Image)(resources.GetObject("tsbCustomer.Image")));
            this.tsbCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCustomer.Name = "tsbCustomer";
            this.tsbCustomer.Size = new System.Drawing.Size(52, 82);
            this.tsbCustomer.Text = "مشتریان";
            this.tsbCustomer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbCustomer.Click += new System.EventHandler(this.tsbCustomer_Click);
            // 
            // tsbChequeList
            // 
            this.tsbChequeList.BackColor = System.Drawing.SystemColors.Control;
            this.tsbChequeList.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbChequeList.Image = ((System.Drawing.Image)(resources.GetObject("tsbChequeList.Image")));
            this.tsbChequeList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbChequeList.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.tsbChequeList.Name = "tsbChequeList";
            this.tsbChequeList.Size = new System.Drawing.Size(68, 82);
            this.tsbChequeList.Text = "چک ها";
            this.tsbChequeList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbChequeList.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbChequeList.Click += new System.EventHandler(this.tsbChequeList_Click);
            // 
            // tsbDetails
            // 
            this.tsbDetails.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbDetails.Image")));
            this.tsbDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDetails.ImageTransparentColor = System.Drawing.Color.White;
            this.tsbDetails.Name = "tsbDetails";
            this.tsbDetails.Size = new System.Drawing.Size(68, 82);
            this.tsbDetails.Text = "ریز حساب ";
            this.tsbDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbDetails.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbDetails.Click += new System.EventHandler(this.tsbDetails_Click);
            // 
            // tsbOpenSpecialFile
            // 
            this.tsbOpenSpecialFile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tsbOpenSpecialFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenSpecialFile.Image")));
            this.tsbOpenSpecialFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOpenSpecialFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenSpecialFile.Name = "tsbOpenSpecialFile";
            this.tsbOpenSpecialFile.Size = new System.Drawing.Size(86, 82);
            this.tsbOpenSpecialFile.Tag = "Customized For Omid Bashjir";
            this.tsbOpenSpecialFile.Text = "ریز حساب دفتر";
            this.tsbOpenSpecialFile.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbOpenSpecialFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbOpenSpecialFile.Visible = false;
            this.tsbOpenSpecialFile.Click += new System.EventHandler(this.tsbOpenSpecialFile_Click);
            // 
            // tsbDB
            // 
            this.tsbDB.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbDB.Image = ((System.Drawing.Image)(resources.GetObject("tsbDB.Image")));
            this.tsbDB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDB.Name = "tsbDB";
            this.tsbDB.Size = new System.Drawing.Size(90, 82);
            this.tsbDB.Text = "تنظیمات نرم افزار";
            this.tsbDB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbDB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbDB.Click += new System.EventHandler(this.tsbDB_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(52, 82);
            this.tsbAbout.Text = "درباره ما";
            this.tsbAbout.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tsbAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.txtMonthOfYear);
            this.groupBox2.Controls.Add(this.txtDayOfWeek);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.groupBox2.Location = new System.Drawing.Point(0, 216);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox2.Size = new System.Drawing.Size(414, 45);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // Frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkBlinkTsbChequeList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Frm_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "سیستم فروش";
            this.Load += new System.EventHandler(this.Frm_main_Load);
            this.Shown += new System.EventHandler(this.Frm_main_Shown);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tsSecond.ResumeLayout(false);
            this.tsSecond.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbSearchNormalFactors;
        private System.Windows.Forms.ToolStripButton tsbNormalSale;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDayOfWeek;
        private System.Windows.Forms.TextBox txtMonthOfYear;
        private System.Windows.Forms.CheckBox chkBlinkTsbChequeList;
        private System.Windows.Forms.Timer tmrChequeListBlink;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip tsSecond;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripButton tsbProduct;
        private System.Windows.Forms.ToolStripButton tsbCustomer;
        private System.Windows.Forms.ToolStripButton tsbDetails;
        private System.Windows.Forms.ToolStripButton tsbChequeList;
        private System.Windows.Forms.ToolStripButton tsbOpenSpecialFile;
        private System.Windows.Forms.ToolStripButton tsbDB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

