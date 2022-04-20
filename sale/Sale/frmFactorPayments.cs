using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SafaShop
{
    public partial class frmFactorPayments : Form
    {
        string strFactorNum;
        string strCustomerCode;
        cUserFunction cUF = new cUserFunction();
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        string strPayCode = "";
        public string strPrevFactorRemainedAmount = "";
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("fa-IR");
        AutoCompleteStringCollection customerCollection = new AutoCompleteStringCollection();
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;
        public frmFactorPayments(string strFNum, string strCustomer)
        {
            strFactorNum = strFNum;
            strCustomerCode = strCustomer;
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            lvPayments.ListViewItemSorter = lvwColumnSorter;
        }

        //Avoids Horizontally resize cursor to appear!
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 0x84: //WM_NCHITTEST
                    var result = (HitTest)m.Result.ToInt32();
                    if (result == HitTest.Left || result == HitTest.Right)
                        m.Result = new IntPtr((int)HitTest.Caption);
                    if (result == HitTest.TopLeft || result == HitTest.TopRight)
                        m.Result = new IntPtr((int)HitTest.Top);
                    if (result == HitTest.BottomLeft || result == HitTest.BottomRight)
                        m.Result = new IntPtr((int)HitTest.Bottom);

                    break;
            }
        }
        enum HitTest
        {
            Caption = 2,
            Transparent = -1,
            Nowhere = 0,
            Client = 1,
            Left = 10,
            Right = 11,
            Top = 12,
            TopLeft = 13,
            TopRight = 14,
            Bottom = 15,
            BottomLeft = 16,
            BottomRight = 17,
            Border = 18
        }
        ///////////////////////////////////////

        Double RemainedAmount(string str1, string str2)
        {
            Double intMinusResult = 0;
            try
            {
                Double intFT = Double.Parse(str1.Replace(",", "").Trim());
                Double intPT = Double.Parse(str2.Replace(",", "").Trim());
                intMinusResult = intFT - intPT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RemainedAmount()");
            }
            return intMinusResult;
        }

        void initialTxtFactorTotal()
        {
            string strda = "SELECT FORMAT(ROUND(ISNULL(SUM(tbSaleDetail.price * tbSaleDetail.[count]),0),0), '#,0.') AS FactorTotal " +
                           "FROM dbo.tbSaleDetail WHERE factorNum = " + strFactorNum.Trim();
            //string strda = "SELECT ROUND(ISNULL(SUM(tbSaleDetail.price * tbSaleDetail.[count]),0),0) AS FactorTotal " +
            //   "FROM dbo.tbSaleDetail WHERE factorNum = " + strFactorNum.Trim();
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtFactorTotal.Text = dt.Rows[0]["FactorTotal"].ToString().Trim();
        }

        private void clearDetail()
        {
            strPayCode = "";
            txtPayAmount.Clear();
            //cmbPayDesc.SelectedIndex = 0;
        }

        private void initial_lvPayments()
        {
            try
            {
                string strda = "SELECT dbo.tbSalePayments.code, " +
               " dbo.tbSalePayments.FactorNum, dbo.tbSalePayments.PayDate," +
               " dbo.tbSalePayments.Amount, dbo.tbSalePayments.Description FROM  dbo.tbSalePayments " +
                     " WHERE FactorNum=" + txtFactorNum.Text.Trim();
                cUF = new cUserFunction();
                string strFaCol = "کد:شماره فاکتور:تاریخ پرداخت:مبلغ:توضیحات";
                string strCol = "code:FactorNum:PayDate:Amount:Description";
                int[] w = { 0, 0, 100, 180, 420 };
                cUF.initialListView(strda, strFaCol, strCol, lvPayments, w);
                TotalPaymentAndTotalBalance();
                cUF.spaceNum(4, lvPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initial_lvPayments()");
            }
        }

        private void initial_lvPayments2()
        {
            try
            {
                con.Close();
                SqlCommand cmd = new SqlCommand("LoadFactorPaymentsForSingleFactor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fac_Num", strFactorNum.Trim());
                DataTable tb = new DataTable();
                cmd.Connection.Open();
                tb.Load(cmd.ExecuteReader());
                cmd.Connection.Close();
                cUF = new cUserFunction();
                string strFaCol = "ردیف:کد:شماره فاکتور:تاریخ پرداخت:ساعت پرداخت:مبلغ:توضیحات";
                string strCol = "RowNumber:code:FactorNum:PayDate:PayTime:Amount:Description";
                int[] w = {40, 0, 0, 100, 100, 180, 420 };
                cUF.initialListView2(tb, strFaCol, strCol, lvPayments, w, this.Name);
                lvPayments.Columns["CheckBox"].Width = 0;
                TotalPaymentAndTotalBalance();
                //cUF.spaceNum(4, lvPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initial_lvPayments2()");
            }
        }

        private void TotalPaymentAndTotalBalance()
        {
            try
            {
                Double grandt = 0;
                for (int i = 0; i < lvPayments.Items.Count; i++)
                    grandt += Double.Parse(lvPayments.Items[i].SubItems["Amount"].Text.Trim().Replace(",", ""));
                txtPaymentTotal.Text = cUF.split_space(grandt.ToString(), ",");
                txtPaymentTotal_TextChanged(new Object(), new EventArgs());
                txtTotalBalance.Text = cUF.split_space((Double.Parse(txtFactorBalance.Text.Trim().Replace(",", "")) + Double.Parse(strPrevFactorRemainedAmount.Trim().Replace(",", ""))).ToString(), ",");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "TotalPaymentAndTotalBalance()");
            }
        }

        private void GetDistinctDescriptionForCmbPayDesc()
        {
            string strcmd = "select 'پرداخت نقدی' as PayDesc, 0 as RowOrder "+
            "union all "+
            "select 'کارت به کارت' as PayDesc, 1 as RowOrder " +
            "union all " +
            "select 'پرداخت با کارت یارانه' as PayDesc,2 as RowOrder " +
            "union all " +
            "select 'انتقال حساب' as PayDesc, 3 as RowOrder " +
            "union all " +
            "select 'پرداخت با چک ' as PayDesc, 4 as RowOrder " +
            "union all " +
            "select distinct Cast(tbSalePayments.[Description] as NVarchar(Max)) as PayDesc, 5 as RowOrder from tbSalePayments ORDER BY RowOrder";
            SqlCommand cmd = new SqlCommand(strcmd, con);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("PayDesc")).ToArray();
            customerCollection.AddRange(strAutoCompleteString);
            cmbPayDesc.DataSource = dt;
            cmbPayDesc.DisplayMember = "PayDesc";
            cmbPayDesc.ValueMember = "PayDesc";
            cmbPayDesc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbPayDesc.AutoCompleteCustomSource = customerCollection;
            cmbPayDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        private void frmFactorPayments_Load(object sender, EventArgs e)
        {
            cUF.ChangeLanguage("fa");
            txtFactorNum.Text = strFactorNum;
            initialTxtFactorTotal();
            initial_lvPayments2();
            GetDistinctDescriptionForCmbPayDesc();
            this.Show();
            cmbPayDesc.SelectedText = "";
            txtPayAmount.Focus();
            //this.Text = cmbCustomer.Text.Trim() + "-" + txtFactorNum.Text.Trim();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                if (txtPayAmount.Text.Trim().Length == 0 || txtPayAmount.Text.Trim() == "0")
                    MessageBox.Show("ابتدا مبلغ را وارد کنید", "btnAdd_Click()");
                else
                {
                    if (strPayCode.Trim().Length == 0)
                    {
                        //if (RemainedAmount(txtBalance.Text.Trim(), txtPayAmount.Text.Trim()) < 0)
                        //    MessageBox.Show("مبلغ پرداختی نمی تواند از مبلغ باقیمانده فاکتور بیشتر باشد", "پرداخت مبلغ جدید");
                        //else
                        //{
                            string strcmd = "INSERT INTO tbSalePayments (code, FactorNum, PayDate, PayTime" +
                                          ", Amount, Description) Values" +
                                  "(@code, @fnum, @pd, @pt, @amnt, @desc)";
                            SqlCommand cmd = new SqlCommand(strcmd, con);
                            string strMaxCode = cUF.GetNextUpperCode("code", "tbSalePayments").ToString();
                            cmd.Parameters.AddWithValue("@code", strMaxCode);
                            cmd.Parameters.AddWithValue("@fnum", txtFactorNum.Text.Trim());
                            cmd.Parameters.AddWithValue("@pd", cUF.GetFormattedPersianDate(DateTime.Now));
                            cmd.Parameters.AddWithValue("@pt", cUF.getTime());
                            //cmd.Parameters.AddWithValue("@amnt", txtPayAmount.Text.Trim().Replace(",", ""));
                            cmd.Parameters.AddWithValue("@amnt", Double.Parse(txtPayAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture));
                            cmd.Parameters.AddWithValue("@desc", cmbPayDesc.Text.Trim());
                            try
                            {
                                cmd.Connection.Open();
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                                initial_lvPayments2();
                                clearDetail();
                                txtPayAmount.Focus();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "btnAdd_Click()");
                                txtPayAmount.Focus();
                            }
                            finally
                            {
                                cmd.Connection.Close();
                            }
                        //}
                    }
                    else
                    {
                        //double dblRA1 = 0;
                        //double dblRA2 = 0;
                        //try
                        //{
                        //    dblRA1 = RemainedAmount(txtPayAmount.Text.Trim(), lvPayments.SelectedItems[0].SubItems[5].Text.Trim());
                        //    dblRA2 = RemainedAmount(txtBalance.Text, dblRA1.ToString());
                        //}
                        //catch { }
                        //if (dblRA2 < 0)
                        //    MessageBox.Show("مبلغ پرداختی نمی تواند از مبلغ باقیمانده فاکتور بیشتر باشد", "ویرایش مبلغ پرداخت شده");
                        //else
                        //{
                            string strcmd = "update tbSalePayments set " +
                                            "Amount=@amnt,Description=@desc where code=@code";
                            SqlCommand cmd = new SqlCommand(strcmd, con);
                            cmd.Parameters.AddWithValue("@amnt", Double.Parse(txtPayAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture));
                            cmd.Parameters.AddWithValue("@desc", cmbPayDesc.Text.Trim());
                            cmd.Parameters.AddWithValue("@code", strPayCode.Trim());
                            try
                            {
                                cmd.Connection.Open();
                                cmd.ExecuteNonQuery();
                                cmd.Connection.Close();
                                initial_lvPayments2();
                                clearDetail();
                                txtPayAmount.Focus();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "btnAdd_Click()");
                                txtPayAmount.Focus();
                            }
                            finally
                            {
                                cmd.Connection.Close();
                            }
                        //}
                    }
                }
                
        }

        private void btnWholeFactorAmount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalBalance.Text))
            {
                txtPayAmount.Text = String.Format(culture, "{0:N0}", txtFactorBalance.Text);
                txtPayAmount.Select(txtPayAmount.Text.Length, 0);
            }
            txtPayAmount.Focus();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            string strCmd = "DELETE FROM tbSalePayments WHERE code=@code";
            SqlCommand cmd = new SqlCommand(strCmd, con);
            try
            {

                cmd.Parameters.AddWithValue("@code", lvPayments.SelectedItems[0].SubItems["code"].Text);

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                strPayCode = "";
                initial_lvPayments2();

            }
            catch
            {
                //MessageBox.Show(ex.Message, "tsmDelete_Click()");
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        private void lvPayments_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lvPayments.SelectedItems[0].SubItems["Amount"].Text.Trim()))
                {
                    txtPayAmount.Text = String.Format(culture, "{0:N0}", lvPayments.SelectedItems[0].SubItems["Amount"].Text.Trim());
                    txtPayAmount.Select(txtPayAmount.Text.Length, 0);
                }
                else txtPayAmount.Text = "0";
                cmbPayDesc.Text = lvPayments.SelectedItems[0].SubItems["Description"].Text.Trim();
                strPayCode = lvPayments.SelectedItems[0].SubItems["code"].Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lvPayments_DoubleClick()");
            }
        }

        private void txtPayAmount_KeyPress(object sender, KeyPressEventArgs e)
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
                txtPayAmount.Text = "";
            }

            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void txtPayDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void frmFactorPayments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnTotalBalanceAmount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTotalBalance.Text))
            {
                txtPayAmount.Text = String.Format(culture, "{0:N0}", txtTotalBalance.Text);
                txtPayAmount.Select(txtPayAmount.Text.Length, 0);
            }
            txtPayAmount.Focus();
        }

        private void txtPaymentTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtFactorBalance.Text = RemainedAmount(txtFactorTotal.Text, txtPaymentTotal.Text).ToString();
                txtFactorBalance.Text = cUF.split_space(txtFactorBalance.Text, ",");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtPaymentTotal_TextChanged()");
            }
        }

        private void txtPayAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtPayAmount.Text))
                {
                    Double valueBefore = Double.Parse(txtPayAmount.Text, System.Globalization.NumberStyles.AllowThousands, culture);
                    txtPayAmount.Text = String.Format(culture, "{0:N0}", valueBefore);
                    txtPayAmount.Select(txtPayAmount.Text.Length, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtPayAmount_KeyUp()");
            }
        }

        private void cmbPayDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void lvPayments_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            try
            {
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }

                // Perform the sort with these new sort options.
                ((ListView)sender).Sort();
            }
            catch { }
        }
    }
}