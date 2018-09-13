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
    public partial class frmRegRecordSetTeam : BaseForm
    {
        bool _isAddMode = true;
        string _eventItemName = "";
        string _teamName = "";
        string _refEventID = "";
        UDT.Teams _updateTeam = null;
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        int? _lotNo = null;
        public frmRegRecordSetTeam()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void SetRefEventID(string id)
        {
            _refEventID = id;
        }

        public void SetUpdateTeam(UDT.Teams team)
        {
            _updateTeam = team;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (iptLotNo.IsEmpty)
            {
                _lotNo = null;
            }
            else
            {
                _lotNo = iptLotNo.Value;
            }

            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                FISCA.Presentation.Controls.MsgBox.Show("請輸入隊名");
                return;
            }

            if (_isAddMode)
            {
                // 檢查隊名是否重複並新增
                if (CheckTeamNamePass(txtTeamName.Text))
                {

                    try
                    {
                        // 新增
                        _teamName = txtTeamName.Text;
                        int? uid = AddTeam();
                    }
                    catch (Exception ex)
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("新增隊伍發生錯誤," + ex.Message);
                    }
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("輸入隊名已被使用，無法新增。");
                    return;

                }
            }
            else
            {
                try
                {
                    // 更新
                    _updateTeam.Name = txtTeamName.Text;
                    _updateTeam.LotNo = _lotNo;
                    _updateTeam.CreatedBy = _userAccount;
                    _updateTeam.Save();
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("更新隊伍發生錯誤," + ex.Message);
                }           
            }           

            this.DialogResult = DialogResult.Yes;
        }

        /// <summary>
        /// 檢查Team Name 是否可以新增
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool CheckTeamNamePass(string name)
        {
            bool pass = true;
            // 檢查資料庫內是否已有 Team Name，如果沒有回傳 true，如果已有相同名稱回傳 false
            QueryHelper qh = new QueryHelper();
            string strSQL = "SELECT uid FROM $ischool.sports.teams WHERE name = '" + name + "'";
            DataTable dt = qh.Select(strSQL);

            if (dt != null)
            {
                // 有相同名稱
                if (dt.Rows.Count > 0)
                    pass = false;
            }

            return pass;
        }

        /// <summary>
        /// 新增隊名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int? AddTeam()
        {
            int? uid = null;
            string lot_no_str = "null";
            if (_lotNo.HasValue)
                lot_no_str = _lotNo.Value.ToString();

            string strSQL = "INSERT INTO $ischool.sports.teams(ref_event_id,name,lot_no,created_by) VALUES(" + _refEventID + ",'" + _teamName + "'," + lot_no_str + ",'" + _userAccount + "')  RETURNING uid;";
            QueryHelper qh = new QueryHelper();
            DataTable dt = qh.Select(strSQL);

            if (dt.Rows[0][0] != null)
            {
                uid = int.Parse(dt.Rows[0][0].ToString());
            }

            return uid;
        }

        public void SetIsAddMode(bool bo)
        {
            _isAddMode = bo;
        }

        public void SetEventItemName(string name)
        {
            _eventItemName = name;
        }

        public string GetTeamName()
        {
            return _teamName;
        }

        public int? GetLotNo()
        {
            return _lotNo;
        }


        private void frmRegRecordSetTeam_Load(object sender, EventArgs e)
        {
            lblEventItem.Text = this._eventItemName;
            if (_isAddMode)
            {
                this.Text = "新增隊伍";
            }
            else
            {                
                this.Text = "修改隊伍";
                if( _updateTeam != null)
                {
                    txtTeamName.Text = _updateTeam.Name;
                    txtTeamName.Enabled = false;
                    if (_updateTeam.LotNo.HasValue)
                    {
                        iptLotNo.Value = _updateTeam.LotNo.Value;
                    }
                }
                
            }
        }
    }
}
