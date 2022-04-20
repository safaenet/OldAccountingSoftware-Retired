using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace SafaShop
{
    public partial class FrmPrint : Form
    {
        public string strcmd;
        public string strPrevFactorNum = "";
        public string strPrevFactorAmount = "";
        public string strTotalPaymentAmount = "";
        public bool blnPrintDate = true;
        public bool blnIsInvoice = false;
        string fnum= "";
        string strPrintMode = "";
        private Avazeh.PrintReports.crSF2 cr = new Avazeh.PrintReports.crSF2();
        public FrmPrint(string FacNum, string PrintMode)
        {
            InitializeComponent();
            fnum = FacNum;
            strPrintMode = PrintMode;
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

    SqlConnection con = new SqlConnection(Frm_main.conStr);

        private void FrmPrint_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("LoadSpecificationsForPrintDialog", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Fac_Num", fnum);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cr.Database.Tables[0].SetDataSource(dt);
            cr.SetParameterValue("paramTotalPayments", Int64.Parse(strTotalPaymentAmount.Replace(",", "")));
            cr.SetParameterValue("paramPrevRemainedAmount", Int64.Parse(strPrevFactorAmount.Replace(",", "")));
            cr.SetParameterValue("paramPrevFactorNumber", strPrevFactorNum);
            cr.SetParameterValue("paramPrintDate", blnPrintDate);
            CRV.ReportSource = cr;
            CRV.Refresh();
            //Determines how to print:
            if (strPrintMode == "SaleWithoutHeader")
            {
                cr.SetParameterValue("HeaderPath", "NULL");
                cr.SetParameterValue("isInvoice", false);
            }
            else if (strPrintMode == "SaleWithoutOfficialHeader")
            {
                cr.SetParameterValue("HeaderPath", Application.StartupPath + "\\Images\\UnOfficialSaleHeader.png");
                cr.SetParameterValue("isInvoice", false);
            }
            else if (strPrintMode == "SaleWithOfficialHeader")
            {
                cr.SetParameterValue("HeaderPath", Application.StartupPath + "\\Images\\OfficialSaleHeader.png");
                cr.SetParameterValue("isInvoice", false);
            }
            else if (strPrintMode == "InvoiceWithoutOfficialHeader")
            {
                cr.SetParameterValue("HeaderPath", Application.StartupPath + "\\Images\\UnOfficialInvoiceHeader.png");
                cr.SetParameterValue("isInvoice", true);
            }
            else if (strPrintMode == "InvoiceWithOfficialHeader")
            {
                cr.SetParameterValue("HeaderPath", Application.StartupPath + "\\Images\\OfficialInvoiceHeader.png");
                cr.SetParameterValue("isInvoice", true);
            }
        }

        private void FrmPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}