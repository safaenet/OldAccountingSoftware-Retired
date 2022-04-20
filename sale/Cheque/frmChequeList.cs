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
    public partial class frmChequeList : Form
    {
        Boolean blnCanInitial_lvChequeList = false; //To prevent initial_lvChequeList from "Multiple running".
        SafaShop.cUserFunction cUF = new cUserFunction();
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        const string _MySelf = "خودم";
        AutoCompleteStringCollection cmbFromCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection cmbToCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection cmbBuyerCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection cmbBankNameCollection = new AutoCompleteStringCollection();
        DataTable tbChequeList = new DataTable();
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;

        public frmChequeList()
        {
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            lvChequeList.ListViewItemSorter = lvwColumnSorter;
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

        private void frmChequeList_Load(object sender, EventArgs e)
        {
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            cUF.ChangeLanguage("fa");
        }

        private void frmChequeList_Shown(object sender, EventArgs e)
        {
            initial_ComboBoxes();
            blnCanInitial_lvChequeList = true;
            Initial_lvChequeList();
        }

        private void Initial_lvChequeList()
        {
            try
            {
                if (blnCanInitial_lvChequeList)
                {
                    SqlConnection con = new SqlConnection(Frm_main.conStr);
                    SqlCommand cmd = new SqlCommand("LoadChequeList", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmbFrom.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@pFrom", cmbFrom.Text.Trim());
                    if (cmbTo.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@pTo", cmbTo.Text.Trim());
                    if (cmbBuyer.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@pStatusName", cmbBuyer.Text.Trim());
                    if (cmbBankName.SelectedIndex != 0)
                        cmd.Parameters.AddWithValue("@pBankName", cmbBankName.Text.Trim());
                    cmd.Parameters.AddWithValue("@pStatus", cmbStatus.SelectedIndex);
                    cmd.Parameters.AddWithValue("@pPersianToday", cUF.GetFormattedPersianDate(DateTime.Now));
                    con.Open();
                    tbChequeList.Clear();
                    tbChequeList.Load(cmd.ExecuteReader());
                    con.Close();
                    string strFaCol = "ردیف:شناسه:شماره مشتری:مبدا:مقصد:مبلغ:نام بانک:تاریخ سررسید:وضعیت خام:وضعیت";
                    string strCol = "RowNumber:chkID:CustomerID:chkFrom:chkTo:Amount:BankName:CashDate:chkStatus:chkStatus2";
                    int[] w = { 60, 0, 0, 200, 200, 190, 160, 90, 0, 85 };
                    cUF.initialListView2(tbChequeList, strFaCol, strCol, lvChequeList, w, this.Name);
                    lvChequeList.Columns["CheckBox"].Width = 0;
                    SetLvChequeListColors();
                }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Initial_lvChequeList()");
            }
}

        void SetLvChequeListColors()
        {
            string strNextChequeDate = cUF.getPersianDate(DateTime.Now.AddDays(2));
            string strToday = cUF.GetFormattedPersianDate(DateTime.Now);
            bool blnBlinkStatus = false;
            double dblFromSum = 0;
            double dblToSum = 0;
            Color[] clrSeq = { Color.FromArgb(255, 237, 237), Color.FromArgb(237, 244, 255) };
            byte bytClrSeqIndex = 0;
            foreach (ListViewItem lvi in lvChequeList.Items)
            {
                lvi.UseItemStyleForSubItems = false;
                if (String.CompareOrdinal(lvi.SubItems["CashDate"].Text.Trim().Replace("/", ""), strNextChequeDate) <= 0 && String.CompareOrdinal(lvi.SubItems["CashDate"].Text.Trim().Replace("/", ""), strToday.Replace("/", "")) > 0)
                {
                    lvi.SubItems["CashDate"].BackColor = Color.FromArgb(248, 255, 175);
                    blnBlinkStatus = true;
                }
                else if (lvi.SubItems["CashDate"].Text.Trim() == strToday)
                {
                    lvi.SubItems["CashDate"].BackColor = Color.FromArgb(255, 255, 104);
                    blnBlinkStatus = true;
                }
                else
                {
                    if (lvi.Index == 0)
                        lvi.SubItems["CashDate"].BackColor = clrSeq[bytClrSeqIndex = 0];
                    else
                        if (lvi.SubItems["CashDate"].Text == lvChequeList.Items[lvi.Index - 1].SubItems["CashDate"].Text)
                        lvi.SubItems["CashDate"].BackColor = lvChequeList.Items[lvi.Index - 1].SubItems["CashDate"].BackColor;
                    else
                    {
                        if (++bytClrSeqIndex == clrSeq.Length) bytClrSeqIndex = 0;
                        lvi.SubItems["CashDate"].BackColor = clrSeq[bytClrSeqIndex];
                    }
                }
                if (lvi.SubItems["chkStatus"].Text.Trim() == "1") //Cashed
                {
                    lvi.SubItems["chkStatus2"].BackColor = Color.FromArgb(124, 255, 166);
                    blnBlinkStatus = false;
                }
                else if (lvi.SubItems["chkStatus"].Text.Trim() == "2") //Forwarded
                {
                    lvi.SubItems["chkStatus2"].BackColor = Color.FromArgb(124, 220, 255);
                    blnBlinkStatus = false;
                }
                else if (lvi.SubItems["chkStatus"].Text.Trim() == "3") //Bounced
                {
                    lvi.SubItems["chkStatus2"].BackColor = Color.FromArgb(255, 150, 124);
                    blnBlinkStatus = false;
                }
                if ((lvi.SubItems["chkFrom"].Text == _MySelf || lvi.SubItems["chkTo"].Text == _MySelf) && lvi.SubItems["chkStatus"].Text == "0")
                    if (lvi.SubItems["chkFrom"].Text == _MySelf)
                        dblFromSum += Convert.ToDouble(lvi.SubItems["Amount"].Text);
                    else
                        dblToSum += Convert.ToDouble(lvi.SubItems["Amount"].Text);
            }
            tsslFromSum.Text = cUF.split_space(dblFromSum.ToString(), ",");
            tsslToSum.Text = cUF.split_space(dblToSum.ToString(), ",");
            tsslTotalBalance.Text = cUF.split_space((dblToSum - dblFromSum).ToString(), ",");
            Frm_main.AccessBlnBlinkTsbChequeList = blnBlinkStatus;
        }

        void initial_ComboBoxes()
        {
            SqlCommand cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "12");
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("chkFrom")).ToArray();
            cmbFromCollection.AddRange(strAutoCompleteString);
            cmbFrom.DataSource = dt;
            cmbFrom.DisplayMember = "chkFrom";
            cmbFrom.ValueMember = "chkFrom";
            cmbFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbFrom.AutoCompleteCustomSource = cmbFromCollection;
            cmbFrom.AutoCompleteMode = AutoCompleteMode.Suggest;

            cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "22");
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("chkTo")).ToArray();
            cmbToCollection.AddRange(strAutoCompleteString);
            cmbTo.DataSource = dt;
            cmbTo.DisplayMember = "chkTo";
            cmbTo.ValueMember = "chkTo";
            cmbTo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbTo.AutoCompleteCustomSource = cmbFromCollection;
            cmbTo.AutoCompleteMode = AutoCompleteMode.Suggest;

            cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "42");
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("chkStatusName")).ToArray();
            cmbBuyerCollection.AddRange(strAutoCompleteString);
            cmbBuyer.DataSource = dt;
            cmbBuyer.DisplayMember = "chkStatusName";
            cmbBuyer.ValueMember = "chkStatusName";
            cmbBuyer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbBuyer.AutoCompleteCustomSource = cmbBuyerCollection;
            cmbBuyer.AutoCompleteMode = AutoCompleteMode.Suggest;

            cmd = new SqlCommand("LoadComboBoxHistoriesFromTblChequeList", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", "32");
            dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("BankName")).ToArray();
            cmbBankNameCollection.AddRange(strAutoCompleteString);
            cmbBankName.DataSource = dt;
            cmbBankName.DisplayMember = "BankName";
            cmbBankName.ValueMember = "BankName";
            //cmbBankName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cmbBankName.AutoCompleteCustomSource = cmbFromCollection;
            //cmbBankName.AutoCompleteMode = AutoCompleteMode.Suggest;

            con.Close();
            cmbStatus.SelectedIndex = 5; //Can be changed.
        }
        private void btnNewCheque_Click(object sender, EventArgs e)
        {
            frmChequeDetail frmNew = new frmChequeDetail();
            frmNew.ShowDialog(this);
            Initial_lvChequeList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void lvChequeList_DoubleClick(object sender, EventArgs e)
        {
            if (lvChequeList.SelectedItems.Count == 0) return;
            frmChequeDetail frm = new frmChequeDetail();
            frm.chkID = lvChequeList.SelectedItems[0].SubItems["chkID"].Text.Trim();
            frm.ShowDialog();
            btnRefresh_Click(sender, e);
        }

        private void frmChequeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void cmbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void cmbBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initial_lvChequeList();
        }

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            lvChequeList_DoubleClick(sender, e);
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvChequeList.SelectedItems.Count == 0)
                return;
            try
            {
                DialogResult dr = MessageBox.Show("آیا از حذف این چک مطمئن هستید ؟", "حذف چک", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                    return;
                SqlCommand cmd = new SqlCommand("DELETE FROM tblChequeList WHERE chkID = @ChequeID", con);
                cmd.Parameters.AddWithValue("@ChequeID", lvChequeList.SelectedItems[0].SubItems["chkID"].Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Initial_lvChequeList();
            }
            catch { }
            finally { con.Close(); }
        }

        private void lvChequeList_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void chkStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = chkStatusBar.Checked;
        }
    }
}