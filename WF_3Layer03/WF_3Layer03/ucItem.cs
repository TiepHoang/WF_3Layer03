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
    public partial class ucItem : UserControl
    {
        #region MyRegion

        bool selected;

        private IAction iAction;

        Color color { get; set; }

        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
                color = selected ? Color.LawnGreen : Color.Khaki;
                this.BackColor = color;
            }
        }

        public ResultRunCode Result { get; set; }

        #endregion

        public ucItem()
        {
            InitializeComponent();
            selected = true;
        }

        void change()
        {
            selected = !selected;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            change();
        }

        private void ucItem_Click(object sender, EventArgs e)
        {
            change();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            change();
        }

        public ResultRunCode Run()
        {
            Result = iAction.Run();
            return Result;
        }

        public ucItem(IAction action)
        {
            this.iAction = action;
        }

        private void ucItem_Load(object sender, EventArgs e)
        {

        }
    }
}
