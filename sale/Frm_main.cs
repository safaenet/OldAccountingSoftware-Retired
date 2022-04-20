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
using System.Runtime.InteropServices;
namespace SafaShop
{
    public partial class Frm_main : Form
    {
        SqlConnection con = new SqlConnection();
        cUserFunction cUF = new cUserFunction();
        static bool blnBlinkTsbChequeList = false;
        bool blnHelpBlinkTsbChequeList;
        static public string conStr = "";
        int intSpecialFileID = -1;
        int intBlinkCounter = 0;
        //================ini file==========================
        private string path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);
        //========================
        //=================ini file===============
        public void IniFile(string INIPath)
        {
            path = INIPath;
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
        public void defaultSetting()
        {
            cEncrypt c = new cEncrypt();

            string dir = Application.StartupPath;
            IniFile(dir + "\\setting.ini");
            IniWriteValue("1", "1", "");
            IniWriteValue("1", "2", "");
            IniWriteValue("1", "3", "");
            IniWriteValue("1", "4", "");
            IniWriteValue("2", "1", dir.Substring(0, dir.LastIndexOf('\\')) + "\\backup");
            IniWriteValue("2", "2", "1");
            IniWriteValue("2", "3", "");
            IniWriteValue("2", "4", "");
        }
        //===================================================================
        String[] strPersianDayOfWeek = new String[7] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        String[] strMonthOfYear = new String[13] { "عدم نمایش", "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی ", "بهمن", "اسفند" };

        public Frm_main()
        {
            InitializeComponent();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            string strOwnerName;
            if (!File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            string strLoginEnabled = cUF.IniReadValue("3", "1");
            if (strLoginEnabled == "1")
            {
                tsMain.Enabled = tsSecond.Enabled = false;
                Frm_login frmLogin = new Frm_login();
                frmLogin.ShowDialog(this);
                tsMain.Enabled = tsSecond.Enabled = frmLogin.LoginOK;
                if (!frmLogin.LoginOK)
                    Application.Exit();
            }
            strOwnerName = cUF.IniReadValue("2", "1").Trim(); //OwnerName
            if (strOwnerName == "")
                strOwnerName = "Avazeh";
            this.Text = strOwnerName;
            if (cUF.IniReadValue("8", "1") == "1")
                tsbNormalSale.Enabled = true;
            else tsbNormalSale.Enabled = false;
            if (cUF.IniReadValue("8", "2") == "1")
                tsbSearchNormalFactors.Enabled = true;
            else tsbSearchNormalFactors.Enabled = false;
            if (cUF.IniReadValue("8", "4") == "1")
                tsbCustomer.Enabled = true;
            else tsbCustomer.Enabled = false;
            if (cUF.IniReadValue("8", "5") == "1")
                tsbChequeList.Enabled = chkBlinkTsbChequeList.Enabled = timer1.Enabled = true;
            else tsbChequeList.Enabled = chkBlinkTsbChequeList.Enabled = timer1.Enabled = false;
            if (cUF.IniReadValue("8", "6") == "1")
                tsbDetails.Enabled = true;
            else tsbDetails.Enabled = false;
            if (cUF.IniReadValue("8", "8") == "1")
                tsbProduct.Enabled = true;
            else tsbProduct.Enabled = false;
            string serverName = cUF.IniReadValue("1", "1").Trim();
            string DBName = cUF.IniReadValue("1", "2");
            string user = cUF.IniReadValue("1", "3");
            string pass = cUF.IniReadValue("1", "4");
            conStr = "Data Source= " + serverName + ";Initial Catalog= " + DBName
                + ";User Id= " + user + ";Password= " + pass + ";";
            con = new SqlConnection(conStr);
            if (cUF.IniReadValue("6", "1") == "1")
            {
                this.Width += 100;
                tsbOpenSpecialFile.Visible = true;
                tsbOpenSpecialFile.Text = cUF.IniReadValue("6", "2");
                intSpecialFileID = int.Parse(cUF.IniReadValue("6", "3"));
            }

            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ارتباط با بانک اطلاعاتی مقدور نمی باشد\r" + ex.Message, "Frm_main_Load()", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Frm_Settings fdb = new Frm_Settings();
                fdb.ShowDialog();
            }
        }

        private void Frm_main_Shown(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string strNextChequeDate = cUF.getPersianDate(DateTime.Now.AddDays(2));
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblChequeList WHERE CAST(REPLACE(CashDate,'/','') AS bigint) <= CAST(@pNextChkDate AS bigint) AND CAST(REPLACE(CashDate,'/','') AS bigint) >= CAST(@pToday AS bigint) AND chkStatus = 0", con);
                cmd.Parameters.AddWithValue("@pNextChkDate", strNextChequeDate);
                cmd.Parameters.AddWithValue("@pToday", cUF.getPersianDate(DateTime.Now));
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count > 0) blnBlinkTsbChequeList = true;
            }
            catch { }
            finally { con.Close(); }
        }

        private void tsbProduct_Click(object sender, EventArgs e)
        {
            Frm_product p = new Frm_product();
            p.Show();
        }

        private void tsbSale_Click(object sender, EventArgs e)
        {
            FrmFactorDetail2 fs = new FrmFactorDetail2();
            fs.Show();
        }

        private void tsbCustomer_Click(object sender, EventArgs e)
        {
            Frm_customer fc = new Frm_customer();
            fc.Show();
        }

        private void tsbDB_Click(object sender, EventArgs e)
        {
            Frm_Settings fd = new Frm_Settings();
            fd.Show();
        }

        private void tsbSeatchFactor_Click(object sender, EventArgs e)
        {
            frmFactorList2 fl = new frmFactorList2();
            fl.Show();
        }

        private void tsbDetails_Click(object sender, EventArgs e)
        {
            Frm_Transactions2 dtl = new Frm_Transactions2();
            dtl.Show();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            frmAbout frmAbout = new frmAbout();
            frmAbout.Show();
            //Avazeh.SystemAndSettings.frmAskForLicense frm = new Avazeh.SystemAndSettings.frmAskForLicense();
            //frm.Show();
        }

        private void tsbOpenSpecialFile_Click(object sender, EventArgs e)
        {
            Frm_TransactionDetails2 ftd = new Frm_TransactionDetails2(Nothing);
            ftd.intFileCode = intSpecialFileID;
            ftd.Text = tsbOpenSpecialFile.Text;
            ftd.history = false;
            ftd.Show(this);
        }
        void Nothing() { }//For tsbOpenSpecialFile_Click()

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                txtDate.Text = cUF.GetFormattedPersianDate(DateTime.Now);
                txtTime.Text = DateTime.Now.ToLongTimeString();
                txtDayOfWeek.Text = strPersianDayOfWeek[(int)DateTime.Now.DayOfWeek];
                txtMonthOfYear.Text = strMonthOfYear[int.Parse(cUF.getPersianDate(DateTime.Now).Substring(4, 2))];
            }
            catch { }
        }

        private void tsbChequeList_Click(object sender, EventArgs e)
        {
            Avazeh.Cheque.frmChequeList frm = new Avazeh.Cheque.frmChequeList();
            frm.Show(this);
        }

        private void tmrChequeListBlink_Tick(object sender, EventArgs e)
        {
            if (blnBlinkTsbChequeList && chkBlinkTsbChequeList.Checked)
            {
                if (blnHelpBlinkTsbChequeList)
                {
                    tsbChequeList.BackColor = Color.Red;
                    blnHelpBlinkTsbChequeList = false;
                }
                else
                {
                    tsbChequeList.BackColor = tsbProduct.BackColor;
                    blnHelpBlinkTsbChequeList = true;
                    if (intBlinkCounter++ == 50) tmrChequeListBlink.Enabled = false;
                }
            }
            else
            {
                tsbChequeList.BackColor = tsbProduct.BackColor;
                intBlinkCounter = 0;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //Shortcuts
        {
            if (keyData == (Keys.Control | Keys.N))
            {
                tsbSale_Click(new object(), new EventArgs());
                return true;
            }
            else if (keyData == (Keys.Control | Keys.F))
            {
                tsbSeatchFactor_Click(new object(), new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public static bool AccessBlnBlinkTsbChequeList //Access and Edit blnBlinkTsbChequeList from frmChequeList
        {
            get { return blnBlinkTsbChequeList; }
            set { blnBlinkTsbChequeList = value; }
        }
    }
}