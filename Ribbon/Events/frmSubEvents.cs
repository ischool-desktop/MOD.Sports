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
            parseItems();

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
            string strQry = " school_year = " + _EventData.SchoolYear + " AND ref_group_type_id = " + _EventData.RefGroupTypeId + " AND name ='" + _EventData.Name + "' AND category = '"+_EventData.Category+"'";
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
            if (_IsAddMode)
            {
                this.Text = "新增競賽項目";
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
        }

        private void parseItems()
        {
            // 比對賽制
            if (_GameTypesDict.ContainsKey(cbxGameType.Text))
            {
                int uid;
                if (int.TryParse(_GameTypesDict[cbxGameType.Text].UID, out uid))
                {
                    _EventData.RefGameTypeId = uid;
                }
            }

            // 比對組別
            if (_GroupTypesDict.ContainsKey(cbxGroupType.Text))
            {
                int uid;
                if (int.TryParse(_GroupTypesDict[cbxGroupType.Text].UID, out uid))
                {
                    _EventData.RefGroupTypeId = uid;
                }
            }
        }


        private void Save()
        {
            // 填入資料並寫入

            _EventData.SchoolYear = iptSchoolYear.Value;
            _EventData.Category = txtCategory.Text;
            _EventData.Name = txtName.Text;

            if (dtEventStartDate.IsEmpty)
            {
                _EventData.EventStartDate = null;
            }
            else
            {
                _EventData.EventStartDate = dtEventStartDate.Value;
            }

            if (dtEventEndDate.IsEmpty)
            {
                _EventData.EventEndDate = null;
            }
            else
            {
                _EventData.EventEndDate = dtEventEndDate.Value;
            }

            if (dtRegStartDate.IsEmpty)
            {
                _EventData.RegStartDate = null;
            }
            else
            {
                _EventData.RegStartDate = dtRegStartDate.Value;
            }

            if (dtRegEndDate.IsEmpty)
            {
                _EventData.RegEndDate = null;
            }
            else
            {
                _EventData.RegEndDate = dtRegEndDate.Value;
            }

            _EventData.MaxMemberCount = iptMaxMemberCount.Value;
            _EventData.MinMemberCount = iptMinMemberCount.Value;

            _EventData.IsTeam = chkIsTeam.Checked;
            _EventData.AthleticOnly = chkAthleticOnly.Checked;
            _EventData.IsDrawLots = chkIsDrawLots.Checked;

            if (dtDrawLotsStartDate.IsEmpty)
            {
                _EventData.DrawLotsStartDate = null;
            }
            else
            {
                _EventData.DrawLotsStartDate = dtDrawLotsStartDate.Value;
            }


            if (dtDrawLotsEndDate.IsEmpty)
            {
                _EventData.DrawLotsEndDate = null;
            }
            else
            {
                _EventData.DrawLotsEndDate = dtDrawLotsEndDate.Value;
            }

            if (dtAnnouncementDate.IsEmpty)
            {
                _EventData.AnnouncementDate = null;
            }
            else
            {
                _EventData.AnnouncementDate = dtAnnouncementDate.Value;
            }

            _EventData.EventDescription = txtEventDescription.Text;
            _EventData.CreatedBy = _userAccount;
            _EventData.Save();
        }

        private void BindData()
        {
            if (_EventData == null)
                _EventData = new UDT.Events();

            iptSchoolYear.Value = _EventData.SchoolYear;
            txtCategory.Text = _EventData.Category;
            txtName.Text = _EventData.Name;

            if (_EventData.EventStartDate.HasValue)
                dtEventStartDate.Value = _EventData.EventStartDate.Value;
            if (_EventData.EventEndDate.HasValue)
                dtEventEndDate.Value = _EventData.EventEndDate.Value;
            // 對照放到畫面
            string RefGameTypeId = _EventData.RefGameTypeId.ToString();
            if (_GameTypesDict.ContainsKey(RefGameTypeId))
                cbxGameType.Text = _GameTypesDict[RefGameTypeId].Name;
            if (_EventData.RegStartDate.HasValue)
                dtRegStartDate.Value = _EventData.RegStartDate.Value;
            if (_EventData.RegEndDate.HasValue)
                dtRegEndDate.Value = _EventData.RegEndDate.Value;
            iptMaxMemberCount.Value = _EventData.MaxMemberCount;
            iptMinMemberCount.Value = _EventData.MinMemberCount;
            string RefGroupTypeId = _EventData.RefGroupTypeId.ToString();

            if (_GroupTypesDict.ContainsKey(RefGroupTypeId))
                cbxGroupType.Text = _GroupTypesDict[RefGroupTypeId].Name;
            chkIsTeam.Checked = _EventData.IsTeam;
            chkAthleticOnly.Checked = _EventData.AthleticOnly;
            chkIsDrawLots.Checked = _EventData.IsDrawLots;

            if (_EventData.AnnouncementDate.HasValue)
                dtAnnouncementDate.Value = _EventData.AnnouncementDate.Value;

            if (_EventData.DrawLotsStartDate.HasValue)
                dtDrawLotsStartDate.Value = _EventData.DrawLotsStartDate.Value;

            if (_EventData.DrawLotsEndDate.HasValue)
                dtDrawLotsEndDate.Value = _EventData.DrawLotsEndDate.Value;

            txtEventDescription.Text = _EventData.EventDescription;

            // 當畫面上學年度0，使用預設學年度學期
            if (iptSchoolYear.Value == 0)
            {
                iptSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            }
        }
    }
}
