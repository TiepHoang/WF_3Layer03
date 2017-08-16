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

namespace WF_3Layer03
{
    public partial class frmSetting : Form
    {
        string table;

        public string Table
        {
            get
            {
                return table;
            }

            set
            {
                table = value;
                lblFormatProc.Text = Common.Setting.GetNameProc(table);
                lblFormatBus.Text = Common.Setting.GetClassBus(table);
                lblFormatDal.Text = Common.Setting.GetClassDal(table);
                lblFormatDto.Text = Common.Setting.GetClassDto(table);
                lblResultTable.Text = Table;
            }
        }

        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (Common.Setting != null)
            {
                this.txtDatabase.Text = Common.InfoServer.Database;

                this.txtNamespace_Bus.Text = Common.Setting.Format_NameSpace_BUS;
                this.txtNamespace_Dal.Text = Common.Setting.Format_NameSpace_DAL;
                this.txtNamespace_Dto.Text = Common.Setting.Format_NameSpace_DTO;
                this.txtFomat_Bus.Text = Common.Setting.Format_class_BUS;
                this.txtFomat_Dal.Text = Common.Setting.Format_class_DAL;
                this.txtFomat_Dto.Text = Common.Setting.Format_class_DTO;
                this.txtFomat_Proc.Text = Common.Setting.Format_PROC;
                dgvReplace.DataSource = Common.Setting.Replace_Table;
            }
            lblTable.Text = new SqlDatabaseConext(Common.connection).GetTable().FirstOrDefault(q => !q.Contains("sys"));
            Table = lblTable.Text;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Common.Setting = new Setting()
            {
                Format_class_BUS = txtFomat_Bus.Text,
                Format_class_DAL = txtFomat_Dal.Text,
                Format_class_DTO = txtFomat_Dto.Text,
                Format_PROC = txtFomat_Proc.Text,
                Format_NameSpace_BUS = txtNamespace_Bus.Text,
                Format_NameSpace_DAL = txtNamespace_Dal.Text,
                Format_NameSpace_DTO = txtNamespace_Dto.Text,
            };
            Common.SaveSetting();
            this.Hide();
            if (new frmMain().ShowDialog() == DialogResult.Yes)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void txtFomat_Bus_TextChanged(object sender, EventArgs e)
        {
            lblFormatBus.Text = Common.Setting.GetClassBus(Table);
        }

        private void txtFomat_Dal_TextChanged(object sender, EventArgs e)
        {
            lblFormatDal.Text = Common.Setting.GetClassDal(Table);
        }

        private void txtFomat_Dto_TextChanged(object sender, EventArgs e)
        {
            lblFormatDto.Text = Common.Setting.GetClassDto(Table);
        }

        private void txtFomat_Proc_TextChanged(object sender, EventArgs e)
        {
            lblFormatProc.Text = Common.Setting.GetNameProc(Table);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Common.Setting.Replace_Table.Add(txtOld.Text, txtNew.Text);
            dgvReplace.DataSource = Common.Setting.Replace_Table;
        }
    }
}
