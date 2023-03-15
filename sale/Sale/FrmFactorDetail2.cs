using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SafaShop
{
    public partial class FrmFactorDetail2 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string strToday = "";
        ////////////////////////////////////////////////////////////////////////////////////////////
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        cUserFunction cUF = new cUserFunction();
        public string facNum = "";
        string strCustomerCode = "";
        string strFloatCount; //Replacement for lblCount.
        string strCodeDetail = ""; //Replacement for lblCodeDetail.
        public string editNum = "";
        public Boolean history = false;
        Boolean blnCanLvItemCheck = false;
        Boolean blnAutoAddNewProduct = false;
        DataTable dtProductList = new DataTable();
        AutoCompleteStringCollection customerCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection productCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection cPriceCollection = new AutoCompleteStringCollection();
        DataTable dtCPrice;
        bool blnCanDuplicateInLv = false;
        bool blnCanEditFactor = true;
        bool blnShowPlusMinusButtonInsideGrid = false;
        public FrmFactorDetail2()
        {
            InitializeComponent();
            strToday = cUF.GetFormattedPersianDate(DateTime.Now);
        }

        Double CalcTotalPayment(string strFN)
        {
            string strda = "SELECT SUM(dbo.tbSalePayments.Amount) AS PaymentTotal FROM dbo.tbSalePayments WHERE FactorNum=" + strFN;
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0]["PaymentTotal"].ToString() == "")
                return 0;
            else
                return double.Parse(dt.Rows[0]["PaymentTotal"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
        }

        public string maxCode(string field, string tbName)
        {
            string uid = "";
            string strCmd = "SELECT MAX(" + field + ") as u_code FROM " + tbName;
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                uid = dt.Rows[0]["u_code"].ToString();
                Int64 i = Int64.Parse(uid.Substring(1), System.Globalization.CultureInfo.InvariantCulture) + 1;
                uid = "C" + i.ToString();
            }
            catch
            {
                uid = "C0";
            }
            return uid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedValue == null)
            {
                //MessageBox.Show("ابتدا نام مشتری را انتخاب نمایید", "btnSave_Click()");
                //return;
            }

            if (txtDate.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا تاریخ را وارد نمایید", "btnSave_Click()");
                return;
            }

            if (txtFactorNum.Text.Trim().Length == 0)
            {
                Int64 i64 = cUF.GetNextUpperCode("factorNum", "tbSale");
                if (i64 > 1)
                    txtFactorNum.Text = i64.ToString();
                else
                    txtFactorNum.Text = "111";
                //if (cmbCustomer.Tag == null || cmbCustomer.Tag.ToString() == "System.Data.DataRowView")
                if (cmbCustomer.SelectedValue == null || cmbCustomer.SelectedValue.ToString() == "System.Data.DataRowView")
                {
                    string strcmd2 = "INSERT INTO tbCustomer ([code], [name], [tell1]) Values"
                                   + "(@code, @name, @tell1)";
                    SqlCommand cmd2 = new SqlCommand(strcmd2, con);
                    string maxCustomer = cUF.GetNextUpperCode("code", "tbCustomer").ToString();
                    cmd2.Parameters.AddWithValue("@code", maxCustomer);
                    string sTemp = cmbCustomer.Text.Trim();
                    cmd2.Parameters.AddWithValue("@name", cmbCustomer.Text.Trim());
                    cmd2.Parameters.AddWithValue("@tell1", txtTelNum.Text.Trim());
                    try
                    {
                        cmd2.Connection.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Connection.Close();
                        strCustomerCode = maxCustomer;
                        initial_cmbCustomer();
                        cmbCustomer.SelectedValue = maxCustomer;
                        // cmbCustomer.Text = sTemp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btnSave_Click()");
                    }
                }
                string strcmd = "INSERT INTO tbSale ([customerCode], [time], [date], [factorNum], [Description])"
                    + " Values(@customerCode, @time, @date, @factornum, @desc)";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                // MessageBox.Show(cUF.maxCode("code", "tbProdut").ToString());
                cmd.Parameters.AddWithValue("@customerCode", cmbCustomer.SelectedValue.ToString().Trim());
                cmd.Parameters.AddWithValue("@time", txtTime.Text.Trim());
                //string d= txtDate.Text.Trim().Remove(5,1);
                //d=d.Remove(2,1);
                cmd.Parameters.AddWithValue("@date", txtDate.Text.Trim());
                cmd.Parameters.AddWithValue("@factornum", txtFactorNum.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    this.Text = cmbCustomer.Text + "-" + txtFactorNum.Text;
                    BuildDataAdapter(dataAdapter);
                    initial_dgvFactorDetail();
                    strCustomerCode = cmbCustomer.SelectedValue.ToString();
                    initial_cmbSellPrice();
                    //initial_cmbCustomer();
                    //Enables detail_eneter controls, Because factor is already saved.
                    gbProductSection.Enabled = true;
                    btnAddDelLastFactor.Enabled = true;
                    txtTelNum.ReadOnly = true;
                    cmbProduct.Select();
                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnSave_Click()");
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            else
            {
                //edit = true;
                if (cmbCustomer.SelectedValue.ToString().Trim() != strCustomerCode)
                {
                    DialogResult DRupdate = MessageBox.Show(this, "نام مشتری برای این فاکتور به نام جدید تغییر خواهد کرد. آیا ادامه میدهید؟", "btnSave_Click()", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (DRupdate == DialogResult.No) return;
                }
                string strcmd = "UPDATE tbSale SET [customerCode]=@customerCode," +
                    "[time]=@time," +
                    "[date]=@date, [Description]=@desc Where [factornum]=@factornum";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                cmd.Parameters.AddWithValue("@customerCode", cmbCustomer.SelectedValue.ToString().Trim());
                cmd.Parameters.AddWithValue("@time", txtTime.Text.Trim());
                cmd.Parameters.AddWithValue("@date", txtDate.Text.Trim());
                cmd.Parameters.AddWithValue("@factornum", txtFactorNum.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    strCustomerCode = cmbCustomer.SelectedValue.ToString();
                    //btnNew_Click(sender, e);
                    //clearTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnSave_Click()");
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            {//Get TellNum
                string strcmdGetTellNum = "SELECT [tell1] FROM tbCustomer WHERE [code]=@code";
                SqlCommand cmdGetTellNum = new SqlCommand(strcmdGetTellNum, con);
                cmdGetTellNum.Parameters.AddWithValue("@code", cmbCustomer.SelectedValue.ToString().Trim());
                DataTable dt = new DataTable();
                try
                {
                    cmdGetTellNum.Connection.Open();
                    dt.Load(cmdGetTellNum.ExecuteReader());
                    txtTelNum.Text = dt.Rows[0]["tell1"].ToString().Trim();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnSave_Click() - GetTellNum");
                }
                finally
                {
                    cmdGetTellNum.Connection.Close();
                }
            }

            facNum = txtFactorNum.Text;
        }

        private void initial_cmbSellPrice()
        {
            string strCCustomerCode = cmbCustomer.SelectedValue.ToString();
            string strda = "select ProductCode, Price from tbCustomerizedPrice WHERE CustomerCode=" + strCCustomerCode;
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            dtCPrice = new DataTable();
            da.Fill(dtCPrice);
        }

        private void initial_cmbProduct()
        {
            SqlCommand cmd = new SqlCommand("LoadAllProductListForComboBox", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            dtProductList.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dtProductList.AsEnumerable().Select(row => row.Field<string>("product")).ToArray();
            productCollection.AddRange(strAutoCompleteString);
            cmbProduct.DataSource = dtProductList;
            cmbProduct.DisplayMember = "product";
            cmbProduct.ValueMember = "code";
            cmbProduct.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbProduct.AutoCompleteCustomSource = productCollection;
            cmbProduct.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void initial_cmbCustomer()
        {
            SqlCommand cmd = new SqlCommand("LoadAllCustomerListForComboBox", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("name")).ToArray();
            customerCollection.AddRange(strAutoCompleteString);
            cmbCustomer.DataSource = dt;
            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "code";
            cmbCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbCustomer.AutoCompleteCustomSource = customerCollection;
            cmbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCustomer.SelectedIndex = 0;
        }

        private void Frm_sale_Load(object sender, EventArgs e)
        {
            dgvFactorDetail.DataSource = bindingSource1;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            if (cUF.IniReadValue("5", "1") == "1")
                blnAutoAddNewProduct = true;
            else
                blnAutoAddNewProduct = false;
            if (cUF.IniReadValue("7", "1") == "1")
                blnCanDuplicateInLv = true;
            else
                blnCanDuplicateInLv = false;
            if (cUF.IniReadValue("8", "3") == "1")
                blnCanEditFactor = true;
            else
                blnCanEditFactor = groupBox1.Enabled = gbProductSection.Enabled = btnSave.Enabled = btnDelete.Enabled = false;
            if (cUF.IniReadValue("7", "2") == "1")
                blnShowPlusMinusButtonInsideGrid = true;
            else blnShowPlusMinusButtonInsideGrid = false;
            try
            {
                pnlBuyPrice.Visible = false;
                initial_cmbProduct();
                initial_cmbCustomer();
                cUF.ChangeLanguage("fa");
                txtBuyPrice.Tag = "";
                if (facNum.Trim().Length > 0) //If Factor is loaded (Not new).
                {
                    txtFactorNum.Text = facNum;
                    BuildDataAdapter(dataAdapter);
                    initial_dgvFactorDetail();
                    initialTextbox2();
                    strCustomerCode = cmbCustomer.Tag.ToString();
                    txtTelNum.ReadOnly = true;
                    initial_cmbSellPrice();
                    //Enables detail_enter controls, Because factor is already saved.
                    gbProductSection.Enabled = blnCanEditFactor;
                    btnAddDelLastFactor.Enabled = blnCanEditFactor;
                    //
                    this.Text = cmbCustomer.Text.Trim() + "-" + txtFactorNum.Text.Trim();
                    cmbProduct.Select();
                }
                else
                    cmbCustomer.Select();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Frm_sale_Load()"); }
            //bindingSource1.ListChanged += BindingSource_ListChanged;
        }

        void initialTextbox2()
        {
            try
            {
                DataRow dr = cUF.LoadSalesFactorDetails(txtFactorNum.Text.Trim());
                cmbCustomer.Text = dr["name"].ToString().Trim();
                cmbCustomer.Tag = dr["customerCode"].ToString().Trim();
                txtTelNum.Text = dr["tell1"].ToString().Trim();
                txtDate.Text = dr["date"].ToString().Trim();
                txtTime.Text = dr["time"].ToString().Trim();
                txtGrandTotal.Text = dr["FactorSum"].ToString().Trim();
                txtLastFactorNum.Text = dr["PrevFactorNum"].ToString().Trim();
                txtLastFactorBalance.Text = dr["PrevTotalRemained"].ToString().Trim();
                txtGTPlusLastRemained.Text = dr["GTPlusPrevTotalRemained"].ToString().Trim();
                txtTotalPayment.Text = dr["TotalPayment"].ToString().Trim();
                txtTotalRemained.Text = dr["TotalRemained"].ToString().Trim();
                txtDescription.Text = dr["Description"].ToString().Trim();
                if (chkShowNetProfit.Checked)
                    txtNetProfit.Text = dr["NetProfit"].ToString().Trim();
                if (dr["PrevFactorNum"].ToString().Trim() != "")
                {
                    btnAddDelLastFactor.Text = "حذف";
                    btnAddDelLastFactor.Tag = "1";
                }
                else
                {
                    txtLastFactorNum.Text = "";
                    txtLastFactorBalance.Text = "0";
                    btnAddDelLastFactor.Text = "انتخاب";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "initialTextbox2()"); }
        }

        private void clearTxt()
        {
            txtFactorNum.Clear();
            txtFactorNum.Clear();
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            cmbSellPrice.Items.Clear();
            cmbSellPrice.Text = "";
            txtTime.Clear();
            txtDate.Clear();
            txtTelNum.Text = "";
            bindingSource1 = new BindingSource();
            cmbCustomer.Tag = null;
            cmbProduct.Tag = null;
            facNum = "";
            strCustomerCode = "";
            txtDescription.Text = "";
        }

        private void txtTime_Enter(object sender, EventArgs e)
        {
            if (txtTime.Text.Trim().Length == 0)
                txtTime.Text = cUF.getTime();
        }

        private void txtDate_Enter(object sender, EventArgs e)
        {
            if (txtDate.Text.Trim().Length == 0)
            {
                string date = cUF.getPersianDate(DateTime.Now);
                string year = date.Substring(0, 4);
                string month = date.Substring(4, 2);
                string day = date.Substring(6, 2);
                txtDate.Text = year + "/" + month + "/" + day;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtFactorNum.Text.Trim().Length > 0)
            {
                string strMessageText = "آیا مایل به حذف این فاکتور هستید ؟";
                string strMessageCation = "حذف فاکتور";
                DialogResult dr;
                dr = MessageBox.Show(this, strMessageText, strMessageCation, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign);
                if (dr == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DeleteFactorWithFactorNumber", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fac_Num", txtFactorNum.Text.Trim());
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        clearTxt();
                        txtGrandTotal.Text = "0";
                        this.Text = "فروش عمده";
                        gbProductSection.Enabled = false;
                        btnAddDelLastFactor.Enabled = false;
                        txtTelNum.ReadOnly = false;
                        facNum = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btnDelete_Click()");
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            else
                MessageBox.Show("لطفا ابتدا فاکتور را انتخاب کنید");


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsPrintMode.Show(ptLowerLeft);
        }

        private void PrintProcess(string strPrintMode)
        {
            if (txtFactorNum.Text.Trim().Length > 0)
                cUF.PrintSalesFactor(txtFactorNum.Text.Trim(), strPrintMode, chkPrintDate.Checked, txtTotalPayment.Text, txtLastFactorBalance.Text, txtLastFactorNum.Text);
            else
                MessageBox.Show("لطفا ابتدا فاکتور را انتخاب کنید", "PrintProcess()");
        }

        private void clearDetail()
        {
            strCodeDetail = "";
            txtRawCount.Clear();
            txtBuyPrice.Clear();
            cmbSellPrice.Items.Clear();
            cmbSellPrice.Text = "";
            //chkAddToFirst.Checked = false;
            txtTotal.Clear();
            strFloatCount = "";
            cmbSellPrice.BackColor = SystemColors.Window;
            cmbProduct.Tag = null;
            cmbProduct.SelectedIndex = -1;
            chkTahvil.Checked = false;
        }

        private void AddNewCustomPrice()
        {
            if (cmbSellPrice.Text.Trim() == "0")
                return;
            string strcmd;
            SqlCommand cmd;
            strcmd = "DELETE FROM tbCustomerizedPrice WHERE CustomerCode=@cc AND ProductCode=@pc";
            cmd = new SqlCommand(strcmd, con);
            cmd.Parameters.AddWithValue("@cc", cmbCustomer.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@pc", cmbProduct.SelectedValue.ToString());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            strcmd = "INSERT INTO tbCustomerizedPrice (CustomerCode, ProductCode, Price) VALUES (@cc, @pc, @p)";
            cmd = new SqlCommand(strcmd, con);
            cmd.Parameters.AddWithValue("@cc", cmbCustomer.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@pc", cmbProduct.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@p", cmbSellPrice.Text.Trim());
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            initial_cmbSellPrice();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFactorNum.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا ابتدا فاکتور را ثبت نمایید", "خطا");
                btnSave.Select();
                return;
            }
            txtCount_Leave(sender, e);
            #region AutoAddNewProduct
            if (cmbProduct.SelectedValue == null || cmbProduct.SelectedValue.ToString().Trim() == "System.Data.DataRowView")
            {
                if (!blnAutoAddNewProduct)
                    return;
                DialogResult dr = MessageBox.Show("این کالا در لیست کالا موجود نیست، آیا اضافه شود؟", "اضافه کردن کالا", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No) return;
                string strcmd2 = "INSERT INTO tbProduct (product, code, sellPrice, BarCode) Values"
                + "(@product, @code, @sellPrice, @barcode)";
                SqlCommand cmd2 = new SqlCommand(strcmd2, con);
                cmd2.Parameters.AddWithValue("@product", cmbProduct.Text.Trim());
                string strMaxCode = cUF.GetNextUpperCode("code", "tbProduct").ToString();
                cmd2.Parameters.AddWithValue("@code", strMaxCode);
                cmd2.Parameters.AddWithValue("@sellPrice", cmbSellPrice.Text.Trim());
                cmd2.Parameters.AddWithValue("@barcode", txtBarCode.Text.Trim());
                try
                {
                    cmd2.Connection.Open();

                    cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();

                    initial_cmbProduct();
                    cmbProduct.SelectedValue = strMaxCode;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnAdd_Click()");
                }
            }
            #endregion
            #region CustomPrice
            try
            {
                if (cmbSellPrice.Text != cmbSellPrice.Items[0].ToString())
                    AddNewCustomPrice();
            }
            catch { }
            string strda = "SELECT buyprice "
                      + " FROM dbo.tbProduct " +
                     "   WHERE code=" + cmbProduct.SelectedValue.ToString().Trim();
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String strOriginalBuyPrice = dt.Rows[0]["buyprice"].ToString().Trim();
            #endregion
            string strProductCode = cmbProduct.SelectedValue.ToString().Trim();
            string strRawCount = txtRawCount.Text.Trim();
            strRawCount= (strRawCount == "") ? "0" : strRawCount;
            strFloatCount = (strFloatCount == null) ? "0" : strFloatCount;
            string strBuyPrice;
            if (chkShowNetProfit.Checked && txtBuyPrice.Text != "")
                strBuyPrice = txtBuyPrice.Text.Trim();
            else
                strBuyPrice = strOriginalBuyPrice;
            strBuyPrice = (strBuyPrice == "") ? "0" : strBuyPrice;
            string strSellPrice = cmbSellPrice.Text.Trim();
            strSellPrice = (strSellPrice == "") ? "0" : strSellPrice;
            string strFactorNumber = txtFactorNum.Text.Trim();
            string strProductRecordCode;
            string strDateAdded = cUF.GetFormattedPersianDate(DateTime.Now);
            string strTimeAdded = cUF.getTime();
            bool blnDuplicateIsFound = false;
            string strDuplicateCount = "";
            string strDuplicateRCode = "";
            string strDuplicateBP = "";
            string strDuplicateSP = "";
            if (!blnCanDuplicateInLv)
            {
                DataRow[] drFindDuplicate = (bindingSource1.DataSource as DataTable).Select("productCode = " + cmbProduct.SelectedValue.ToString());
                if (drFindDuplicate.Length != 0)
                {
                    blnDuplicateIsFound = true;
                    strDuplicateCount = drFindDuplicate[0]["count"].ToString();
                    strDuplicateRCode = drFindDuplicate[0]["code"].ToString();
                    strDuplicateBP = drFindDuplicate[0]["buyprice"].ToString();
                    strDuplicateSP = drFindDuplicate[0]["price"].ToString();
                }
            }
            #region INSERT INTO tbSaleDetail
            if (strCodeDetail.Length == 0)
            {
                if (!blnCanDuplicateInLv && blnDuplicateIsFound)
                {
                    strRawCount = (double.Parse(strDuplicateCount, System.Globalization.CultureInfo.InvariantCulture) + 1).ToString();
                    this.strFloatCount = strRawCount;
                    UpdateTbSaleDetail(strProductCode, cmbProduct.Text, strFloatCount, strRawCount, strDuplicateBP, strDuplicateSP, strFactorNumber, strDuplicateRCode);
                }
                else
                {
                    if (chkAddToFirst.Checked == true)
                        strProductRecordCode = cUF.GetNextLowerCode("code", "tbSaleDetail").ToString();
                    else
                        strProductRecordCode = cUF.GetNextUpperCode("code", "tbSaleDetail").ToString();
                    InsertIntoTbSaleDetail(strProductCode, cmbProduct.Text, strFloatCount, strRawCount, strBuyPrice, strSellPrice, strFactorNumber, strProductRecordCode, strDateAdded, strTimeAdded);
                    TryUpdateBuyPrice(strOriginalBuyPrice);
                }
                initial_cmbProduct();
            }
            #endregion
            #region UPDATE tbSaleDetail
            else
            {
                strProductRecordCode = strCodeDetail.Trim();
                UpdateTbSaleDetail(strProductCode, cmbProduct.Text, strFloatCount, strRawCount, strBuyPrice, strSellPrice, strFactorNumber, strProductRecordCode);
            }
            #endregion
            cmbProduct.Select();
            initialTextbox2();
            clearDetail();
        }

        void InsertIntoTbSaleDetail(string PC, string PN, string StrFloatCount, string StrRawCount, string BP, string SP, string FN, string PCode, string AD, string AT)
        {
            
            DataRow dr = ((DataTable)bindingSource1.DataSource).NewRow();
            dr["code"] = PCode;
            dr["tahvil"] = chkTahvil.Checked;
            dr["factorNum"] = FN;
            dr["productCode"] = PC;
            dr["product"] = PN;
            dr["Count"] = StrFloatCount;
            dr["strCount"] = StrRawCount;
            dr["buyprice"] = BP;
            dr["price"] = SP;
            dr["total1"] = (double.Parse(SP, System.Globalization.CultureInfo.InvariantCulture) * double.Parse(StrFloatCount, System.Globalization.CultureInfo.InvariantCulture)).ToString();
            dr["AddedDate"] = AD;
            dr["AddedTime"] = AT;
            ((DataTable)bindingSource1.DataSource).Rows.Add(dr);
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        void UpdateTbSaleDetail(string PC, string PN, string StrFloatCount, string StrRawCount, string BP, string SP, string FN, string RCode)
        {
            DataRow[] dr = (bindingSource1.DataSource as DataTable).Select("code = " + RCode);
            if (dr.Length == 0)
                return;
            dr[0]["tahvil"] = chkTahvil.Checked;
            dr[0]["productCode"] = PC;
            dr[0]["product"] = PN;
            dr[0]["Count"] = StrFloatCount;
            dr[0]["strCount"] = StrRawCount;
            dr[0]["buyprice"] = BP;
            dr[0]["price"] = SP;
            dr[0]["total1"] = double.Parse(SP, System.Globalization.CultureInfo.InvariantCulture) * double.Parse(StrFloatCount, System.Globalization.CultureInfo.InvariantCulture);
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        void TryUpdateBuyPrice(String strOriginalBuyPrice)
        {
            if (!chkShowNetProfit.Checked)
                return;
            if (strOriginalBuyPrice == txtBuyPrice.Text.Trim())
                return;
            DialogResult dr;
            String strMessage = "قیمت خرید جدید با قیمت خرید ثبت شده قبلی متفاوت است. آیا مایل به بروزرسانی قیمت خرید این کالا هستید؟" +
                "\nقیمت خرید قبلی: " + cUF.split_space(strOriginalBuyPrice, ",") +
                "\nقیمت خرید جدید: " + cUF.split_space(txtBuyPrice.Text.Trim(), ",");
            dr = MessageBox.Show(strMessage, "بروزرسانی قیمت", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                string strcmd = "UPDATE tbProduct SET tbProduct.[buyprice]=@value1 WHERE tbProduct.[code]=@value2";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                cmd.Parameters.AddWithValue("@value1", txtBuyPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@value2", cmbProduct.SelectedValue.ToString().Trim());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        private void initial_dgvFactorDetail()
        {
            try
            {
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                bindingSource1.DataSource = dt;
                dgvFactorDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                string[] strFaCol = { "ردیف", "کد", "شماره فاکتور", "کدکالا", "ت", "کالا", "تعداد", "تعداد", "ق خرید", "قیمت", "قیمت کل", "تاریخ", "ساعت" };
                string[] strCol = { "RowNumber", "code", "factorNum", "productCode", "tahvil", "product", "Count", "strCount", "buyprice", "price", "total1", "AddedDate", "AddedTime" };
                int[] ColWidth = { 0, 0, 0, 0, 20, 300, 0, 100, 0, 120, 120, 80, 80 };
                for (int i = 0; i < ColWidth.Length; i++)
                {
                    dgvFactorDetail.Columns[strCol[i]].HeaderText = strFaCol[i].ToString();
                    dgvFactorDetail.Columns[strCol[i]].Width = ColWidth[i];
                    dgvFactorDetail.Columns[strCol[i]].Visible = Convert.ToBoolean(ColWidth[i]);
                }
                //CalculateIncomesAndExpenses();
                dgvFactorDetail.Sort(dgvFactorDetail.Columns["code"], System.ComponentModel.ListSortDirection.Descending);
                dgvFactorDetail.Columns["buyprice"].DefaultCellStyle.Format = "N0";
                dgvFactorDetail.Columns["price"].DefaultCellStyle.Format = "N0";
                dgvFactorDetail.Columns["total1"].DefaultCellStyle.Format = "N0";
                if (blnShowPlusMinusButtonInsideGrid)
                {
                    DataGridViewButtonColumn dgvbtnColumnPlus = new DataGridViewButtonColumn();
                    dgvbtnColumnPlus.Name = "dgvbtnColumnPlus";
                    dgvbtnColumnPlus.Text = "+";
                    dgvbtnColumnPlus.UseColumnTextForButtonValue = true;
                    dgvbtnColumnPlus.Width = 25;
                    dgvbtnColumnPlus.ToolTipText = "اضافه کردن 1 عدد به تعداد";
                    dgvbtnColumnPlus.HeaderText = "";
                    dgvFactorDetail.Columns.Insert(dgvFactorDetail.Columns.Count, dgvbtnColumnPlus);

                    DataGridViewButtonColumn dgvbtnColumnMinus = new DataGridViewButtonColumn();
                    dgvbtnColumnMinus.Name = "dgvbtnColumnMinus";
                    dgvbtnColumnMinus.Text = "-";
                    dgvbtnColumnMinus.UseColumnTextForButtonValue = true;
                    dgvbtnColumnMinus.Width = 25;
                    dgvbtnColumnMinus.ToolTipText = "کم کردن 1 عدد از تعداد";
                    dgvbtnColumnMinus.HeaderText = "";
                    dgvFactorDetail.Columns.Insert(dgvFactorDetail.Columns.Count, dgvbtnColumnMinus);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initial_lvDetail2()");
            }
        }

        void BuildDataAdapter(SqlDataAdapter da)
        {
            SqlCommand cmd;
            SqlParameter parameter;
            #region Build Select Command
            cmd = new SqlCommand("LoadFactorSaleDetails", con); //Load the product sale list.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fac_Num", txtFactorNum.Text.Trim());
            da.SelectCommand = cmd;
            #endregion

            #region Build Insert Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTbSaleDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 1);
            cmd.Parameters.Add("@productCode", SqlDbType.BigInt, 64, "productCode");
            cmd.Parameters.Add("@count", SqlDbType.Float, 64, "count");
            cmd.Parameters.Add("@pTahvil", SqlDbType.Bit, 1, "tahvil");
            cmd.Parameters.Add("@strcount", SqlDbType.NVarChar, 100, "strCount");
            cmd.Parameters.Add("@buyprice", SqlDbType.BigInt, 64, "buyprice");
            cmd.Parameters.Add("@price", SqlDbType.BigInt, 64, "price");
            cmd.Parameters.Add("@factornum", SqlDbType.BigInt, 64, "factornum");
            cmd.Parameters.Add("@code", SqlDbType.BigInt, 64, "code");
            cmd.Parameters.Add("@addeddate", SqlDbType.Char, 10, "AddedDate");
            cmd.Parameters.Add("@addedtime", SqlDbType.Char, 8, "AddedTime");
            dataAdapter.InsertCommand = cmd;
            #endregion

            #region Build Update Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTbSaleDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 2);
            cmd.Parameters.Add("@productCode", SqlDbType.BigInt, 64, "productCode");
            cmd.Parameters.Add("@count", SqlDbType.Float, 64, "count");
            cmd.Parameters.Add("@pTahvil", SqlDbType.Bit, 1, "tahvil");
            cmd.Parameters.Add("@strcount", SqlDbType.NVarChar, 100, "strCount");
            cmd.Parameters.Add("@buyprice", SqlDbType.BigInt, 64, "buyprice");
            cmd.Parameters.Add("@price", SqlDbType.BigInt, 64, "price");
            cmd.Parameters.Add("@factornum", SqlDbType.BigInt, 64, "factornum");
            parameter = cmd.Parameters.Add("@code", SqlDbType.BigInt, 64, "code");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand = cmd;
            #endregion

            #region Build Delete Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTbSaleDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 3); //Runs Delete Command
            parameter = cmd.Parameters.Add("@code", SqlDbType.BigInt, 64, "code");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.DeleteCommand = cmd;
            #endregion
        }

        private void txtCount_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] arrNum;
                double a = 0;
                if (!txtRawCount.Text.Contains("+") && !txtRawCount.Text.Contains("*"))
                    a = double.Parse(txtRawCount.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                else if (txtRawCount.Text.Contains("+"))
                {
                    arrNum = txtRawCount.Text.Split('+');
                    a = 0;
                    for (int i = 0; i < arrNum.Length; i++)
                    {
                        a += double.Parse(arrNum[i], System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                else if (txtRawCount.Text.Contains("*"))
                {
                    arrNum = txtRawCount.Text.Split('*');
                    a = 1;
                    for (int i = 0; i < arrNum.Length; i++)
                    {
                        a *= double.Parse(arrNum[i], System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
                strFloatCount = a.ToString();
            }
            catch
            {
                //MessageBox.Show(ex.Message, "txtCount_Leave()");
            }
            cUF.ChangeLanguage("fa");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTxt();
            txtTelNum.ReadOnly = false;
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTbSaleDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (dgvFactorDetail.SelectedRows.Count == 0) return;
                DialogResult res = MessageBox.Show("آیا از حذف این مورد/موارد اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.No) return;
                foreach (DataGridViewRow row in dgvFactorDetail.SelectedRows)
                {
                    if (!row.IsNewRow)
                        dgvFactorDetail.Rows.Remove(row);
                }
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
                initialTextbox2();
            } catch{ }
        }

        private void txtCount_Enter(object sender, EventArgs e)
        {
            cUF.ChangeLanguage("en");
            if (txtRawCount.Text.Trim().Length == 0)
            {
                txtRawCount.Text = "1";
            }
            txtRawCount.SelectAll();

            //if (cmbSellPrice.Items.Count == 1)
            //{
            //    DataRow[] dr = dtCPrice.Select("ProductCode=" + cmbProduct.SelectedValue.ToString());
            //    if (dr.Length > 0)
            //    {
            //        if (dr[0]["Price"].ToString() != cmbSellPrice.Text)
            //            cmbSellPrice.Items.Add(dr[0]["Price"]);
            //        cmbSellPrice.DroppedDown = true;
            //    }
            //}
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // cmbCustomer.Tag = cmbCustomer.SelectedValue.ToString();
                if (txtDate.Text.Trim().Length == 0)
                {
                    string date = cUF.getPersianDate(DateTime.Now);
                    string year = date.Substring(0, 4);
                    string month = date.Substring(4, 2);
                    string day = date.Substring(6, 2);
                    txtDate.Text = year + "/" + month + "/" + day;
                }
                if (txtTime.Text.Trim().Length == 0)
                    txtTime.Text = cUF.getTime();
            }
            catch
            { }
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // cmbProduct.Tag = cmbProduct.SelectedValue.ToString();
                string strda = "SELECT buyprice, sellPrice "
                  + " FROM dbo.tbProduct " +
                 "   where code=" + cmbProduct.SelectedValue.ToString().Trim();
                SqlDataAdapter da = new SqlDataAdapter(strda, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbSellPrice.Items.Clear();
                cmbSellPrice.Items.Add(dt.Rows[0]["sellPrice"].ToString().Trim());
                cmbSellPrice.Text = dt.Rows[0]["sellPrice"].ToString().Trim();
                if (chkShowNetProfit.Checked)
                    txtBuyPrice.Text = dt.Rows[0]["buyprice"].ToString().Trim();
                txtBuyPrice.Tag = dt.Rows[0]["buyprice"].ToString().Trim();
                if (cmbSellPrice.Items.Count == 1)
                {
                    DataRow[] dr = dtCPrice.Select("ProductCode=" + cmbProduct.SelectedValue.ToString());
                    if (dr.Length > 0)
                    {
                        //if (dr[0]["Price"].ToString() != cmbSellPrice.Text)
                        //    cmbSellPrice.Items.Add(dr[0]["Price"]);
                        //cmbSellPrice.DroppedDown = true;
                        cmbSellPrice.BackColor = Color.Silver;
                    }
                }
            }
            catch { }
        }

        private void cmbCustomer_Leave(object sender, EventArgs e)
        {
            try
            {
                txtDate_Enter(sender, e);
                txtTime_Enter(sender, e);
                cmbCustomer.Tag = cmbCustomer.SelectedValue.ToString();
            }
            catch
            { }

        }

        private void cmbSellPrice_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbSellPrice.Text.Trim().Length > 0)
                {
                    Int64 i = Int64.Parse(cmbSellPrice.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture) * Int64.Parse(txtRawCount.Text.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                    txtTotal.Text = i.ToString();
                }
            }
            catch { }
        }

        private void cmbSellPrice_Enter_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbSellPrice.Items.Count == 1)
                {
                    DataRow[] dr = dtCPrice.Select("ProductCode=" + cmbProduct.SelectedValue.ToString());
                    if (dr.Length > 0)
                    {
                        if (dr[0]["Price"].ToString() != cmbSellPrice.Text)
                            cmbSellPrice.Items.Add(dr[0]["Price"]);
                        cmbSellPrice.DroppedDown = true;
                    }
                }
            }
            catch { }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (facNum.Trim().Length > 0)
            {
                frmFactorPayments frmFP = new frmFactorPayments(facNum.Trim(), strCustomerCode);
                frmFP.Text += " : " + cmbCustomer.Text;
                if (txtLastFactorBalance.Text.Trim() == "")
                    frmFP.strPrevFactorRemainedAmount = "0";
                else
                    frmFP.strPrevFactorRemainedAmount = txtLastFactorBalance.Text.Trim();
                frmFP.ShowDialog(this);
                initialTextbox2();
            }
            else MessageBox.Show("لطفا ابتدا فاکتور را ثبت نمایید", "خطا");
        }

        private void btnAddDelLastFactor_Click(object sender, EventArgs e)
        {
            if (facNum.Trim() == "")
                return;
            else
            {
                if (btnAddDelLastFactor.Tag == (object)"0")//btn is Select btn.
                {
                    frmBrowsePrevFactors BPF = new frmBrowsePrevFactors(strCustomerCode, txtFactorNum.Text.Trim());
                    BPF.ShowDialog(this);
                    if (BPF.ReturnValFactorNum == null) //If user doesn't choose any factor.
                        return;
                    SqlCommand cmd = new SqlCommand("UpdatePrevFactorNumber", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fac_Num", txtFactorNum.Text.Trim());
                    cmd.Parameters.AddWithValue("@Prev_Fac_Num", BPF.ReturnValFactorNum.Trim());
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        btnAddDelLastFactor.Tag = "1";
                        btnAddDelLastFactor.Text = "حذف";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btnAddDelLastFactor_Click()");
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
                else if (btnAddDelLastFactor.Tag == (object)"1")//btn is Delete btn.
                {
                    DialogResult dres = MessageBox.Show(this, "آیا مایل به حذف این شماره فاکتور به عنوان مانده قبلی هستید ؟", "btnAddDelLastFactor_Click()", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (dres != DialogResult.Yes) return;
                    SqlCommand cmd = new SqlCommand("UpdatePrevFactorNumber", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Fac_Num", txtFactorNum.Text.Trim());
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        btnAddDelLastFactor.Tag = "0";
                        btnAddDelLastFactor.Text = "انتخاب";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "btnAddDelLastFactor_Click()");
                    }
                    finally
                    {
                        cmd.Connection.Close();
                    }
                }
                initialTextbox2();
            }
        }

        private void lvDetail_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (blnCanLvItemCheck == false)
                e.NewValue = e.CurrentValue;
        }

        private void Frm_sale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAddDelLastFactor_TextChanged(object sender, EventArgs e)
        {
            if (btnAddDelLastFactor.Text == "انتخاب")
                btnAddDelLastFactor.Image = Avazeh.Properties.Resources.Attachment;
            else if (btnAddDelLastFactor.Text == "حذف")
                btnAddDelLastFactor.Image = Avazeh.Properties.Resources.Delete;
        }

        private void chkShowNetProfit_CheckedChanged(object sender, EventArgs e)
        {

            pnlBuyPrice.Visible = chkShowNetProfit.Checked;
            if (chkShowNetProfit.Checked)
            {
                if (facNum.Length == 0) //If factor is new
                    return;
                initialTextbox2();
                txtBuyPrice.Text = txtBuyPrice.Tag.ToString();
            }
            else
                txtBuyPrice.Text = txtNetProfit.Text = "";
        }

        private void txtBuyPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                txtRawCount.Focus();
                e.Handled = true;
            }
        }

        private void txtBarCode_Leave(object sender, EventArgs e)
        {
            if (txtBarCode.Text == "") return;
            string strExpression = "BarCode = '" + ((TextBox)sender).Text.Trim() + "'";
            DataRow[] dr = dtProductList.Select(strExpression);
            if (dr.Length > 0)
            {
                cmbProduct.SelectedValue = dr[0]["code"].ToString();
                txtRawCount.Text = "1";
                btnAdd.PerformClick();
                ((TextBox)sender).Clear();
                ((TextBox)sender).Focus();
            }
            //else
            //    ((TextBox)sender).Clear();
        }

        private void lvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                tsmDelete.PerformClick();
        }

        private void DgvFactorDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactorDetail.Columns[e.ColumnIndex].Name == "dgvbtnColumnPlus" || dgvFactorDetail.Columns[e.ColumnIndex].Name == "dgvbtnColumnMinus")
                return;
            try
            {
                cmbSellPrice.BackColor = SystemColors.Window;
                DataGridView dgv = sender as DataGridView;
                cmbProduct.SelectedValue = int.Parse(dgv.Rows[e.RowIndex].Cells["productCode"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                cmbProduct.Tag = dgv.Rows[e.RowIndex].Cells["productCode"].Value.ToString();
                if (chkShowNetProfit.Checked)
                    txtBuyPrice.Text = dgv.Rows[e.RowIndex].Cells["buyprice"].Value.ToString().Replace(",", "");
                else
                    txtBuyPrice.Tag = dgv.Rows[e.RowIndex].Cells["buyprice"].Value.ToString().Replace(",", "");
                string strSellPrice = dgv.Rows[e.RowIndex].Cells["price"].Value.ToString().Replace(",", "");
                cmbSellPrice.Text = strSellPrice;
                cmbSellPrice.Items.Clear();
                cmbSellPrice.Items.Add(strSellPrice);
                txtRawCount.Text = dgv.Rows[e.RowIndex].Cells["strCount"].Value.ToString();
                strFloatCount = dgv.Rows[e.RowIndex].Cells["Count"].Value.ToString();
                strCodeDetail = dgv.Rows[e.RowIndex].Cells["code"].Value.ToString();
                if (dgv.Rows[e.RowIndex].Cells["tahvil"].Value == DBNull.Value)
                    chkTahvil.Checked = false;
                else
                    chkTahvil.Checked = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["tahvil"].Value);
                cmbSellPrice_Leave(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dgvFactorDetail_CellDoubleClick()");
            }
        }

        private void dgvFactorDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (gridView.Rows.Count - r.Index).ToString();
                }
            }
        }

        private void dgvFactorDetail_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgv.HitTest(e.X, e.Y);
                    dgv.ClearSelection();
                    dgv.Rows[hti.RowIndex].Selected = true;
                }
            }catch { }
        }

        private void dgvFactorDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                double fltCount = 0;
                DataRow[] dr = null; ;
                bool blnCanUpdate = false;
                if (senderGrid.Columns[e.ColumnIndex].Name == "dgvbtnColumnPlus" || senderGrid.Columns[e.ColumnIndex].Name == "dgvbtnColumnMinus")
                {
                    dr = (bindingSource1.DataSource as DataTable).Select("code = " + dgvFactorDetail.Rows[e.RowIndex].Cells["code"].Value.ToString());
                    if (dr.Length == 0)
                        return;
                    if (!double.TryParse(dr[0]["count"].ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out fltCount))
                        return;
                    if (senderGrid.Columns[e.ColumnIndex].Name == "dgvbtnColumnPlus")
                    {
                        fltCount++;
                        blnCanUpdate = true;
                    }
                    else if (senderGrid.Columns[e.ColumnIndex].Name == "dgvbtnColumnMinus")
                    {
                        fltCount--;
                        blnCanUpdate = true;
                    }
                    if (blnCanUpdate)
                    {
                        dr[0]["count"] = dr[0]["strCount"] = fltCount;
                        dr[0]["total1"] = (double.Parse(dr[0]["Count"].ToString(), System.Globalization.CultureInfo.InvariantCulture) * double.Parse(dr[0]["price"].ToString(), System.Globalization.CultureInfo.InvariantCulture)).ToString();
                        dataAdapter.Update((DataTable)bindingSource1.DataSource);
                        initialTextbox2();
                    }
                }
            }
        }

        private void dgvFactorDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                tsmDelete_Click(new object(), new EventArgs());
        }

        private void DgvFactorDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFactorDetail.SelectedRows.Count == 0)
            {
                tsslTotalSumOfSelectedRows.Text = "0";
                return;
            }
            Int64 intSum = 0;
            Int64 intTotalSum = 0;
            foreach (DataGridViewRow r in dgvFactorDetail.SelectedRows)
                if (Int64.TryParse(r.Cells["total1"].Value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out intSum))
                    intTotalSum += intSum;
            tsslTotalSumOfSelectedRows.Text = cUF.split_space(intTotalSum.ToString(), ",");
        }

        private void TsmiPrintSaleWithoutOfficialHeader_Click(object sender, EventArgs e)
        {
            PrintProcess("SaleWithoutOfficialHeader");
        }

        private void TsmiPrintSaleWithOfficialHeader_Click(object sender, EventArgs e)
        {
            PrintProcess("SaleWithOfficialHeader");
        }

        private void TsmiPrintInvoiceWithoutOfficialHeader_Click(object sender, EventArgs e)
        {
            PrintProcess("InvoiceWithoutOfficialHeader");
        }

        private void TsmiPrintInvoiceWithOfficialHeader_Click(object sender, EventArgs e)
        {
            PrintProcess("InvoiceWithOfficialHeader");
        }

        private void TsmiPrintSaleWithoutHeader_Click(object sender, EventArgs e)
        {
            PrintProcess("SaleWithoutHeader");
        }
    }
}