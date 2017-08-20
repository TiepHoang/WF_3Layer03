using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace WF_3Layer03
{
    public partial class frmMain : Form
    {
        List<ucBussiness> lstUc = new List<ucBussiness>();

        public frmMain()
        {
            InitializeComponent();
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
            SqlConnectionStringBuilder buid = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
            txtDatabase.Text = buid.InitialCatalog;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder buid = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
            txtDatabase.Text = buid.InitialCatalog;
            fpnCode.Controls.Clear();
            var lstTable = new SqlDatabaseContext(Common.connection).GetTable();
            foreach (var item in lstTable)
            {
                FlowLayoutPanel pn = new FlowLayoutPanel();
                fpnCode.Controls.Add(pn);
                pn.Width = fpnCode.Width;
                pn.Height = 39;
                pn.Controls.Add(new Label() { Text = item });

                if (cbBus.Checked)
                {
                    var uc = new ucBussiness(new Bus(item, Common.connection, Common.Setting));
                    uc.Visible = true;
                    lstUc.Add(uc);
                    pn.Controls.Add(uc);
                }
                if (cbDal.Checked)
                {
                    var uc = new ucBussiness(new Dal(item, Common.connection, Common.Setting));
                    lstUc.Add(uc);
                    pn.Controls.Add(uc);
                }
                if (cbDto.Checked)
                {
                    var uc = new ucBussiness(new Dto(item, Common.connection, Common.Setting));
                    lstUc.Add(uc);
                    pn.Controls.Add(uc);
                }
                if (cbProc.Checked)
                {
                    var uc = new ucBussiness(new Proc(item, Common.connection, Common.Setting));
                    lstUc.Add(uc);
                    pn.Controls.Add(uc);
                }
            }
            btnRun.Visible = true;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            foreach (var item in lstUc)
            {
                _log(item.Run());
            }
        }

        private void _log(ResultRunCode resultRunCode)
        {
            bool error = resultRunCode.Status == ResultRunCode.eStatus.Error;
            string message = error ? resultRunCode.MessageError : "Success";
            _log(message, error);
        }

        void _log(string message, bool error)
        {
            message = $"\r\n{DateTime.Now.ToShortTimeString()}>> { message}";
            rtbLog.Select(rtbLog.Text.Length, rtbLog.Text.Length + message.Length);
            rtbLog.SelectionColor = error ? Color.Red : Color.Green;
            rtbLog.AppendText(message);
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void btnDeleteAllProc_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
            if(MessageBox.Show($"Bạn có muốn XÓA TẤT CẢ các STORE PROCEDURE của database {b.InitialCatalog}?","Cảnh báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new SqlProvider().DropAllProc(b.InitialCatalog, Common.connection);
                MessageBox.Show($"XÓA Thành công TẤT CẢ các STORE PROCEDURE của database {b.InitialCatalog}?", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
