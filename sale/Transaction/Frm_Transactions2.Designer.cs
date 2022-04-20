namespace SafaShop
{
    partial class Frm_Transactions2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Transactions2));
            this.cmsRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbTransFileName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTransFileCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbTransStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkStatusBar = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.ssStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslIncomesSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslExpensesSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslTotalBalance = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvTransFileList = new System.Windows.Forms.DataGridView();
            this.cmsRightClick.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.ssStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransFileList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsRightClick
            // 
            this.cmsRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenFile,
            this.tsmRenameFile,
            this.tsmDeleteFile});
            this.cmsRightClick.Name = "cmsRightClick";
            this.cmsRightClick.Size = new System.Drawing.Size(116, 70);
            // 
            // tsmOpenFile
            // 
            this.tsmOpenFile.Name = "tsmOpenFile";
            this.tsmOpenFile.Size = new System.Drawing.Size(115, 22);
            this.tsmOpenFile.Text = "نمایش";
            this.tsmOpenFile.Click += new System.EventHandler(this.tsmOpenFile_Click);
            // 
            // tsmRenameFile
            // 
            this.tsmRenameFile.Name = "tsmRenameFile";
            this.tsmRenameFile.Size = new System.Drawing.Size(115, 22);
            this.tsmRenameFile.Text = "تغییر نام";
            this.tsmRenameFile.Click += new System.EventHandler(this.tsmRenameFile_Click);
            // 
            // tsmDeleteFile
            // 
            this.tsmDeleteFile.Name = "tsmDeleteFile";
            this.tsmDeleteFile.Size = new System.Drawing.Size(115, 22);
            this.tsmDeleteFile.Text = "حذف";
            this.tsmDeleteFile.Click += new System.EventHandler(this.tsmDeleteFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.chkStatusBar);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(847, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbTransFileName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(286, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 38);
            this.panel3.TabIndex = 24;
            // 
            // cmbTransFileName
            // 
            this.cmbTransFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTransFileName.FormattingEnabled = true;
            this.cmbTransFileName.Location = new System.Drawing.Point(0, 16);
            this.cmbTransFileName.Name = "cmbTransFileName";
            this.cmbTransFileName.Size = new System.Drawing.Size(558, 21);
            this.cmbTransFileName.TabIndex = 0;
            this.cmbTransFileName.TextChanged += new System.EventHandler(this.cmbTransFileName_TextChanged);
            this.cmbTransFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbTransFileName_KeyPress);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(558, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "عنوان";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTransFileCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(219, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(67, 38);
            this.panel2.TabIndex = 23;
            // 
            // txtTransFileCode
            // 
            this.txtTransFileCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTransFileCode.Location = new System.Drawing.Point(0, 16);
            this.txtTransFileCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTransFileCode.Name = "txtTransFileCode";
            this.txtTransFileCode.Size = new System.Drawing.Size(67, 20);
            this.txtTransFileCode.TabIndex = 1;
            this.txtTransFileCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTransFileCode.TextChanged += new System.EventHandler(this.txtTransFileCode_TextChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "کد فایل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbTransStatus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(134, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 38);
            this.panel1.TabIndex = 22;
            // 
            // cmbTransStatus
            // 
            this.cmbTransStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTransStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransStatus.FormattingEnabled = true;
            this.cmbTransStatus.Items.AddRange(new object[] {
            "همه",
            "مثبت",
            "منفی",
            "صفر"});
            this.cmbTransStatus.Location = new System.Drawing.Point(0, 16);
            this.cmbTransStatus.Name = "cmbTransStatus";
            this.cmbTransStatus.Size = new System.Drawing.Size(85, 21);
            this.cmbTransStatus.TabIndex = 4;
            this.cmbTransStatus.SelectedIndexChanged += new System.EventHandler(this.cmbTransStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "تراز فایل";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chkStatusBar
            // 
            this.chkStatusBar.AutoSize = true;
            this.chkStatusBar.Location = new System.Drawing.Point(6, 0);
            this.chkStatusBar.Name = "chkStatusBar";
            this.chkStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkStatusBar.Size = new System.Drawing.Size(78, 17);
            this.chkStatusBar.TabIndex = 6;
            this.chkStatusBar.Text = "نوار وضعیت";
            this.chkStatusBar.UseVisualStyleBackColor = true;
            this.chkStatusBar.CheckedChanged += new System.EventHandler(this.chkStatusBar_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnNewFile);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(75, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(59, 38);
            this.panel5.TabIndex = 25;
            // 
            // btnNewFile
            // 
            this.btnNewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewFile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewFile.Image")));
            this.btnNewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewFile.Location = new System.Drawing.Point(0, 0);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(59, 38);
            this.btnNewFile.TabIndex = 2;
            this.btnNewFile.Text = "New";
            this.btnNewFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(3, 16);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(72, 38);
            this.panel4.TabIndex = 24;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 38);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ssStatusBar
            // 
            this.ssStatusBar.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslIncomesSum,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.tsslExpensesSum,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel3,
            this.tsslTotalBalance});
            this.ssStatusBar.Location = new System.Drawing.Point(0, 479);
            this.ssStatusBar.Name = "ssStatusBar";
            this.ssStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ssStatusBar.Size = new System.Drawing.Size(847, 22);
            this.ssStatusBar.SizingGrip = false;
            this.ssStatusBar.TabIndex = 21;
            this.ssStatusBar.Text = "statusStrip1";
            this.ssStatusBar.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(94, 17);
            this.toolStripStatusLabel1.Text = "جمع کل درآمدها:";
            // 
            // tsslIncomesSum
            // 
            this.tsslIncomesSum.Name = "tsslIncomesSum";
            this.tsslIncomesSum.Size = new System.Drawing.Size(14, 17);
            this.tsslIncomesSum.Text = "0";
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(99, 17);
            this.toolStripStatusLabel2.Text = "جمع کل هزینه ها:";
            // 
            // tsslExpensesSum
            // 
            this.tsslExpensesSum.Name = "tsslExpensesSum";
            this.tsslExpensesSum.Size = new System.Drawing.Size(14, 17);
            this.tsslExpensesSum.Text = "0";
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
            // dgvTransFileList
            // 
            this.dgvTransFileList.AllowUserToAddRows = false;
            this.dgvTransFileList.AllowUserToDeleteRows = false;
            this.dgvTransFileList.AllowUserToResizeRows = false;
            this.dgvTransFileList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransFileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransFileList.ColumnHeadersHeight = 25;
            this.dgvTransFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransFileList.ContextMenuStrip = this.cmsRightClick;
            this.dgvTransFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransFileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransFileList.Location = new System.Drawing.Point(0, 57);
            this.dgvTransFileList.Name = "dgvTransFileList";
            this.dgvTransFileList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTransFileList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvTransFileList.RowHeadersWidth = 70;
            this.dgvTransFileList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTransFileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransFileList.Size = new System.Drawing.Size(847, 444);
            this.dgvTransFileList.TabIndex = 120;
            this.dgvTransFileList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransFileList_CellDoubleClick);
            this.dgvTransFileList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTransFileList_CellFormatting);
            this.dgvTransFileList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTransFileList_DataBindingComplete);
            this.dgvTransFileList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTransFileList_KeyDown);
            this.dgvTransFileList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvTransFileList_MouseDown);
            // 
            // Frm_Transactions2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 501);
            this.Controls.Add(this.dgvTransFileList);
            this.Controls.Add(this.ssStatusBar);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.KeyPreview = true;
            this.Name = "Frm_Transactions2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فایل های تراکنش";
            this.Load += new System.EventHandler(this.Frm_Transactions_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Transactions_KeyDown);
            this.cmsRightClick.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ssStatusBar.ResumeLayout(false);
            this.ssStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransFileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkStatusBar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTransStatus;
        private System.Windows.Forms.TextBox txtTransFileCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTransFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip ssStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslIncomesSum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslExpensesSum;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslTotalBalance;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.ContextMenuStrip cmsRightClick;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmDeleteFile;
        private System.Windows.Forms.ToolStripMenuItem tsmRenameFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTransFileList;
    }
}