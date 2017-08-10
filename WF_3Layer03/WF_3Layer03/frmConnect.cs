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
                    this.Cursor = Cursors.WaitCursor;
                    con.Open();
                    con.Close();
                    Common.ChaneConnection(new InfoServer()
                    {
                        Database = Common.InfoServer.Database,
                        NameServer = cmbServer.Text,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        UseAccount = cbAccount.Checked
                    });
                    if (Common.LstServer.Count == 0 || !Common.LstServer.Any(q => q.Trim().ToLower().Equals(cmbServer.Text.Trim().ToLower())))
                    {
                        Common.AddListServer(cmbServer.Text);
                    }
                    Common.SaveInfoServer(new InfoServer()
                    {
                        NameServer = cmbServer.Text,
                        UseAccount = cbAccount.Checked,
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        Database = Common.InfoServer.Database
                    });
                    this.Cursor = Cursors.Default;

                    this.Hide();
                    if (new frmDatabase().ShowDialog() == DialogResult.Yes)
                    {
                        this.Show();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Error: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
