using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafaShop
{
    public partial class Frm_AddNewOrRenameTransactionFile : Form
    {
        public string strFileSubject = "";
        Boolean blnSubjectEntered = false;
        cUserFunction cUF = new cUserFunction();
        public Frm_AddNewOrRenameTransactionFile()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFileSubject.Text.Trim() == "")
                MessageBox.Show("نام فایل را وارد کنید");
            else
            {
                blnSubjectEntered = true;
                strFileSubject = txtFileSubject.Text.Trim();
                this.Close();
            }
        }

        private void Frm_AddNewTransactionFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!blnSubjectEntered)
                strFileSubject = "";
        }

        private void Frm_AddNewTransactionFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtFileSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                btnSave_Click(sender, e);
            }
        }

        private void Frm_AddNewOrRenameTransactionFile_Load(object sender, EventArgs e)
        {
            txtFileSubject.Text = strFileSubject;
            txtFileSubject.SelectAll();
            cUF.ChangeLanguage("fa");
        }
    }
}
