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
    public partial class FrmUser : Form
    {
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Trim() != "" && txtNewPassword.Text.Trim() != ""
                  && txtConfirm.Text.Trim() != "")
            {
                if (!(txtNewPassword.Text == txtConfirm.Text))
                {
                    MessageBox.Show("کلمه عبور جدید و تکراش برابر نیستند");
                    return;
                }
                string strDa = "SELECT username FROM tbUser WHERE (username='user' AND password=@password)";
                SqlDataAdapter da = new SqlDataAdapter(strDa, con);
                DataTable table = new DataTable();
                da.SelectCommand.Parameters.AddWithValue("@password", txtPass.Text.Trim().GetHashCode().ToString());
                da.Fill(table);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است");
                    return;
                }
                else
                {
                    string strcmd = "UPDATE tbUser SET password=@password"+
                                       " Where username='user'";
                    SqlCommand cmd = new SqlCommand(strcmd, con);
                    cmd.Parameters.AddWithValue("@password", txtConfirm.Text.Trim().GetHashCode().ToString());
                    try
                    {
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
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
            else
                MessageBox.Show("لطفا تمام فیلدها را پر کنید");
        }
        private void clearTxt()
        {
            txtPass.Clear();
            txtNewPassword.Clear();
            txtConfirm.Clear();
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            txtPass.Focus();
        }
    }
}
