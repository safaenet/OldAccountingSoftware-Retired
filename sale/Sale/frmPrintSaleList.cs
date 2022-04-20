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
    
    public partial class frmPrintSaleList : Form
    {
        DataTable dtSaleList;
        cUserFunction cUF = new cUserFunction();
        public frmPrintSaleList(DataTable dtTable)
        {
            dtSaleList = dtTable;
            InitializeComponent();
        }

        private void frmPrintSaleList_Load(object sender, EventArgs e)
        {
            Avazeh.PrintReports.crSaleList cr = new Avazeh.PrintReports.crSaleList();
            cr.Database.Tables["dtSaleList"].SetDataSource(dtSaleList);
            cr.SetParameterValue("pPersianDate", cUF.GetFormattedPersianDate(DateTime.Now));
            cr.SetParameterValue("pTime", DateTime.Now.ToShortTimeString());
            CRV.ReportSource = cr;
            CRV.Refresh();
        }
    }
}