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
    public partial class fromPrintChequePreview : Form
    {
        string strAmountInNum;
        string strAmountInText;
        string strDay;
        string strMonth;
        string strYear;
        string strBearer;
        public fromPrintChequePreview(string AmountInNum, string AmountInText, string Day, string Month, string Year, string Bearer)
        {
            strAmountInNum = AmountInNum;
            strAmountInText = AmountInText;
            strDay = Day;
            strMonth = Month;
            strYear = Year;
            strBearer = Bearer;
            InitializeComponent();
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

        private void fromPrintChequePreview_Load(object sender, EventArgs e)
        {
            //Avazeh.PrintReports.crPrintCheque crp = new Avazeh.PrintReports.crPrintCheque();
            //crp.SetParameterValue("AmountInNum", (object)strAmountInNum);
            //crp.SetParameterValue("AmountInText", (object)strAmountInText);
            //crp.SetParameterValue("Day", (object)strDay);
            //crp.SetParameterValue("Month", (object)strMonth);
            //crp.SetParameterValue("Year", (object)strYear);
            //crp.SetParameterValue("Bearer", (object)strBearer);
            //CRV.Refresh();
            //CRV.ReportSource = crp;
            //CRV.Refresh();
        }

        private void fromPrintChequePreview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
