using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using System.Threading;

namespace WF_3Layer03
{
    public partial class frmWellcome : Form
    {
        public frmWellcome()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://fb.com/tiep.hoang.dev");
            Next();
        }

        private void Next()
        {
            this.Hide();
            if (new frmConnect().ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
            else this.Close();
        }

        private void frmWellcome_Load(object sender, EventArgs e)
        {
            Common.ReadInfoServer();
            Common.ReadServer();
            Common.ReadSetting();
            new Task(() =>
            {
                Thread.Sleep(1234);
                Next();
            }).Start();
        }
    }
}
