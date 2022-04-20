using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace SafaShop
{
    public partial class Frm_customer : Form
    {
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        cUserFunction cUF = new cUserFunction();
        Boolean blnCanInitializeLv = false;
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;
        public Frm_customer()
        {
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            lvCustomer.ListViewItemSorter = lvwColumnSorter;
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
                Int64 i =Int64.Parse( uid.Substring(1))+1;
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
            if (txtcustomer.Text.Trim().Length == 0)
            {
                MessageBox.Show("لطفا ابتدا نام را وارد نمایید", "btnSave_Click");
                return;
            }
            if (txtCode.Text.Trim().Length == 0)
            {
                string strcmd = "INSERT INTO tbCustomer (code,name,nickname,tell1,tell2,address) Values"
              + "(@code,@name,@nickname,@tell1,@tell2,@address)";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                txtCode.Text=cUF.GetNextUpperCode("code", "tbCustomer").ToString();
                cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtcustomer.Text.Trim());
                cmd.Parameters.AddWithValue("@nickname", txtNickName.Text.Trim());
                cmd.Parameters.AddWithValue("@tell1", txtTell1.Text.Trim());
                cmd.Parameters.AddWithValue("@tell2", txtTell2.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
              
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    blnCanInitializeLv = false;
                    clearTxt();
                    blnCanInitializeLv = true;
                    initial_lvCustomer2();
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
                string strcmd = "UPDATE tbCustomer SET name=@name,"
                    +"nickname=@nickname,tell1=@tell1,tell2=@tell2,address=@address" +
                    " Where code=@code";
                SqlCommand cmd = new SqlCommand(strcmd, con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                cmd.Parameters.AddWithValue("@name", txtcustomer.Text.Trim());
                cmd.Parameters.AddWithValue("@nickname", txtNickName.Text.Trim());
                cmd.Parameters.AddWithValue("@tell1", txtTell1.Text.Trim());
                cmd.Parameters.AddWithValue("@tell2", txtTell2.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                try
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    initial_lvCustomer2();
                    cmd.Connection.Close();
                    clearTxt();
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
        }

        private void Frm_customer_Load(object sender, EventArgs e)
        {
            blnCanInitializeLv = true;
            initial_lvCustomer2();
            cUF.ChangeLanguage("fa");
            
        }

        private void initial_lvCustomer()
        {
            string strda = "select code,name,nickname,tell1,tell2,address from tbCustomer";
            cUserFunction cUF = new cUserFunction();
            string strFaCol = "کد:مشتری:شهرت:شماره تماس1:شماره تماس2:آدرس";
            string strCol = "code:name:nickname:tell1:tell2:address";
            int[] w = { 50, 150, 100, 100,100, 250 };
            cUF.initialListView(strda, strFaCol, strCol, lvCustomer, w);
        }

        private void initial_lvCustomer2()
        {
            if (blnCanInitializeLv)
            {
                con.Close();
                SqlCommand cmd = new SqlCommand("LoadAllCustomerList", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ParamCustomerName", txtcustomer.Text.Trim());
                DataTable dt = new DataTable();
                con.Open();
                dt.Load(cmd.ExecuteReader());
                con.Close();

                cUserFunction cUF = new cUserFunction();
                string strFaCol = "ردیف:کد:مشتری:شهرت:شماره تماس1:شماره تماس2:آدرس";
                string strCol = "RowNumber:code:name:nickname:tell1:tell2:address";
                int[] w = { 43, 50, 150, 100, 100, 100, 227 };
                cUF.initialListView2(dt, strFaCol, strCol, lvCustomer, w, this.Name);
                lvCustomer.Columns["CheckBox"].Width = 0;
            }
        }

        private void clearTxt()
        {
            txtcustomer.Focus();
            txtCode.Clear();
            txtcustomer.Clear();
            txtNickName.Clear();
            txtTell1.Clear();
            txtTell2.Clear();
            txtAddress.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim().Length == 0)
                return;
            DialogResult result = new DialogResult();
            result = MessageBox.Show("با حذف مشتری تمام اطلاعات این مشتری حذف می شود آیا ادامه می دهید؟. "
                , "ادامه می دهید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                con.Close();
                string strCmd = "DELETE FROM tbCustomer WHERE code=@code";
                SqlCommand cmd = new SqlCommand(strCmd, con);
                cmd.Parameters.AddWithValue("@code", txtCode.Text.Trim());
                //try
                //{
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    blnCanInitializeLv = true;
                    initial_lvCustomer2();
                    clearTxt();
                //}
                //catch (Exception ex)
                //{
                    //MessageBox.Show(ex.Message, "btnDelete_Click()");
                //}
                //finally
                //{
                    cmd.Connection.Close();
                //}
            }
        }

        private void lvCustomer_DoubleClick(object sender, EventArgs e)
        {
            //try
            {
                //clearTxt();
                blnCanInitializeLv = false;
                txtCode.Text = lvCustomer.SelectedItems[0].SubItems["code"].Text.Trim();
                txtcustomer.Text = lvCustomer.SelectedItems[0].SubItems["name"].Text.Trim();
                txtNickName.Text = lvCustomer.SelectedItems[0].SubItems["nickname"].Text.Trim();
                txtTell1.Text = lvCustomer.SelectedItems[0].SubItems["tell1"].Text.Trim();
                txtTell2.Text = lvCustomer.SelectedItems[0].SubItems["tell2"].Text.Trim();
                txtAddress.Text = lvCustomer.SelectedItems[0].SubItems["address"].Text.Trim();
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "lvCustomer_DoubleClick()");
            //}
        }

        private void txtTell2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTxt();
        }

        private void Frm_customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            initial_lvCustomer2();
        }

        private void lvCustomer_ColumnClick(object sender, ColumnClickEventArgs e)
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
