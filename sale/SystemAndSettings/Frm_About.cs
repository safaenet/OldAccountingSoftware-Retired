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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lnkInstagram.Links.Add(0,100, "www.instagram.com/avazeh.store");
            lnkTelegram.Links.Add(0, 100, "www.telegram.me/avazehstore");
            //lnkTelegram.Links.Add(0, 100, "wwwtg://resolve?domain=avazehstore");
        }

        private void lnkInstagram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void lnkTelegram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string strUsername = System.Environment.UserName;
            //string strRoot = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
            //string strPath = strRoot + "Us0ers\\" + strUsername + "\\AppData\\Roaming\\Telegram Desktop\\Telegram.exe";
            //if (!System.IO.File.Exists(strPath))
            //    System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            //else
            //{
            //    System.Diagnostics.Process pr = new System.Diagnostics.Process();
            //    pr.StartInfo.FileName = strPath;
            //    pr.Start();
            //}
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void frmAbout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            frmChangeLog frcl = new frmChangeLog();
            frcl.ShowInTaskbar = false;
            frcl.Text = ((Button)sender).Text;
            frcl.ShowDialog(this);
        }
    }
}
