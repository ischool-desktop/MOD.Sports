using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;

namespace ischool.Sports
{
    public partial class frmCopyEventItem : BaseForm
    {
        UDT.Events _sourceEvent = null; 
        public frmCopyEventItem()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Yes;
        }

        private void frmCopyEventItem_Load(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell cbCell = new DataGridViewComboBoxCell();
            cbCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
        }

        public void SetSourceEvent(UDT.Events ev)
        {
            _sourceEvent = ev;
        }
    }
}
