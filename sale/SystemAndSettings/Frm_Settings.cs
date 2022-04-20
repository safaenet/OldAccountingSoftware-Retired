using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;
/// <summary>
/// setting.ini Structure:
/// 1,1: ServerName
/// 1,2: DB Name
/// 1,3: DB Username
/// 1,4: DB Password
/// 2,1: Owner name (Title)
/// 2,2: AutoChangeLanguage Check State
/// 3,1: LoginEnabled Check State
/// 3,2: Login Username1
/// 3,3: Login Password1
/// 4,1: btnTodayFactorColor
/// 4,2: btnCreditorFactorColor
/// 4,3: btnDebtorFactorColor
/// 4,4: btnZeroFactorColor
/// 4,5: btnTodayTransFileColor
/// 4,6: btnCreditorTransFileColor
/// 4,7: btnDebtorTransFileColor
/// 4,8: btnZeroFileColor
/// 4,9: btnTodayTransactionColor (Deactive)
/// 4,10:btnFwFactorColor
/// 8,1: chkEnDisNewFactor
/// 8,2: chkEnDisFactorList
/// 8,3: chkEnDisEditFactors
/// 8,4: chkEnDisCustomers
/// 8,5: chkEnDisChequeList
/// 8,6: chkEnDisTransactions
/// 8,7: chkEnDisEditTransaction
/// 8,8: 
/// </summary>
namespace SafaShop
{
    public partial class Frm_Settings : Form
    {
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        AutoCompleteStringCollection TransactionFileListCollection = new AutoCompleteStringCollection();
        public Boolean ok = false;

        public Frm_Settings()
        {
            InitializeComponent();
        }

        private void Frm_db_Load(object sender, EventArgs e)
        {
            try
            {
                cUserFunction cUF = new cUserFunction();
                cEncrypt c = new cEncrypt();
                string dir = Application.StartupPath;
                if (!File.Exists(dir + "\\setting.ini"))
                    cUF.defaultSetting();
                cUF.IniFile(dir + "\\setting.ini");
                txtServerName.Text = cUF.IniReadValue("1", "1").Trim();
                txtDBName.Text = cUF.IniReadValue("1", "2");
                txtDBUserName.Text = cUF.IniReadValue("1", "3");
                txtDBPassword.Text = cUF.IniReadValue("1", "4");

                txtOwnerName.Text = cUF.IniReadValue("2", "1"); //OwnerName
                if (cUF.IniReadValue("2", "2") == "1") //AutoChangeLanguage
                    chkAutoChangeLanguage.Checked = true;

                string strUsername1 = cUF.IniReadValue("3", "2"); //LoginUsername
                string strLoginEnabled = cUF.IniReadValue("3", "1"); //LoginEnabled?
                if (strLoginEnabled == "1")
                {
                    chkLoginEnabled1.Checked = true;
                    if (strUsername1 == "")
                        strUsername1 = "admin";
                    txtUsername1.Text = strUsername1;
                }
                else
                    txtUsername1.Text = "admin";
                {//Load Colors
                    String strColor = "";
                    int intTFC;
                    int intCFC;
                    int intDFC;
                    int intZFC;
                    int intTTFC;
                    int intCTFC;
                    int intDTFC;
                    int intZTFC;
                    int intTTC;
                    int intFwFC;
                    strColor = cUF.IniReadValue("4", "1");
                    int.TryParse(strColor, out intTFC);
                    strColor = cUF.IniReadValue("4", "2");
                    int.TryParse(strColor, out intCFC);
                    strColor = cUF.IniReadValue("4", "3");
                    int.TryParse(strColor, out intDFC);
                    strColor = cUF.IniReadValue("4", "4");
                    int.TryParse(strColor, out intZFC);
                    strColor = cUF.IniReadValue("4", "5");
                    int.TryParse(strColor, out intTTFC);
                    strColor = cUF.IniReadValue("4", "6");
                    int.TryParse(strColor, out intCTFC);
                    strColor = cUF.IniReadValue("4", "7");
                    int.TryParse(strColor, out intDTFC);
                    strColor = cUF.IniReadValue("4", "8");
                    int.TryParse(strColor, out intZTFC);
                    strColor = cUF.IniReadValue("4", "9");
                    int.TryParse(strColor, out intTTC);
                    strColor = cUF.IniReadValue("4", "10");
                    int.TryParse(strColor, out intFwFC);
                    btnTodayFactorColor.BackColor = Color.FromArgb(intTFC);
                    btnCreditorFactorColor.BackColor = Color.FromArgb(intCFC);
                    btnDebtorFactorColor.BackColor = Color.FromArgb(intDFC);
                    btnZeroFactorColor.BackColor = Color.FromArgb(intZFC);
                    btnTodayTransFileColor.BackColor = Color.FromArgb(intTTFC);
                    btnCreditorTransFileColor.BackColor = Color.FromArgb(intCTFC);
                    btnDebtorTransFileColor.BackColor = Color.FromArgb(intDTFC);
                    btnZeroFileColor.BackColor = Color.FromArgb(intZTFC);
                    //btnTodayTransactionColor.BackColor = Color.FromArgb(intTTC);
                    btnFwFactorColor.BackColor = Color.FromArgb(intFwFC);
                }
                //LoadGeneralSettings
                if (cUF.IniReadValue("5", "1") == "1")
                    chkAutoAddNewProduct.Checked = true;
                else
                    chkAutoAddNewProduct.Checked = false;
                if (cUF.IniReadValue("7", "1") == "1")
                    chkCanDuplicateInSaleDetail.Checked = true;
                else
                    chkCanDuplicateInSaleDetail.Checked = false;
                if (cUF.IniReadValue("7", "2") == "1")
                    chkShowPlusMinusInSaleDetail.Checked = true;
                else
                    chkShowPlusMinusInSaleDetail.Checked = false;
                {//Load Enable or Disable Button Settings
                    if (cUF.IniReadValue("8", "1") == "1")
                        chkEnDisNewFactor.Checked = true;
                    else
                        chkEnDisNewFactor.Checked = false;
                    if (cUF.IniReadValue("8", "2") == "1")
                        chkEnDisFactorList.Checked = true;
                    else
                        chkEnDisFactorList.Checked = false;
                    if (cUF.IniReadValue("8", "3") == "1")
                        chkEnDisEditFactors.Checked = true;
                    else
                        chkEnDisEditFactors.Checked = false;
                    if (cUF.IniReadValue("8", "4") == "1")
                        chkEnDisCustomers.Checked = true;
                    else
                        chkEnDisCustomers.Checked = false;
                    if (cUF.IniReadValue("8", "5") == "1")
                        chkEnDisChequeList.Checked = true;
                    else
                        chkEnDisChequeList.Checked = false;
                    if (cUF.IniReadValue("8", "6") == "1")
                        chkEnDisTransactions.Checked = true;
                    else
                        chkEnDisTransactions.Checked = false;
                    if (cUF.IniReadValue("8", "7") == "1")
                        chkEnDisEditTransaction.Checked = true;
                    else
                        chkEnDisEditTransaction.Checked = false;
                    if (cUF.IniReadValue("8", "8") == "1")
                        chkEnDisProducts.Checked = true;
                    else
                        chkEnDisProducts.Checked = false;
                }
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT tbTransactions.[FileSubject], tbTransactions.FileCode FROM tbTransactions ORDER BY FileCode", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    dt.Load(cmd.ExecuteReader());
                    string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("FileSubject")).ToArray();
                    TransactionFileListCollection.AddRange(strAutoCompleteString);
                    cmbSpecialFileShortcutTarget.DataSource = dt;
                    cmbSpecialFileShortcutTarget.DisplayMember = "FileSubject";
                    cmbSpecialFileShortcutTarget.ValueMember = "FileCode";
                    cmbSpecialFileShortcutTarget.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    cmbSpecialFileShortcutTarget.AutoCompleteCustomSource = TransactionFileListCollection;
                    cmbSpecialFileShortcutTarget.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    if (cmbSpecialFileShortcutTarget.Items.Count == 0) chkShowSpecialFileShortcut.Enabled = gbSpecialFileShortcut.Enabled = false;
                    if (cUF.IniReadValue("6", "1").Trim() == "1")
                    {
                        chkShowSpecialFileShortcut.Checked = true;
                        txtSpecialFileShortcutTitle.Text = cUF.IniReadValue("6", "2").Trim();
                        cmbSpecialFileShortcutTarget.SelectedValue = cUF.IniReadValue("6", "3").Trim();
                    }
                    else
                        chkShowSpecialFileShortcut.Checked = false;

                }
                catch
                {
                    gbSpecialFileShortcut.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Frm_db_Load()");
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
             SqlConnection con=new SqlConnection() ;
            try
            {
                string conStr = "Data Source=" + txtServerName.Text.Trim() + ";Initial Catalog=" 
                    + txtDBName.Text.Trim()
                    + ";User ID=" + txtDBUserName.Text.Trim() + ";password=" + txtDBPassword.Text.Trim() + ";";
                //MessageBox.Show(conStr);
                //conStr = "Data Source=.;Initial Catalog=sale;Integrated Security=True";
               con = new SqlConnection(conStr);
                con.Open();
                MessageBox.Show("ارتباط با موفقیت برقرار شد");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cUserFunction cUF = new cUserFunction();
                cEncrypt c = new cEncrypt();
                string dir = Application.StartupPath;
                //MessageBox.Show(dir + "\\setting.ini");
                if (!File.Exists(dir + "\\setting.ini"))
                    cUF.defaultSetting();
                cUF.IniFile(dir + "\\setting.ini");
                //cUF.IniWriteValue("1", "1", c.encode(txtServerName.Text.Trim()));
                //cUF.IniWriteValue("1", "2", c.encode(txtDBName.Text.Trim()));
                //cUF.IniWriteValue("1", "3", c.encode(txtDBUserName.Text.Trim()));
                //cUF.IniWriteValue("1", "4", c.encode(txtDBPassword.Text.Trim()));
                cUF.IniWriteValue("1", "1", txtServerName.Text.Trim());
                cUF.IniWriteValue("1", "2", txtDBName.Text.Trim());
                cUF.IniWriteValue("1", "3", txtDBUserName.Text.Trim());
                cUF.IniWriteValue("1", "4", txtDBPassword.Text.Trim());
                MessageBox.Show("تغییرات ذخیره شد، برای اعمال تغییرات برنامه را بسته و دوباره باز کنید");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click()");
            }
        }

        private void btnSaveEnvironment_Click(object sender, EventArgs e)
        {
            cUserFunction cUF = new cUserFunction();
            cEncrypt c = new cEncrypt();
            try
            {
                string dir = Application.StartupPath;
                if (!File.Exists(dir + "\\setting.ini"))
                    cUF.defaultSetting();
                cUF.IniFile(dir + "\\setting.ini");
                if (txtOwnerName.Text.Trim() == "")
                    txtOwnerName.Text = "Avazeh";
                cUF.IniWriteValue("2", "1", txtOwnerName.Text.Trim()); //OwnerName
                if (chkAutoChangeLanguage.Checked) //AutoChangeLanguage
                    cUF.IniWriteValue("2", "2", "1");
                else
                    cUF.IniWriteValue("2", "2", "2");
                //Save Colors:
                cUF.IniWriteValue("4", "1", btnTodayFactorColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "2", btnCreditorFactorColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "3", btnDebtorFactorColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "4", btnZeroFactorColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "5", btnTodayTransFileColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "6", btnCreditorTransFileColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "7", btnDebtorTransFileColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "8", btnZeroFileColor.BackColor.ToArgb().ToString());
                //cUF.IniWriteValue("4", "9", btnTodayTransactionColor.BackColor.ToArgb().ToString());
                cUF.IniWriteValue("4", "10", btnFwFactorColor.BackColor.ToArgb().ToString());
                //Close();
                MessageBox.Show("تغییرات ذخیره شد، برای اعمال تغییرات برنامه را بسته و دوباره باز کنید");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnSave_Click()");
            }
        }

        private void btnSaveLoginInfo_Click(object sender, EventArgs e)
        {
            if ((txtUsername1.Text.Trim() == "" || txtPassword1.Text.Trim() == "") && chkLoginEnabled1.Checked)
            {
                MessageBox.Show("لطفا نام کاربری و رمز عبور را وارد کنید");
                return;
            }
            cUserFunction cUF = new cUserFunction();
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            if (chkLoginEnabled1.Checked)
                cUF.IniWriteValue("3", "1", "1");
            else
                cUF.IniWriteValue("3", "1", "0");
            cUF.IniWriteValue("3", "2", txtUsername1.Text.Trim());
            cUF.IniWriteValue("3", "3", txtPassword1.Text.Trim());
            MessageBox.Show("تغییرات ذخیره شد");
        }

        private void chkLoginEnabled1_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername1.Enabled = txtPassword1.Enabled = chkLoginEnabled1.Checked;
        }

        private void btnTodayFactorColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = (sender as Button).BackColor;
            colorDialog1.ShowDialog();
            (sender as Button).BackColor = colorDialog1.Color;
            btnSaveEnvironment.Focus();
        }

        private void btnSaveGeneral_Click(object sender, EventArgs e)
        {
            cUserFunction cUF = new cUserFunction();
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            if (chkAutoAddNewProduct.Checked)
                cUF.IniWriteValue("5", "1", "1");
            else
                cUF.IniWriteValue("5", "1", "0");
            if (chkCanDuplicateInSaleDetail.Checked)
                cUF.IniWriteValue("7", "1", "1");
            else
                cUF.IniWriteValue("7", "1", "0");
            if (chkShowSpecialFileShortcut.Checked && cmbSpecialFileShortcutTarget.Items.Count != 0)
            {
                if(txtSpecialFileShortcutTitle.Text.Trim() == "")
                {
                    MessageBox.Show("عنوان میانبر را وارد کنید");
                    return;
                }
                cUF.IniWriteValue("6", "1", "1");
                cUF.IniWriteValue("6", "2", txtSpecialFileShortcutTitle.Text.Trim());
                cUF.IniWriteValue("6", "3", cmbSpecialFileShortcutTarget.SelectedValue.ToString());
            }
            else
            {
                cUF.IniWriteValue("6", "1", "0");
                cUF.IniWriteValue("6", "2", "");
                cUF.IniWriteValue("6", "3", "-1");
            }
        }

        private void chkShowSpecialFileShortcut_CheckedChanged(object sender, EventArgs e)
        {
            txtSpecialFileShortcutTitle.Enabled = cmbSpecialFileShortcutTarget.Enabled = chkShowSpecialFileShortcut.Checked;
        }

        private void BtnSaveEnOrDisButtons_Click(object sender, EventArgs e)
        {
            cUserFunction cUF = new cUserFunction();
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");

            if (chkShowPlusMinusInSaleDetail.Checked)
                cUF.IniWriteValue("7", "2", "1");
            else
                cUF.IniWriteValue("7", "2", "0");
            if (chkEnDisNewFactor.Checked)
                cUF.IniWriteValue("8", "1", "1");
            else
                cUF.IniWriteValue("8", "1", "0");
            if (chkEnDisFactorList.Checked)
                cUF.IniWriteValue("8", "2", "1");
            else
                cUF.IniWriteValue("8", "2", "0");
            if (chkEnDisEditFactors.Checked)
                cUF.IniWriteValue("8", "3", "1");
            else
                cUF.IniWriteValue("8", "3", "0");
            if (chkEnDisCustomers.Checked)
                cUF.IniWriteValue("8", "4", "1");
            else
                cUF.IniWriteValue("8", "4", "0");
            if (chkEnDisChequeList.Checked)
                cUF.IniWriteValue("8", "5", "1");
            else
                cUF.IniWriteValue("8", "5", "0");
            if (chkEnDisTransactions.Checked)
                cUF.IniWriteValue("8", "6", "1");
            else
                cUF.IniWriteValue("8", "6", "0");
            if (chkEnDisEditTransaction.Checked)
                cUF.IniWriteValue("8", "7", "1");
            else
                cUF.IniWriteValue("8", "7", "0");
            if (chkEnDisProducts.Checked)
                cUF.IniWriteValue("8", "8", "1");
            else
                cUF.IniWriteValue("8", "8", "0");
        }

        private void ChkEnDisFactorList_CheckedChanged(object sender, EventArgs e)
        {
            if (!(chkEnDisEditFactors.Enabled = chkEnDisFactorList.Checked))
                chkEnDisEditFactors.Checked = false;
        }

        private void ChkEnDisTransactions_CheckedChanged(object sender, EventArgs e)
        {
            if (!(chkEnDisEditTransaction.Enabled = chkEnDisTransactions.Checked))
                chkEnDisEditTransaction.Checked = false;
        }
    }
}
