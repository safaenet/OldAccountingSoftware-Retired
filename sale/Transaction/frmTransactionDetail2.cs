using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace SafaShop
{
    public partial class Frm_TransactionDetails2 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string strToday = "";
        ////////////////////////////////////////////////////////////////////////////////////////////
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        cUserFunction cUF = new cUserFunction();
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("fa-IR");
        string strCodeDetail = ""; //Replacement for lblCodeDetail.
        public int intFileCode = -1;
        Boolean blnCanInitial_lvDetail = false; //To prevent initial_lvDetail from "Multiple running".
        public string editNum = "";
        public Boolean history = false;
        Boolean blnCanLvItemCheck = false;
        AutoCompleteStringCollection customerCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection FileSubjectCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection productCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection cPriceCollection = new AutoCompleteStringCollection();
        private readonly Action actListInitializer;
        Color clrTodayTransactions;
        Color clrCreditorTransaction;
        Color clrDebtorTransaction;
        bool blnCanEdit = true;

        protected override CreateParams CreateParams //To speed up form painting.
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public Frm_TransactionDetails2(Action _actListInitializer)
        {
            InitializeComponent();
            actListInitializer = _actListInitializer;
            strToday = cUF.GetFormattedPersianDate(DateTime.Now);
        }

        private void Frm_Details_Load(object sender, EventArgs e)
        {
            dgvDetail.DataSource = bindingSource1;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            clrTodayTransactions = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "5")));
            clrCreditorTransaction = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "6")));
            clrDebtorTransaction = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "7")));
            cmbSearchBy.SelectedIndex = 0;
            if (cUF.IniReadValue("8", "7") == "1") groupBox4.Enabled = panel10.Enabled = blnCanEdit = true; else groupBox4.Enabled = panel10.Enabled = blnCanEdit = false;
            Initial_CalenderForComboBoxes();
            initial_cmbTitle();
            initial_cmbAddToAnotherFile();
            cmbTitle.SelectedIndexChanged += cmbTitle_SelectedIndexChanged;
            blnCanInitial_lvDetail = true;
            
            initial_dgvDetail();
            initialTextbox2();
            cmbTitle.Select();
            cmbTitle.Text = "";
            //bindingSource1.ListChanged += BindingSource_ListChanged;
            cUF.ChangeLanguage("fa");
        }

        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            CalculateIncomesAndExpenses();
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
                Int64 i = Int64.Parse(uid.Substring(1)) + 1;
                uid = "C" + i.ToString();
            }
            catch
            {
                uid = "C0";
            }
            return uid;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbTitle.Text.Trim().Length == 0 || txtAmount.Text.Trim().Length == 0)
                return;
            if (strCodeDetail.Length == 0)//Insert
            {
                DataRow dr = ((DataTable)bindingSource1.DataSource).NewRow();
                dr["code"] = cUF.GetNextUpperCode("code", "tbTransactionDetails").ToString();
                dr["FileCode"] = txtFileCode.Text.Trim();
                dr["title"] = cmbTitle.Text.Trim();
                dr["amount"] = txtAmount.Text;
                dr["date"] = cUF.GetFormattedPersianDate(DateTime.Now);
                dr["time"] = cUF.getTime();
                dr["description"] = txtDesc.Text.Trim();
                ((DataTable)bindingSource1.DataSource).Rows.Add(dr);
                initial_cmbTitle();
                if (cmbAddToAnotherFile.SelectedValue.ToString() != "-1")
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@AlsoAddToFileCode", Int64.Parse(cmbAddToAnotherFile.SelectedValue.ToString()));
                else
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@AlsoAddToFileCode", -1);
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
                //dataAdapter.InsertCommand.Parameters[1].
                BuildDataAdapter(dataAdapter);
                cmbAddToAnotherFile.SelectedIndex = 0;
            }
            else//Update
            {
                DialogResult dres = MessageBox.Show("آیا از این ویرایش مطمئن هستید؟", "ویرایش", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dres == DialogResult.Yes)
                {
                    DataRow[] dr = ((DataTable)bindingSource1.DataSource).Select("code = " + strCodeDetail);
                    if (dr.Length == 0) return;
                    dr[0]["title"] = cmbTitle.Text.Trim();
                    dr[0]["amount"] = txtAmount.Text.Replace(",", "");
                    dr[0]["description"] = txtDesc.Text.Trim();
                    cmbAddToAnotherFile.Enabled = true;
                    dataAdapter.Update((DataTable)bindingSource1.DataSource);
                    initial_dgvDetail();
                }
            }
            CalculateIncomesAndExpenses();
            clearDetail();
            cmbTitle.Select();
        }

        private void initial_dgvDetail()
        {
            try
            {
                if (blnCanInitial_lvDetail)
                {
                    BuildDataAdapter(dataAdapter);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    //if (dt.Rows.Count == 0)
                    //{
                    //    bindingSource1.DataSource = null;
                    //    return;
                    //}
                    //else
                        bindingSource1.DataSource = dt;
                    dgvDetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    string[] strFaCol = { "ردیف", "کدفایل", "کد", "شرح تراکنش", "مبلغ", "تاریخ ایجاد", "ساعت", "تاریخ ویرایش", "توضیحات" };
                    string[] strCol = { "RowNumber", "FileCode", "code", "title", "amount", "date", "time", "DateModified", "description" };
                    int[] ColWidth = { 0, 0, 0, 230, 115, 75, 73, 75, 200 };
                    for (int i = 0; i < ColWidth.Length; i++)
                    {
                        dgvDetail.Columns[strCol[i]].HeaderText = strFaCol[i].ToString();
                        dgvDetail.Columns[strCol[i]].Width = ColWidth[i];
                        dgvDetail.Columns[strCol[i]].Visible = Convert.ToBoolean(ColWidth[i]);
                    }
                    CalculateIncomesAndExpenses();
                    dgvDetail.Sort(dgvDetail.Columns["code"], System.ComponentModel.ListSortDirection.Descending);
                    dgvDetail.Columns["amount"].DefaultCellStyle.Format = "N0";
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
            cmd = new SqlCommand("LoadTransactionDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FileCode", intFileCode);
            cmd.Parameters.AddWithValue("@S_Date", BuildFilterDateString());
            //cmd.Parameters.AddWithValue("@ParamFieldIndex", cmbSearchBy.SelectedIndex);
            //if (cmbSearchBy.SelectedIndex == 1)
            //    if (txtSearchBy.Text != "")
            //        cmd.Parameters.AddWithValue("@ParamValue", Double.Parse(txtSearchBy.Text, System.Globalization.NumberStyles.AllowThousands, culture));
            //    else { }
            //else
            //    cmd.Parameters.AddWithValue("@ParamValue", txtSearchBy.Text.Trim());
            da.SelectCommand = cmd;
            #endregion

            #region Build Insert Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTransactionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 1); //Runs Insert Command
            cmd.Parameters.AddWithValue("@tfilecode", intFileCode);
            cmd.Parameters.Add("@tcode", SqlDbType.BigInt, 64, "code");
            cmd.Parameters.Add("@ttitle", SqlDbType.NVarChar, 100, "title");
            cmd.Parameters.Add("@tamount", SqlDbType.BigInt, 64, "amount");
            cmd.Parameters.AddWithValue("@tdate", cUF.GetFormattedPersianDate(DateTime.Now));
            cmd.Parameters.AddWithValue("@ttime", cUF.getTime());
            cmd.Parameters.Add("@tdesc", SqlDbType.NText, 1024, "description");
            cmd.Parameters.AddWithValue("@tRecordModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));
            cmd.Parameters.AddWithValue("@NewModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));
            dataAdapter.InsertCommand = cmd;
            #endregion

            #region Build Update Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTransactionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 2); //Runs Update Command
            cmd.Parameters.AddWithValue("@tfilecode", intFileCode);
            cmd.Parameters.Add("@ttitle", SqlDbType.NVarChar, 100, "title");
            cmd.Parameters.Add("@tamount", SqlDbType.BigInt, 64, "amount");
            cmd.Parameters.Add("@tdesc", SqlDbType.NText, 1024, "description");
            cmd.Parameters.AddWithValue("@tRecordModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));
            parameter = cmd.Parameters.Add("@tcode", SqlDbType.BigInt, 64, "code");
            parameter.SourceVersion= DataRowVersion.Original;
            cmd.Parameters.AddWithValue("@NewModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));

            dataAdapter.UpdateCommand = cmd;
            #endregion

            #region Build Delete Command
            cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTransactionDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 3); //Runs Delete Command
            parameter = cmd.Parameters.Add("@tcode", SqlDbType.BigInt, 64, "code");
            parameter.SourceVersion = DataRowVersion.Original;
            cmd.Parameters.AddWithValue("@tfilecode", intFileCode);
            cmd.Parameters.AddWithValue("@NewModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));
            dataAdapter.DeleteCommand = cmd;
            #endregion
        }

        private void CalculateIncomesAndExpenses()
        {
            try
            {
                //double dblCurrentIncomes = Double.Parse((bindingSource1.DataSource as DataTable).Compute("SUM([amount])", "[amount] > 0").ToString());
                //double dblCurrentExpenses = Double.Parse((bindingSource1.DataSource as DataTable).Compute("SUM([amount])", "[amount] < 0").ToString());
                //double dblCurrentBalance = Double.Parse((bindingSource1.DataSource as DataTable).Compute("SUM([amount])", "true").ToString());
                //txtCurrentIncome.Text = cUF.split_space(dblCurrentIncomes.ToString(), ",");
                //txtCurrentExpence.Text = cUF.split_space(dblCurrentExpenses.ToString(), ",");
                //txtCurrentBalance.Text = cUF.split_space(dblCurrentBalance.ToString(), ",");

                SqlCommand cmd = new SqlCommand("GetTextBoxValuesForTransactionDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FileCode", intFileCode);
                cmd.Parameters.AddWithValue("@S_Date", BuildFilterDateString());
                cmd.Parameters.AddWithValue("@ParamFieldIndex", cmbSearchBy.SelectedIndex);
                if (cmbSearchBy.SelectedIndex == 1)
                    cmd.Parameters.AddWithValue("@ParamValue", txtSearchBy.Text.Replace(",", ""));
                else
                    cmd.Parameters.AddWithValue("@ParamValue", txtSearchBy.Text.Trim());
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                txtCurrentIncome.Text = dt.Rows[0]["CurrentIncomes"].ToString();
                txtCurrentExpence.Text = dt.Rows[0]["CurrentExpenses"].ToString();
                txtCurrentBalance.Text = dt.Rows[0]["CurrentBalance"].ToString();

                txtTotalIncome.Text = dt.Rows[0]["TotalIncomes"].ToString();
                txtTotalExpence.Text = dt.Rows[0]["TotalExpenses"].ToString();
                txtTotalBalance.Text = dt.Rows[0]["TotalBalance"].ToString();
            }
            catch
            {
                txtCurrentIncome.Text = "0";
                txtCurrentExpence.Text = "0";
                txtCurrentBalance.Text = "0";
                txtTotalIncome.Text = "0";
                txtTotalExpence.Text = "0";
                txtTotalBalance.Text = "0";
            }
        }

        private string BuildFilterDateString()
        {
            string strFilterDate = "";
            if (cmbYear.SelectedIndex != 0)
                strFilterDate = cmbYear.Text;
            else
                strFilterDate = "____";
            if (cmbMonth.SelectedIndex != 0)
            {
                if (cmbMonth.SelectedIndex < 10)
                    strFilterDate += "/0" + cmbMonth.SelectedIndex.ToString();
                else
                    strFilterDate += "/" + cmbMonth.SelectedIndex.ToString();
            }
            else
                strFilterDate += "/__";
            if (cmbDay.SelectedIndex != 0)
            {
                if (cmbDay.SelectedIndex < 10)
                    strFilterDate += "/0" + cmbDay.Text;
                else
                    strFilterDate += "/" + cmbDay.Text;
            }
            else
                strFilterDate += "/__";
            return strFilterDate;
        }

        private void Initial_CalenderForComboBoxes()
        {
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            int i;
            ////cmbYear
            cmbYear.Items.Add("همه");
            //for (i = intBeginYear1390; i <= iyear; i++)
            //    cmbYear.Items.Add((object)(i));
            SqlConnection con = new SqlConnection(Frm_main.conStr);
            SqlCommand cmd = new SqlCommand("GetMinYearMaxYearMaxMonthFromTransactionDetailsTable", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            int MinYear = int.Parse(dt.Rows[0]["MinYear"].ToString());
            int MaxYear = int.Parse(dt.Rows[0]["MaxYear"].ToString());
            for (i = MinYear; i <= iyear; i++)
                cmbYear.Items.Add((object)(i));
            if (MinYear == MaxYear)
                //cmbYear.SelectedIndex = 1;
                cmbYear.SelectedIndex = 0;
            else
                cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            //
            //cmbMonth
            //cmbMonth.SelectedIndex = imonth;
            cmbMonth.SelectedIndex = 0; //Applied also in Designer.cs
            //
            //cmbDay
            cmbDay.Items.Add("همه");
            i = PCal.GetDaysInMonth(iyear, imonth);
            for (int j = 1; j <= i; j++)
                cmbDay.Items.Add((object)j);
            //cmbDay.SelectedIndex = iday;
            cmbDay.SelectedIndex = 0;
            //
        }

        private void clearDetail()
        {
            strCodeDetail = "";
            cmbTitle.Text = "";
            txtAmount.Clear();
            txtDesc.Clear();
            cmbTitle.Tag = null;
        }

        private void initial_cmbAddToAnotherFile()
        {
            SqlCommand cmd = new SqlCommand("GetFileSubjectListForAddtoAnotherFileMethod", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FileCode", intFileCode);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("FileSubject")).ToArray();
            FileSubjectCollection.AddRange(strAutoCompleteString);
            cmbAddToAnotherFile.DataSource = dt;
            cmbAddToAnotherFile.DisplayMember = "FileSubject";
            cmbAddToAnotherFile.ValueMember = "FileCode";
            cmbAddToAnotherFile.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbAddToAnotherFile.AutoCompleteCustomSource = FileSubjectCollection;
            cmbAddToAnotherFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void initial_cmbTitle()
        {
            SqlCommand cmd = new SqlCommand("GetTransactionDetailTitleHistory", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("title")).ToArray();
            customerCollection.AddRange(strAutoCompleteString);
            cmbTitle.DataSource = dt;
            cmbTitle.DisplayMember = "title";
            cmbTitle.ValueMember = "Price";
            cmbTitle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbTitle.AutoCompleteCustomSource = customerCollection;
            cmbTitle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        void initialTextbox2()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT [FileSubject], [Description] FROM tbTransactions WHERE [FileCode] = @filecode", con);
                cmd.Parameters.AddWithValue("@filecode", intFileCode);
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                txtGeneralDescription.Text = dt.Rows[0]["Description"].ToString().Trim();
                txtFileCode.Text = intFileCode.ToString();
                txtFileSubject.Text = dt.Rows[0]["FileSubject"].ToString().Trim();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "initialTextbox2()"); }
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_dgvDetail();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            {//cmbDayCountInitialize
                try
                {
                    //If Esfand is selected.
                    //if (cmbMonth.SelectedIndex == 11 && cmbDay.Items.Count > 29)
                    //    cmbDay.Items.Remove((object)30);
                    //else if (cmbMonth.SelectedIndex != 11 && cmbDay.Items.Count <= 29)
                    //    cmbDay.Items.Add((object)30);
                    //
                    //If 31_Day Month is selected.
                    if (((ComboBox)sender).SelectedIndex <= 6 && cmbDay.Items.Count == 31)
                        cmbDay.Items.Add((object)31);
                    else if (((ComboBox)sender).SelectedIndex > 6 && cmbDay.Items.Count == 32)
                        cmbDay.Items.Remove((object)31);
                    //

                    if (cmbDay.SelectedIndex < 0)
                    {
                        cmbDay.SelectedIndex = 29;
                        return;
                    }
                }
                catch { }
                //string str = (cmbMonth.SelectedIndex + 1).ToString();
                //if (str.Length == 1)
                //    str = "0" + str;
                //lblChMonth.Text = str;
            }
            {//Filter Procedure
                initial_dgvDetail();
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_dgvDetail();
        }

        private void btnGotoToday_Click(object sender, EventArgs e)
        {
            DateTime dtimeToday;
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            dtimeToday = DateTime.Today;
            //cmbYear.SelectedValue = PCal.GetYear(dtimeToday) - 1390 - 1;
            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbMonth.SelectedIndex = PCal.GetMonth(dtimeToday);
            cmbDay.SelectedIndex = PCal.GetDayOfMonth(dtimeToday);
        }

        private void GotoThisMonth_Click(object sender, EventArgs e)
        {
            DateTime dtimeToday;
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            dtimeToday = DateTime.Today;
            //cmbYear.SelectedValue = PCal.GetYear(dtimeToday) - 1390 - 1;
            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbMonth.SelectedIndex = PCal.GetMonth(dtimeToday);
            cmbDay.SelectedIndex = 0;
        }

        private void GotoThisYear_Click(object sender, EventArgs e)
        {
            DateTime dtimeToday;
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            dtimeToday = DateTime.Today;
            //cmbYear.SelectedValue = PCal.GetYear(dtimeToday) - 1390 - 1;
            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbMonth.SelectedIndex = 0;
            cmbDay.SelectedIndex = 0;
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '0') && ((sender as TextBox).Text == "0"))
            {
                e.Handled = true;
            }
            if ((e.KeyChar != '0') && ((sender as TextBox).Text == "0"))
            {
                txtAmount.Text = "";
            }
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void cmbTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != string.Empty)
                bindingSource1.Filter = BuildFilterString();
            else
                bindingSource1.Filter = "";
            CalculateIncomesAndExpenses();
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchBy.Clear();
            initial_dgvDetail();
        }

        private void txtCurrentBalance_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentBalance.Text.Contains("-"))
                txtCurrentBalance.BackColor = clrDebtorTransaction;
            else
                txtCurrentBalance.BackColor = SystemColors.Control;
        }

        private void txtTotalBalance_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalBalance.Text.Contains("-"))
                txtTotalBalance.BackColor = clrDebtorTransaction;
            //else if (txtTotalBalance.Text == "0")
            //    txtTotalBalance.BackColor = Color.FromArgb(124, 200, 250);
            else
                txtTotalBalance.BackColor = SystemColors.Control;
        }

        private void txtSearchBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSearchBy.SelectedIndex == 1) //If "Amount" is selected
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == '0') && ((sender as TextBox).Text == "0"))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar != '0') && ((sender as TextBox).Text == "0"))
                {
                    txtAmount.Text = "";
                }
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (!blnCanEdit) return;
            if (dgvDetail.SelectedRows.Count == 0)
                return;
            DialogResult res = MessageBox.Show("آیا از حذف این گزینه/گزینه ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.No) return;
            foreach (DataGridViewRow row in dgvDetail.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvDetail.Rows.Remove(row);
            }
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
            CalculateIncomesAndExpenses();
        }

        private void btnSaveGeneralDescription_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", 4); //Runs File Description Update Command.
                cmd.Parameters.AddWithValue("@ParamDesc", txtGeneralDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@ParamFileCode", intFileCode);
                cmd.Parameters.AddWithValue("@ParamDate", cUF.GetFormattedPersianDate(DateTime.Now));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSaveGeneralDescription_Click()");
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private void Frm_TransactionDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            actListInitializer();
        }

        private void cmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAmount.Text = cmbTitle.SelectedValue.ToString();
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Trim().Length == 0)
            {
                (sender as TextBox).Text = "0";
                (sender as TextBox).SelectAll();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmPrintTransactionDetails frmReport = new frmPrintTransactionDetails();
            frmReport.sqlDataAdaptor.SelectCommand = new SqlCommand("LoadSpecificationsForPrintTransactionDetailDialog", con);
            frmReport.sqlDataAdaptor.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            frmReport.sqlDataAdaptor.SelectCommand.Parameters.AddWithValue("@_FileCode", intFileCode);
            frmReport.sqlDataAdaptor.SelectCommand.Parameters.AddWithValue("@_S_Date", BuildFilterDateString());
            frmReport.sqlDataAdaptor.SelectCommand.Parameters.AddWithValue("@_ParamFieldIndex", cmbSearchBy.SelectedIndex);
            if (cmbSearchBy.SelectedIndex == 1)
                if (txtSearchBy.Text != "")
                    frmReport.sqlDataAdaptor.SelectCommand.Parameters.AddWithValue("@_ParamValue", Double.Parse(txtSearchBy.Text, System.Globalization.NumberStyles.AllowThousands, culture));
                else { }
            else
                frmReport.sqlDataAdaptor.SelectCommand.Parameters.AddWithValue("@_ParamValue", txtSearchBy.Text.Trim());
            frmReport.Show(this);
        }

        private void btnGotoAll_Click(object sender, EventArgs e)
        {
            cmbYear.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
            cmbDay.SelectedIndex = 0;
        }

        private void dgvDetail_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                Color[] clrSeq = { Color.FromArgb(255, 237, 237), Color.FromArgb(237, 244, 255) };
                byte bytClrSeqIndex = 0;
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    if (r.Index == 0) //To group list by color accourding to date.
                        r.Cells["date"].Style.BackColor = clrSeq[bytClrSeqIndex = 0];
                    else
                        if (r.Cells["date"].Value.ToString() == dgvDetail.Rows[r.Index - 1].Cells["date"].Value.ToString())
                        r.Cells["date"].Style.BackColor = dgvDetail.Rows[r.Index - 1].Cells["date"].Style.BackColor;
                    else
                    {
                        if (++bytClrSeqIndex == clrSeq.Length) bytClrSeqIndex = 0;
                        r.Cells["date"].Style.BackColor = clrSeq[bytClrSeqIndex];
                    }
                    if (r.Cells["date"].Value.ToString().Trim().Equals(strToday))//Highlight today's transactions.
                        r.Cells["title"].Style.BackColor = clrTodayTransactions;
                    if (r.Cells["DateModified"].Value.ToString().Trim().Equals(strToday))//Highlight today edited transactions.
                        r.Cells["title"].Style.BackColor = Color.LightGray;
                    if (r.Cells["amount"].Value.ToString().Contains("-"))//"Hazineh"
                        r.Cells["amount"].Style.BackColor = clrDebtorTransaction;
                    else //"Daramad"
                        r.Cells["amount"].Style.BackColor = clrCreditorTransaction;
                }
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                cmbTitle.Text = dgv.Rows[e.RowIndex].Cells["title"].Value.ToString();
                cmbTitle.Tag = dgv.Rows[e.RowIndex].Cells["code"].Value.ToString();
                txtAmount.Text = dgv.Rows[e.RowIndex].Cells["amount"].Value.ToString();
                txtDesc.Text = dgv.Rows[e.RowIndex].Cells["description"].Value.ToString();
                strCodeDetail = dgv.Rows[e.RowIndex].Cells["code"].Value.ToString();
                cmbAddToAnotherFile.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "dgvDetail_CellDoubleClick()");
            }
        }

        string BuildFilterString()
        {
            string str = "";
            if(cmbSearchBy.SelectedIndex==0)//SearchBy title
            {
                str = "title LIKE '%" + txtSearchBy.Text + "%'";
            }
            else if(cmbSearchBy.SelectedIndex == 1)//SearchBy amount
            {
                str = "amount = " + txtSearchBy.Text;
            }
            else if (cmbSearchBy.SelectedIndex == 2)//SearchBy description
            {
                str = "description LIKE '%" + txtSearchBy.Text + "%'";
            }
            return str;
        }

        private void dgvDetail_MouseDown(object sender, MouseEventArgs e)
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

        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                tsmDelete_Click(new object(), new EventArgs());
        }
    }
}