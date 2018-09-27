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
    public partial class frmEvents : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();

        List<UDT.Events> _EventsList = new List<UDT.Events>();
        List<UDT.GroupTypes> _GroupTypesList = new List<UDT.GroupTypes>();
        List<UDT.GameTypes> _GameTypesList = new List<UDT.GameTypes>();
        Dictionary<string, UDT.GroupTypes> _GroupTypesDict = new Dictionary<string, UDT.GroupTypes>();
        Dictionary<string, UDT.GameTypes> _GameTypesDict = new Dictionary<string, UDT.GameTypes>();

        BackgroundWorker _bgw = new BackgroundWorker();

        public frmEvents()
        {
            InitializeComponent();
            _bgw.WorkerReportsProgress = true;
            _bgw.DoWork += _bgw_DoWork;
            _bgw.RunWorkerCompleted += _bgw_RunWorkerCompleted;
        }

        private void _bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetEditButtonEnable(true);
            LoadEventsToDataGridView();
        }

        private void _bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            // 讀取 比賽項目
            LoadEventsList();

            // 讀取賽制
            LoadGameTypesList();

            // 讀取組別
            LoadGroupTypesList();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count == 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            else
            {
                SetEditButtonEnable(false);
                UDT.Events selectEvent = dgData.SelectedRows[0].Tag as UDT.Events;

                if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除競賽項目與相關聯成績，請問是否刪除？", "刪除競賽項目", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    selectEvent.Deleted = true;
                    selectEvent.Save();
                    // 資料重整
                    _bgw.RunWorkerAsync();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count == 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            else
            {
                SetEditButtonEnable(false);
                UDT.Events selectEvent = dgData.SelectedRows[0].Tag as UDT.Events;
                frmSubEvents editFrom = new frmSubEvents();
                editFrom.SetEvents(selectEvent);
                editFrom.SetIsAddMode(false);
                editFrom.SetGameTypesDict(_GameTypesDict);
                editFrom.SetGroupTypesDict(_GroupTypesDict);
                if (editFrom.ShowDialog() == DialogResult.OK)
                {

                    // 資料重整
                    _bgw.RunWorkerAsync();
                }
                else
                {
                    SetEditButtonEnable(true);
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UDT.Events addEvents = null;
            SetEditButtonEnable(false);
            frmEventsTemplateAdd1 feta = new frmEventsTemplateAdd1();
            if (feta.ShowDialog() == DialogResult.OK)
            {
                addEvents = feta.GetEvents();
            }

            frmSubEvents addFrom = new frmSubEvents();
            addFrom.SetEvents(addEvents);
            addFrom.SetIsAddMode(true);
            addFrom.SetGameTypesDict(_GameTypesDict);
            addFrom.SetGroupTypesDict(_GroupTypesDict);
            if (addFrom.ShowDialog() == DialogResult.OK)
            {
                addEvents = addFrom.GetEventData();
                // 資料重整
                _bgw.RunWorkerAsync();
            }
            else
            {
                SetEditButtonEnable(true);
            }
        }

        private void frmEvents_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            SetEditButtonEnable(false);
            _bgw.RunWorkerAsync();

        }

        private void SetEditButtonEnable(bool bo)
        {
            this.btnAdd.Enabled = this.btnEdit.Enabled = this.btnDel.Enabled = bo;
        }

        private void LoadEventsToDataGridView()
        {
            dgData.Rows.Clear();
            foreach (var data in _EventsList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = data;
                dgData.Rows[rowIdx].Cells[colSchoolYear.Index].Value = data.SchoolYear;
                dgData.Rows[rowIdx].Cells[colEventCategory.Index].Value = data.Category;
                dgData.Rows[rowIdx].Cells[colEventName.Index].Value = data.Name;
                if (data.EventStartDate.HasValue)
                    dgData.Rows[rowIdx].Cells[colEventStartDate.Index].Value = data.EventStartDate.Value.ToShortDateString();
                if (data.EventEndDate.HasValue)
                    dgData.Rows[rowIdx].Cells[colEventEndDate.Index].Value = data.EventEndDate.Value.ToShortDateString();
                string GameType = "", gaUid = data.RefGameTypeId.ToString();
                if (_GameTypesDict.ContainsKey(gaUid))
                {
                    GameType = _GameTypesDict[gaUid].Name;
                }
                dgData.Rows[rowIdx].Cells[colGameType.Index].Value = GameType;
                if (data.RegStartDate.HasValue)
                    dgData.Rows[rowIdx].Cells[colRegStartDate.Index].Value = data.RegStartDate.Value.ToShortDateString();
                if (data.RegEndDate.HasValue)
                    dgData.Rows[rowIdx].Cells[colRegEndDate.Index].Value = data.RegEndDate.Value.ToShortDateString();
                dgData.Rows[rowIdx].Cells[colMaxMember.Index].Value = data.MaxMemberCount;
                dgData.Rows[rowIdx].Cells[colMinMember.Index].Value = data.MinMemberCount;
                string GroupType = "", grUid = data.RefGroupTypeId.ToString();
                if (_GroupTypesDict.ContainsKey(grUid))
                {
                    GroupType = _GroupTypesDict[grUid].Name;
                }
                dgData.Rows[rowIdx].Cells[colGroupType.Index].Value = GroupType;
                dgData.Rows[rowIdx].Cells[colIsTeam.Index].Value = data.IsTeam ? "是" : "否";
                dgData.Rows[rowIdx].Cells[colIsDrawLots.Index].Value = data.IsDrawLots ? "是" : "否";
                if (data.DrawLotsStartDate.HasValue)
                {
                    dgData.Rows[rowIdx].Cells[colDrawLotsStartDate.Index].Value = data.DrawLotsStartDate.Value.ToShortDateString();
                }

                if (data.DrawLotsEndDate.HasValue)
                {
                    dgData.Rows[rowIdx].Cells[colDrawLotsEndDate.Index].Value = data.DrawLotsEndDate.Value.ToShortDateString();
                }
                dgData.Rows[rowIdx].Cells[colEventDesc.Index].Value = data.EventDescription;
                dgData.Rows[rowIdx].Cells[colAlthleticOnly.Index].Value = data.AthleticOnly ? "是" : "否";
                dgData.Rows[rowIdx].Cells[colCreatedBy.Index].Value = data.CreatedBy;
                if (data.AnnouncementDate.HasValue)
                    dgData.Rows[rowIdx].Cells[colAnnouncementDate.Index].Value = data.AnnouncementDate.Value.ToShortDateString();
            }
        }

        private void LoadEventsList()
        {
            _EventsList = _access.Select<UDT.Events>();

        }

        private void LoadGroupTypesList()
        {
            _GroupTypesList = _access.Select<UDT.GroupTypes>();
            // 建立對照
            _GroupTypesDict.Clear();
            foreach (var data in _GroupTypesList)
            {
                if (!_GroupTypesDict.ContainsKey(data.UID))
                    _GroupTypesDict.Add(data.UID, data);

                if (!_GroupTypesDict.ContainsKey(data.Name))
                    _GroupTypesDict.Add(data.Name, data);
            }
        }

        private void LoadGameTypesList()
        {
            _GameTypesList = _access.Select<UDT.GameTypes>();
            _GameTypesDict.Clear();
            foreach (var data in _GameTypesList)
            {
                if (!_GameTypesDict.ContainsKey(data.UID))
                    _GameTypesDict.Add(data.UID, data);

                if (!_GameTypesDict.ContainsKey(data.Name))
                    _GameTypesDict.Add(data.Name, data);

            }
        }
    }
}
