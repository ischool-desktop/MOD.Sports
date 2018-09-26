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

    public partial class frmRegistrationRecord : BaseForm
    {
        private string _selectSchoolYear = "";
        BackgroundWorker _bgwLoad = new BackgroundWorker();
        BackgroundWorker _bgSearch = new BackgroundWorker();
        QueryHelper qh = new QueryHelper();
        DataTable _dtData = new DataTable();
        DataTable _dtData1 = new DataTable();
        DataTable _dtClassData = new DataTable();
        DataTable _dtEventData = new DataTable();
        string _PersionalTeam = "==個人賽^^";

        // 畫面上畫面上所選競賽項目
        UDT.Events _selectedEvent = null;

        // 畫面上所選 team_id
        string _selectedTeamUID = "";

        Dictionary<string, string> _classNameIdDict = new Dictionary<string, string>();
        Dictionary<string, string> _eventItemDict = new Dictionary<string, string>();
        Dictionary<string, UDT.Events> _eventItemEventDict = new Dictionary<string, UDT.Events>();
        Dictionary<string, UDT.Events> _eventDict = new Dictionary<string, UDT.Events>();
        Dictionary<string, UDT.GroupTypes> _groupDict = new Dictionary<string, UDT.GroupTypes>();


        //private string searchText = "";
        private StringBuilder _querySB = new StringBuilder();
        //private List<string> _queryItems = new List<string>();
        // 隊
        List<DataRow> _teamList = new List<DataRow>();
        // 隊員
        Dictionary<string, List<DataRow>> _playerDict = new Dictionary<string, List<DataRow>>();

        public frmRegistrationRecord()
        {
            InitializeComponent();
            _bgwLoad.WorkerReportsProgress = true;
            _bgwLoad.DoWork += _bgwLoad_DoWork;
            _bgwLoad.RunWorkerCompleted += _bgwLoad_RunWorkerCompleted;
            _bgSearch.WorkerReportsProgress = true;
            _bgSearch.DoWork += _bgSearch_DoWork;
            _bgSearch.RunWorkerCompleted += _bgSearch_RunWorkerCompleted;
        }

        private void _bgSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_bgSearch.IsBusy)
            {
                FISCA.Presentation.Controls.MsgBox.Show("Busy");
                
            }

            SetControlEnabled(true);
            LoadDataToGridView();

            // 檢查已選 team，再選到 team
            if (!string.IsNullOrWhiteSpace(_selectedTeamUID))
            {
                // 選到該隊
                foreach(DataGridViewRow drv in dgTeamData.Rows)
                {
                    string tuid = drv.Tag.ToString();
                    if (tuid == _selectedTeamUID)
                    {
                        drv.Selected = true;
                    }
                }

                LoadDGPlayerDataGridView(_selectedTeamUID);
            }
            // 檢查個人賽
            if (_playerDict.ContainsKey(_PersionalTeam))
            {
                LoadDGPlayerDataGridView(_PersionalTeam);
            }
        }

        private void _bgSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void _bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlEnabled(true);
            LoadEventDataToCombo();
            LoadClassDataToCombo();            

        }

        private void _bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {

            LoadEventData();
            LoadClassData();
        }

        private void SetControlEnabled(bool bo)
        {
            iptSchoolYear.Enabled = btnAddPlayer.Enabled = btnAddTeam.Enabled = btnEditPlayer.Enabled = btnEditTeam.Enabled = btnDelPlayer.Enabled = btnDelTeam.Enabled = bo;
        }

        private void Run()
        {
            // 取得畫面上學年度學期
            _selectSchoolYear = iptSchoolYear.Value.ToString();
            SetControlEnabled(false);
            _bgwLoad.RunWorkerAsync();
        }

        private void SetLblTeamCount(int x)
        {
            lblTeamCount.Text = "隊伍 (" + x + "隊)";
        }

        private void SetLblPlayerCount(int x)
        {
            lblPlayerCount.Text = "參賽人員 (" + x + "人)";
        }

        private void LoadDataToGridView()
        {
            dgTeamData.Rows.Clear();
            dgPlayerData.Rows.Clear();

            if (_selectedEvent != null && _selectedEvent.IsTeam)
            {
                foreach (DataRow dr in _teamList)
                {
                    int rowIdx = dgTeamData.Rows.Add();
                    // team uid 
                    dgTeamData.Rows[rowIdx].Tag = dr["t_uid"].ToString();
                    dgTeamData.Rows[rowIdx].Cells[colCategory.Index].Value = dr["category"].ToString();
                    dgTeamData.Rows[rowIdx].Cells[colEventItem.Index].Value = dr["event_name"].ToString();
                    dgTeamData.Rows[rowIdx].Cells[colGroupType.Index].Value = dr["group_types_name"].ToString();
                    dgTeamData.Rows[rowIdx].Cells[colTeamName.Index].Value = dr["team_name"].ToString();
                    dgTeamData.Rows[rowIdx].Cells[colTeamLotNo.Index].Value = dr["t_lot_no"].ToString();
                }

                SetLblTeamCount(_teamList.Count);

                if (dgTeamData.SelectedRows.Count == 1)
                {
                    string t_uid = dgTeamData.SelectedRows[0].Tag.ToString();
                    LoadDGPlayerDataGridView(t_uid);
                }
            }           
        }

        private void LoadEventData()
        {
            AccessHelper ah = new AccessHelper();
            List<UDT.Events> evList = ah.Select<UDT.Events>(" school_year = " + _selectSchoolYear);
            _eventDict.Clear();
            List<int> grIDList = new List<int>();
            foreach (UDT.Events data in evList)
            {

                if (!_eventDict.ContainsKey(data.UID))
                    _eventDict.Add(data.UID, data);

                if (!grIDList.Contains(data.RefGroupTypeId))
                    grIDList.Add(data.RefGroupTypeId);
            }


            string qryStr = "SELECT $ischool.sports.events.uid,category,$ischool.sports.events.name AS event_name,$ischool.sports.events.is_team AS event_is_team ,$ischool.sports.group_types.name AS group_types_name FROM $ischool.sports.events INNER JOIN $ischool.sports.group_types ON $ischool.sports.events.ref_group_type_id = $ischool.sports.group_types.uid WHERE $ischool.sports.events.school_year = " + _selectSchoolYear + " ORDER BY category,event_name";
            QueryHelper qh = new QueryHelper();
            _dtEventData = qh.Select(qryStr);
            _eventItemDict.Clear();
            _eventItemEventDict.Clear();
            foreach (DataRow dr in _dtEventData.Rows)
            {
                string gp_name = dr["event_name"].ToString();
                string uid = dr["uid"].ToString();
                string key = gp_name + "-" + dr["group_types_name"].ToString();
                if (!_eventItemDict.ContainsKey(key))
                {
                    _eventItemDict.Add(key, uid);

                    if (_eventDict.ContainsKey(uid))
                    {
                        _eventItemEventDict.Add(key, _eventDict[uid]);
                    }
                }
            }

            _groupDict.Clear();
            if (grIDList.Count > 0)
            {
                List<UDT.GroupTypes> gpList = ah.Select<UDT.GroupTypes>(" uid in (" + string.Join(",", grIDList.ToArray()) + ")");
                foreach (UDT.GroupTypes d in gpList)
                {
                    if (!_groupDict.ContainsKey(d.UID))
                        _groupDict.Add(d.UID, d);
                }
            }
        }

        private void LoadEventDataToCombo()
        {
            cbxEventItem.Items.Clear();
           // cbxEventItem.Items.Add("全部");
            foreach (string key in _eventItemDict.Keys)
            {
                cbxEventItem.Items.Add(key);
            }
        }

        private void LoadData()
        {
            try
            {
                // 取得資料 (團體)
                string strSQL = "SELECT $ischool.sports.teams.uid AS t_uid,$ischool.sports.players.uid AS p_uid,category,$ischool.sports.events.name AS event_name,$ischool.sports.events.is_team AS event_is_team ,$ischool.sports.group_types.name AS group_types_name ,$ischool.sports.teams.name AS team_name,$ischool.sports.players.name AS student_name,class_name,seat_no,$ischool.sports.players.created_by,$ischool.sports.players.last_update AS player_last_update,$ischool.sports.teams.lot_no AS t_lot_no,$ischool.sports.players.lot_no AS p_lot_no,is_team_leader FROM $ischool.sports.events INNER JOIN $ischool.sports.teams ON $ischool.sports.events.uid = $ischool.sports.teams.ref_event_id LEFT JOIN $ischool.sports.players ON $ischool.sports.teams.uid = $ischool.sports.players.ref_team_id INNER JOIN  $ischool.sports.group_types ON $ischool.sports.events.ref_group_type_id= $ischool.sports.group_types.uid WHERE $ischool.sports.events.school_year = " + _selectSchoolYear + _querySB.ToString() + " ORDER BY category,event_name,team_name,class_name,seat_no";
                _dtData = qh.Select(strSQL);

                _teamList.Clear();
                _playerDict.Clear();
                // 解析隊、隊員
                foreach (DataRow dr in _dtData.Rows)
                {
                    // 以隊來分
                    string t_uid = dr["t_uid"].ToString();

                    if (!_playerDict.ContainsKey(t_uid))
                    {
                        _teamList.Add(dr);
                        _playerDict.Add(t_uid, new List<DataRow>());
                    }

                    _playerDict[t_uid].Add(dr);
                }

                // 個人賽
                string strSQL1 = "SELECT $ischool.sports.players.uid AS p_uid,category,$ischool.sports.events.name AS event_name,$ischool.sports.events.is_team AS event_is_team ,$ischool.sports.group_types.name AS group_types_name,$ischool.sports.players.name AS student_name,class_name,seat_no,$ischool.sports.players.created_by,$ischool.sports.players.last_update AS player_last_update,$ischool.sports.players.lot_no AS p_lot_no,is_team_leader FROM $ischool.sports.events INNER JOIN $ischool.sports.players ON $ischool.sports.events.uid = $ischool.sports.players.ref_event_id INNER JOIN $ischool.sports.group_types ON $ischool.sports.events.ref_group_type_id= $ischool.sports.group_types.uid WHERE $ischool.sports.players.ref_team_id IS NULL AND $ischool.sports.events.school_year =" + _selectSchoolYear + _querySB.ToString() + " ORDER BY category,event_name,class_name,seat_no";
                _dtData1 = qh.Select(strSQL1);

                if (_dtData1.Rows.Count > 0)
                {
                    _playerDict.Add(_PersionalTeam, new List<DataRow>());
                    foreach (DataRow dr in _dtData1.Rows)
                    {
                        _playerDict[_PersionalTeam].Add(dr);
                    }
                }
            }
            catch (Exception err)
            {
                FISCA.Presentation.Controls.MsgBox.Show(err.Message);
            }

        }

        private void LoadClassData()
        {
            try
            {
                string qryStr = "SELECT class.id AS class_id,class_name,class.grade_year FROM class INNER JOIN student ON class.id = student.ref_class_id WHERE student.status IN(1,2) AND class.grade_year IN(1,2,3) GROUP BY class_id,class_name,class.grade_year ORDER BY class.grade_year,class.display_order,class.class_name";
                QueryHelper qh = new QueryHelper();
                _dtClassData = qh.Select(qryStr);

                _classNameIdDict.Clear();

                foreach (DataRow dr in _dtClassData.Rows)
                {
                    string className = dr["class_name"].ToString();
                    if (!_classNameIdDict.ContainsKey(className))
                    {
                        _classNameIdDict.Add(className, dr["class_id"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void LoadClassDataToCombo()
        {
            cbxClassName.Items.Clear();
            cbxClassName.Items.Add("全部");
            foreach (string key in _classNameIdDict.Keys)
            {
                cbxClassName.Items.Add(key);
            }
        }

        private void frmRegistrationRecord_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            lblTeamType.Text = "";

            iptSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            Run();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 設定隊功能是否可以使用
        /// </summary>
        /// <param name="bo"></param>
        private void SetTeamFuncEnable(bool bo)
        {
            dgTeamData.Enabled = btnAddTeam.Enabled = btnEditTeam.Enabled = btnDelTeam.Enabled = bo;
        }

        /// <summary>
        /// 刪除隊員
        /// </summary>
        /// <param name="uid"></param>
        private void DeletePlayerRec(string uid)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                try
                {
                    string strSQL = "delete from $ischool.sports.players where uid = " + uid;
                    UpdateHelper uh = new UpdateHelper();
                    int n = uh.Execute(strSQL);
                    
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("刪除隊員過程發生錯誤:" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 刪除隊
        /// </summary>
        /// <param name="uid"></param>
        private void DeleteTeamRec(string uid)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                try
                {
                    string strSQLDelPlayer = "delete from $ischool.sports.players where ref_team_id = " + uid;
                    string strSQLDelTeam = "delete from $ischool.sports.teams where uid = " + uid;
                    UpdateHelper uh = new UpdateHelper();
                    int n1 = uh.Execute(strSQLDelPlayer);
                    int n2 = uh.Execute(strSQLDelTeam);
                    FISCA.Presentation.Controls.MsgBox.Show("刪除完成");
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("刪除隊過程發生錯誤:" + ex.Message);
                }
            }
        }

        private void iptSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            _selectSchoolYear = iptSchoolYear.Value.ToString();
            int defSchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
            if (iptSchoolYear.Value != defSchoolYear)
            {
                SetControlEnabled(false);
                iptSchoolYear.Enabled = true;

            }
            else
            {
                SetControlEnabled(true);
            }
        }

        private void dgTeamData_MouseClick(object sender, MouseEventArgs e)
        {

            if (dgTeamData.SelectedRows.Count == 1)
            {
                _selectedTeamUID = dgTeamData.SelectedRows[0].Tag.ToString();
                LoadDGPlayerDataGridView(_selectedTeamUID);
            }
        }

        private void LoadDGPlayerDataGridView(string uid)
        {
            dgPlayerData.Rows.Clear();
            // 統計數
            SetLblPlayerCount(0);
            if (_playerDict.ContainsKey(uid))
            {
                int count = 0;
                int cotTeamLeader = 0;
                foreach (DataRow dr in _playerDict[uid])
                {
                    string puid = dr["p_uid"].ToString();
                    if (!string.IsNullOrEmpty(puid))
                    {
                        count++;
                        int rowIdx = dgPlayerData.Rows.Add();
                        dgPlayerData.Rows[rowIdx].Tag = puid;
                        dgPlayerData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                        dgPlayerData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                        dgPlayerData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                        string strLeader = "否";
                        if (dr["is_team_leader"].ToString() == "true" || dr["is_team_leader"].ToString() == "t")
                        {

                            strLeader = "是";
                            cotTeamLeader++;
                        }
                        dgPlayerData.Rows[rowIdx].Cells[colLeader.Index].Value = strLeader;
                        dgPlayerData.Rows[rowIdx].Cells[colPlayerLotNo.Index].Value = dr["p_lot_no"].ToString();
                        dgPlayerData.Rows[rowIdx].Cells[colRegDate.Index].Value = dr["player_last_update"].ToString();
                        dgPlayerData.Rows[rowIdx].Cells[colRegAccount.Index].Value = dr["created_by"].ToString();

                    }
                }
                if (count > 0 && cotTeamLeader == 0)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("請設定隊長。");
                }

                // 統計數
                SetLblPlayerCount(count);
            }
        }

        private void dgPlayerData_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnDelTeam_Click(object sender, EventArgs e)
        {
            btnDelTeam.Enabled = false;
            if (dgTeamData.SelectedRows.Count == 1)
            {
                if (dgTeamData.SelectedRows[0].Tag != null)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除報名隊與參賽選手資料，請問是否刪除？", "刪除報名隊資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string puid = dgTeamData.SelectedRows[0].Tag.ToString();
                        DeleteTeamRec(puid);
                        _bgSearch.RunWorkerAsync();
                    }
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("刪除發生錯誤:沒有隊uid");
                }
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            btnDelTeam.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


        }

        private void LoadSearch()
        {
            _querySB.Clear();
            SetControlEnabled(false);
            if (cbxEventItem.Text != "全部")
            {
                // 比對資料
                if (_eventItemDict.ContainsKey(cbxEventItem.Text))
                {
                    string uid = _eventItemDict[cbxEventItem.Text];
                    _querySB.Append(" AND $ischool.sports.events.uid = " + uid);
                }
            }

            if (cbxClassName.Text != "全部" && cbxClassName.Text != "")
            {
                _querySB.Append(" AND $ischool.sports.players.class_name = '" + cbxClassName.Text + "'");
            }

            _bgSearch.RunWorkerAsync();
        }

        private void btnDelPlayer_Click(object sender, EventArgs e)
        {
            btnDelPlayer.Enabled = false;
            // 刪隊員
            if (dgPlayerData.SelectedRows.Count == 1)
            {
                if (dgPlayerData.SelectedRows[0].Tag != null)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除參賽選手資料，請問是否刪除？", "刪除報名隊員資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string puid = dgPlayerData.SelectedRows[0].Tag.ToString();
                        DeletePlayerRec(puid);
                        _bgSearch.RunWorkerAsync();
                    }
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("刪除發生錯誤:沒有隊員uid");
                }
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            btnDelPlayer.Enabled = true;
        }

        private void cbxEventItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTeamType.Text = "";
            // 檢查所選的是團體或個人賽
            _selectedEvent = null;
            SetLblPlayerCount(0);
            SetLblTeamCount(0);

            if (_eventItemEventDict.ContainsKey(cbxEventItem.Text))
            {
                _selectedEvent = _eventItemEventDict[cbxEventItem.Text];
            }

            bool isTeamEnable = true;
            if (_selectedEvent != null)
            {
                _selectedTeamUID = "";
                if (_selectedEvent.IsTeam)
                {
                    lblTeamType.Text = "團體賽";
                }
                else
                {
                    
                    lblTeamType.Text = "個人賽";
                    isTeamEnable = false;
                }
            }
            
            SetTeamFuncEnable(isTeamEnable);

            LoadSearch();
        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            string refEventID = "";
            // 檢查競賽項目
            if (_eventItemDict.ContainsKey(cbxEventItem.Text))
            {
                refEventID = _eventItemDict[cbxEventItem.Text];
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目");
                return;
            }

            frmRegRecordSetTeam frrs = new frmRegRecordSetTeam();
            frrs.SetIsAddMode(true);
            frrs.SetRefEventID(refEventID);
            frrs.SetEventItemName(cbxEventItem.Text);
            if (frrs.ShowDialog() == DialogResult.Yes)
            {
                _bgSearch.RunWorkerAsync();
            }
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            if (dgTeamData.SelectedRows.Count == 1)
            {
                string uid = dgTeamData.SelectedRows[0].Tag.ToString();
                AccessHelper ah = new AccessHelper();
                List<UDT.Teams> data = ah.Select<UDT.Teams>(" uid = " + uid);
                if (data.Count > 0)
                {
                    UDT.Teams updateTeam = data[0];
                    frmRegRecordSetTeam frrs = new frmRegRecordSetTeam();
                    frrs.SetIsAddMode(false);
                    frrs.SetUpdateTeam(updateTeam);
                    frrs.SetEventItemName(cbxEventItem.Text);
                    if (frrs.ShowDialog() == DialogResult.Yes)
                    {
                        _bgSearch.RunWorkerAsync();
                    }
                }
            }


        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            if (dgPlayerData.SelectedRows.Count == 1)
            {

                string uid = dgPlayerData.SelectedRows[0].Tag.ToString();
                frmRegRecordUpdatePlayer frup = new frmRegRecordUpdatePlayer();
                frup.SetPlayerUID(uid);
                if (_selectedEvent != null)
                    frup.SetIsTeam(_selectedEvent.IsTeam);
                if (frup.ShowDialog() == DialogResult.Yes)
                {
                    _bgSearch.RunWorkerAsync();
                }
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選1位參賽人員。");
            }
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            string refEventID = "";


            // 檢查競賽項目
            if (_eventItemDict.ContainsKey(cbxEventItem.Text))
            {
                refEventID = _eventItemDict[cbxEventItem.Text];
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目");
                return;
            }
            UDT.Events curEvent = null;
            // 取得競賽 udt
            if (_eventDict.ContainsKey(refEventID))
            {
                curEvent = _eventDict[refEventID];
            }

            int maxCount = 0;

            if (curEvent != null)
            {
                maxCount = curEvent.MaxMemberCount;
            }
            UDT.GroupTypes curGp = null;
            // 取得 group
            if (_groupDict.ContainsKey(curEvent.RefGroupTypeId.ToString()))
            {
                curGp = _groupDict[curEvent.RefGroupTypeId.ToString()];
            }

            // 檢查隊員是否超過最大人數，如果超過無法新增。

            if (dgPlayerData.Rows.Count == curEvent.MaxMemberCount)
            {
                FISCA.Presentation.Controls.MsgBox.Show("參賽人數已達最多人數" + curEvent.MaxMemberCount + "人，無法新增。");
                return;
            }

            frmRegRecordAddPlayer frrap = new frmRegRecordAddPlayer();
            if (curGp != null)
            {
                if (curGp.Grade.HasValue)
                {
                    frrap.SetGradeYearFilter(curGp.Grade.Value.ToString());
                }

                if (curGp.Gender == "M" || curGp.Gender == "F")
                {
                    frrap.SetGenderFilter(curGp.Gender);
                }
            }

            // 判斷如果是個人賽傳入 null，團體賽取得 ID 傳入
            if (_selectedEvent != null && _selectedEvent.IsTeam)
            {
                // 團體，取得畫面上所選隊伍 ID
                if (dgTeamData.SelectedRows.Count == 1)
                {
                    int tid = int.Parse(dgTeamData.SelectedRows[0].Tag.ToString());
                    frrap.SetTeamID(tid);
                    frrap.SetTeamName(dgTeamData.SelectedRows[0].Cells[colTeamName.Index].Value.ToString());
                }else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("請選擇隊伍");
                    return;
                }                
            }
            else
            {
                // 個人
                frrap.SetTeamID(null);
            }

            frrap.SetEventID(int.Parse(refEventID));

            // 設定最多人數
            maxCount = maxCount - dgPlayerData.Rows.Count;
            frrap.SetMaxCount(maxCount);

            if (frrap.ShowDialog() == DialogResult.Yes)
            {
                _bgSearch.RunWorkerAsync();
            }
        }

        private void cbxClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSearch();
        }
    }
}
