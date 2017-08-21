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

        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
                cbRun.Checked = selected;
                if (!cbRun.Checked) ResultRun.Status = ResultRunCode.eStatus.NotRun;
                _loadColor();
            }
        }

        bool selected;

        #endregion

        public ucBussiness(Bussiness Bussiness)
        {
            InitializeComponent();
            ResultRun = new ResultRunCode()
            {
                Status = ResultRunCode.eStatus.NotRun,
                Message = $"{Bussiness.GetNameClass()} : Not run"
            };
            Selected = true;
            this.Bussiness = Bussiness;
            _reload();
            this.toolTip1.SetToolTip(this, ResultRun.ToString());
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
            _loadColor();
        }

        private void cbRun_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbRun.Checked) ResultRun.Status = ResultRunCode.eStatus.NotRun;
            _loadColor();
        }

        public ResultRunCode Run()
        {
            if (cbRun.Checked)
            {
                ResultRun = Bussiness.Run();
            }
            _loadColor();
            this.toolTip1.SetToolTip(this, ResultRun.ToString());
            return ResultRun;
        }

        private void _loadColor()
        {
            switch (ResultRun.Status)
            {
                case ResultRunCode.eStatus.NotRun:
                    this.BackColor = cbRun.Checked ? Color.LightGreen : Color.Tan;
                    break;
                case ResultRunCode.eStatus.Success:
                    BackColor = Color.Green;
                    break;
                case ResultRunCode.eStatus.Error:
                    BackColor = Color.Red;
                    break;
                default:
                    BackColor = Color.OrangeRed;
                    break;
            }

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
                _loadColor();
            }
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            _click(e);
        }

        private void txtName_MouseEnter(object sender, EventArgs e)
        {
            this.Width = cbRun.Width + txtName.Width + 50;
        }

        private void txtName_MouseLeave(object sender, EventArgs e)
        {
            this.Width = 200;
        }
    }
}
