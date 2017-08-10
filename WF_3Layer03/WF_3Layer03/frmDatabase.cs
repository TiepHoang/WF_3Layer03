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

namespace WF_3Layer03
{
    public partial class frmDatabase : Form
    {
        private bool isEndLoad = false;

        public frmDatabase()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var o = Common.InfoServer;
            o.Database = cmbDatabase.Text;
            Common.SaveInfoServer(o);
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isEndLoad)
            {
                Common.ChaneConnection(new InfoServer()
                {
                    Database = cmbDatabase.Text,
                    Username = Common.InfoServer.Username,
                    Password = Common.InfoServer.Password,
                    UseAccount = Common.InfoServer.UseAccount,
                    NameServer = Common.InfoServer.NameServer,
                });
                cmbTable.DataSource = new SqlDatabaseConext(Common.connection).GetTable(cmbDatabase.SelectedText);
            }
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = new SqlProvider().GetData(string.Format("SELECT * FROM [{0}]", cmbTable.Text), Common.connection);
        }

        private void frmDatabase_Load(object sender, EventArgs e)
        {
            var sql = new SqlDatabaseConext(Common.connection);
            cmbDatabase.DataSource = sql.GetAllDatatable();
            isEndLoad = true;
            if (!string.IsNullOrWhiteSpace(Common.InfoServer.Database)) cmbDatabase.Text = Common.InfoServer.Database;
        }
    }
}
