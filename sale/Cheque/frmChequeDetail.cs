using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SafaShop;

namespace Avazeh.Cheque
{
    public partial class frmChequeDetail : Form
    {
        public string chkID = ""; //If form is gonna be loaded. (Not New)
        const string _MySelf = "خودم";
        cUserFunction cUF = new cUserFunction();
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("fa-IR");
        AutoCompleteStringCollection ChequeFromToStatusNameCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection ChequeForCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection ChequeBankNameCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection TransactionFileListCollection = new AutoCompleteStringCollection();
        bool blnSaveAndCloseCanExit = false;

        public frmChequeDetail()
        {
            InitializeComponent();
        }

        private void frmChequeDetail_Load(object sender, EventArgs e)
        {
            cUF.ChangeLanguage("fa");
            FillDateComboBoxes();
            FillComboBoxHistory();

        }

        private void frmChequeDetail_Shown(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            if (chkID.Trim().Length > 0) //Is loaded, Not new.
            {
                txtID.Text = chkID;
                string strcmd;
                strcmd = "SELECT *, FORMAT([Amount], '#,0.') AS 'FAmount' FROM tblChequeList WHERE chkID = " + chkID;
                SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("چک با این مشخصات یافت نشد");
                }
                else
                {
                    if (dt.Rows[0]["chkFrom"].ToString() == _MySelf) chkFromMySelf.Checked = true;
                    else cmbFrom.Text = dt.Rows[0]["chkFrom"].ToString();
                    if (dt.Rows[0]["chkTo"].ToString() == _MySelf) chkToMySelf.Checked = true;
                    else cmbTo.Text = dt.Rows[0]["chkTo"].ToString();
                    cmbFor.Text = dt.Rows[0]["chkFor"].ToString();
                    txtAmount.Text = dt.Rows[0]["FAmount"].ToString();
                    txtSerialNum.Text = dt.Rows[0]["ChequeSerial"].ToString();
                    cmbBankName.Text = dt.Rows[0]["BankName"].ToString();
                    txtDesc.Text = dt.Rows[0]["chkDesc"].ToString();
                    String strDate = "";
                    String strYear = "";
                    int intMonth = 0;
                    int intDay = 0;
                    if (dt.Rows[0]["CashDate"].ToString().Length == 10)
                    {
                        strDate = dt.Rows[0]["CashDate"].ToString();
                        strYear = strDate.Substring(0, 4);
                        intMonth = Convert.ToInt32(strDate.Substring(5, 2));
                        intDay = Convert.ToInt32(strDate.Substring(8, 2));
                        cmbCashYear.Text = strYear;
                        cmbCashMonth.SelectedIndex = intMonth - 1;
                        cmbCashDay.SelectedIndex = intDay - 1;
                    }
                    if (dt.Rows[0]["IssueDate"].ToString().Length == 10)
                    {
                        strYear = dt.Rows[0]["IssueDate"].ToString().Substring(0, 4);
                        intMonth = int.Parse(dt.Rows[0]["IssueDate"].ToString().Substring(5, 2));
                        intDay = int.Parse(dt.Rows[0]["IssueDate"].ToString().Substring(8, 2));
                        cmbIssueYear.Text = strYear;
                        cmbIssueMonth.SelectedIndex = intMonth - 1;
                        cmbIssueDay.SelectedIndex = intDay - 1;
                    }
                    if (dt.Rows[0]["chkStatus"].ToString() == "0") //radStatusNone
                    {
                        radStatusNone.Checked = true;
                    }
                    else if (dt.Rows[0]["chkStatus"].ToString() == "1") //radStatusCashed
                    {
                        radStatusCashed.Checked = true;
                        if (dt.Rows[0]["StatusDate"].ToString().Length == 10)
                        {
                            strYear = dt.Rows[0]["StatusDate"].ToString().Substring(0, 4);
                            intMonth = int.Parse(dt.Rows[0]["StatusDate"].ToString().Substring(5, 2));
                            intDay = int.Parse(dt.Rows[0]["StatusDate"].ToString().Substring(8, 2));
                            cmbStatusYear.Text = strYear;
                            cmbStatusMonth.SelectedIndex = intMonth - 1;
                            cmbStatusDay.SelectedIndex = intDay - 1;
                        }
                    }
                    else if (dt.Rows[0]["chkStatus"].ToString() == "2") //radStatusForwarded
                    {
                        radStatusForwarded.Checked = true;
                        cmbStatusName.Text = dt.Rows[0]["StatusName"].ToString();
                        if (dt.Rows[0]["StatusDate"].ToString().Length == 10)
                        {
                            strYear = dt.Rows[0]["StatusDate"].ToString().Substring(0, 4);
                            intMonth = int.Parse(dt.Rows[0]["StatusDate"].ToString().Substring(5, 2));
                            intDay = int.Parse(dt.Rows[0]["StatusDate"].ToString().Substring(8, 2));
                            cmbStatusYear.Text = strYear;
                            cmbStatusMonth.SelectedIndex = intMonth - 1;
                            cmbStatusDay.SelectedIndex = intDay - 1;
                        }
                    }
                    else if (dt.Rows[0]["chkStatus"].ToString() == "3") //radStatusBounced
                    {
                        radStatusBounced.Checked = true;
                    }
                    btnDelete.Enabled = true;
                }
            }
            else //Is New
            {
                cmbCashYear.Text = iyear.ToString();
                cmbCashMonth.SelectedIndex = imonth - 1;
                cmbCashDay.Text = iday.ToString();
                cmbIssueYear.Text = iyear.ToString();
                cmbIssueMonth.SelectedIndex = imonth - 1;
                cmbIssueDay.Text = iday.ToString();
                Int64 i64 = cUF.GetNextUpperCode("chkID", "tblChequeList");
                if (i64 > 1)
                    txtID.Text = i64.ToString();
                else
                    txtID.Text = "111";
            }
        }

        void FillDateComboBoxes()
        {
            int i;
            string s;
            for (i = 1390; i <= 1600; i++)
            {
                cmbCashYear.Items.Add((object)i);
                cmbIssueYear.Items.Add((object)i);
                cmbStatusYear.Items.Add((object)i);
            }

            for (i = 1; i <= 30; i++)
            {
                s = i.ToString();
                if (s.Length == 1) s = "0" + s;
                cmbCashDay.Items.Add((object)s);
                cmbIssueDay.Items.Add((object)s);
                cmbStatusDay.Items.Add((object)s);
            }
        }

        private void FillComboBoxHistory()
        {
            SqlCommand cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            cmd.Parameters.AddWithValue("@Mode", 1);
            con.Open();
            dt.Load(cmd.ExecuteReader());
            dt1 = dt.Copy();
            dt2 = dt.Copy();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("chkFromToStatusName")).ToArray();
            ChequeFromToStatusNameCollection.AddRange(strAutoCompleteString);
            cmbFrom.DataSource = dt;
            cmbTo.DataSource = dt1;
            cmbStatusName.DataSource = dt2;
            cmbFrom.DisplayMember = cmbStatusName.DisplayMember = cmbTo.DisplayMember = "chkFromToStatusName";
            cmbFrom.AutoCompleteSource = cmbStatusName.AutoCompleteSource = cmbTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbFrom.AutoCompleteCustomSource = cmbTo.AutoCompleteCustomSource = cmbStatusName.AutoCompleteCustomSource;
            cmbFrom.AutoCompleteMode = cmbStatusName.AutoCompleteMode = cmbTo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            dt = new DataTable();
            cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 2);
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("chkFor")).ToArray();
            ChequeForCollection.AddRange(strAutoCompleteString);
            cmbFor.DataSource = dt;
            cmbFor.DisplayMember = "chkFor";
            cmbFor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbFor.AutoCompleteCustomSource = ChequeForCollection;
            cmbFor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            dt = new DataTable();
            cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 3);
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("BankName")).ToArray();
            ChequeBankNameCollection.AddRange(strAutoCompleteString);
            cmbBankName.DataSource = dt;
            cmbBankName.DisplayMember = "BankName";
            cmbBankName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbBankName.AutoCompleteCustomSource = ChequeBankNameCollection;
            cmbBankName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            dt = new DataTable();
            cmd = new SqlCommand("GetFileSubjectListForAddtoAnotherFileMethod", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FileCode", -1);
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("FileSubject")).ToArray();
            TransactionFileListCollection.AddRange(strAutoCompleteString);
            cmbAddToTransactions.DataSource = dt;
            cmbAddToTransactions.DisplayMember = "FileSubject";
            cmbAddToTransactions.ValueMember = "FileCode";
            cmbAddToTransactions.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbAddToTransactions.AutoCompleteCustomSource = TransactionFileListCollection;
            cmbAddToTransactions.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFrom.Text.Trim().Length == 0 || cmbTo.Text.Trim().Length == 0 || txtAmount.Text.Trim().Length == 0 || cmbCashYear.Text.Length == 0 || cmbCashMonth.Text.Length == 0 || cmbCashDay.Text.Length == 0)
            {
                MessageBox.Show("لطفا موارد خواسته شده را پر کنید", "btnSave_Click()");
                return;
            }
            if (Int64.Parse(txtAmount.Text.Replace(",", "")) == 0)
            {
                MessageBox.Show("مبلغ نمیتواند صفر باشد", "btnSave_Click()");
                return;
            }
            if (radStatusCashed.Checked || radStatusForwarded.Checked)
                if (cmbStatusYear.Text.Length == 0 || cmbStatusMonth.Text.Length == 0 || cmbStatusDay.Text.Length == 0)
                {
                    MessageBox.Show("لطفا تاریخ وصول/فروش را وارد نمایید", "btnSave_Click()");
                    return;
                }
            if (cmbFrom.Text.ToUpper() == cmbTo.Text.ToUpper())
            {
                MessageBox.Show("مبدا و مقصد چک نمیتوانند برابر باشند");
                return;
            }
            string strMonthFormat = (cmbCashMonth.SelectedIndex + 1).ToString();
            if (strMonthFormat.Length == 1) strMonthFormat = "0" + strMonthFormat;
            string strCashDate = cmbCashYear.Text + "/" + strMonthFormat + "/" + cmbCashDay.Text;

            strMonthFormat = (cmbIssueMonth.SelectedIndex + 1).ToString();
            if (strMonthFormat.Length == 1) strMonthFormat = "0" + strMonthFormat;
            string strIssueDate = cmbIssueYear.Text + "/" + strMonthFormat + "/" + cmbIssueDay.Text;

            strMonthFormat = (cmbStatusMonth.SelectedIndex + 1).ToString();
            if (strMonthFormat.Length == 1) strMonthFormat = "0" + strMonthFormat;
            string strStatusDate = cmbStatusYear.Text + "/" + strMonthFormat + "/" + cmbStatusDay.Text;
            if (String.CompareOrdinal(strIssueDate, strCashDate) > 0)
            {
                MessageBox.Show("تاریخ سررسید باید از تاریخ صدور بالاتر باشد");
                return;
            }
            if ((String.CompareOrdinal(strStatusDate, strCashDate) < 0) && (radStatusCashed.Checked))
            {
                MessageBox.Show("تاریخ وصول باید از تاریخ سررسید بالاتر باشد");
                return;
            }
            if ((String.CompareOrdinal(strStatusDate, strCashDate) > 0) && (radStatusForwarded.Checked))
            {
                MessageBox.Show("تاریخ فروش باید از تاریخ سررسید پایینتر باشد");
                return;
            }
            SqlCommand cmd = new SqlCommand("InsertIntoOrUpdateTblChequeList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (chkID.Trim().Length > 0)//Loaded
            {
                cmd.Parameters.AddWithValue("@Mode", 2); //Runs Update Command
                cmd.Parameters.AddWithValue("@pchkID", Int64.Parse(chkID));
                //cmd.Parameters.AddWithValue("@pCustomerID", );
                cmd.Parameters.AddWithValue("@pchkFrom", cmbFrom.Text.Trim());
                cmd.Parameters.AddWithValue("@pchkTo", cmbTo.Text.Trim());
                cmd.Parameters.AddWithValue("@pchkFor", cmbFor.Text.Trim());
                cmd.Parameters.AddWithValue("@pAmount", Double.Parse(txtAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture));
                cmd.Parameters.AddWithValue("@pCashDate", strCashDate);
                if (strIssueDate.Length == 10)
                    cmd.Parameters.AddWithValue("@pIssueDate", strIssueDate);
                else
                    cmd.Parameters.AddWithValue("@pIssueDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@pChequeSerial", txtSerialNum.Text.Trim());
                cmd.Parameters.AddWithValue("@pBankName", cmbBankName.Text.Trim());
                if (radStatusNone.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 0);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", DBNull.Value);
                }
                else if (radStatusCashed.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 1);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", strStatusDate);

                }
                else if (radStatusForwarded.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 2);
                    cmd.Parameters.AddWithValue("@pStatusName", cmbStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pStatusDate", strStatusDate);
                }
                else if (radStatusBounced.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 3);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@pchkDesc", txtDesc.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    blnSaveAndCloseCanExit = true;
                    if (cmbAddToTransactions.SelectedIndex > 0)
                    {
                        cmd = new SqlCommand("InsertIntoOrUpdateOrDeleteFromTransactionDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        Int64 intCode = cUF.GetNextUpperCode("code", "tbTransactionDetails");
                        cmd.Parameters.AddWithValue("@Mode", 1);
                        cmd.Parameters.AddWithValue("@tfilecode", cmbAddToTransactions.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@tcode", intCode);
                        cmd.Parameters.AddWithValue("@ttitle", cmbFrom.Text + " به " + cmbTo.Text);
                        string strAmount = txtAmount.Text.Replace(",", "");
                        if (chkFromMySelf.Checked) strAmount = "-" + strAmount;
                        cmd.Parameters.AddWithValue("@tamount", strAmount);
                        cmd.Parameters.AddWithValue("@tdate", strStatusDate);
                        cmd.Parameters.AddWithValue("@ttime", DateTime.Now.TimeOfDay.ToString());
                        cmd.Parameters.AddWithValue("@tdesc", "اضافه شده از طریق لیست چک ها");
                        cmd.Parameters.AddWithValue("@NewModifiedDate", cUF.GetFormattedPersianDate(DateTime.Now));
                        cmd.ExecuteNonQuery();
                        cmbAddToTransactions.SelectedIndex = 0;
                    }
                    cmd.Connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnSave_Click()");
                }
            }
            else //New
            {
                //string strNewID = cUF.GetNextUpperCode("chkID", "tblChequeList").ToString();
                string strNewID = txtID.Text;
                cmd.Parameters.AddWithValue("@Mode", 1); //Runs Insert Command
                cmd.Parameters.AddWithValue("@pchkID", Int64.Parse(strNewID));
                //cmd.Parameters.AddWithValue("@pCustomerID", );
                cmd.Parameters.AddWithValue("@pchkFrom", cmbFrom.Text.Trim());
                cmd.Parameters.AddWithValue("@pchkTo", cmbTo.Text.Trim());
                cmd.Parameters.AddWithValue("@pchkFor", cmbFor.Text.Trim());
                cmd.Parameters.AddWithValue("@pAmount", Double.Parse(txtAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture));
                cmd.Parameters.AddWithValue("@pCashDate", strCashDate);
                if (strIssueDate.Length == 10)
                    cmd.Parameters.AddWithValue("@pIssueDate", strIssueDate);
                else
                    cmd.Parameters.AddWithValue("@pIssueDate", DBNull.Value);
                cmd.Parameters.AddWithValue("@pChequeSerial", txtSerialNum.Text.Trim());
                cmd.Parameters.AddWithValue("@pBankName", cmbBankName.Text.Trim());
                if (radStatusNone.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 0);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", DBNull.Value);
                }
                else if (radStatusCashed.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 1);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", strStatusDate);
                }
                else if (radStatusForwarded.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 2);
                    cmd.Parameters.AddWithValue("@pStatusName", cmbStatusName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pStatusDate", strStatusDate);
                }
                else if (radStatusBounced.Checked)
                {
                    cmd.Parameters.AddWithValue("@pchkStatus", 3);
                    cmd.Parameters.AddWithValue("@pStatusName", DBNull.Value);
                    cmd.Parameters.AddWithValue("@pStatusDate", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@pchkDesc", txtDesc.Text);
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    blnSaveAndCloseCanExit = true;
                    btnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnSave_Click()");
                }
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            if (blnSaveAndCloseCanExit)
                this.Close();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&&(e.KeyChar != '.')
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

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtAmount.Text))
                {
                    Double valueBefore = Double.Parse(txtAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture);
                    txtAmount.Text = String.Format(culture, "{0:N0}", valueBefore);
                    txtAmount.Select(txtAmount.Text.Length, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtPayAmount_KeyUp()");
            }
        }

        private void cmbCashMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            {//cmbDayCountInitialize
                try
                {
                    if (((ComboBox)sender).SelectedIndex <= 5 && cmbCashDay.Items.Count == 30)
                        cmbCashDay.Items.Add((object)31);
                    else if (((ComboBox)sender).SelectedIndex > 5 && cmbCashDay.Items.Count == 31)
                        cmbCashDay.Items.Remove((object)31);
                    //

                    if (cmbCashDay.SelectedIndex < 0)
                    {
                        cmbCashDay.SelectedIndex = 29;
                        return;
                    }
                }
                catch { }
            }
        }

        private void cmbIssueMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            {//cmbDayCountInitialize
                try
                {
                    if (((ComboBox)sender).SelectedIndex <= 5 && cmbIssueDay.Items.Count == 30)
                        cmbIssueDay.Items.Add((object)31);
                    else if (((ComboBox)sender).SelectedIndex > 5 && cmbIssueDay.Items.Count == 31)
                        cmbIssueDay.Items.Remove((object)31);
                    //

                    if (cmbIssueDay.SelectedIndex < 0)
                    {
                        cmbIssueDay.SelectedIndex = 29;
                        return;
                    }
                }
                catch { }
            }
        }

        private void btnCashDateToday_Click(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            cmbCashYear.Text = iyear.ToString();
            cmbCashMonth.SelectedIndex = imonth - 1;
            cmbCashDay.SelectedIndex = iday - 1;
        }

        private void btnIssueDateToday_Click(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            cmbIssueYear.Text = iyear.ToString();
            cmbIssueMonth.SelectedIndex = imonth - 1;
            cmbIssueDay.SelectedIndex = iday - 1;
        }

        private void frmChequeDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void radStatusNone_CheckedChanged(object sender, EventArgs e)
        {
            gbChequeStatus.Enabled = !radStatusNone.Checked;
        }

        private void radStatusCashed_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatusName.Enabled = !radStatusCashed.Checked;
            cmbAddToTransactions.Enabled = radStatusCashed.Checked;
        }

        private void radStatusForwarded_CheckedChanged(object sender, EventArgs e)
        {
            cmbStatusName.Enabled = radStatusForwarded.Checked;
            cmbAddToTransactions.Enabled = !radStatusForwarded.Checked;
        }

        private void radStatusBounced_CheckedChanged(object sender, EventArgs e)
        {
            gbChequeStatus.Enabled = !radStatusBounced.Checked;
        }

        private void chkFromMySelf_CheckedChanged(object sender, EventArgs e)
        {
            chkToMySelf.Enabled = cmbFrom.Enabled = radStatusBounced.Enabled = radStatusForwarded.Enabled = !chkFromMySelf.Checked;
            radStatusNone.Checked = true;
            if (chkFromMySelf.Checked)
            {
                cmbFrom.Tag = cmbFrom.Text;
                cmbFrom.Text = "خودم";
            }
            else cmbFrom.Text = cmbFrom.Tag.ToString();
        }

        private void chkToMySelf_CheckedChanged(object sender, EventArgs e)
        {
            chkFromMySelf.Enabled = cmbTo.Enabled = !chkToMySelf.Checked;
            if (chkToMySelf.Checked)
            {
                cmbTo.Tag = cmbTo.Text;
                cmbTo.Text = "خودم";
            }
            else cmbTo.Text = cmbTo.Tag.ToString();
        }

        private void cmbStatusToday_Click(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
            int iyear = PCal.GetYear(DateTime.Today);
            int imonth = PCal.GetMonth(DateTime.Today);
            int iday = PCal.GetDayOfMonth(DateTime.Today);
            cmbStatusYear.Text = iyear.ToString();
            cmbStatusMonth.SelectedIndex = imonth - 1;
            cmbStatusDay.SelectedIndex = iday - 1;
        }

        private void cmbStatusMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            {//cmbDayCountInitialize
                try
                {
                    if (((ComboBox)sender).SelectedIndex <= 5 && cmbStatusDay.Items.Count == 30)
                        cmbStatusDay.Items.Add((object)31);
                    else if (((ComboBox)sender).SelectedIndex > 5 && cmbStatusDay.Items.Count == 31)
                        cmbStatusDay.Items.Remove((object)31);
                    //

                    if (cmbStatusDay.SelectedIndex < 0)
                    {
                        cmbStatusDay.SelectedIndex = 29;
                        return;
                    }
                }
                catch { }
            }
        }

        private void cmbFrom_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == _MySelf) chkFromMySelf.Checked = true;
        }

        private void cmbTo_Leave(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Text == _MySelf) chkToMySelf.Checked = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("آیا از حذف این چک مطمئن هستید ؟", "حذف چک", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                    return;
                SqlCommand cmd = new SqlCommand("DELETE FROM tblChequeList WHERE chkID = @ChequeID", con);
                cmd.Parameters.AddWithValue("@ChequeID", txtID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                this.Close();
            }
            catch { }
            finally { con.Close(); }
        }

        private void BtnSaveAndNew_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            chkID = "";
            frmChequeDetail_Shown(sender, e);
        }
    }
}