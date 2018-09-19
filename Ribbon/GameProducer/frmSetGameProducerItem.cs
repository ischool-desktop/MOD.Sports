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
using K12.Data;
using FISCA.UDT;
using FISCA.Data;

namespace ischool.Sports
{
    public partial class frmSetGameProducerItem : BaseForm
    {
        bool _isAdd = false;
        UDT.Games _game = null;
        public frmSetGameProducerItem()
        {
            InitializeComponent();
        }

        public void SetIsAdd(bool mode)
        {
            _isAdd = mode;
        }

        public void SetGame(UDT.Games ga)
        {
            _game = ga;
            if (_game == null)
                _game = new UDT.Games();
        }

        private void frmSetGameProducerItem_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            if (_isAdd)
            {

            }
            else
            {
                iptRoundNo.Enabled = false;
                iptGameNo.Enabled = false;

                iptRoundNo.Value = _game.RoundNo;
                iptGameNo.Value = _game.GameNo;
                
            }
        }
    }
}
