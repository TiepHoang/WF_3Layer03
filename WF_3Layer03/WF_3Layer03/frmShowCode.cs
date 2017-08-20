using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace WF_3Layer03
{
    public partial class frmShowCode : Form
    {
        public Bussiness bussiness { get; set; }

        public frmShowCode(Bussiness bussiness)
        {
            InitializeComponent();
            this.bussiness = bussiness;
        }

        private void frmShowCode_Load(object sender, EventArgs e)
        {
            rtbCode.Text = bussiness.GetCode();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
