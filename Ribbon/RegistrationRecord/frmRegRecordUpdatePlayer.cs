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
    public partial class frmRegRecordUpdatePlayer : BaseForm
    {
        UDT.Players _player = null;
        private string _uid = "";
        List<UDT.Players> _temp = new List<UDT.Players>();
        BackgroundWorker _bgLoadData = new BackgroundWorker();
        public frmRegRecordUpdatePlayer()
        {
            InitializeComponent();
            _bgLoadData.WorkerReportsProgress = true;
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
        }

        private void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _player = null;
            if (_temp != null && _temp.Count > 0)
            {
                _player = _temp[0];
            }

            if (_player != null)
            {
                lblStudentText.Text = _player.ClassName + " 班 " + _player.SeatNo + " 號 " + _player.Name;
                chkIsLeader.Checked = _player.IsTeamLeader;
                if (_player.LotNo.HasValue)
                {
                    iptLotNo.Value = _player.LotNo.Value;
                }
            }
        }

        private void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            AccessHelper ah = new AccessHelper();
            _temp = ah.Select<UDT.Players>(" uid = " + _uid);

        }

        public void SetPlayerUID(string uid)
        {
            _uid = uid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmRegRecordUpdatePlayer_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _bgLoadData.RunWorkerAsync();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_player != null)
            {
                try
                {
                    if (iptLotNo.IsEmpty)
                    {
                        _player.LotNo = null;
                    }
                    else
                    {
                        _player.LotNo = iptLotNo.Value;
                    }
                    _player.IsTeamLeader = chkIsLeader.Checked;
                    _player.Save();
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("更新參賽人員失敗，" + ex.Message);
                    return;
                }

            }
            this.DialogResult = DialogResult.Yes;
        }
    }
}
