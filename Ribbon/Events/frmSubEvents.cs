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

        bool _IsAddMode = true;

        BackgroundWorker _bgw = new BackgroundWorker();
        BackgroundWorker _bgwSave = new BackgroundWorker();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        // 對照表
        Dictionary<string, UDT.GroupTypes> _GroupTypesDict = new Dictionary<string, UDT.GroupTypes>();
        Dictionary<string, UDT.GameTypes> _GameTypesDict = new Dictionary<string, UDT.GameTypes>();
        Dictionary<string, UDT.ScoreTypes> _ScoreTypesDict = new Dictionary<string, UDT.ScoreTypes>();
        public frmSubEvents()
        {
            InitializeComponent();
            _bgw.WorkerReportsProgress = true;
            _bgwSave.WorkerReportsProgress = true;
            _bgw.DoWork += _bgw_DoWork;
            _bgw.RunWorkerCompleted += _bgw_RunWorkerCompleted;
            _bgwSave.DoWork += _bgwSave_DoWork;
            _bgwSave.RunWorkerCompleted += _bgwSave_RunWorkerCompleted;
        }

        private void _bgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnSave.Enabled = true;
            if (e.Error == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存完成");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗," + e.Error.Message);
            }
        }

        private void _bgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            Save();
        }

        private void _bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = true;
            BindData();
        }

        private void _bgw_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        public void SetGroupTypesDict(Dictionary<string, UDT.GroupTypes> dict)
        {
            _GroupTypesDict = dict;
        }

        public void SetGameTypesDict(Dictionary<string, UDT.GameTypes> dict)
        {
            _GameTypesDict = dict;
        }

        public void SetScoreTypesDict(Dictionary<string, UDT.ScoreTypes> dict)
        {
            _ScoreTypesDict = dict;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 檢查畫面日期是否合理
            // 活動開始日期與活動結束日期必填
            if (dtEventStartDate.IsEmpty || dtEventEndDate.IsEmpty)
            {
                FISCA.Presentation.Controls.MsgBox.Show("活動開始日期與活動結束日期 必填");
                return;
            }
            // 活動開始日期必須在活動結束日期之前
            if (dtEventStartDate.Value > dtEventEndDate.Value)
            {
                FISCA.Presentation.Controls.MsgBox.Show("活動開始日期必須在活動結束日期之前");
                return;
            }

            //當報名開始日期與報名結束日期當其中有填，需要填完整。
            if (dtRegStartDate.IsEmpty == false || dtRegEndDate.IsEmpty == false)
            {
                if (dtRegStartDate.IsEmpty == false && dtRegEndDate.IsEmpty == false)
                {

                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("當報名開始日期與報名結束日期其中有填，需要填寫完整。");
                    return;
                }
            }
            // 當報名開始日期與報名結束日期都有填寫。
            if (dtRegStartDate.IsEmpty == false && dtRegEndDate.IsEmpty == false)
            {
                if (dtRegStartDate.Value > dtRegEndDate.Value)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("報名開始日期必須在報名結束日期之前");
                    return;
                }
            }

            //當抽籤開始日期與抽籤結束日期當其中有填，需要填完整。
            if (dtDrawLotsStartDate.IsEmpty == false || dtDrawLotsEndDate.IsEmpty == false)
            {
                if (dtDrawLotsStartDate.IsEmpty == false && dtDrawLotsEndDate.IsEmpty == false)
                {

                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("當抽籤開始日期與抽籤結束日期其中有填，需要填寫完整。");
                    return;
                }
            }
            // 當抽籤開始日期與抽籤結束日期都有填寫。
            if (dtDrawLotsStartDate.IsEmpty == false && dtDrawLotsEndDate.IsEmpty == false)
            {
                if (dtRegEndDate.IsEmpty)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("需要填寫報名日期。");
                    return;
                }

                if (dtDrawLotsStartDate.Value > dtDrawLotsEndDate.Value)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("抽籤開始日期必須在抽籤結束日期之前");
                    return;
                }

                if (dtDrawLotsStartDate.Value < dtRegEndDate.Value)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("抽籤開始日期必須在報名結束日期之後");
                    return;
                }

            }

            // 檢查資料新增是否有重複
            // 條件 學年度+名稱+組別id
            if (_IsAddMode)
            {
                // 已有資料無法新增
                if (CheckHasEvent())
                {
                    FISCA.Presentation.Controls.MsgBox.Show("資料庫內已有相同學年度+競賽類別+競賽名稱+參賽組別，無法新增。");
                    return;
                }
            }
            btnSave.Enabled = false;
            _bgwSave.RunWorkerAsync();

        }

        private bool CheckHasEvent()
        {
            bool value = false;
            AccessHelper acc = new AccessHelper();
            string strQry = " school_year = " + _EventData.SchoolYear + " AND ref_group_type_id = " + _EventData.RefGroupTypeId + " AND name ='" + _EventData.Name + "' AND category = '" + _EventData.Category + "'";
            List<UDT.Events> dd = acc.Select<UDT.Events>(strQry);
            if (dd.Count > 0)
                value = true;
            return value;
        }

        public void SetEvents(UDT.Events data)
        {
            if (data == null)
            {
                _EventData = new UDT.Events();
            }
            else
            {
                _EventData = data;
            }
        }

        public UDT.Events GetEventData()
        {
            return _EventData;
        }


        public void SetIsAddMode(bool isAdd)
        {
            _IsAddMode = isAdd;
        }

        private void frmSubEvents_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            this.btnSave.Enabled = false;
            cbxGameType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGroupType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxScoreType.DropDownStyle = ComboBoxStyle.DropDownList;

            if (_IsAddMode)
            {
                AddDefaultSet();
            }
            else
            {
                this.Text = "修改競賽項目";
                // key 無法修改
                iptSchoolYear.Enabled = false;
                txtName.Enabled = false;
                cbxGroupType.Enabled = false;
                txtCategory.Enabled = false;
            }
            BindCanSelectItems();
            _bgw.RunWorkerAsync();
        }

        private void AddDefaultSet()
        {
            this.Text = "新增競賽項目";
            chkSportMeet.Checked = false;
            cbxScoreType.Text = "";
            dtDrawLotsStartDate.Enabled = dtDrawLotsEndDate.Enabled = chkIsDrawLots.Checked = false;
            rbPersonal.Checked = true;
            rbAllStud.Checked = true;

        }

        private void BindCanSelectItems()
        {
            cbxGameType.Items.Clear();
            foreach (var data in _GameTypesDict.Values)
            {
                if (!cbxGameType.Items.Contains(data.Name))
                    cbxGameType.Items.Add(data.Name);
            }

            cbxGroupType.Items.Clear();
            foreach (var data in _GroupTypesDict.Values)
            {
                if (!cbxGroupType.Items.Contains(data.Name))
                    cbxGroupType.Items.Add(data.Name);
            }

            cbxScoreType.Items.Clear();
            foreach (var data in _ScoreTypesDict.Values)
            {
                if (!cbxScoreType.Items.Contains(data.Name))
                    cbxScoreType.Items.Add(data.Name);
            }
        }


        private void Save()
        {
            // 填入資料並寫入

            // 學年度
            _EventData.SchoolYear = iptSchoolYear.Value;

            // 競賽類別
            _EventData.Category = txtCategory.Text;

            // 競賽名稱
            _EventData.Name = txtName.Text;

            // 運動會
            _EventData.IsSportMeet = chkSportMeet.Checked;

            // 參賽組別
            if (_GroupTypesDict.ContainsKey(cbxGroupType.Text))
            {
                int uid;
                if (int.TryParse(_GroupTypesDict[cbxGroupType.Text].UID, out uid))
                {
                    _EventData.RefGroupTypeId = uid;
                }
            }

            // 賽制
            if (_GameTypesDict.ContainsKey(cbxGameType.Text))
            {
                int uid;
                if (int.TryParse(_GameTypesDict[cbxGameType.Text].UID, out uid))
                {
                    _EventData.RefGameTypeId = uid;
                }
            }

            // 計分方式
            if (_ScoreTypesDict.ContainsKey(cbxScoreType.Text))
            {
                int uid;
                if (int.TryParse(_ScoreTypesDict[cbxScoreType.Text].UID, out uid))
                {
                    _EventData.RefScoreTypeId = uid;
                }
            }

            // 公告日期
            if (dtAnnouncementDate.IsEmpty)
            {
                _EventData.AnnouncementDate = null;
            }
            else
            {
                _EventData.AnnouncementDate = dtAnnouncementDate.Value;
            }

            // 報名開始日期
            if (dtRegStartDate.IsEmpty)
            {
                _EventData.RegStartDate = null;
            }
            else
            {
                _EventData.RegStartDate = dtRegStartDate.Value;
            }
            // 報名結束日期
            if (dtRegEndDate.IsEmpty)
            {
                _EventData.RegEndDate = null;
            }
            else
            {
                _EventData.RegEndDate = dtRegEndDate.Value;
            }

            // 活動開始日期
            if (dtEventStartDate.IsEmpty)
            {
                _EventData.EventStartDate = null;
            }
            else
            {
                _EventData.EventStartDate = dtEventStartDate.Value;
            }
            
            // 活動結束日期
            if (dtEventEndDate.IsEmpty)
            {
                _EventData.EventEndDate = null;
            }
            else
            {
                _EventData.EventEndDate = dtEventEndDate.Value;
            }

            // 抽籤
            _EventData.IsDrawLots = chkIsDrawLots.Checked;

            // 抽籤開始日期
            if (dtDrawLotsStartDate.IsEmpty)
            {
                _EventData.DrawLotsStartDate = null;
            }
            else
            {
                _EventData.DrawLotsStartDate = dtDrawLotsStartDate.Value;
            }

            // 抽籤結束日期
            if (dtDrawLotsEndDate.IsEmpty)
            {
                _EventData.DrawLotsEndDate = null;
            }
            else
            {
                _EventData.DrawLotsEndDate = dtDrawLotsEndDate.Value;
            }

            // 全校學生
            _EventData.IsRegAll = rbAllStud.Checked;

            // 僅體育股長
            _EventData.AthleticOnly = rbAthleticOnly.Checked;

            // 僅限制人員
            _EventData.IsRegLimit = rbLimit.Checked;

            // 個人賽,團體賽 
            _EventData.IsTeam = rbTeam.Checked;

            // 報名人數上限
            _EventData.MaxMemberCount = iptMaxMemberCount.Value;

            // 報名人數下限
            _EventData.MinMemberCount = iptMinMemberCount.Value;

            // 競賽說明
            _EventData.EventDescription = txtEventDescription.Text;
                        
            _EventData.CreatedBy = _userAccount;
            _EventData.Save();
        }

        private void BindData()
        {
            if (_EventData == null)
                _EventData = new UDT.Events();

            // 學年度
            iptSchoolYear.Value = _EventData.SchoolYear;
            // 競賽類別
            txtCategory.Text = _EventData.Category;
            // 競賽名稱
            txtName.Text = _EventData.Name;

            // 運動會
            chkSportMeet.Checked = _EventData.IsSportMeet;

            // 參賽組別
            string RefGroupTypeId = _EventData.RefGroupTypeId.ToString();
            if (_GroupTypesDict.ContainsKey(RefGroupTypeId))
                cbxGroupType.Text = _GroupTypesDict[RefGroupTypeId].Name;

            // 賽制
            string RefGameTypeId = _EventData.RefGameTypeId.ToString();
            if (_GameTypesDict.ContainsKey(RefGameTypeId))
                cbxGameType.Text = _GameTypesDict[RefGameTypeId].Name;
            // 計分方式
            string RefScoreTypeId = _EventData.RefScoreTypeId.ToString();
            if (_ScoreTypesDict.ContainsKey(RefScoreTypeId))
                cbxScoreType.Text = _ScoreTypesDict[RefScoreTypeId].Name;
            
            // 公告日期
            if (_EventData.AnnouncementDate.HasValue)
                dtAnnouncementDate.Value = _EventData.AnnouncementDate.Value;

            // 報名開始日期
            if (_EventData.RegStartDate.HasValue)
                dtRegStartDate.Value = _EventData.RegStartDate.Value;

            // 報名結束日期
            if (_EventData.RegEndDate.HasValue)
                dtRegEndDate.Value = _EventData.RegEndDate.Value;

            // 活動開始日期
            if (_EventData.EventStartDate.HasValue)
                dtEventStartDate.Value = _EventData.EventStartDate.Value;

            // 活動結束日期
            if (_EventData.EventEndDate.HasValue)
                dtEventEndDate.Value = _EventData.EventEndDate.Value;

            // 抽籤
            chkIsDrawLots.Checked = _EventData.IsDrawLots;

            // 抽籤開始日期
            if (_EventData.DrawLotsStartDate.HasValue)
                dtDrawLotsStartDate.Value = _EventData.DrawLotsStartDate.Value;

            // 抽籤結束日期
            if (_EventData.DrawLotsEndDate.HasValue)
                dtDrawLotsEndDate.Value = _EventData.DrawLotsEndDate.Value;

            // 全校學生
            rbAllStud.Checked = _EventData.IsRegAll;

            // 僅體育股長
            rbAthleticOnly.Checked = _EventData.AthleticOnly;

            // 僅限制人員
            rbLimit.Checked = _EventData.IsRegLimit;

            // 個人賽、團體賽
            if (_EventData.IsTeam)
            {
                rbTeam.Checked = true;
                rbPersonal.Checked = false;               
            }
            else
            {
                rbTeam.Checked = false;
                rbPersonal.Checked = true;
            }

            // 報名人數上限
            iptMaxMemberCount.Value = _EventData.MaxMemberCount;

            // 報名人數下限
            iptMinMemberCount.Value = _EventData.MinMemberCount;

            // 競賽說明
            txtEventDescription.Text = _EventData.EventDescription;
                      
            // 當畫面上學年度0，使用預設學年度學期
            if (iptSchoolYear.Value == 0)
            {
                iptSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            }

            // 畫面合理處理
            // 當抽籤沒勾，日期無法使用
            dtDrawLotsStartDate.Enabled = dtDrawLotsEndDate.Enabled = _EventData.IsDrawLots;
            // 人數上下限用在團體賽
            iptMaxMemberCount.Enabled = iptMinMemberCount.Enabled = _EventData.IsTeam;

            // 限制條件都沒選，選全校
            if (_EventData.IsRegAll == _EventData.IsRegLimit == _EventData.AthleticOnly == false)
            {
                rbAllStud.Checked = true;
            }
        }

        private void rbAllStud_CheckedChanged(object sender, EventArgs e)
        {
            btnRegLimit.Enabled = false;
        }

        private void btnRegLimit_Click(object sender, EventArgs e)
        {

        }



        private void rbAthleticOnly_CheckedChanged(object sender, EventArgs e)
        {
            btnRegLimit.Enabled = false;
        }

        private void cbLimit_CheckedChanged(object sender, EventArgs e)
        {
            btnRegLimit.Enabled = true;
        }

        private void rbPersonal_CheckedChanged(object sender, EventArgs e)
        {
            iptMaxMemberCount.Enabled = iptMinMemberCount.Enabled = false;
        }

        private void rbTeam_CheckedChanged(object sender, EventArgs e)
        {
            iptMaxMemberCount.Enabled = iptMinMemberCount.Enabled = true;
        }

        private void chkIsDrawLots_CheckedChanged(object sender, EventArgs e)
        {
            dtDrawLotsStartDate.Enabled = dtEventEndDate.Enabled = chkIsDrawLots.Checked;
        }
    }
}
