using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using System.Collections;
using System.IO;

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
                lblNamespaceBus.Text = Common.Setting.GetNamespaceBus(table);
                lblNamespaceDal.Text = Common.Setting.GetNamespaceDal(table);
                lblNamespaceDto.Text = Common.Setting.GetNamespaceDto(table);

                lblFormatBus.Text = Common.Setting.GetClassBus(table);
                lblFormatDal.Text = Common.Setting.GetClassDal(table);
                lblFormatDto.Text = Common.Setting.GetClassDto(table);

                lblFormatProc.Text = Common.Setting.GetNameProc(table);
                lblResultTable.Text = Table;
            }
        }

        Hashtable hashtable;

        public frmSetting()
        {
            InitializeComponent();
            hashtable = new Hashtable();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (Common.Setting != null)
            {
                this.txtDatabase.Text = Common.InfoServer.Database;

                this.txtNamespace_Bus.Text = Common.Setting.Format_Basic.Format_NameSpace_BUS;
                this.txtNamespace_Dal.Text = Common.Setting.Format_Basic.Format_NameSpace_DAL;
                this.txtNamespace_Dto.Text = Common.Setting.Format_Basic.Format_NameSpace_DTO;
                this.txtFomat_Bus.Text = Common.Setting.Format_Basic.Format_class_BUS;
                this.txtFomat_Dal.Text = Common.Setting.Format_Basic.Format_class_DAL;
                this.txtFomat_Dto.Text = Common.Setting.Format_Basic.Format_class_DTO;
                this.txtFomat_Proc.Text = Common.Setting.Format_Basic.Format_PROC;
            }
            else
            {
                Common.Setting = new Setting();
            }
            lblTable.Text = new SqlDatabaseConext(Common.connection).GetTable().FirstOrDefault(q => !q.Contains("sys"));
            Table = lblTable.Text;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
            txtDatabase.Text = builder.InitialCatalog;
            txtServer.Text = builder.DataSource;

            loadListView();
        }

        private void loadListView()
        {
            listView.Columns.Clear();
            listView.Columns.Add("Text cũ", 169);
            listView.Columns.Add("Text mới", 169);
            listView.Items.Clear();
            foreach (string item in Common.Setting.Replace_Table.Keys)
            {
                listView.Items.Add(new ListViewItem(new string[] { item, Common.Setting.Replace_Table[item].ToString() }));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Common.Setting = new Setting()
            {
                Format_Basic = new Setting.Basic()
                {
                    Format_class_BUS = txtFomat_Bus.Text,
                    Format_class_DAL = txtFomat_Dal.Text,
                    Format_class_DTO = txtFomat_Dto.Text,
                    Format_PROC = txtFomat_Proc.Text,
                    Format_NameSpace_BUS = txtNamespace_Bus.Text,
                    Format_NameSpace_DAL = txtNamespace_Dal.Text,
                    Format_NameSpace_DTO = txtNamespace_Dto.Text,
                },
                Replace_Table = hashtable
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Setting.Replace_Table.Add(txtOld.Text, txtNew.Text);
                listView.Items.Clear();
                foreach (string item in Common.Setting.Replace_Table.Keys)
                {
                    listView.Items.Add(new ListViewItem(new string[] { item, Common.Setting.Replace_Table[item].ToString() }));
                }
                Table = Common.Setting.GetNameTable(lblTable.Text);
                txtNew.Clear();
                txtOld.Clear();
                txtNew.ReadOnly = true;
                btnAdd.Enabled = false;
                txtOld.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtFomat_Bus_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Enter) return;
                Common.Setting.Format_Basic.Format_class_BUS = txtFomat_Bus.Text;
                lblFormatBus.Text = Common.Setting.GetClassBus(Table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtFomat_Dal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_class_DAL = txtFomat_Dal.Text;
                lblFormatDal.Text = Common.Setting.GetClassDal(Table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtFomat_Dto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_class_DTO = txtFomat_Dto.Text;
                lblFormatDto.Text = Common.Setting.GetClassDto(Table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtFomat_Proc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_PROC = txtFomat_Proc.Text;
                lblFormatProc.Text = Common.Setting.GetNameProc(Table);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtNamespace_Bus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_BUS = txtNamespace_Bus.Text;
                lblNamespaceBus.Text = Common.Setting.GetNamespaceBus(Table);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtNamespace_Dal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_DAL = txtNamespace_Dal.Text;
                lblNamespaceDal.Text = Common.Setting.GetNamespaceDal(Table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void txtNamespace_Dto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_DTO = txtNamespace_Dto.Text;
                lblNamespaceDto.Text = Common.Setting.GetNamespaceDto(Table);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.Checked)
                        {
                            Common.Setting.Replace_Table.Remove(item.Text);
                            listView.Items[item.Index].Remove();
                        }
                    }
                    Table = Common.Setting.GetNameTable(lblTable.Text);
                    loadListView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOld_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (!string.IsNullOrEmpty(txtOld.Text) && !Common.Setting.Replace_Table.ContainsKey(txtOld.Text))
            {
                txtNew.Focus();
                btnAdd.Enabled = true;
                txtNew.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Định dạng không hợp lệ, nhập lại", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                txtNew.ReadOnly = true;
            }
        }

        private void txtNew_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            btnAdd_Click(sender, e);
        }

        private void txtFolderBus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (Directory.Exists(txtFolderBus.Text))
            {
                GetNameSpace();
            }
            else
            {
                MessageBox.Show("Chọn lại folder Bus, folder hiện tại không tồn tại!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFolderBus.Focus();
            }
        }

        private void GetNameSpace()
        {
            List<string> lst = new List<string>();
            if (!string.IsNullOrWhiteSpace(txtFolderBus.Text)) lst.Add(txtFolderBus.Text.Replace("\\", "."));
            if (!string.IsNullOrWhiteSpace(txtFolderDal.Text)) lst.Add(txtFolderDal.Text.Replace("\\", "."));
            if (!string.IsNullOrWhiteSpace(txtFolderDto.Text)) lst.Add(txtFolderDto.Text.Replace("\\", "."));
            if (lst.Count < 2) return;

        }

        private void txtFolderDal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (Directory.Exists(txtFolderDal.Text))
            {
                GetNameSpace();
            }
            else
            {
                MessageBox.Show("Chọn lại folder Dal, folder hiện tại không tồn tại!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFolderDal.Focus();
            }
        }

        private void txtFolderDto_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (Directory.Exists(txtFolderDto.Text))
            {
                GetNameSpace();
            }
            else
            {
                MessageBox.Show("Chọn lại folder Dto, folder hiện tại không tồn tại!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtFolderDto.Focus();
            }
        }
    }
}
