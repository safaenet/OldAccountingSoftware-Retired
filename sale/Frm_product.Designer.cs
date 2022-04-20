namespace SafaShop
{
    partial class Frm_product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_product));
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtSearchBy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkShowExtraInfo = new System.Windows.Forms.CheckBox();
            this.chkToggleBuyPrice = new System.Windows.Forms.CheckBox();
            this.chkToggleSellPrice = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lvProduct = new System.Windows.Forms.ListView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnCountAndPrices = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProduct
            // 
            this.txtProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProduct.Location = new System.Drawing.Point(0, 16);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(289, 20);
            this.txtProduct.TabIndex = 2;
            this.txtProduct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "کد کالا";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(77, 20);
            this.txtCode.TabIndex = 7;
            this.txtCode.TabStop = false;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // txtDetail
            // 
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(0, 16);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(202, 20);
            this.txtDetail.TabIndex = 6;
            this.txtDetail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSellPrice.Location = new System.Drawing.Point(0, 16);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(100, 20);
            this.txtSellPrice.TabIndex = 5;
            this.txtSellPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuyPrice.Location = new System.Drawing.Point(0, 16);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(100, 20);
            this.txtBuyPrice.TabIndex = 4;
            this.txtBuyPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduct_KeyPress);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "قیمت فروش";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "قیمت خرید";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "شرح کالا";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "توضیحات";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(150, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 51);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "ثبت";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 51);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "حذف";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.Image = global::Avazeh.Properties.Resources.New;
            this.btnNew.Location = new System.Drawing.Point(75, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 51);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "جدید";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 51);
            this.panel1.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtSearchBy);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(478, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(538, 51);
            this.panel11.TabIndex = 12;
            // 
            // txtSearchBy
            // 
            this.txtSearchBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchBy.Location = new System.Drawing.Point(0, 16);
            this.txtSearchBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchBy.Name = "txtSearchBy";
            this.txtSearchBy.Size = new System.Drawing.Size(538, 20);
            this.txtSearchBy.TabIndex = 0;
            this.txtSearchBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearchBy.TextChanged += new System.EventHandler(this.txtSearchBy_TextChanged);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(538, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "شرح جستجو";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbSearchBy);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(353, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 51);
            this.panel4.TabIndex = 11;
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(0, 16);
            this.cmbSearchBy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(125, 21);
            this.cmbSearchBy.TabIndex = 1;
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "بر اساس";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkShowExtraInfo);
            this.panel3.Controls.Add(this.chkToggleBuyPrice);
            this.panel3.Controls.Add(this.chkToggleSellPrice);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(225, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(128, 51);
            this.panel3.TabIndex = 10;
            // 
            // chkShowExtraInfo
            // 
            this.chkShowExtraInfo.AutoSize = true;
            this.chkShowExtraInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkShowExtraInfo.Location = new System.Drawing.Point(0, 34);
            this.chkShowExtraInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkShowExtraInfo.Name = "chkShowExtraInfo";
            this.chkShowExtraInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowExtraInfo.Size = new System.Drawing.Size(128, 17);
            this.chkShowExtraInfo.TabIndex = 18;
            this.chkShowExtraInfo.Text = "نمایش اطلاعات آماری";
            this.chkShowExtraInfo.UseVisualStyleBackColor = true;
            this.chkShowExtraInfo.CheckedChanged += new System.EventHandler(this.chkShowExtraInfo_CheckedChanged);
            // 
            // chkToggleBuyPrice
            // 
            this.chkToggleBuyPrice.AutoSize = true;
            this.chkToggleBuyPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkToggleBuyPrice.Location = new System.Drawing.Point(0, 17);
            this.chkToggleBuyPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkToggleBuyPrice.Name = "chkToggleBuyPrice";
            this.chkToggleBuyPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkToggleBuyPrice.Size = new System.Drawing.Size(128, 17);
            this.chkToggleBuyPrice.TabIndex = 10;
            this.chkToggleBuyPrice.Text = "نمایش قیمت خرید";
            this.chkToggleBuyPrice.UseVisualStyleBackColor = true;
            this.chkToggleBuyPrice.CheckedChanged += new System.EventHandler(this.chkToggleBuyPrice_CheckedChanged);
            // 
            // chkToggleSellPrice
            // 
            this.chkToggleSellPrice.AutoSize = true;
            this.chkToggleSellPrice.Checked = true;
            this.chkToggleSellPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkToggleSellPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkToggleSellPrice.Location = new System.Drawing.Point(0, 0);
            this.chkToggleSellPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkToggleSellPrice.Name = "chkToggleSellPrice";
            this.chkToggleSellPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkToggleSellPrice.Size = new System.Drawing.Size(128, 17);
            this.chkToggleSellPrice.TabIndex = 9;
            this.chkToggleSellPrice.Text = "نمایش قیمت فروش";
            this.chkToggleSellPrice.UseVisualStyleBackColor = true;
            this.chkToggleSellPrice.CheckedChanged += new System.EventHandler(this.chkToggleSellPrice_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "بارکد";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBarCode
            // 
            this.txtBarCode.AcceptsReturn = true;
            this.txtBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBarCode.Location = new System.Drawing.Point(0, 16);
            this.txtBarCode.MaxLength = 15;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(120, 20);
            this.txtBarCode.TabIndex = 3;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // lvProduct
            // 
            this.lvProduct.CheckBoxes = true;
            this.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProduct.GridLines = true;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(0, 91);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvProduct.RightToLeftLayout = true;
            this.lvProduct.Size = new System.Drawing.Size(1016, 356);
            this.lvProduct.TabIndex = 8;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProduct_ColumnClick);
            this.lvProduct.DoubleClick += new System.EventHandler(this.lvProduct_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 40);
            this.panel2.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtProduct);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(727, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(289, 40);
            this.panel5.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtBarCode);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(607, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(120, 40);
            this.panel6.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtBuyPrice);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(507, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(100, 40);
            this.panel7.TabIndex = 11;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtSellPrice);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(407, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(100, 40);
            this.panel8.TabIndex = 11;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtCount);
            this.panel12.Controls.Add(this.btnCountAndPrices);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(279, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(128, 40);
            this.panel12.TabIndex = 12;
            this.panel12.Visible = false;
            // 
            // txtCount
            // 
            this.txtCount.AcceptsReturn = true;
            this.txtCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCount.Location = new System.Drawing.Point(0, 16);
            this.txtCount.MaxLength = 15;
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(97, 20);
            this.txtCount.TabIndex = 3;
            // 
            // btnCountAndPrices
            // 
            this.btnCountAndPrices.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCountAndPrices.Location = new System.Drawing.Point(97, 16);
            this.btnCountAndPrices.Name = "btnCountAndPrices";
            this.btnCountAndPrices.Size = new System.Drawing.Size(31, 24);
            this.btnCountAndPrices.TabIndex = 20;
            this.btnCountAndPrices.Text = "...";
            this.btnCountAndPrices.UseVisualStyleBackColor = true;
            this.btnCountAndPrices.Click += new System.EventHandler(this.BtnCountAndPrices_Click);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "موجودی/تعداد";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtDetail);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(77, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(202, 40);
            this.panel9.TabIndex = 11;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txtCode);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(77, 40);
            this.panel10.TabIndex = 11;
            // 
            // Frm_product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 447);
            this.Controls.Add(this.lvProduct);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Frm_product";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "مشخصات کالا";
            this.Load += new System.EventHandler(this.Frm_product_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_product_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkToggleBuyPrice;
        private System.Windows.Forms.CheckBox chkToggleSellPrice;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.TextBox txtSearchBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkShowExtraInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBarCode;
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
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCountAndPrices;
    }
}