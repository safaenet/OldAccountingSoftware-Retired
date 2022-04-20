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
    public partial class frmPrintTransactionDetails : Form
    {
        public SqlDataAdapter sqlDataAdaptor = new SqlDataAdapter();
        SqlConnection con = new SqlConnection(Frm_main.conStr);
        public frmPrintTransactionDetails()
        {
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

        private void frmPrintTransactionDetails_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            sqlDataAdaptor.Fill(dt);
            Avazeh.PrintReports.crTD cr = new Avazeh.PrintReports.crTD();
            cr.Database.Tables[0].SetDataSource((DataTable)dt);
            CRV.Refresh();
            CRV.ReportSource = cr;
            CRV.Refresh();
        }

        private void frmPrintTransactionDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}