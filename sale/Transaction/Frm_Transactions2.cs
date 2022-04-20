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
    public partial class Frm_Transactions2 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string strToday = "";
        //////////////////////////////////////////////////////////////////////////////////
        Boolean blnCanInitial_lvTransFileList = false; //To prevent initial_lvTransFileList from "Multiple running".
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        AutoCompleteStringCollection FileCollection = new AutoCompleteStringCollection();
        cUserFunction cUF = new cUserFunction();
        DataTable tbTransactions = new DataTable();
        Color clrTodayFile;
        Color clrCreditorFile;
        Color clrDebtorFile;
        Color clrZeroFile;
        bool blnCanEdit = true;
        private cUserFunction.ListViewColumnSorter lvwColumnSorter;
        public Frm_Transactions2()
        {
            InitializeComponent();
            lvwColumnSorter = new cUserFunction.ListViewColumnSorter();
            strToday = cUF.GetFormattedPersianDate(DateTime.Now);
        }

        private void Frm_Transactions_Load(object sender, EventArgs e)
        {
            dgvTransFileList.DataSource = bindingSource1;
            ////////////////////////////////////////////////////////////////////////////////////////////////
            cEncrypt c = new cEncrypt();
            string dir = Application.StartupPath;
            if (!System.IO.File.Exists(dir + "\\setting.ini"))
                cUF.defaultSetting();
            cUF.IniFile(dir + "\\setting.ini");
            clrTodayFile = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "5")));
            clrCreditorFile = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "6")));
            clrDebtorFile = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "7")));
            clrZeroFile = Color.FromArgb(int.Parse(cUF.IniReadValue("4", "8")));
            if (cUF.IniReadValue("8", "7") == "1") blnCanEdit = btnNewFile.Enabled = true; else blnCanEdit = btnNewFile.Enabled = false;
            cmbTransStatus.SelectedIndex = 0;
            Initial_cmbTransFileName();
            blnCanInitial_lvTransFileList = true;
            BuildDataAdapter(dataAdapter);
            Initial_dgvTransFileList();
            bindingSource1.ListChanged += BindingSource_ListChanged;
            cUF.ChangeLanguage("fa");
        }

        private void Initial_cmbTransFileName()
        {
            SqlCommand cmd = new SqlCommand("GetTransactionFileSubjectHistory", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(cmd.ExecuteReader());
            con.Close();
            string[] strAutoCompleteString = dt.AsEnumerable().Select(row => row.Field<string>("FileSubject")).ToArray();
            FileCollection.AddRange(strAutoCompleteString);
            cmbTransFileName.DataSource = dt;
            cmbTransFileName.DisplayMember = "FileSubject";
            cmbTransFileName.ValueMember = "FileCode";
            cmbTransFileName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbTransFileName.AutoCompleteCustomSource = FileCollection;
            cmbTransFileName.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void Initial_dgvTransFileList()
        {
            try
            {
                if (blnCanInitial_lvTransFileList)
                {

                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    bindingSource1.DataSource = dt;
                    dgvTransFileList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    string[] strFaCol = { "کد فایل", "عنوان", "جمع درآمد", "جمع هزینه", "تراز", "تاریخ ایجاد", "تاریخ ویرایش" };
                    string[] strCol = { "FileCode", "FileSubject", "IncomeAmount", "ExpenseAmount", "Balance", "DateCreated", "DateModified" };
                    int[] ColWidth = { 50, 190, 115, 115, 115, 85, 85 };
                    for (int i = 0; i < ColWidth.Length; i++)
                    {
                        dgvTransFileList.Columns[strCol[i]].HeaderText = strFaCol[i].ToString();
                        dgvTransFileList.Columns[strCol[i]].Width = ColWidth[i];
                        //dgvTransFileList.Columns[strCol[i]].Visible = Convert.ToBoolean(ColWidth[i]);
                    }
                    dgvTransFileList.Sort(dgvTransFileList.Columns["FileCode"], System.ComponentModel.ListSortDirection.Descending);
                    dgvTransFileList.Columns["IncomeAmount"].DefaultCellStyle.Format = "N0";
                    dgvTransFileList.Columns["ExpenseAmount"].DefaultCellStyle.Format = "N0";
                    dgvTransFileList.Columns["Balance"].DefaultCellStyle.Format = "N0";
                    ComputeAndUpdateStatusBar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Initial_dgvTransFileList()");
            }
        }

        void BindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            ComputeAndUpdateStatusBar();
        }

        void ComputeAndUpdateStatusBar()
        {
            double dblIncomes = Double.Parse((bindingSource1.DataSource as DataTable).Compute("SUM(IncomeAmount)", "true").ToString());
            double dblExpenses = Double.Parse((bindingSource1.DataSource as DataTable).Compute("SUM(ExpenseAmount)", "true").ToString());
            tsslIncomesSum.Text = cUF.split_space(dblIncomes.ToString(), ",");
            tsslExpensesSum.Text = cUF.split_space(dblExpenses.ToString(), ",");
            tsslTotalBalance.Text = cUF.split_space((dblIncomes + dblExpenses).ToString(), ",");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Initial_dgvTransFileList();
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            //try
            {
                string strFileSubject = "";
                Frm_AddNewOrRenameTransactionFile frmAddNew = new SafaShop.Frm_AddNewOrRenameTransactionFile();
                frmAddNew.ShowDialog(this);
                strFileSubject = frmAddNew.strFileSubject;
                if (strFileSubject == "")
                    return;
                DataRow dr = ((DataTable)bindingSource1.DataSource).NewRow();
                dr["FileCode"] = cUF.GetNextUpperCode("FileCode", "tbTransactions").ToString();
                dr["FileSubject"] = strFileSubject;
                dr["IncomeAmount"] = 0;
                dr["ExpenseAmount"] = 0;
                dr["Balance"] = 0;
                dr["DateCreated"] = cUF.GetFormattedPersianDate(DateTime.Now);
                dr["DateModified"] = cUF.GetFormattedPersianDate(DateTime.Now);
                ((DataTable)bindingSource1.DataSource).Rows.Add(dr);
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
                blnCanInitial_lvTransFileList = false;
                txtTransFileCode.Clear();
                cmbTransFileName.SelectedIndex = 0;
                cmbTransStatus.SelectedIndex = 0;
                blnCanInitial_lvTransFileList = true;
            }
            //catch
            //{
            //    MessageBox.Show("خطا در ایجاد فایل جدید", "btnNewFile_Click()");
            //}
        }

        private void Frm_Transactions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbTransFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToString(e.KeyChar) == "\r")
            {
                
            }
        }

        private void txtTransFileCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cmbTransStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 1) //Positive
                bindingSource1.Filter = "Balance > 0";
            else if ((sender as ComboBox).SelectedIndex == 2) //Negative
                bindingSource1.Filter = "Balance < 0";
            else if ((sender as ComboBox).SelectedIndex == 3) //Zero
                bindingSource1.Filter = "Balance = 0";
            else //All
                bindingSource1.Filter = "";
        }

        private void chkStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            ssStatusBar.Visible = chkStatusBar.Checked;
        }

        private void tsmDeleteFile_Click(object sender, EventArgs e)
        {
            if (!blnCanEdit) return;
            if (dgvTransFileList.SelectedRows.Count == 0)
                return;
            DialogResult res = MessageBox.Show("آیا از حذف این فایل/فایل ها اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.No) return;
            foreach (DataGridViewRow row in dgvTransFileList.SelectedRows)
            {
                if (!row.IsNewRow)
                    dgvTransFileList.Rows.Remove(row);
            }
            dataAdapter.Update((DataTable)bindingSource1.DataSource);
        }

        private void tsmOpenFile_Click(object sender, EventArgs e)
        {
            dgvTransFileList_CellDoubleClick(new object(), new DataGridViewCellEventArgs(0, 0));
        }

        private void tsmRenameFile_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (!blnCanEdit) return;
                Frm_AddNewOrRenameTransactionFile fAR = new SafaShop.Frm_AddNewOrRenameTransactionFile();
                fAR.Text = "ویرایش نام فایل";
                fAR.strFileSubject = dgvTransFileList.SelectedRows[0].Cells["FileSubject"].Value.ToString().Trim();
                fAR.ShowDialog(this);
                if (fAR.strFileSubject == "")
                    return;
                string strCode= dgvTransFileList.SelectedRows[0].Cells["FileCode"].Value.ToString().Trim();
                DataRow[] dr = (bindingSource1.DataSource as DataTable).Select("FileCode = " + strCode);
                if (dr.Length == 0)
                    return;
                dr[0]["FileSubject"] = fAR.strFileSubject;
                dr[0]["DateModified"] = cUF.GetFormattedPersianDate(DateTime.Now);
                dataAdapter.Update((DataTable)bindingSource1.DataSource);
            //}
            //catch { }
        }

        void BuildDataAdapter(SqlDataAdapter da)
        {
            SqlCommand cmd;
            SqlParameter parameter;
            #region Build Select Command
            cmd = new SqlCommand("LoadTransactionFileList", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            if (cmbTransFileName.Text.Trim() != "" && cmbTransFileName.SelectedIndex != 0)
                cmd.Parameters.AddWithValue("@FileCode", cmbTransFileName.SelectedValue.ToString());
            int intFileCode;
            if (int.TryParse(txtTransFileCode.Text.Trim(), out intFileCode))
                cmd.Parameters.AddWithValue("@FileCode", txtTransFileCode.Text.Trim());
            cmd.Parameters.AddWithValue("@TransStatusIndex", cmbTransStatus.SelectedIndex);
            da.SelectCommand = cmd;
            #endregion

            #region Build Insert Command
            cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 1); //Runs Insert Command
            cmd.Parameters.Add("@ParamFileCode", SqlDbType.BigInt, 64, "FileCode");
            cmd.Parameters.Add("@ParamFileSubject", SqlDbType.NVarChar, 100, "FileSubject");
            cmd.Parameters.Add("@ParamDate", SqlDbType.Char, 10, "DateCreated");
            dataAdapter.InsertCommand = cmd;
            #endregion

            #region Build Update Command
            cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 2); //Runs Update Command.
            cmd.Parameters.Add("@ParamFileCode", SqlDbType.BigInt, 64, "FileCode");
            cmd.Parameters.Add("@ParamFileSubject", SqlDbType.NVarChar, 100, "FileSubject");
            cmd.Parameters.Add("@ParamDate", SqlDbType.Char, 10, "DateModified");
            dataAdapter.UpdateCommand = cmd;
            #endregion

            #region Build Delete Command
            cmd = new SqlCommand("AddNewOrUpdateOrDeleteTransactionFile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Mode", 3); //Runs Delete Command
            parameter = cmd.Parameters.Add("@ParamFileCode", SqlDbType.BigInt, 64, "FileCode");
            parameter.SourceVersion = DataRowVersion.Original;
            dataAdapter.DeleteCommand = cmd;
            #endregion
        }

        private void dgvTransFileList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dgvTransFileList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            SetCellFormatAndColor(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex], strToday);
        }

        void SetCellFormatAndColor(DataGridViewCell cell, string date)
        {
            if (cell.OwningColumn.Name == "DateCreated")
                if (cell.Value.ToString().Trim() == date)
                    cell.OwningRow.Cells["FileSubject"].Style.BackColor = clrTodayFile;//Highlight today's files.
                else { }
            else if (cell.OwningColumn.Name == "DateModified")
            {
                if (cell.Value.ToString().Trim() == date)
                    cell.OwningRow.Cells["FileCode"].Style.BackColor = Color.BurlyWood;
                else { }
            }
            else if (cell.OwningColumn.Name == "Balance")
            {
                if (cell.Value.ToString().Trim() == "0")
                    cell.OwningRow.Cells["Balance"].Style.BackColor = clrZeroFile;
                else if (cell.Value.ToString().Contains("-"))
                    cell.OwningRow.Cells["Balance"].Style.BackColor = clrDebtorFile;
                else cell.OwningRow.Cells["Balance"].Style.BackColor = clrCreditorFile;
            }
            //else if (cell.OwningColumn.Name == "IncomeAmount")
            //    dblIncomes += Convert.ToDouble(cell.Value.ToString());
            //else if (cell.OwningColumn.Name == "ExpenseAmount")
            //    dblExpenses += Convert.ToDouble(cell.Value.ToString());
            //else if (cell.OwningColumn.Name == "Balance")
            //    cell.Value = (dblIncomes + dblExpenses).ToString();
        }

        private void dgvTransFileList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Frm_TransactionDetails2 ftd = new Frm_TransactionDetails2(this.Initial_dgvTransFileList);
                int intFileCode = -1;
                if (int.TryParse(dgvTransFileList.SelectedRows[0].Cells["FileCode"].Value.ToString(), out intFileCode))
                {
                    ftd.intFileCode = intFileCode;
                    ftd.Text = dgvTransFileList.SelectedRows[0].Cells["FileSubject"].Value.ToString() + " - ریز حساب";
                    ftd.history = false;
                    ftd.Show();
                }
                else MessageBox.Show("خطا در یافتن کد فایل", "lvTransFileList_DoubleClick()");
            }catch { }
        }

        private void dgvTransFileList_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgv.HitTest(e.X, e.Y);
                    dgv.ClearSelection();
                    dgv.Rows[hti.RowIndex].Selected = true;
                }
            }catch { }
        }

        private void cmbTransFileName_TextChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == 0)
                bindingSource1.Filter = "";
            else if ((sender as ComboBox).Text != "")
                bindingSource1.Filter = "FileSubject LIKE '%" + (sender as ComboBox).Text.ToString() + "%'";
            else bindingSource1.Filter = "";
        }

        private void txtTransFileCode_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
                bindingSource1.Filter = "FileCode = " + (sender as TextBox).Text.Trim();
            else bindingSource1.Filter = "";
        }

        private void dgvTransFileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                tsmDeleteFile_Click(new object(), new EventArgs());
        }
    }
}