namespace SafaShop
{
    partial class frmProductDetails
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
            this.lvProductPrices = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.pnlPriority = new System.Windows.Forms.Panel();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtProductDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlPriority.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvProductPrices
            // 
            this.lvProductPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProductPrices.HideSelection = false;
            this.lvProductPrices.Location = new System.Drawing.Point(0, 82);
            this.lvProductPrices.MultiSelect = false;
            this.lvProductPrices.Name = "lvProductPrices";
            this.lvProductPrices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvProductPrices.RightToLeftLayout = true;
            this.lvProductPrices.Size = new System.Drawing.Size(828, 142);
            this.lvProductPrices.TabIndex = 0;
            this.lvProductPrices.UseCompatibleStateImageBehavior = false;
            this.lvProductPrices.DoubleClick += new System.EventHandler(this.LvProductPrices_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 82);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSaveDetail);
            this.panel6.Controls.Add(this.pnlPriority);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 39);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(828, 39);
            this.panel6.TabIndex = 1;
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveDetail.Location = new System.Drawing.Point(0, 0);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(251, 39);
            this.btnSaveDetail.TabIndex = 7;
            this.btnSaveDetail.Text = "ذخیره";
            this.btnSaveDetail.UseVisualStyleBackColor = true;
            this.btnSaveDetail.Click += new System.EventHandler(this.BtnSaveDetail_Click);
            // 
            // pnlPriority
            // 
            this.pnlPriority.Controls.Add(this.cmbPriority);
            this.pnlPriority.Controls.Add(this.label8);
            this.pnlPriority.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlPriority.Location = new System.Drawing.Point(251, 0);
            this.pnlPriority.Name = "pnlPriority";
            this.pnlPriority.Size = new System.Drawing.Size(80, 39);
            this.pnlPriority.TabIndex = 8;
            // 
            // cmbPriority
            // 
            this.cmbPriority.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(0, 18);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(80, 21);
            this.cmbPriority.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "مقدار اولویت";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtPriority);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(331, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(102, 39);
            this.panel10.TabIndex = 6;
            // 
            // txtPriority
            // 
            this.txtPriority.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtPriority.Location = new System.Drawing.Point(0, 19);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(102, 20);
            this.txtPriority.TabIndex = 1;
            this.txtPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "اولویت";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtCount);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(433, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(140, 39);
            this.panel9.TabIndex = 5;
            // 
            // txtCount
            // 
            this.txtCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCount.Location = new System.Drawing.Point(0, 19);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(140, 20);
            this.txtCount.TabIndex = 1;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "تعداد";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtSellPrice);
            this.panel8.Controls.Add(this.label5);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(573, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(130, 39);
            this.panel8.TabIndex = 4;
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtSellPrice.Location = new System.Drawing.Point(0, 19);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(130, 20);
            this.txtSellPrice.TabIndex = 1;
            this.txtSellPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "قیمت فروش";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtBuyPrice);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(703, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(125, 39);
            this.panel7.TabIndex = 3;
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtBuyPrice.Location = new System.Drawing.Point(0, 19);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(125, 20);
            this.txtBuyPrice.TabIndex = 1;
            this.txtBuyPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "قیمت خرید";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(828, 39);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtProductName);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(251, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(496, 39);
            this.panel4.TabIndex = 2;
            // 
            // txtProductName
            // 
            this.txtProductName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtProductName.Location = new System.Drawing.Point(0, 19);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(496, 20);
            this.txtProductName.TabIndex = 1;
            this.txtProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(496, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "شرح کالا";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtProductDesc);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(251, 39);
            this.panel5.TabIndex = 3;
            // 
            // txtProductDesc
            // 
            this.txtProductDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtProductDesc.Location = new System.Drawing.Point(0, 19);
            this.txtProductDesc.Name = "txtProductDesc";
            this.txtProductDesc.ReadOnly = true;
            this.txtProductDesc.Size = new System.Drawing.Size(251, 20);
            this.txtProductDesc.TabIndex = 1;
            this.txtProductDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "توضیحات کالا";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtProductCode);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(747, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(81, 39);
            this.panel3.TabIndex = 0;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtProductCode.Location = new System.Drawing.Point(0, 19);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Size = new System.Drawing.Size(81, 20);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد کالا";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 224);
            this.Controls.Add(this.lvProductPrices);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Name = "frmProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "جزئیات کالا";
            this.Load += new System.EventHandler(this.FrmProductDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProductDetails_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnlPriority.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvProductPrices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtProductDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.Panel pnlPriority;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label8;
    }
}