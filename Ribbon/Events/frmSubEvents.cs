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
    public partial class frmSubEvents : BaseForm
    {
         UDT.Events _EventData = null;


        public frmSubEvents()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void SetEvents(UDT.Events data)
        {
            if (data == null)
            {
                _EventData = new UDT.Events();
            }else
            {
                _EventData = data;
            }            
        }

        public UDT.Events GetEventData()
        {
            return _EventData;
        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSubEvents_Load(object sender, EventArgs e)
        {

        }
    }
}
