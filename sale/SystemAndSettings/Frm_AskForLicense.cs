using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Avazeh.SystemAndSettings
{
    public partial class frmAskForLicense : Form
    {
        public frmAskForLicense()
        {
            InitializeComponent();
        }

        private void frmAskForLicense_Load(object sender, EventArgs e)
        {
            txtLicenseID.Text = MachineIDGenerator.Value();
        }
    }
}
