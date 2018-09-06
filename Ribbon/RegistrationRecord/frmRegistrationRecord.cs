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
        DataTable _dtClassData = new DataTable();
        DataTable _dtEventData = new DataTable();

        Dictionary<string, string> _classNameIdDict = new Dictionary<string, string>();
        Dictionary<string, string> _eventItemDict = new Dictionary<string, string>();

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
            SetControlEnabled(true);
            LoadDataToGridView();
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
            LoadDataToGridView();
        }

        private void _bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
            LoadEventData();
            LoadClassData();
        }

        private void SetControlEnabled(bool bo)
        {
            iptSchoolYear.Enabled = btnAddPlayer.Enabled = btnAddTeam.Enabled = btnEditPlayer.Enabled = btnEditTeam.Enabled = btnDelPlayer.Enabled = btnDelTeam.Enabled = btnSearch.Enabled = bo;
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
            foreach (DataRow dr in _teamList)
            {
                int rowIdx = dgTeamData.Rows.Add();
                // team uid 
                dgTeamData.Rows[rowIdx].Tag = dr["t_uid"].ToString();
                dgTeamData.Rows[rowIdx].Cells[colCategory.Index].Value = dr["category"].ToString();
                dgTeamData.Rows[rowIdx].Cells[colEventItem.Index].Value = dr["event_name"].ToString();
                dgTeamData.Rows[rowIdx].Cells[colGroupType.Index].Value = dr["group_types_name"].ToString();
                dgTeamData.Rows[rowIdx].Cells[colTeamName.Index].Value = dr["team_name"].ToString();
            }

            SetLblTeamCount(_teamList.Count);

            if (dgTeamData.SelectedRows.Count == 1)
            {
                string t_uid = dgTeamData.SelectedRows[0].Tag.ToString();
                LoadDGPlayerDataGridView(t_uid);
            }
        }

        private void LoadEventData()
        {
            string qryStr = "SELECT $ischool.sports.events.uid,category,$ischool.sports.events.name AS event_name,$ischool.sports.events.is_team AS event_is_team ,$ischool.sports.group_types.name AS group_types_name FROM $ischool.sports.events INNER JOIN $ischool.sports.group_types ON $ischool.sports.events.ref_group_type_id = $ischool.sports.group_types.uid WHERE $ischool.sports.events.school_year = " + _selectSchoolYear + " ORDER BY category,event_name";
            QueryHelper qh = new QueryHelper();
            _dtEventData = qh.Select(qryStr);
            _eventItemDict.Clear();
            foreach (DataRow dr in _dtEventData.Rows)
            {
                string key = dr["event_name"].ToString() + "-" + dr["group_types_name"].ToString();
                if (!_eventItemDict.ContainsKey(key))
                {
                    _eventItemDict.Add(key, dr["uid"].ToString());
                }
            }
        }

        private void LoadEventDataToCombo()
        {
            cbxEventItem.Items.Clear();
            cbxEventItem.Items.Add("全部");
            foreach (string key in _eventItemDict.Keys)
            {
                cbxEventItem.Items.Add(key);
            }
        }

        private void LoadData()
        {
            try
            {
                // 取得資料
                string strSQL = "select $ischool.sports.teams.uid as t_uid,$ischool.sports.players.uid as p_uid,category,$ischool.sports.events.name as event_name,$ischool.sports.events.is_team as event_is_team ,$ischool.sports.group_types.name as group_types_name ,$ischool.sports.teams.name as team_name,$ischool.sports.players.name as student_name,class_name,seat_no,$ischool.sports.players.created_by,$ischool.sports.players.last_update as player_last_update from $ischool.sports.events inner join $ischool.sports.teams on $ischool.sports.events.uid = $ischool.sports.teams.ref_event_id inner join $ischool.sports.players on $ischool.sports.teams.uid = $ischool.sports.players.ref_team_id inner join  $ischool.sports.group_types on $ischool.sports.events.ref_group_type_id= $ischool.sports.group_types.uid where $ischool.sports.events.school_year = " + _selectSchoolYear + _querySB.ToString() + " order by category,event_name,team_name,class_name,seat_no";
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

            iptSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            Run();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    // 當輸入 enter
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        this.searchText = txtSearch.Text;
        //        this._querySB.Clear();
        //        this._queryItems.Clear();

        //        // 使用 OR 的方式進行搜尋
        //        if (txtSearch.Text.Length > 0)
        //        {
        //            // 依班級
        //            if (chkByClassName.Checked)
        //            {
        //                _queryItems.Add(" class_name like '%" + searchText + "%' ");
        //            }

        //            // 依競賽項目
        //            if (chkByEventName.Checked)
        //            {
        //                _queryItems.Add(" $ischool.sports.events.name like '%" + searchText + "%' ");
        //            }

        //            //  學生姓名
        //            if(chkByName.Checked)
        //            {
        //                _queryItems.Add(" $ischool.sports.players.name like '%" + searchText + "%' ");
        //            }

        //            if (_queryItems.Count > 0)
        //            {
        //                _querySB.Append(" AND (");
        //                if (_queryItems.Count == 1)
        //                {
        //                    _querySB.Append(_queryItems[0]);
        //                }
        //                else
        //                {
        //                    _querySB.Append(string.Join(" OR ", _queryItems.ToArray()));
        //                }
        //                _querySB.Append(") ");
        //            }

        //        }
        //        Run();
        //    }
        //}



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
                    FISCA.Presentation.Controls.MsgBox.Show("刪除完成");
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
                btnSearch.Enabled = true;
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
                string t_uid = dgTeamData.SelectedRows[0].Tag.ToString();
                LoadDGPlayerDataGridView(t_uid);
            }
        }

        private void LoadDGPlayerDataGridView(string uid)
        {
            dgPlayerData.Rows.Clear();
            if (_playerDict.ContainsKey(uid))
            {
                foreach (DataRow dr in _playerDict[uid])
                {
                    int rowIdx = dgPlayerData.Rows.Add();
                    dgPlayerData.Rows[rowIdx].Tag = dr["p_uid"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colRegDate.Index].Value = dr["player_last_update"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colRegAccount.Index].Value = dr["created_by"].ToString();
                }

                // 統計數
                SetLblPlayerCount(_playerDict[uid].Count);
            }
        }

        private void dgPlayerData_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSubAddRegistrationRecord fsar = new frmSubAddRegistrationRecord();
            fsar.setSchoolYear(iptSchoolYear.Value.ToString());

            if (fsar.ShowDialog() == DialogResult.Yes)
            {
                Run();
            }
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
                        Run();
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

            if (cbxClassName.Text != "全部")
            {
                _querySB.Append(" AND $ischool.sports.players.class_name = '" + cbxClassName.Text+"'");
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
                        Run();
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
    }
}
