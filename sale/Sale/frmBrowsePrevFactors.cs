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
    public partial class frmBrowsePrevFactors : Form
    {
        DataTable tbSale = new DataTable();
        AutoCompleteStringCollection customerCollection = new AutoCompleteStringCollection();
        System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
        Boolean blnCanInitial_lvSale = false; //To prevent initial_lvsale2 from "Multiple running".
        string strCustomerCode = "";
        string strCurrentFactorNumber = "";
        public string ReturnValFactorNum { get; private set; }
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;
        public frmBrowsePrevFactors(string strCustCode, string strCurrFactorNum)
        {
            strCustomerCode = strCustCode;
            strCurrentFactorNumber = strCurrFactorNum;
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            lvSale.ListViewItemSorter = lvwColumnSorter;
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

        cUserFunction cUF = new cUserFunction();

        private void frmBrowsePrevFactors_Load(object sender, EventArgs e)
        {
            Initial_CalenderForComboBoxes();
            //cmbFinStatus
            cmbFinStatus.SelectedIndex = 0;
            //
            Initial_txtCustomer();
            txtFactorNum.Text = strCurrentFactorNumber;
            blnCanInitial_lvSale = true;
            initial_lvSale2();
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
            //if (MinYear == MaxYear)
            //    cmbYear.SelectedIndex = 1;
            //else
            //    cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbYear.SelectedIndex = 0;
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

        private void Initial_txtCustomer()
        {
            string strda = "select [code], [name] from tbCustomer WHERE [code]=" + strCustomerCode; ;
            SqlConnection con = new SqlConnection(Frm_main.conStr);
            SqlDataAdapter da = new SqlDataAdapter(strda, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtCustomerName.Text = dt.Rows[0]["name"].ToString();
            this.Text += txtCustomerName.Text;
            //DataRow dr = dt.NewRow();
            //dr["name"] = "همه";
            //dr["code"] = -1;
            //dt.Rows.InsertAt(dr, 0);
            //customerCollection.Add("همه");
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    customerCollection.Add(dt.Rows[i]["name"].ToString());
            //}
            //cmbCustomerName.DataSource = dt;
            //cmbCustomerName.DisplayMember = "name";
            //cmbCustomerName.ValueMember = "code";
            //cmbCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cmbCustomerName.AutoCompleteCustomSource = customerCollection;
            //cmbCustomerName.AutoCompleteMode = AutoCompleteMode.Suggest;
            //cmbCustomerName.SelectedIndex = 0;
        }

        private string BuildFilterCustomerName()
        {
            string str = "%";
            //if (cmbCustomerName.SelectedIndex == 0)
            //    return str;
            //else if (cmbCustomerName.Text.Trim().Length != 0)
            //    str = cmbCustomerName.Text.Trim() + str;
            return str;
        }

        private string BuildFilterFactorNum()
        {
            string str = "%";
            if (txtFactorNum.Text.Trim().Length != 0)
                str = txtFactorNum.Text.Trim() + str;
            return str;
        }

        private string BuildFilterFactorFinStatus()
        {
            string str = "";
            if (cmbFinStatus.SelectedIndex == 0)//Show all
                str= "%";
            else if (cmbFinStatus.SelectedIndex == 1)//If "Tasvieh"
                str = "[0]%";
            else if (cmbFinStatus.SelectedIndex == 2)//If "Bedehkar"
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
            //lblFilterDateString.Text = strFilterDate;
            //MessageBox.Show(strFilterDate);
        }

        private void initial_lvSale2()
        {
            if (blnCanInitial_lvSale)
            {
                SqlConnection con = new SqlConnection(Frm_main.conStr);
                SqlCommand cmd = new SqlCommand("LoadAllPreviousFactorsForSingleCustomer", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Current_FacNum", strCurrentFactorNumber);
                cmd.Parameters.AddWithValue("@S_Date", BuildFilterDateString());
                //cmd.Parameters.AddWithValue("@S_FinStatus", BuildFilterFactorFinStatus());
                //cmd.Parameters.AddWithValue("@Fac_Num", BuildFilterFactorNum());
                cmd.Parameters.AddWithValue("@C_Code", strCustomerCode);

                con.Open();
                tbSale.Clear();
                tbSale.Load(cmd.ExecuteReader());
                con.Close();
                //foreach (DataColumn col in tbSale.Columns) col.ReadOnly = false;
                //foreach (DataRow dr in tbSale.Rows)
                //{
                //    dr["FacSum"] = cUF.split_space(dr["FacSum"].ToString(), ",");
                //    dr["TotalPayment"] = cUF.split_space(dr["TotalPayment"].ToString(), ",");
                //    dr["PrevTotalRemained"] = cUF.split_space(dr["PrevTotalRemained"].ToString(), ",");
                //    dr["TotalBalance"] = cUF.split_space(dr["TotalBalance"].ToString(), ",");
                //}
                string strFaCol = "ش فاکتور:نام مشتری:تاریخ:ساعت:جمع فاکتور:مانده قبل:فاکتور قبل:جمع پرداختها:تراز فاکتور:فاکتور بعد";
                string strCol = "factorNum:name:date:time:FacSum:PrevTotalRemained:PrevFactorNum:TotalPayment:TotalBalance:FwdFactorNum";
                int[] w = { 63, 200, 83, 65, 100, 100, 66, 100, 100, 65 };
                cUF.initialListView2(tbSale, strFaCol, strCol, lvSale, w, this.Name);
                lvSale.Columns["CheckBox"].Width = 0;
                
                //foreach (ListViewItem lvi in lvSale.Items)
                //{
                //    //To change row color according to "TotalBalance" value.
                //
                //}
            }
        }

        private void lvSale_DoubleClick(object sender, EventArgs e)
        {
            btnSelectAndClose_Click(sender, e);
            //Frm_sale fs = new Frm_sale();
            //fs.facNum= lvSale.SelectedItems[0].SubItems[1].Text.Trim();
            //fs.history = false;
            //fs.Show();
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
                    if (cmbMonth.SelectedIndex <= 6 && cmbDay.Items.Count == 31)
                        cmbDay.Items.Add((object)31);
                    else if (cmbMonth.SelectedIndex > 6 && cmbDay.Items.Count == 32)
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
                initial_lvSale2();
            }
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_lvSale2();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_lvSale2();
        }

        private void cmbFinStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_lvSale2();
        }

        private void txtFactorNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
            //if (e.KeyChar == (char)Keys.Enter)
            //    initial_lvSale2();
        }

        private void cmbCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                initial_lvSale2();
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            initial_lvSale2();
        }

        private void btnSelectAndClose_Click(object sender, EventArgs e)
        {
            if (lvSale.SelectedItems.Count > 0)
            {
                this.ReturnValFactorNum = lvSale.SelectedItems[0].SubItems[1].Text; //Return FactorNumber
                this.Close();
            }
        }

        private void frmBrowsePrevFactors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tmnuOpenFactor_Click(object sender, EventArgs e)
        {
            if (lvSale.SelectedItems.Count != 0)
            {
                FrmFactorDetail2 fs = new FrmFactorDetail2();
                fs.facNum = lvSale.SelectedItems[0].SubItems["factorNum"].Text.Trim();
                fs.history = false;
                fs.ShowDialog(this);
                initial_lvSale2();
            }
        }

        private void tmnuSelectFactor_Click(object sender, EventArgs e)
        {
            if (lvSale.SelectedItems.Count != 0)
                lvSale_DoubleClick(sender, e);
        }

        private void lvSale_ColumnClick(object sender, ColumnClickEventArgs e)
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
