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
    public partial class Frm_login : Form
    {
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        public Boolean LoginOK = false;
        cUserFunction cUF = new cUserFunction();
        cEncrypt cEnc = new cEncrypt();
        public Frm_login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = cUF.IniReadValue("3", "2");
            string strPassword = cUF.IniReadValue("3", "3");
            if (txtUsername.Text.Trim() == strUsername && txtPassword.Text.Trim() == strPassword)
            {
                if (chkRemUsername.Checked)
                    cUF.IniWriteValue("3", "4", "1");
                else cUF.IniWriteValue("3", "4", "0");
                if (chkRemPassword.Checked)
                    cUF.IniWriteValue("3", "5", "1");
                else cUF.IniWriteValue("3", "5","0");
                LoginOK = true;
                this.Close();
            }
            else
                MessageBox.Show("نام کاربری یا رمزعبور اشتباه است", "احراز هویت", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            string strRemUser = cUF.IniReadValue("3", "4");
            if (strRemUser.Equals("1"))
            {
                chkRemUsername.Checked = true;
                string strUsername = cUF.IniReadValue("3", "2");
                txtUsername.Text = strUsername;
                string strRemPass = cUF.IniReadValue("3", "5");
                if (strRemPass.Equals("1"))
                {
                    chkRemPassword.Checked = true;
                    string strPassword = cUF.IniReadValue("3", "3");
                    txtPassword.Text = strPassword;
                }
                else chkRemPassword.Checked = false;
            }
            else chkRemUsername.Checked = false;
            
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            txtPassword.DeselectAll();
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUsername.DeselectAll();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            txtUsername.SelectAll();
        }

        private void chkRemUsername_CheckedChanged(object sender, EventArgs e)
        {
            chkRemPassword.Enabled = chkRemUsername.Checked;
            if (!chkRemUsername.Checked) chkRemPassword.Checked = false;
        }
    }
}
