using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
/// 3,4: Remember Username (Boolean)
/// 3,5: Remember Password (Boolean)
/// 4,1: btnTodayFactorColor
/// 4,2: btnCreditorFactorColor
/// 4,3: btnDebtorFactorColor
/// 4,4: btnZeroFactorColor
/// 4,5: btnTodayTransFileColor
/// 4,6: btnCreditorTransFileColor
/// 4,7: btnDebtorTransFileColor
/// 4,8: btnZeroFileColor
/// 4,9: btnTodayTransactionColor (Deactive)
/// 4,10: btnFwFactorColor
/// 5,1: If new product should be added automatically or not. 0=No 1=Yes
/// 6,1: If special file shortcut should be shown in main window.
/// 6,2: Special file shortcut title.
/// 6,3: special file ID, Default = -1
/// 7,1: Can duplicate in SaleDetail
/// 7,2: Show plus and minus button inside Datagridview.
/// </summary>
namespace SafaShop
{
    class cUserFunction
    {
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        #region INI File
        private string path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
          string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
          string key, string def, StringBuilder retVal,
          int size, string filePath);
        #endregion
        public void IniFile(string INIPath)
        {
            path = INIPath;
        }
        public void ChangeLanguage(string cl)
        {
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!File.Exists(dir + "\\setting.ini"))
                defaultSetting();
            IniFile(dir + "\\setting.ini");
            if (IniReadValue("2", "2").Trim() == "1")
            {
                foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
                {
                    if (lang.Culture.TwoLetterISOLanguageName == cl)
                    {
                        //Application.CurrentCulture = lang.Culture;
                        Application.CurrentInputLanguage = lang;
                    }
                }
            }
        }
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
        public string split_space(string num, string ch)
        {
            string s = num;
            try
            {
                int n = s.Trim().Length;
                for (int i = 0; i < (n / 3); i++)
                {
                    int a = n - 3 * (i + 1);
                    s = s.Insert(a, ch);
                }
                s = s.TrimStart(new char[] { Convert.ToChar(ch) });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "split_space()");
            }
            return s;
        }
        public void spaceNum(int x, ListView lv)
        {
            try
            {
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    string strText = lv.Items[i].SubItems[x].Text;
                    lv.Items[i].SubItems[x].Text = split_space(strText, ",");
                }
            }
            catch
            { }
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
            #region Database
            IniWriteValue("1", "1", ".");
            IniWriteValue("1", "2", "avazehstore");
            IniWriteValue("1", "3", "sa");
            IniWriteValue("1", "4", "123");
            #endregion
            //IniWriteValue("2", "1", dir.Substring(0, dir.LastIndexOf('\\')) + "\\backup");
            //IniWriteValue("2", "2", "1");
            //IniWriteValue("2", "3", "");
            //IniWriteValue("2", "4", "");
            IniWriteValue("2", "1", "Avazeh");
            IniWriteValue("2", "2", "2");
            #region Security
            IniWriteValue("3", "1", "0");
            IniWriteValue("3", "2", "admin");
            IniWriteValue("3", "3", "admin");
            #endregion
            #region Colors
            IniWriteValue("4", "1", "-3958");
            IniWriteValue("4", "2", "-5185306");
            IniWriteValue("4", "3", "-1331815");
            IniWriteValue("4", "4", "-7418738");
            IniWriteValue("4", "5", "-3958");
            IniWriteValue("4", "6", "-5185306");
            IniWriteValue("4", "7", "-1331815");
            IniWriteValue("4", "8", "-7418738");
            //IniWriteValue("4", "9", "-3958");
            IniWriteValue("4", "10", "-3414850");
            #endregion
            #region GeneralSettings
            IniWriteValue("5", "1", "0"); //If new product should be added automatically or not. 0=No 1=Yes
            IniWriteValue("6", "1", "0"); //Show shortcut for special file in main window. 0=No 1=Yes
            IniWriteValue("6", "2", "");
            IniWriteValue("6", "3", "-1");
            #endregion
            #region Enable or Disable Button Settings
            IniWriteValue("8", "1", "1");
            IniWriteValue("8", "2", "1");
            IniWriteValue("8", "3", "1");
            IniWriteValue("8", "4", "1");
            IniWriteValue("8", "5", "1");
            IniWriteValue("8", "6", "1");
            IniWriteValue("8", "7", "1");
            IniWriteValue("8", "8", "1");
            #endregion
        }

        public void initialListView(string strcmd, string strFaCol, string strCol, ListView lv, int[] w)
        {
            try
            {
                con.Close();
                lv.Items.Clear();
                //InitializeListView(strFaCol, lv, w); //temporarily disabled.

                SqlDataAdapter da = new SqlDataAdapter(strcmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "tb");
                DataTable table = new DataTable();
                table = ds.Tables["tb"];

                string[] arrCol = strCol.Split(':');
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow drow = table.Rows[i];
                    // Only row that have not been deleted
                    if (drow.RowState != DataRowState.Deleted)
                    {
                        // Define the list items
                        ListViewItem lvi = new ListViewItem("");
                        for (int j = 0; j < arrCol.Length; j++)
                        {
                            lvi.SubItems.Add(drow[arrCol[j]].ToString());
                        }
                        // Add the list items to the ListView
                        lv.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initialListView()");
            }
        }

        public void initialListView2(DataTable table, string strFaCol, string strCol, ListView lv, int[] w, string strCallerName)
        {
            try
            {
                con.Close();
                lv.Items.Clear();
                InitializeListView(strFaCol, strCol, lv, w, strCallerName);
                //MessageBox.Show("DING1");
                string[] arrCol = strCol.Split(':');
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    // Only row that have not been deleted
                    if (table.Rows[i].RowState != DataRowState.Deleted)
                    {
                        // Define the list items
                        ListViewItem lvi = new ListViewItem("");
                        for (int j = 0; j < arrCol.Length; j++)
                        {
                            lvi.SubItems.Add(table.Rows[i][arrCol[j]].ToString());
                            lvi.SubItems[j + 1].Name = arrCol[j];
                        }
                        // Add the list items to the ListView
                        lv.Items.Add(lvi);
                    }
                }
                //MessageBox.Show("DING2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "initialListView2()");
            }

        }

        private void InitializeListView(string strFaCol, string strCol, ListView lv, int[] w, string strCallerName)
        {
            try
            {
                lv.Columns.Clear();
                // Set the view to show details.
                lv.View = System.Windows.Forms.View.Details;

                // Allow the user to edit item text.
                //lv.LabelEdit = true;

                // Allow the user to rearrange columns.
                lv.AllowColumnReorder = true;

                // Select the item and subitems when selection is made.
                lv.FullRowSelect = true;

                // Display grid lines.
                lv.GridLines = true;

                // Sort the items in the list in ascending order.
                lv.Sorting = System.Windows.Forms.SortOrder.Ascending;
                string[] arrFaCol = strFaCol.Split(':');
                string[] arrCol = strCol.Split(':');
                // Attach Subitems to the ListView
                lv.Columns.Add("CheckBox", "انتخاب", 0, HorizontalAlignment.Center, 0);
                for (int i = 0; i < arrFaCol.Length; i++)
                {
                    lv.Columns.Add(arrCol[i], arrFaCol[i], w[i], HorizontalAlignment.Center, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "InitializeListView()");
            }

        }

        public Int64 GetNextLowerCode(string field, string tbName)
        {
            Int64 uid = 0;
            string strCmd = "SELECT MIN(" + field + ") as u_code FROM " + tbName;
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                uid = Convert.ToInt64(dt.Rows[0]["u_code"].ToString()) - 1;
            }
            catch
            {
                uid = 0;
            }
            return uid;
        }

        public Int64 GetNextUpperCode(string field, string tbName)
        {
            Int64 uid = 0;
            string strCmd = "SELECT MAX(" + field + ") as u_code FROM " + tbName;
            SqlDataAdapter da = new SqlDataAdapter(strCmd, con);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                uid = Convert.ToInt64(dt.Rows[0]["u_code"].ToString()) + 1;
            }
            catch
            {
                uid = 0;
            }
            return uid;
        }

        public string getTime()
        {
            string Hour = DateTime.Now.Hour.ToString();
            if (Hour.Length == 1)
                Hour = "0" + Hour;
            string Minute = DateTime.Now.Minute.ToString();
            if (Minute.Length == 1)
                Minute = "0" + Minute;
            string Second = DateTime.Now.Second.ToString();
            if (Second.Length == 1)
                Second = "0" + Second;
            string Time = Hour + ":" + Minute + ":" + Second;
            //Int32 T_now = Convert.ToInt32(ConvertTimeSpan(Time));
            return Time;
        }

        PersianCalendar pCalendar = new PersianCalendar();

        public string getPersianDate(DateTime dt)
        {
            string Year = pCalendar.GetYear(dt).ToString();
            string Month = pCalendar.GetMonth(dt).ToString();
            if (Month.Length == 1) Month = "0" + Month;
            string Day = pCalendar.GetDayOfMonth(dt).ToString();
            if (Day.Length == 1) Day = "0" + Day;
            string _date = Year + Month + Day;
            return _date;
        }

        public string GetFormattedPersianDate(DateTime fdt)
        {
            string date = getPersianDate(fdt);
            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);
            return year + "/" + month + "/" + day;
        }

        public class ListViewItemComparer : System.Collections.IComparer //Used for sorting ListView by clicking on header.
        {
            private int col;
            public ListViewItemComparer()
            {
                col = 0;
            }
            public ListViewItemComparer(int column)
            {
                col = column;
            }
            public int Compare(object x, object y)
            {
                int returnVal = -1;
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                ((ListViewItem)y).SubItems[col].Text);
                return returnVal;
            }
        }
        /// <summary>
        /// This class is an implementation of the 'IComparer' interface.
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private System.Windows.Forms.SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = System.Windows.Forms.SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == System.Windows.Forms.SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public System.Windows.Forms.SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }

        public DataRow LoadSalesFactorDetails(String strFactorNumber)
        {
            DataRow dr;
            SqlCommand cmd = new SqlCommand("LoadFactorDetails", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fac_Num", strFactorNumber);
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            if (dt.Rows.Count > 0) dr = dt.Rows[0]; else dr = null;
            return dr;
        }

        public void PrintSalesFactor(string FactorNumber, string PrintMode, bool PrintDate, string TotalPaymentAmount, string PreviousFactorAmount, string PreviousFactorNumber)
        {
            FrmPrint frmReport = new FrmPrint(FactorNumber, PrintMode)
            {
                blnPrintDate = PrintDate,
                strTotalPaymentAmount = TotalPaymentAmount,
                strPrevFactorAmount = PreviousFactorAmount,
                strPrevFactorNum = PreviousFactorNumber
                
            };
            frmReport.Show();
        }
    }
}
