using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
            btnConnect.BackColor = btnDatabase.BackColor = btnSetting.BackColor = btnRun.BackColor = Color.Red;
            bool oke = false;
            if (Common.connection != null)
            {
                SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
                btnConnect.BackColor = Color.LightGreen;
                if (!string.IsNullOrWhiteSpace(b.InitialCatalog))
                {
                    btnDatabase.BackColor = Color.LightGreen;
                    oke = true;
                }
            }
            if (Common.Setting != null)
            {
                btnSetting.BackColor = Color.LightGreen;
                oke = oke && true;
            }

            btnRun.BackColor = oke ? Color.LightGreen : Color.Red;
        }

        Form fOpen;

        void _open(Form f)
        {
            _check();
            if (this.fOpen != null)
            {
                this.fOpen.Close();
                fOpen = null;
            }
            this.fOpen = f;
            fOpen.TopLevel = false;
            grCode.Controls.Add(fOpen);
            fOpen.FormBorderStyle = FormBorderStyle.None;
            fOpen.Dock = DockStyle.Fill;
            fOpen.Show();
            fOpen.FormClosing += FOpen_FormClosing;
        }

        private void FOpen_FormClosing(object sender, FormClosingEventArgs e)
        {
            _check();
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
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            _open(new frmSetting());
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            _open(new frmMain());
        }
    }
}
