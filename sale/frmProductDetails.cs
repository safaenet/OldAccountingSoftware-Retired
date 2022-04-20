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
    public partial class frmProductDetails : Form
    {
        int intProductCode;
        bool blnCanInitializeLv = false;
        private readonly SqlConnection con = new SqlConnection(Frm_main.conStr);
        private readonly cUserFunction cUF = new cUserFunction();
        int intCurrentCounterID = -1;
        public frmProductDetails(int ProductCode)
        {
            InitializeComponent();
            intProductCode = ProductCode;
        }

        private void FrmProductDetails_Load(object sender, EventArgs e)
        {
            txtProductCode.Text = intProductCode.ToString();
            var SearchField = new BindingList<KeyValuePair<string, string>>();
            SearchField.Add(new KeyValuePair<string, string>("0", "بالاترین"));
            SearchField.Add(new KeyValuePair<string, string>("1", "پایین ترین"));
            cmbPriority.DataSource = SearchField;
            cmbPriority.ValueMember = "Key";
            cmbPriority.DisplayMember = "Value";
            cmbPriority.SelectedIndex = 1;
            blnCanInitializeLv = true;
            Initial_lvProduct2();
            cUF.ChangeLanguage("fa");
        }
        private void Initial_lvProduct2()
        {
            if (!blnCanInitializeLv) return;
            con.Close();
            SqlCommand cmd = new SqlCommand("LoadSingleProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ParamProductCode", intProductCode);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string strFaCol = "ردیف:کدرکورد:قیمت خرید:قیمت فروش:تعداد:تاریخ ورود:ساعت ورود:اولویت:وضعیت";
            string strCol = "RowNumber:CounterID:BuyPrice:SellPrice:intCount:DateEntered:TimeEntered:Priority:Enabled";
            int[] w = { 45, 45, 130, 130, 45, 90, 90, 45, 45 };
            cUF.initialListView2(dt, strFaCol, strCol, lvProductPrices, w, this.Name);
            lvProductPrices.Columns["Enabled"].Width = 0;
            lvProductPrices.Columns["Priority"].Width = 0;
            lvProductPrices.Columns["CounterID"].Width = 0;
        }

        private void FrmProductDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void LvProductPrices_DoubleClick(object sender, EventArgs e)
        {
            if (lvProductPrices.SelectedItems.Count == 0) return;
            blnCanInitializeLv = false;
            txtBuyPrice.Text = lvProductPrices.SelectedItems[0].SubItems["BuyPrice"].Text.Trim().Replace(",", "");
            txtSellPrice.Text = lvProductPrices.SelectedItems[0].SubItems["SellPrice"].Text.Trim().Replace(",", "");
            txtCount.Text = lvProductPrices.SelectedItems[0].SubItems["intCount"].Text.Trim();
            txtPriority.Text = lvProductPrices.SelectedItems[0].SubItems["Priority"].Text.Trim();
        }

        private void BtnSaveDetail_Click(object sender, EventArgs e)
        {
            if (intCurrentCounterID == -1) //Add New
            {
                string strcmd = "INSERT INTO tbProductPrices (CounterID, ProductID, BuyPrice, SellPrice, intCount, DateEntered, TimeEntered, []) VALUES" +
                    "(@CID, @PID, @BP, @SP, @CNT, @DE, @TE, @PRT)";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                _ = cmd.Parameters.AddWithValue("@CID", cUF.GetNextUpperCode("CounterID", "tbProductPrices").ToString());
                _ = cmd.Parameters.AddWithValue("@PID", intProductCode);
                _ = cmd.Parameters.AddWithValue("@BP", txtBuyPrice.Text.Trim());
                _ = cmd.Parameters.AddWithValue("@SP", txtSellPrice.Text.Trim());
                _ = cmd.Parameters.AddWithValue("@CNT", txtCount.Text.Trim());
                _ = cmd.Parameters.AddWithValue("@DE", cUF.GetFormattedPersianDate(DateTime.Now));
                _ = cmd.Parameters.AddWithValue("@TE", DateTime.Now.ToLongTimeString());
                //Some Code for getting last priority from DB, Here.
                String strMaxOrMin = "";
                String strIncVal = "";
                int intNextPriorityNum = 100;
                if (cmbPriority.SelectedIndex == 0)//Highest
                {
                    strMaxOrMin = "MAX";
                    strIncVal = "5";
                }
                else if (cmbPriority.SelectedIndex == 0)//Lowest
                {
                    strMaxOrMin = "MIN";
                    strIncVal = "-5";
                }
                using (SqlCommand cmdNextPrt = new SqlCommand("SELECT " + strMaxOrMin + "([Priority]) + (" + strIncVal + ") FROM tbProductPrices WHERE ProductID = " + intProductCode.ToString(), con))
                {
                    con.Open();
                    SqlDataReader sdr = cmdNextPrt.ExecuteReader();
                    if (sdr.HasRows)
                        while (sdr.Read())
                        {
                            intNextPriorityNum = sdr.GetInt32(0);
                        }
                    sdr.Close();
                    con.Close();
                }
                _ = cmd.Parameters.AddWithValue("@PTR", intNextPriorityNum);
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
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
            else //Update
            {

            }
        }
    }
}