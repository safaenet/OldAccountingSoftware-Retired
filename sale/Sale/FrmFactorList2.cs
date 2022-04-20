using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Avazeh.Sale;
using System.Runtime.InteropServices;

namespace SafaShop
{
    public partial class frmFactorList2 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string strToday = "";
        ///////////////////////////////////////////////////////////////////////////////////////////////
        DataTable tbSale = new DataTable();
        AutoCompleteStringCollection customerCollection = new AutoCompleteStringCollection();
        System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
        Boolean blnCanInitial_lvSale = false; //To prevent initial_lvsale2 from "Multiple running".
        Boolean blnCanUpdateStatusBar = false;
        cUserFunction cUF = new cUserFunction();
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        Color clrTodayFactor;
        Color clrCreditorFactor;
        Color clrDebtorFactor;
        Color clrZeroFactor;
        Color clrFwFactor;
        [DllImport("user32.dll")]//To Speed-up DGV
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        public frmFactorList2()
        {
            InitializeComponent();
            strToday = cUF.GetFormattedPersianDate(DateTime.Now);
        }

        private void FrmLastFactor_Load(object sender, EventArgs e)
        {
            dgvFactorList.DataSource = bindingSource1;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            clrTodayFactor = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "1")));
            clrCreditorFactor = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "2")));
            clrDebtorFactor = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "3")));
            clrZeroFactor = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "4")));
            clrFwFactor = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "10")));
            Initial_CalenderForComboBoxes();
            Initial_cmbCustomer();
            blnCanInitial_lvSale = true;
            //BuildDataAdapter(dataAdapter);
            cmbFinStatus.SelectedIndex = 0;
            initial_dgvFactorList();
            bindingSource1.ListChanged += customersBindingSource_ListChanged;
            blnCanUpdateStatusBar = true;
            cmbFinStatus.SelectedIndex = 4;
            cUF.ChangeLanguage("fa");
        }

        private void Initial_CalenderForComboBoxes()
        {
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            int i;
            ////cmbYear
            cmbYear.Items.Add("همه");
            //for (i = intBeginYear1390; i <= iyear; i++)
            //    cmbYear.Items.Add((object)(i));
            SqlConnection con = new SqlConnection(Frm_main.conStr);
            SqlCommand cmd = new SqlCommand("GetMinYearMaxYearMaxMonth", con);
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
                cmbYear.SelectedIndex = 0;
            //cmbYear.SelectedIndex = 1;
            else
                cmbYear.SelectedIndex = 0;
            //cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            //
            //cmbMonth
            //cmbMonth.SelectedIndex = imonth;
            cmbMonth.SelectedIndex = 0;
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

        private void Initial_cmbCustomer()
        {
            string strda = "SELECT [code], [name] FROM tbCustomer ORDER BY [name]";
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow dr = dt.NewRow();
            dr["name"] = "همه";
            dr["code"] = -1;
            dt.Rows.InsertAt(dr, 0);
            customerCollection.Add("همه");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                customerCollection.Add(dt.Rows[i]["name"].ToString());
            }
            cmbCustomerName.DataSource = dt;
            cmbCustomerName.DisplayMember = "name";
            cmbCustomerName.ValueMember = "code";
            cmbCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbCustomerName.AutoCompleteCustomSource = customerCollection;
            cmbCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbCustomerName.SelectedIndex = 0;
        }

        private string BuildFilterCustomerCode()
        {
            string str = "-1";
            if (cmbCustomerName.SelectedIndex == 0)
                return str;
            else //if (cmbCustomerName.Text.Trim().Length != 0)
                str = cmbCustomerName.SelectedValue.ToString();
            return str;
        }

        private string BuildFilterFactorNum()
        {
            string str = "-1";
            if (txtFactorNum.Text.Trim().Length != 0)
                str = txtFactorNum.Text.Trim();
            return str;
        }

        private string BuildFilterFactorFinStatus()
        {
            string str = "";
            if (cmbFinStatus.SelectedIndex == 0)//Show all
                str = "0";
            else if (cmbFinStatus.SelectedIndex == 1)//If "Tasvieh"
                str = "[0]%";
            else if (cmbFinStatus.SelectedIndex == 2 || cmbFinStatus.SelectedIndex == 4)//If "Bedehkar"
                str = "[^0]%";
            else if (cmbFinStatus.SelectedIndex == 3)//If "Bestankar"
                str = "[-]%";
            return str;
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

        private void initial_dgvFactorList()
        {
            try
            {
                if (blnCanInitial_lvSale)
                {
                    SendMessage(dgvFactorList.Handle, WM_SETREDRAW, false, 0);
                    BuildDataAdapter(dataAdapter);
                    tbSale = new DataTable();
                    bindingSource1.SuspendBinding();
                    _ = dataAdapter.Fill(tbSale);
                    bindingSource1.ResumeBinding();
                    bindingSource1.DataSource = tbSale;
                    dgvFactorList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    string[] strFaCol = { "شماره مشتری", "ش فاکتور", "نام مشتری", "تاریخ", "ساعت", "جمع فاکتور", "مانده قبل", "فاکتور قبل", "جمع پرداختها", "تراز فاکتور", "فاکتور بعد" };
                    string[] strCol = { "customerCode", "factorNum", "name", "date", "time", "FacSum", "PrevTotalRemained", "PrevFactorNum", "TotalPayment", "TotalBalance", "FwdFactorNum" };
                    int[] ColWidth = { 0, 65, 200, 83, 65, 100, 100, 69, 100, 100, 65 };
                    for (int i = 0; i < ColWidth.Length; i++)
                    {
                        dgvFactorList.Columns[strCol[i]].HeaderText = strFaCol[i].ToString();
                        dgvFactorList.Columns[strCol[i]].Width = ColWidth[i];
                        dgvFactorList.Columns[strCol[i]].Visible = Convert.ToBoolean(ColWidth[i]);
                    }
                    dgvFactorList.Sort(dgvFactorList.Columns["factorNum"], System.ComponentModel.ListSortDirection.Descending);
                    dgvFactorList.Columns["FacSum"].DefaultCellStyle.Format = "N0";
                    dgvFactorList.Columns["PrevTotalRemained"].DefaultCellStyle.Format = "N0";
                    dgvFactorList.Columns["TotalPayment"].DefaultCellStyle.Format = "N0";
                    dgvFactorList.Columns["TotalBalance"].DefaultCellStyle.Format = "N0";
                    SendMessage(dgvFactorList.Handle, WM_SETREDRAW, true, 0);
                    dgvFactorList.Refresh();
                    ComputeAndUpdateStatusBar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initial_dgvFactorList()");
            }
        }

        void ComputeAndUpdateStatusBar()
        {
            if (!blnCanUpdateStatusBar) return;
            double dblTotalFacSum = 0;
            Double.TryParse((bindingSource1.DataSource as DataTable).Compute("SUM(FacSum)", BuildFilterString()).ToString(), out dblTotalFacSum);
            double dblTotalPaymentsSum = 0;
            Double.TryParse((bindingSource1.DataSource as DataTable).Compute("SUM(TotalPayment)", BuildFilterString()).ToString(), out dblTotalPaymentsSum);
            double dblTotalCreditorSum = 0;
            Double.TryParse((bindingSource1.DataSource as DataTable).Compute("SUM(TotalBalance)", BuildFilterString()).ToString(), out dblTotalCreditorSum);
            tsslTotalCreditorSum.Text = cUF.split_space(dblTotalCreditorSum.ToString(), ",");
            tsslFacSum.Text = cUF.split_space(dblTotalFacSum.ToString(), ",");
            tsslTotalPaymentsSum.Text = cUF.split_space(dblTotalPaymentsSum.ToString(), ",");
            //MessageBox.Show("ComputeAndUpdateStatusBar()");
        }

        void BuildDataAdapter(SqlDataAdapter da)
        {
            SqlCommand cmd;
            SqlParameter parameter;
            #region Build Select Command
            cmd = new SqlCommand("LastFactorListQuery", con);
            cmd.CommandType = CommandType.StoredProcedure;
            _ = cmd.Parameters.AddWithValue("@S_Date", BuildFilterDateString());
            cmd.Parameters.AddWithValue("@S_FinStatus", BuildFilterFactorFinStatus());
            cmd.Parameters.AddWithValue("@Fac_Num", BuildFilterFactorNum());
            cmd.Parameters.AddWithValue("@C_Code", BuildFilterCustomerCode());
            if (cmbFinStatus.SelectedIndex == 4)
                cmd.Parameters.AddWithValue("@FwdFactor_Num", 0);
            da.SelectCommand = cmd;
            #endregion

            #region Build Insert Command
            //cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Mode", 1); //Runs Insert Command
            //cmd.Parameters.Add("@ParamFileCode", SqlDbType.BigInt, 64, "FileCode");
            //cmd.Parameters.Add("@ParamFileSubject", SqlDbType.NVarChar, 100, "FileSubject");
            //cmd.Parameters.Add("@ParamDate", SqlDbType.Char, 10, "DateCreated");
            //dataAdapter.InsertCommand = cmd;
            #endregion

            #region Build Update Command
            //cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Mode", 2); //Runs Update Command.
            //cmd.Parameters.Add("@ParamFileCode", SqlDbType.BigInt, 64, "FileCode");
            //cmd.Parameters.Add("@ParamFileSubject", SqlDbType.NVarChar, 100, "FileSubject");
            //cmd.Parameters.Add("@ParamDate", SqlDbType.Char, 10, "DateModified");
            //dataAdapter.UpdateCommand = cmd;
            #endregion

            #region Build Delete Command
            cmd = new SqlCommand("DeleteFactorWithFactorNumber", con);
            cmd.CommandType = CommandType.StoredProcedure;
            parameter = cmd.Parameters.Add("@Fac_Num", SqlDbType.BigInt, 64, "factornum");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.DeleteCommand = cmd;
            #endregion
        }

        void customersBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            ComputeAndUpdateStatusBar();
            //MessageBox.Show("customersBindingSource_ListChanged");
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bindingSource1.Filter = "[date] LIKE '" + BuildFilterDateString() + "'";
            //cmbDayCountInitialize
            try
            {
                if (cmbMonth.SelectedIndex <= 6 && cmbDay.Items.Count == 31)
                    cmbDay.Items.Add((object)31);
                else if (cmbMonth.SelectedIndex > 6 && cmbDay.Items.Count == 32)
                    cmbDay.Items.Remove((object)31);
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
            initial_dgvFactorList();
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_dgvFactorList();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_dgvFactorList();
        }

        private void cmbFinStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!blnCanInitial_lvSale) return;
            bindingSource1.Filter = BuildFilterString();
            //initial_dgvFactorList();
            //MessageBox.Show("cmbFinStatus_SelectedIndexChanged");
        }

        string BuildFilterString()
        {
            string str = "1 = 1 ";

            if (cmbFinStatus.SelectedIndex == 1) //If "Tasvieh"
                str = "TotalBalance = 0 ";
            else if (cmbFinStatus.SelectedIndex == 2) //If "Bedehkar"
                str = "TotalBalance <> 0 ";
            else if (cmbFinStatus.SelectedIndex == 3) //Positive
                str = "TotalBalance < 0 ";
            else if (cmbFinStatus.SelectedIndex == 4) //Moavvagh
                str = "TotalBalance <> 0 AND FwdFactorNum IS NULL ";
            else if (cmbFinStatus.SelectedIndex == 0) //All
                str = "1 = 1 ";

            if (cmbCustomerName.SelectedIndex == 0)
                str += "";
            else if (cmbCustomerName.Text != "")
                str += "AND name LIKE '%" + cmbCustomerName.Text.ToString() + "%' ";

            if (txtFactorNum.Text != "")
                str += "AND factorNum = " + txtFactorNum.Text.Trim();
            //_ = MessageBox.Show(str);
            return str;
        }

        private void txtFactorNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = BuildFilterString();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            blnCanInitial_lvSale = false;
            int i = cmbFinStatus.SelectedIndex;
            cmbFinStatus.SelectedIndex = 0;
            blnCanInitial_lvSale = true;
            initial_dgvFactorList();
            cmbFinStatus.SelectedIndex = i;
        }

        private void frmLastFactors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tmnuFilterList_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count != 0)
                cmbCustomerName.SelectedValue = dgvFactorList.SelectedRows[0].Cells["customerCode"].Value.ToString();
        }

        private void tmnuOpenFactor_Click(object sender, EventArgs e)
        {
            dgvFactorList_CellDoubleClick(new object(), new DataGridViewCellEventArgs(0, 0));
        }

        private void tmnuShowAll_Click(object sender, EventArgs e)
        {
            cmbCustomerName.SelectedIndex = 0;
        }

        private void chkStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = chkStatusBar.Checked;
        }

        private void cmbCustomerName_Enter(object sender, EventArgs e)
        {
            cUF.ChangeLanguage("fa");
        }

        private void dgvFactorList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            //if (dgv.Columns[e.ColumnIndex].Name.Equals("date"))
            //    if (e.Value.ToString().Trim() == strToday)
            //        dgv.Rows[e.RowIndex].Cells["factorNum"].Style.BackColor = clrTodayFactor;//Highlight today's factors.
            //    else { }
            //else if (dgv.Columns[e.ColumnIndex].Name.Equals("FwdFactorNum"))//Forwarded factor
            //    if (e.Value.ToString() != "") dgv.Rows[e.RowIndex].Cells["TotalBalance"].Style.BackColor = clrFwFactor; else { }
            //else if (dgv.Columns[e.ColumnIndex].Name.Equals("TotalBalance"))
            //{
            //    if (e.Value.ToString() == "0" && dgv.Rows[e.RowIndex].Cells["FwdFactorNum"].Value.ToString() == "") e.CellStyle.BackColor = clrZeroFactor;//"Tasvieh"
            //    else if (e.Value.ToString().Contains("-") && dgv.Rows[e.RowIndex].Cells["FwdFactorNum"].Value.ToString() == "") e.CellStyle.BackColor = clrCreditorFactor;//"Creditor"
            //    else if (dgv.Rows[e.RowIndex].Cells["FwdFactorNum"].Value.ToString() == "") e.CellStyle.BackColor = clrDebtorFactor;//"Debtor"
            //}
        }

        private void dgvFactorList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0) return;
            FrmFactorDetail2 fs = new FrmFactorDetail2();
            int intFileCode = 0;
            if (int.TryParse(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), out intFileCode))
            {
                fs.facNum = intFileCode.ToString();
                fs.history = false;
                fs.Show();
            }
            else MessageBox.Show("خطا در یافتن شماره فاکتور", "dgvFactorList_CellDoubleClick()");
        }

        private void dgvFactorList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                    if (r.Cells["date"].Value.ToString().Trim() == strToday)
                        r.Cells["factorNum"].Style.BackColor = clrTodayFactor;//Highlight today's factors.
                    if (r.Cells["FwdFactorNum"].Value.ToString() != "") r.Cells["TotalBalance"].Style.BackColor = clrFwFactor;
                    if (r.Cells["TotalBalance"].Value.ToString() == "0" && r.Cells["FwdFactorNum"].Value.ToString() == "") r.Cells["TotalBalance"].Style.BackColor = clrZeroFactor;//"Tasvieh"
                    else if (r.Cells["TotalBalance"].Value.ToString().Contains("-") && r.Cells["FwdFactorNum"].Value.ToString() == "") r.Cells["TotalBalance"].Style.BackColor = clrCreditorFactor;//"Creditor"
                    else if (r.Cells["FwdFactorNum"].Value.ToString() == "") r.Cells["TotalBalance"].Style.BackColor = clrDebtorFactor;//"Debtor"
                }
            }
        }

        private void dgvFactorList_MouseDown(object sender, MouseEventArgs e)
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

        private void dgvFactorList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                tmnuDeleteFactor_Click(new object(), new EventArgs());
        }

        private void tmnuDeleteFactor_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DialogResult res = MessageBox.Show("آیا از حذف فاکتور/فاکتور ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.No) return;
            foreach (DataGridViewRow row in dgvFactorList.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvFactorList.Rows.Remove(row);
            }
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void txtFactorNum_TextChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = BuildFilterString();
        }

        private void btnPrintSaleList_Click(object sender, EventArgs e)
        {
            DataTable dt = tbSale.Clone();
            for (int i = dt.Columns.Count - 1; i >= 0; i--)
                dt.Columns[i].DataType = typeof(String);
            foreach (DataGridViewRow dgvRow in dgvFactorList.Rows)
                _ = dt.Rows.Add(dgvRow.Cells["customerCode"].Value, dgvRow.Cells["factorNum"].Value, dgvRow.Cells["name"].Value.ToString(), dgvRow.Cells["date"].Value, dgvRow.Cells["time"].Value, cUF.split_space(dgvRow.Cells["FacSum"].Value.ToString(), ","), dgvRow.Cells["PrevTotalRemained"].Value, dgvRow.Cells["PrevFactorNum"].Value, cUF.split_space(dgvRow.Cells["TotalPayment"].Value.ToString(), ","), cUF.split_space(dgvRow.Cells["TotalBalance"].Value.ToString(), ","), dgvRow.Cells["FwdFactorNum"].Value);
            frmPrintSaleList frmReport = new frmPrintSaleList(dt);
            frmReport.Show(this);
        }

        private void DgvFactorList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
            {
                tsslSelectedFacSum.Text = "0";
                tsslSelectedFacPayments.Text = "0";
                return;
            }
            Int64 intFacSum = 0;
            Int64 intFacPayments = 0;
            Int64 intTotalFacSum = 0;
            Int64 intTotalFacPayments = 0;
            foreach (DataGridViewRow r in dgvFactorList.SelectedRows)
            {
                if (Int64.TryParse(r.Cells["FacSum"].Value.ToString(), out intFacSum))
                    intTotalFacSum += intFacSum;
                if (Int64.TryParse(r.Cells["TotalPayment"].Value.ToString(), out intFacPayments))
                    intTotalFacPayments += intFacPayments;
            }
            tsslSelectedFacSum.Text = cUF.split_space(intTotalFacSum.ToString(), ",");
            tsslSelectedFacPayments.Text = cUF.split_space(intTotalFacPayments.ToString(), ",");
        }

        void initial_dgvFactorListThread()
        {
            var thread = new System.Threading.Thread(SomeMethod);
            thread.Start();
        }

        void SomeMethod()
        {
            dataAdapter.Fill(tbSale);
        }

        private void TmnuOpenPayments_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0) return;
            int intFileCode = 0;
            if (int.TryParse(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), out intFileCode))
            {

                frmFactorPayments frmFP = new frmFactorPayments(intFileCode.ToString(), dgvFactorList.SelectedRows[0].Cells["customerCode"].Value.ToString());
                frmFP.Text += " : " + dgvFactorList.SelectedRows[0].Cells["name"].Value.ToString();
                frmFP.strPrevFactorRemainedAmount = dgvFactorList.SelectedRows[0].Cells["PrevTotalRemained"].Value.ToString().Trim();
                frmFP.Show(this);
            }
            else MessageBox.Show("خطا در یافتن شماره فاکتور", "dgvFactorList_CellDoubleClick()");
        }

        private void TmnuPrintSaleWithoutOfficialHeader_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DataRow dr = cUF.LoadSalesFactorDetails(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString());
            cUF.PrintSalesFactor(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), "SaleWithoutOfficialHeader", true, dr["TotalPayment"].ToString().Trim(), dr["PrevTotalRemained"].ToString().Trim(), dr["PrevFactorNum"].ToString().Trim());
        }

        private void TmnuPrintSaleWithOfficialHeader_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DataRow dr = cUF.LoadSalesFactorDetails(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString());
            cUF.PrintSalesFactor(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), "SaleWithOfficialHeader", true, dr["TotalPayment"].ToString().Trim(), dr["PrevTotalRemained"].ToString().Trim(), dr["PrevFactorNum"].ToString().Trim());
        }

        private void TmnuPrintInvoiceWithoutOfficialHeader_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DataRow dr = cUF.LoadSalesFactorDetails(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString());
            cUF.PrintSalesFactor(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), "InvoiceWithoutOfficialHeader", true, dr["TotalPayment"].ToString().Trim(), dr["PrevTotalRemained"].ToString().Trim(), dr["PrevFactorNum"].ToString().Trim());
        }

        private void TmnuPrintInvoiceWithOfficialHeader_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DataRow dr = cUF.LoadSalesFactorDetails(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString());
            cUF.PrintSalesFactor(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), "InvoiceWithOfficialHeader", true, dr["TotalPayment"].ToString().Trim(), dr["PrevTotalRemained"].ToString().Trim(), dr["PrevFactorNum"].ToString().Trim());
        }

        private void TmnuPrintSaleWithoutHeader_Click(object sender, EventArgs e)
        {
            if (dgvFactorList.SelectedRows.Count == 0)
                return;
            DataRow dr = cUF.LoadSalesFactorDetails(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString());
            cUF.PrintSalesFactor(dgvFactorList.SelectedRows[0].Cells["factorNum"].Value.ToString(), "SaleWithoutHeader", true, dr["TotalPayment"].ToString().Trim(), dr["PrevTotalRemained"].ToString().Trim(), dr["PrevFactorNum"].ToString().Trim());
        }
    }
}