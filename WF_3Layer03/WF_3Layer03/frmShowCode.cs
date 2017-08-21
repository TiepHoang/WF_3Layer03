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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var f = new FolderBrowserDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                bussiness.Save(f.SelectedPath);
                MessageBox.Show("Save in: " + f.SelectedPath, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bussiness.Run().ToString(), "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInfoTable_Click(object sender, EventArgs e)
        {
            rtbCode.Text = string.Join("\r\n", bussiness.Table.lstColumns);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            rtbCode.Text = bussiness.GetCode();
        }
    }
}
