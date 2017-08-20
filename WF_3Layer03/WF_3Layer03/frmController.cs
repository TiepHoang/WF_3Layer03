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
    public partial class frmController : Form
    {
        public frmController()
        {
            InitializeComponent();
        }

        private void frmController_Load(object sender, EventArgs e)
        {
            new frmWellcome().ShowDialog();
            new frmConnect().ShowDialog();
            _check();
        }

        private void _check()
        {
            bool oke = false;
            btnConnect.BackColor = Common.connection == null || Common.InfoServer == null || string.IsNullOrWhiteSpace(Common.InfoServer.NameServer) ? Color.Red : Color.LightGreen;
            btnDatabase.BackColor = Common.connection == null || string.IsNullOrWhiteSpace(Common.InfoServer.Database) ? Color.Red : Color.LightGreen;
            btnSetting.BackColor = Common.Setting == null ? Color.Red : Color.LightGreen;
            oke = btnConnect.BackColor == Color.LightGreen && btnSetting.BackColor == Color.LightGreen && btnDatabase.BackColor == Color.LightGreen;
            btnRun.BackColor = oke ? Color.LightGreen : Color.Red;
            btnRun.Visible = oke;
        }

        Form fOpen;

        void _open(Form f)
        {
            if (this.fOpen != null) this.fOpen.Close();
            this.fOpen = f;
            fOpen.TopLevel = false;
            grCode.Controls.Add(fOpen);
            fOpen.FormBorderStyle = FormBorderStyle.None;
            fOpen.Dock = DockStyle.Fill;
            fOpen.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phần mềm được phát triển bởi Hoàng Tiệp.\r\n Cảm ơn bạn đã sử dụng ^^", "ThreeLayer ver 3.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            new frmConnect().ShowDialog();
            _check();
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            _open(new frmDatabase());
            _check();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            _open(new frmSetting());
            _check();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            _open(new frmMain());
            _check();
        }
    }
}
