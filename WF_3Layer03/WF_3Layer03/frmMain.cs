using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_3Layer03
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Common.Setting.Format_Basic.FolderSave_Bus))
            {
                cbBus.ForeColor = Color.Red;
                cbBus.Enabled = false;
                cbBus.Checked = false;
            }
            if (string.IsNullOrWhiteSpace(Common.Setting.Format_Basic.FolderSave_Dal))
            {
                cbDal.ForeColor = Color.Red;
                cbDal.Enabled = false;
                cbDal.Checked = false;
            }
            if (string.IsNullOrWhiteSpace(Common.Setting.Format_Basic.FolderSave_Dto))
            {
                cbDto.ForeColor = Color.Red;
                cbDto.Enabled = false;
                cbDto.Checked = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}
