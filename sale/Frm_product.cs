using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Media;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
namespace SafaShop
{
    public partial class Frm_product : Form
    {
        //================ini file==========================
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);
        //========================
        string strLastSellPrice = "0";
        Boolean blnCanInitializeLv = false;
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        private readonly cUserFunction cUF = new cUserFunction();
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;
        public Frm_product()
        {
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            lvProduct.ListViewItemSorter = lvwColumnSorter;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length == 0)
            {
                if (txtProduct.Text.Trim().Length == 0)
                {
                    MessageBox.Show("لطفا ابتدا شرح کالا را وارد نمایید", "btnSave_Click()");
                    return;
                }
                string strcmd = "INSERT INTO tbProduct (product, BarCode, code, sellPrice, buyPrice, detail) Values"+
                    "(@product,@barcode , @code, @sellPrice, @buyPrice, @detail)";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                // MessageBox.Show(cUF.maxCode("code", "tbProdut").ToString());
                cmd.Parameters.AddWithValue("@product", txtProduct.Text.Trim());
                cmd.Parameters.AddWithValue("@barcode", txtBarCode.Text.Trim());
                cmd.Parameters.AddWithValue("@code", cUF.GetNextUpperCode("code", "tbProduct").ToString());
                cmd.Parameters.AddWithValue("@sellPrice", txtSellPrice.Text.Trim());
                if (txtBuyPrice.Text.Trim() == "")
                    cmd.Parameters.AddWithValue("@buyPrice", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@buyPrice", txtBuyPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@detail", txtDetail.Text.Trim());
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
            else
            {
                blnCanInitializeLv = true;
                string strcmd = "UPDATE tbProduct SET product = @product, BarCode = @barcode," +
                    " sellPrice = @sellPrice, buyPrice = @buyPrice, detail = @detail" +
                    " Where code = @code";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                cmd.Parameters.AddWithValue("@product", txtProduct.Text.Trim());
                cmd.Parameters.AddWithValue("@barcode", txtBarCode.Text.Trim());
                cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                cmd.Parameters.AddWithValue("@sellPrice", txtSellPrice.Text.Trim());
                if (txtBuyPrice.Text.Trim() == "")
                    cmd.Parameters.AddWithValue("@buyPrice", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@buyPrice", txtBuyPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@detail", txtDetail.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    if (strLastSellPrice != txtSellPrice.Text.Trim())
                    {
                        strcmd = "DELETE FROM tbCustomerizedPrice WHERE ProductCode=@pc";
                        cmd = new SqlCommand(strcmd, con);
                        cmd.Parameters.AddWithValue("@pc", txtCode.Text.Trim());
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                    //initial_lvProduct2();
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
            blnCanInitializeLv = false;
            clearTxt();
            blnCanInitializeLv = true;
            txtProduct.Focus();
            initial_lvProduct2();
        }

        private void Frm_product_Load(object sender, EventArgs e)
        {
            //Initialize cmbSearchBy Items
            var SearchField = new BindingList<KeyValuePair<string, string>>();
            SearchField.Add(new KeyValuePair<string, string>("0", "شرح کالا"));
            SearchField.Add(new KeyValuePair<string, string>("1", "قیمت خرید"));
            SearchField.Add(new KeyValuePair<string, string>("2", "قیمت فروش"));
            SearchField.Add(new KeyValuePair<string, string>("3", "توضیحات"));
            SearchField.Add(new KeyValuePair<string, string>("4", "کد کالا"));
            cmbSearchBy.DataSource = SearchField;
            cmbSearchBy.ValueMember = "Key";
            cmbSearchBy.DisplayMember = "Value";
            cmbSearchBy.SelectedIndex = 0;

            //txtCode.Text =cUF. maxCode("code","tbProdut").ToString();
            blnCanInitializeLv = true;
            initial_lvProduct2();
            txtProduct.Focus();
            cUF.ChangeLanguage("fa");
        }

        private void initial_lvProduct2()
        {
            if (blnCanInitializeLv)
            {
                con.Close();
                SqlCommand cmd = new SqlCommand("LoadAllProductList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParamFieldIndex", cmbSearchBy.SelectedIndex);
                cmd.Parameters.AddWithValue("@ParamValue", txtSearchBy.Text.Trim());
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                string strFaCol = "ردیف:کدکالا:کالا:بارکد:قیمت خرید:قیمت فروش:توضیحات:تعداد فروش:مبلغ فروش";
                string strCol = "RowNumber:code:product:BarCode:buyPrice:sellPrice:detail:SoldCount:SoldAmount";
                int[] w = { 40, 45, 200, 130, 0, 90, 200, 0, 0 };
                if (chkToggleBuyPrice.Checked) w[3] = 90;
                if (!chkToggleSellPrice.Checked) w[4] = 0;
                cUF.initialListView2(dt, strFaCol, strCol, lvProduct, w, this.Name);
                lvProduct.Columns["CheckBox"].Width = 0;
            }
        }

        private void lvProduct_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                blnCanInitializeLv = false;
                txtCode.Text = lvProduct.SelectedItems[0].SubItems["code"].Text.Trim();
                txtProduct.Text = lvProduct.SelectedItems[0].SubItems["product"].Text.Trim();
                txtBarCode.Text = lvProduct.SelectedItems[0].SubItems["BarCode"].Text.Trim();
                txtBuyPrice.Text = lvProduct.SelectedItems[0].SubItems["buyPrice"].Text.Trim().Replace(",", "");
                txtSellPrice.Text = lvProduct.SelectedItems[0].SubItems["sellPrice"].Text.Trim().Replace(",", "");
                txtDetail.Text = lvProduct.SelectedItems[0].SubItems["detail"].Text.Trim();
                strLastSellPrice = txtSellPrice.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "lvProduct_DoubleClick()");
            }
        }
        private void clearTxt()
        {
            txtCode.Clear();
            txtDetail.Clear();
            txtProduct.Clear();
            txtBarCode.Clear();
            txtSellPrice.Clear();
            txtBuyPrice.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length == 0)
                return;
            DialogResult result = new DialogResult();
            result = MessageBox.Show("با حذف این کالا تمام اطلاعات این کالا حذف می شود آیا ادامه می دهید؟. "
                , "ادامه می دهید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Close();
                string strCmd = "DELETE FROM tbProduct WHERE code=@code";
                SqlCommand cmd = new SqlCommand(strCmd, con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    clearTxt();
                    blnCanInitializeLv = true;
                    initial_lvProduct2();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "btnDelete_Click");
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtBuyPrice.Clear();
            txtCode.Clear();
            txtDetail.Clear();
            txtProduct.Clear();
            txtSellPrice.Clear();
        }

        private void Frm_product_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void chkToggleBuyPrice_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                lvProduct.Columns["buyPrice"].Width = 90;
            else
                lvProduct.Columns["buyPrice"].Width = 0;
        }

        private void chkToggleSellPrice_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
                lvProduct.Columns["sellPrice"].Width = 90;
            else
                lvProduct.Columns["sellPrice"].Width = 0;
        }

        private void txtSearchBy_TextChanged(object sender, EventArgs e)
        {
            initial_lvProduct2();
            chkToggleBuyPrice_CheckedChanged(chkToggleBuyPrice as object, e);
            chkToggleSellPrice_CheckedChanged(chkToggleSellPrice as object, e);
            chkShowExtraInfo_CheckedChanged(chkShowExtraInfo as object, e);
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtSearchBy.Text.Trim().Length != 0)
                initial_lvProduct2();
        }

        private void lvProduct_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void chkShowExtraInfo_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                lvProduct.Columns["SoldCount"].Width = 75;
                lvProduct.Columns["SoldAmount"].Width = 120;
            }
            else
                lvProduct.Columns["SoldCount"].Width = lvProduct.Columns["SoldAmount"].Width = 0;
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                //((TextBox)sender).SelectNextControl(((TextBox)sender), true, true, true, true);
                txtBuyPrice.Focus();
                e.Handled = true;
            }
        }

        private void BtnCountAndPrices_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "") return;
            frmProductDetails frm = new frmProductDetails(int.Parse(txtCode.Text));
            _ = frm.ShowDialog();
        }
    }
}