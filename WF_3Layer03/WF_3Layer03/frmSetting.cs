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
                txtResultTable.Text = Table;
            }
        }

        public frmSetting()
        {
            InitializeComponent();
        }

        bool getFolderSave()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LastPath = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Save();
                return true;
            }
            return false;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (Common.Setting != null)
            {
                _loadSetting();
            }
            else
            {
                Common.Setting = new Setting();
            }
            txtTable.Text = new SqlDatabaseContext(Common.connection).GetTable().Aggregate("", (m, c) => !m.Contains("sys") && m.Length > c.Length ? m : c);
            Table = txtTable.Text;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Common.connection.ConnectionString);
            txtDatabase.Text = builder.InitialCatalog;
            txtServer.Text = builder.DataSource;

            loadListView();

        }

        private void _loadSetting()
        {
            this.txtDatabase.Text = Common.InfoServer.Database;

            this.txtNamespace_Bus.Text = Common.Setting.Format_Basic.Format_NameSpace_BUS;
            this.txtNamespace_Dal.Text = Common.Setting.Format_Basic.Format_NameSpace_DAL;
            this.txtNamespace_Dto.Text = Common.Setting.Format_Basic.Format_NameSpace_DTO;
            this.txtFomat_Bus.Text = Common.Setting.Format_Basic.Format_class_BUS;
            this.txtFomat_Dal.Text = Common.Setting.Format_Basic.Format_class_DAL;
            this.txtFomat_Dto.Text = Common.Setting.Format_Basic.Format_class_DTO;
            this.txtFolderBus.Text = Common.Setting.Format_Basic.FolderSave_Bus;
            this.txtFolderDal.Text = Common.Setting.Format_Basic.FolderSave_Dal;
            this.txtFolderDto.Text = Common.Setting.Format_Basic.FolderSave_Dto;
            this.txtFomat_Proc.Text = Common.Setting.Format_Basic.Format_PROC;
            this.txtEntity.Text = Common.Setting.Format_Basic.Namespace_Entity;
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
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolderBus.Text) || string.IsNullOrWhiteSpace(txtFolderDal.Text) || string.IsNullOrWhiteSpace(txtFolderDto.Text) ||
                string.IsNullOrWhiteSpace(txtNamespace_Bus.Text) || string.IsNullOrWhiteSpace(txtNamespace_Dal.Text) || string.IsNullOrWhiteSpace(txtNamespace_Dto.Text))
                if (MessageBox.Show("Bạn không nhập đủ tên hoặc không hợp lệ namespace, folder save code! Bỏ qua?", "Chú ý", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) != DialogResult.Yes) return;
            Common.Setting.Format_Basic = new Setting.Basic()
            {
                Format_class_BUS = txtFomat_Bus.Text,
                Format_class_DAL = txtFomat_Dal.Text,
                Format_class_DTO = txtFomat_Dto.Text,
                Format_PROC = txtFomat_Proc.Text,
                Format_NameSpace_BUS = txtNamespace_Bus.Text,
                Format_NameSpace_DAL = txtNamespace_Dal.Text,
                Format_NameSpace_DTO = txtNamespace_Dto.Text,
                FolderSave_Bus = txtFolderBus.Text,
                FolderSave_Dal = txtFolderDal.Text,
                FolderSave_Dto = txtFolderDto.Text,
                Namespace_Entity = txtEntity.Text
            };
            Common.SaveSetting();
            this.Close();
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
                Table = Common.Setting.GetNameTable(txtTable.Text);
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
                lblFormatProc.Text = Common.Setting.GetNameProc(txtTable.Text);

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
                    Table = Common.Setting.GetNameTable(txtTable.Text);
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
            if (!string.IsNullOrWhiteSpace(txtFolderBus.Text)) lst.Add(txtFolderBus.Text);
            if (!string.IsNullOrWhiteSpace(txtFolderDal.Text)) lst.Add(txtFolderDal.Text);
            if (!string.IsNullOrWhiteSpace(txtFolderDto.Text)) lst.Add(txtFolderDto.Text);
            if (lst.Count < 2) return;

            lst = lst.OrderByDescending(q => q.Length).ToList();
            string r = "";
            var a1 = lst[0].Split('\\');
            var a2 = lst[1].Split('\\');
            int length = a1.Length;
            for (int i = 0; i < length; i++)
            {
                if (a2.Length <= i || a1[i] != a2[i]) break;
                r += a1[i] + '\\';
            }

            if (string.IsNullOrEmpty(r)) return;

            txtNamespace_Bus.Text = txtFolderBus.Text.Replace(r, "").Replace("\\", ".");
            if (txtNamespace_Bus.Text.Length > 0)
            {
                Common.Setting.Format_Basic.Format_NameSpace_BUS = txtNamespace_Bus.Text;
                Common.Setting.Format_Basic.FolderSave_Bus = txtFolderBus.Text;
                lblNamespaceBus.Text = Common.Setting.GetNamespaceBus(Table);
            }

            txtNamespace_Dal.Text = txtFolderDal.Text.Replace(r, "").Replace("\\", ".");
            if (txtNamespace_Dal.Text.Length > 0)
            {
                Common.Setting.Format_Basic.Format_NameSpace_DAL = txtNamespace_Dal.Text;
                Common.Setting.Format_Basic.FolderSave_Dal = txtFolderDal.Text;
                txtNamespace_Dal.Text = Common.Setting.GetNamespaceDal(Table);
            }

            txtNamespace_Dto.Text = txtFolderDto.Text.Replace(r, "").Replace("\\", ".");
            if (txtNamespace_Dto.Text.Length > 0)
            {
                Common.Setting.Format_Basic.Format_NameSpace_DTO = txtNamespace_Dto.Text;
                Common.Setting.Format_Basic.FolderSave_Dto = txtFolderDto.Text;
                txtNamespace_Dto.Text = Common.Setting.GetNamespaceDto(Table);
            }

            _loadSetting();
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

        private void txtFolderBus_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFolderBus.Text) && Directory.Exists(txtFolderBus.Text)) folderBrowserDialog1.SelectedPath = txtFolderBus.Text;
            if (getFolderSave())
            {
                txtFolderBus.Text = folderBrowserDialog1.SelectedPath;
                GetNameSpace();
            }
        }

        private void txtFolderDal_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFolderDal.Text) && Directory.Exists(txtFolderDal.Text)) folderBrowserDialog1.SelectedPath = txtFolderDal.Text;
            if (getFolderSave())
            {
                txtFolderDal.Text = folderBrowserDialog1.SelectedPath;
                GetNameSpace();
            }
        }

        private void txtFolderDto_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFolderDto.Text) && Directory.Exists(txtFolderDto.Text)) folderBrowserDialog1.SelectedPath = txtFolderDto.Text;
            if (getFolderSave())
            {
                txtFolderDto.Text = folderBrowserDialog1.SelectedPath;
                GetNameSpace();
            }
        }

        private void txtEntity_KeyUp(object sender, KeyEventArgs e)
        {
            txtEntity.Text = GetEntity(txtEntity.Text);
        }

        private void txtEntity_DoubleClick(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtEntity.Text = GetEntity(folderBrowserDialog1.SelectedPath);
            }
        }

        private string GetEntity(string selectedPath)
        {
            string r = "";

            var a1 = selectedPath.Split('\\');
            var a2 = txtFolderDal.Text.Split('\\');
            var a3 = txtFolderDto.Text.Split('\\');
            if (a3.Length < 1) a3 = txtFolderBus.Text.Split('\\');
            if (a1.Length < 1 || a2.Length < 1) return selectedPath;
            List<string> lst = new List<string>();
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i]) break;
                lst.Add(a1[i]);
            }
            for (int i = 0; i < lst.Count; i++)
            {
                if (a3.Length <= i || a3[i] != lst[i]) break;
                r += a3[i] + '\\';
            }
            return r == "" ? selectedPath : selectedPath.Replace(r, "").Replace('\\', '.');
        }

        private void txtNamespace_Bus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_BUS = txtNamespace_Bus.Text;
                lblNamespaceBus.Text = Common.Setting.GetNamespaceBus(Table);

            }
            catch
            {
            }
        }

        private void txtNamespace_Dal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_DAL = txtNamespace_Dal.Text;
                lblNamespaceDal.Text = Common.Setting.GetNamespaceDal(Table);
            }
            catch
            {
            }
        }

        private void txtNamespace_Dto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Common.Setting.Format_Basic.Format_NameSpace_DTO = txtNamespace_Dto.Text;
                lblNamespaceDto.Text = Common.Setting.GetNamespaceDto(Table);
            }
            catch
            {
            }
        }
    }
}
