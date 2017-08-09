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
    public partial class Form1 : Form
    {
        public Form1()
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
                    this.Cursor = Cursors.WaitCursor;
                    con.Open();
                    con.Close();
                    Common.ChaneConnection(sConnect: sConnect);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.Default;
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
            if (File.Exists(Common.FILE_SERVER))
            {
                string[] lst = File.ReadAllLines(Common.FILE_SERVER);
                cmbServer.DataSource = lst;
                if (lst.Length > 0) cmbServer.Text = lst[0];
            }
            var info = new InfoServer().Read(Common.FILE_INFOSERVER);
            if (info != null)
            {
                cbAccount.Checked = info.UseAccount;
                txtUsername.Text = info.Username;
                txtPassword.Text = info.Password;
                cmbServer.Text = info.NameServer;
            }
        }
    }
}
