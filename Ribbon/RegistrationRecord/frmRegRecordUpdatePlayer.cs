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
        // 團體 t,個人f
        private bool _isTeam = false;
        List<UDT.Players> _temp = new List<UDT.Players>();
        List<UDT.Players> _teamP = new List<UDT.Players>();
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
            _player = null;
            if (_temp != null && _temp.Count > 0)
            {
                _player = _temp[0];
            }

            if (_isTeam)
            {
                if (_player.RefTeamId.HasValue)
                {
                    _teamP = ah.Select<UDT.Players>("ref_team_id = " + _player.RefTeamId.Value);
                }
            }
        }

        public void SetPlayerUID(string uid)
        {
            _uid = uid;
        }

        public void SetIsTeam(bool bo)
        {
            _isTeam = bo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmRegRecordUpdatePlayer_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            // 當個人一定是隊長
            if (_isTeam == false)
                chkIsLeader.Checked = true;

            _bgLoadData.RunWorkerAsync();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_player != null)
            {
                try
                {
                    // 檢查是團體或個人，團體先將其他隊員isLeader設成 false
                    if (_isTeam)
                    {
                        // 當設定隊長
                        if (chkIsLeader.Checked)
                        {
                            if (_teamP.Count > 0)
                            {
                                foreach (UDT.Players p in _teamP)
                                {
                                    p.IsTeamLeader = false;
                                }
                                _teamP.SaveAll();
                            }
                        }
                        else
                        {
                            // 取消隊長，需要檢查是否有其他人當隊長，如果沒有不能取消
                            bool hasTeamLeader = false;
                            if (_teamP.Count > 0)
                            {
                                foreach (UDT.Players p in _teamP)
                                {
                                    // 自己不算
                                    if (p.UID == _uid)
                                        continue;

                                    hasTeamLeader = p.IsTeamLeader;
                                }
                            }

                            if (hasTeamLeader == false)
                            {
                                FISCA.Presentation.Controls.MsgBox.Show("沒有其他隊員是隊長無法取消。");
                                return;
                            }
                        }
                    }
                    else
                    {
                        // 個人賽自己一定是隊長
                        chkIsLeader.Checked = true;
                    }

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
