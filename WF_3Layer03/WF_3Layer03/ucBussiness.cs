using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace WF_3Layer03
{
    public partial class ucBussiness : UserControl
    {
        #region my value

        public ResultRunCode ResultRun { get; private set; }
        public Bussiness Bussiness { get; set; }

        #endregion

        public ucBussiness(Bussiness Bussiness)
        {
            InitializeComponent();
            ResultRun = new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.NotRun
            };
            this.Bussiness = Bussiness;
            _reload();
        }

        private void _reload()
        {
            txtName.Text = Bussiness.GetNameClass();
            if (Bussiness.GetNameClass().Contains("sys"))
            {
                cbRun.Checked = false;
            }
            else
            {
                cbRun.Checked = true;
            }
            BackColor = cbRun.Checked ? Color.LawnGreen : Color.Azure;
        }

        private void cbRun_CheckedChanged(object sender, EventArgs e)
        {
            BackColor = cbRun.Checked ? Color.LawnGreen : Color.OrangeRed;
        }

        public ResultRunCode Run()
        {
            if (cbRun.Checked)
            {
                ResultRun = Bussiness.Run();
            }
            switch (ResultRun.Status)
            {
                case ResultRunCode.eStatus.NotRun:
                    BackColor = Color.OrangeRed;
                    break;
                case ResultRunCode.eStatus.Success:
                    BackColor = Color.Green;
                    break;
                case ResultRunCode.eStatus.Error:
                    BackColor = Color.Red;
                    break;
                default:
                    BackColor = Color.DimGray;
                    break;
            }
            return ResultRun;
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _reload();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Run().ToString(), "Kết quả", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void showCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmShowCode(Bussiness).ShowDialog();
        }

        private void ucBussiness_MouseClick(object sender, MouseEventArgs e)
        {
            _click(e);
        }

        private void _click(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
            else
            {
                cbRun.Checked = !cbRun.Checked;
                BackColor = cbRun.Checked ? Color.LawnGreen : Color.Azure;
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            _click(e);
        }
    }
}
