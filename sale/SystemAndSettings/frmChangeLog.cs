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
    public partial class frmChangeLog : Form
    {
        public frmChangeLog()
        {
            InitializeComponent();
        }

        private void frmChangeLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
