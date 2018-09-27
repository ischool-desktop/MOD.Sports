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
    public partial class frmHistoricalRecords : BaseForm
    {
        int _SelectSchoolYear = 0;
        int _DefaultSchoolYear = 0;
        List<UDT.Events> _EventsList = new List<UDT.Events>();
        Dictionary<int, UDT.Events> _EventsDict = new Dictionary<int, UDT.Events>();
        Dictionary<int, UDT.GroupTypes> _GroupTypesDict = new Dictionary<int, UDT.GroupTypes>();
        List<UDT.HistoricalRecords> _HistoricalRecordsList = new List<UDT.HistoricalRecords>();
        Dictionary<string, int> _EventItemDict = new Dictionary<string, int>();
        Dictionary<int, List<UDT.Teams>> _teamDict = new Dictionary<int, List<UDT.Teams>>();
        Dictionary<int, List<UDT.Players>> _playerDict = new Dictionary<int, List<UDT.Players>>();
        Dictionary<string, List<UDT.Players>> _teamPlayerDict = new Dictionary<string, List<UDT.Players>>();
        AccessHelper _accessHelper = new AccessHelper();
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        bool _is_bgwLoadDataBusy = false;
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();

        int _selectEventID = 0;
        public frmHistoricalRecords()
        {
            InitializeComponent();
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //            lblRowCount.Text = $"共{_HistoricalRecordsList.Count}筆";

            if (_is_bgwLoadDataBusy)
            {
                _is_bgwLoadDataBusy = false;
                _bgwLoadData.RunWorkerAsync();
                return;
            }

            btnSave.Enabled = iptSchoolYear.Enabled = true;
            LoadEventItemName();
            LoadDataToGridView(false);
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {

            // 取得競賽            
            _EventsList = _accessHelper.Select<UDT.Events>($"school_year = {_SelectSchoolYear}");

            _EventsDict.Clear();
            _EventItemDict.Clear();
            _playerDict.Clear();
            _teamDict.Clear();
            foreach (UDT.Events ev in _EventsList)
            {
                int uid = int.Parse(ev.UID);
                _EventsDict.Add(uid, ev);
                string gpName = "";
                if (_GroupTypesDict.ContainsKey(ev.RefGroupTypeId))
                {
                    gpName = _GroupTypesDict[ev.RefGroupTypeId].Name;
                }
                string key = $"{ev.Category}_{ev.Name}_{gpName}";

                if (!_EventItemDict.ContainsKey(key))
                    _EventItemDict.Add(key, uid);
            }

            if (_EventsDict.Keys.Count > 0)
            {
                // 取得歷史資料 
                _HistoricalRecordsList = _accessHelper.Select<UDT.HistoricalRecords>($"ref_event_id in({string.Join(",", _EventsDict.Keys.ToArray())})");

                List<UDT.Teams> teamsList = _accessHelper.Select<UDT.Teams>($"ref_event_id in({string.Join(",", _EventsDict.Keys.ToArray())})");

                List<string> tempID = new List<string>();
                foreach (UDT.Teams t in teamsList)
                {
                    if (!_teamDict.ContainsKey(t.RefEventId))
                        _teamDict.Add(t.RefEventId, new List<UDT.Teams>());

                    tempID.Add(t.UID);
                    _teamDict[t.RefEventId].Add(t);
                }

                List<UDT.Players> playerList = _accessHelper.Select<UDT.Players>($"ref_team_id is null AND ref_event_id in({string.Join(",", _EventsDict.Keys.ToArray())})");

                foreach (UDT.Players p in playerList)
                {
                    if (!_playerDict.ContainsKey(p.RefEventId))
                        _playerDict.Add(p.RefEventId, new List<UDT.Players>());

                    _playerDict[p.RefEventId].Add(p);
                }

                _teamPlayerDict.Clear();

                List<UDT.Players> playerListT = _accessHelper.Select<UDT.Players>($"ref_team_id in({string.Join(",", tempID.ToArray())})");

                foreach (UDT.Players p in playerListT)
                {
                    string uid = p.RefTeamId.ToString();
                    if (!_teamPlayerDict.ContainsKey(uid))
                        _teamPlayerDict.Add(uid, new List<UDT.Players>());

                    _teamPlayerDict[uid].Add(p);
                }
            }

        }

        private void LoadEventItemName()
        {
            string Temp = cbxEventItem.Text;
            cbxEventItem.Items.Clear();
            // cbxEventItem.Items.Add("全部");
            foreach (string name in _EventItemDict.Keys)
                cbxEventItem.Items.Add(name);

            if (_EventItemDict.ContainsKey(Temp))
                cbxEventItem.Text = Temp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHistoricalRecords_Load(object sender, EventArgs e)
        {
            _SelectSchoolYear = _DefaultSchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
            iptSchoolYear.Value = _DefaultSchoolYear;
            cbxEventItem.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadData();
        }

        private void LoadData()
        {
            iptSchoolYear.Enabled = btnSave.Enabled = false;
            LoadGroupType();

            if (_bgwLoadData.IsBusy)
            {
                _is_bgwLoadDataBusy = true;
            }
            else
            {
                _bgwLoadData.RunWorkerAsync();
            }


        }

        /// <summary>
        /// 取得組別
        /// </summary>
        private void LoadGroupType()
        {
            _GroupTypesDict.Clear();
            List<UDT.GroupTypes> gp = _accessHelper.Select<UDT.GroupTypes>();
            foreach (UDT.GroupTypes gt in gp)
            {
                int uid = int.Parse(gt.UID);
                _GroupTypesDict.Add(uid, gt);
            }
        }


        private void cbxEventItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectEventID = 0;

            if (cbxEventItem.Text == "全部")
            {

            }
            else
            {
                if (_EventItemDict.ContainsKey(cbxEventItem.Text))
                {
                    _selectEventID = _EventItemDict[cbxEventItem.Text];
                    LoadDataToGridView(false);
                }
                if (_selectEventID == 0)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("競賽項目無法比對");
                    return;
                }
            }
        }

        private void LoadDataToGridView(bool isAll)
        {
            int rowCount = 0;
            dgData.Rows.Clear();
            if (isAll)
            {

            }
            else
            {
                if (_EventsDict.ContainsKey(_selectEventID))
                {
                    UDT.Events ev = _EventsDict[_selectEventID];
                    string gpName = "";

                    if (_GroupTypesDict.ContainsKey(ev.RefGroupTypeId))
                        gpName = _GroupTypesDict[ev.RefGroupTypeId].Name;

                    // 列隊
                    if (_teamDict.ContainsKey(_selectEventID) && ev.IsTeam)
                    {

                        foreach (UDT.Teams t in _teamDict[_selectEventID])
                        {
                            int rowIdx = dgData.Rows.Add();

                            UDT.HistoricalRecords hr = null;

                            foreach (UDT.HistoricalRecords rec in _HistoricalRecordsList)
                            {
                                if (rec.RefEventId == _selectEventID && rec.TeamName == t.Name)
                                {
                                    hr = rec;
                                }
                            }

                            if (hr == null)
                            {
                                hr = new UDT.HistoricalRecords();
                                hr.RefEventId = _selectEventID;
                                hr.TeamName = t.Name;

                            }


                            dgData.Rows[rowIdx].Cells[colSchoolYear.Index].Value = ev.SchoolYear;
                            dgData.Rows[rowIdx].Cells[colEventCategory.Index].Value = ev.Category;
                            dgData.Rows[rowIdx].Cells[colEventName.Index].Value = ev.Name;
                            dgData.Rows[rowIdx].Cells[colGroupType.Index].Value = gpName;
                            dgData.Rows[rowIdx].Cells[colIsTeam.Index].Value = ev.IsTeam ? "是" : "否";
                            dgData.Rows[rowIdx].Cells[colTeamName.Index].Value = t.Name;

                            if (hr.Rank.HasValue)
                            {
                                dgData.Rows[rowIdx].Cells[colRank.Index].Value = hr.Rank.Value;
                            }

                            if (_teamPlayerDict.ContainsKey(t.UID))
                            {
                                List<string> name = new List<string>();
                                List<string> jSON = new List<string>();

                                foreach (UDT.Players p in _teamPlayerDict[t.UID])
                                {
                                    name.Add(p.Name);
                                    jSON.Add(parsePlayerToJSonString(p));
                                }
                                dgData.Rows[rowIdx].Cells[colPlayer.Index].Value = string.Join(",", name.ToArray());

                                if (jSON.Count > 0)
                                {
                                    hr.Players = $"[{string.Join(",", jSON.ToArray())}]";
                                }
                            }

                            dgData.Rows[rowIdx].Tag = hr;

                            rowCount++;
                        }
                    }

                    // 列選手
                    if (_playerDict.ContainsKey(_selectEventID) && ev.IsTeam == false)
                    {

                        foreach (UDT.Players p in _playerDict[_selectEventID])
                        {
                            int rowIdx = dgData.Rows.Add();
                            dgData.Rows[rowIdx].Cells[colSchoolYear.Index].Value = ev.SchoolYear;
                            dgData.Rows[rowIdx].Cells[colEventCategory.Index].Value = ev.Category;
                            dgData.Rows[rowIdx].Cells[colEventName.Index].Value = ev.Name;
                            dgData.Rows[rowIdx].Cells[colGroupType.Index].Value = gpName;
                            dgData.Rows[rowIdx].Cells[colIsTeam.Index].Value = ev.IsTeam ? "是" : "否";
                            dgData.Rows[rowIdx].Cells[colTeamName.Index].Value = "";
                            dgData.Rows[rowIdx].Cells[colPlayer.Index].Value = p.Name;


                            UDT.HistoricalRecords hr = null;

                            foreach (UDT.HistoricalRecords rec in _HistoricalRecordsList)
                            {
                                // 比對學生系統編號

                                string key = $"\"ref_student_id\":{p.RefStudentId}";

                                if (rec.RefEventId == _selectEventID && rec.Players.Contains(key))
                                {
                                    hr = rec;
                                }
                            }

                            if (hr == null)
                            {
                                hr = new UDT.HistoricalRecords();
                                hr.RefEventId = _selectEventID;
                                hr.Players = $"[{parsePlayerToJSonString(p)}]";
                            }

                            if (hr.Rank.HasValue)
                            {
                                dgData.Rows[rowIdx].Cells[colRank.Index].Value = hr.Rank.Value;
                            }

                            dgData.Rows[rowIdx].Tag = hr;

                            rowCount++;
                        }
                    }
                }
            }

            SetDataGridViewCellsReadOnlyColor();

            lblRowCount.Text = $"共{rowCount}筆";
        }

        private void SetDataGridViewCellsReadOnlyColor()
        {
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                foreach (DataGridViewCell cel in drv.Cells)
                {
                    if (cel.ColumnIndex == colRank.Index)
                        continue;
                    cel.Style.BackColor = Color.LightGray;
                }
            }
        }


        private string parsePlayerToJSonString(UDT.Players p)
        {
            char cc = '"';
            string c1 = "'";
            string value = "{'ref_student_id':" + p.RefStudentId + ",'name':'" + p.Name + "','class_name':'" + p.ClassName + "','seat_no':" + p.SeatNo + ",'is_team_leader':" + p.IsTeamLeader.ToString().ToLower() + "}";
            value = value.Replace(Char.Parse(c1), cc);
            return value;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                List<UDT.HistoricalRecords> ssData = new List<UDT.HistoricalRecords>();
                foreach (DataGridViewRow drv in dgData.Rows)
                {
                    UDT.HistoricalRecords hr = drv.Tag as UDT.HistoricalRecords;

                    if (hr != null)
                    {
                        hr.Rank = null;
                        if (drv.Cells[colRank.Index].Value != null)
                        {
                            int rank;

                            int.TryParse(drv.Cells[colRank.Index].Value.ToString(), out rank);
                            hr.Rank = rank;
                            hr.CreatedBy = _userAccount;
                        }
                        ssData.Add(hr);
                    }
                }
                if (ssData.Count > 0)
                {
                    ssData.SaveAll();
                }
                FISCA.Presentation.Controls.MsgBox.Show("儲存完成");
                LoadData();
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗," + ex.Message);
                btnSave.Enabled = true;
                return;
            }
            finally
            {

            }

        }

        private void iptSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            if (!iptSchoolYear.IsEmpty)
                _SelectSchoolYear = iptSchoolYear.Value;
            
            LoadData();
        }
    }
}
