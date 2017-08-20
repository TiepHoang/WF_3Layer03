﻿using System;
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
    public partial class frmMain : Form
    {
        List<ucBussiness> lstUc = new List<ucBussiness>();

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
            bool error = resultRunCode.Status == ResultRunCode.eStatus.Success ? true : false;
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
    }
}
