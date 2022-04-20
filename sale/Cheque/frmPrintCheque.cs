using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JntNum2Text;

namespace SafaShop
{
    public partial class frmPrintCheque : Form
    {
        cUserFunction cUF = new cUserFunction();
        DateTime dtimeToday;
        System.Globalization.PersianCalendar PCal = new System.Globalization.PersianCalendar();
        int intBeginYear = 1390;
        public frmPrintCheque()
        {
            InitializeComponent();
        }

        private void frmPrintCheque_Load(object sender, EventArgs e)
        {
            dtimeToday = DateTime.Today;
            int iyear = PCal.GetYear(dtimeToday);
            int imonth = PCal.GetMonth(dtimeToday);
            int iday = PCal.GetDayOfMonth(dtimeToday);
            int i = 0;
            lblDate.Text = iyear.ToString() + "/" + imonth.ToString() + "/" + iday.ToString();
            string[] strDays = { "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه", "یکشنبه" };
            string[] strMonths = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            //Determine the index of DayOfWeek manually.
            if (dtimeToday.DayOfWeek == DayOfWeek.Monday)
                i = 0;
            if (dtimeToday.DayOfWeek == DayOfWeek.Tuesday)
                i = 1;
            if (dtimeToday.DayOfWeek == DayOfWeek.Wednesday)
                i = 2;
            if (dtimeToday.DayOfWeek == DayOfWeek.Thursday)
                i = 3;
            if (dtimeToday.DayOfWeek == DayOfWeek.Friday)
                i = 4;
            if (dtimeToday.DayOfWeek == DayOfWeek.Saturday)
                i = 5;
            if (dtimeToday.DayOfWeek == DayOfWeek.Sunday)
                i = 6;
            lblDayOfWeek.Text = strDays[i];
            lblMonthOfYear.Text = strMonths[imonth - 1];
            //cmbYear
            for (i = 0; i < 100; i++)
                cmbYear.Items.Add((object)(intBeginYear + i));
            cmbYear.SelectedIndex = iyear - intBeginYear;
            //
            //cmbMonth
            cmbMonth.SelectedIndex = imonth - 1;
            //
            //cmbDay
            i = PCal.GetDaysInMonth(iyear + 1300, imonth);
            for (int j = 1; j <= i; j++)
                cmbDay.Items.Add((object)j);
            cmbDay.SelectedIndex = iday - 1;
            //
        }

        private void txtMoney_Leave(object sender, EventArgs e)
        {
            if (txtMoney.Text == "")
                txtMoney.Text = "0";
            txtMoney.Text = cUF.split_space(txtMoney.Text, " ");
        }

        private void txtMoney_Enter(object sender, EventArgs e)
        {
            txtMoney.Text = txtMoney.Text.Replace(" ","");
            txtMoney.SelectAll();
        }

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//&&(e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '0') && ((sender as TextBox).Text == "0"))
            {
                e.Handled = true;
            }
            if ((e.KeyChar != '0') && ((sender as TextBox).Text == "0"))
            {
                txtMoney.Text = "";
            }
        }

        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            if ((txtMoney.Text.Length > 0) && (txtMoney.Text != "0"))
            {
                string str = txtMoney.Text.Replace(" ", "");
                txtNumInChar.Text = Num2Text.ToFarsi(Convert.ToInt64(str)) + " ریال تمام ";
                lblChAmount.Text = cUF.split_space(str, ",");
            }
            else txtNumInChar.Text = "صفر ریال تمام";
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //If Esfand is selected.
                //if (cmbMonth.SelectedIndex == 11 && cmbDay.Items.Count > 29)
                //    cmbDay.Items.Remove((object)30);
                //else if (cmbMonth.SelectedIndex != 11 && cmbDay.Items.Count <= 29)
                //    cmbDay.Items.Add((object)30);
                //
                //If 31_Day Month is selected.
                if (cmbMonth.SelectedIndex < 6 && cmbDay.Items.Count == 30)
                    cmbDay.Items.Add((object)31);
                else if (cmbMonth.SelectedIndex >= 6 && cmbDay.Items.Count == 31)
                    cmbDay.Items.Remove((object)31);
                //

                if (cmbDay.SelectedIndex < 0)
                    cmbDay.SelectedIndex = 29;
            }
            catch { }
            string str=(cmbMonth.SelectedIndex + 1).ToString();
            if (str.Length == 1)
                str = "0" + str;
            lblChMonth.Text = str;

        }

        private void btnSetNextNDays_Click(object sender, EventArgs e)
        {
            dtimeToday = DateTime.Today;
            dtimeToday = dtimeToday.AddDays(Double.Parse(nudDays.Value.ToString()));
            //MessageBox.Show(PCal.GetDayOfMonth(dtimeToday).ToString());
            cmbYear.SelectedValue = PCal.GetYear(dtimeToday) - intBeginYear - 1;
            cmbMonth.SelectedIndex = PCal.GetMonth(dtimeToday) - 1;
            cmbDay.SelectedIndex = PCal.GetDayOfMonth(dtimeToday) - 1;
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            dtimeToday = DateTime.Today;
            cmbYear.SelectedValue = PCal.GetYear(dtimeToday) - intBeginYear - 1;
            cmbMonth.SelectedIndex = PCal.GetMonth(dtimeToday) - 1;
            cmbDay.SelectedIndex = PCal.GetDayOfMonth(dtimeToday) - 1;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            fromPrintChequePreview pcp = new fromPrintChequePreview(lblChAmount.Text, txtNumInChar.Text, lblChDay.Text, lblChMonth.Text, lblChYear.Text, lblChBearer.Text);
            pcp.Show();
        }

        private void txtBearer_TextChanged(object sender, EventArgs e)
        {
            lblChBearer.Text = txtBearer.Text;
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cmbDay.Text;
            if (str.Length == 1)
                str = "0" + str;
            lblChDay.Text = str;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblChYear.Text = cmbYear.Text;
        }

        private void frmPrintCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
