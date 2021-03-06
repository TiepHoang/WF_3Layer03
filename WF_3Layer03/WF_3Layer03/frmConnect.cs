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
using System.Data.SqlClient;
using System.IO;

namespace WF_3Layer03
{
    public partial class frmConnect : Form
    {
        Document document = new Document();

        public frmConnect()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbServer.Text)) MessageBox.Show("Nhập tên server!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            else
            {
                string sConnect = "";
                if (cbAccount.Checked)
                {
                    if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        MessageBox.Show("Nhập đầy đủ Username và Password!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        sConnect = new SqlProvider().CreatConnectString(cmbServer.Text, null, txtUsername.Text, txtPassword.Text);
                    }
                }
                else
                {
                    sConnect = new SqlProvider().CreatConnectString(cmbServer.Text, null, null, null);
                }
                try
                {
                    SqlConnection con = new SqlConnection(sConnect);
                    con.Open();
                    con.Close();
                    var info = new InfoServer()
                    {
                        NameServer = cmbServer.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        UseAccount = cbAccount.Checked,
                        Database = null
                    };
                    string tmp = null;
                    if (Common.InfoServer != null) tmp = Common.InfoServer.Database;
                    Common.ChaneConnection(info);
                    info.Database = tmp;
                    Common.SaveInfoServer(info);
                    if (Common.LstServer.Count == 0 || !Common.LstServer.Any(q => q.Trim().ToLower().Equals(cmbServer.Text.Trim().ToLower())))
                    {
                        Common.AddListServer(cmbServer.Text);
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void btnShow_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnShow_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void cbAccount_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Enabled = txtUsername.Enabled = cbAccount.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Common.LstServer.Count > 0) cmbServer.Text = Common.LstServer[0];
            if (Common.InfoServer != null)
            {
                cbAccount.Checked = Common.InfoServer.UseAccount;
                txtUsername.Text = Common.InfoServer.Username;
                txtPassword.Text = Common.InfoServer.Password;
                cmbServer.Text = Common.InfoServer.NameServer;
            }
        }
    }
}
