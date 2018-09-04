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
        QueryHelper qh = new QueryHelper();
        DataTable _dtData = new DataTable();

        private string searchText = "";
        private StringBuilder _querySB = new StringBuilder();
        private List<string> _queryItems = new List<string>();
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
        }

        private void _bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            iptSchoolYear.Enabled = btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = btnExit.Enabled = true;
            LoadDataToGridView();
        }

        private void _bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void Run()
        {
            iptSchoolYear.Enabled = btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = btnExit.Enabled = false;
            // 取得畫面上學年度學期
            _selectSchoolYear = iptSchoolYear.Value.ToString();
            _bgwLoad.RunWorkerAsync();
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
            if (dgTeamData.SelectedRows.Count == 1)
            {
                string t_uid = dgTeamData.SelectedRows[0].Tag.ToString();
                LoadDGPlayerDataGridView(t_uid);
            }
            // 統計數
            lblTeamCount.Text = "共 " + _teamList.Count + " 筆";
            lblPlayerCount.Text = "";
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
                foreach(DataRow dr in _dtData.Rows)
                {
                    // 以隊來分
                    string t_uid = dr["t_uid"].ToString();
                    
                    if(!_playerDict.ContainsKey(t_uid))
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



        private void frmRegistrationRecord_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            chkByClassName.Checked = chkByEventName.Checked = chkByName.Checked = true; ;
            iptSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            Run();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            // 當輸入 enter
            if (e.KeyCode == Keys.Enter)
            {
                this.searchText = txtSearch.Text;
                this._querySB.Clear();
                this._queryItems.Clear();

                // 使用 OR 的方式進行搜尋
                if (txtSearch.Text.Length > 0)
                {
                    // 依班級
                    if (chkByClassName.Checked)
                    {
                        _queryItems.Add(" class_name like '%" + searchText + "%' ");
                    }

                    // 依競賽項目
                    if (chkByEventName.Checked)
                    {
                        _queryItems.Add(" $ischool.sports.events.name like '%" + searchText + "%' ");
                    }

                    //  學生姓名
                    if(chkByName.Checked)
                    {
                        _queryItems.Add(" $ischool.sports.players.name like '%" + searchText + "%' ");
                    }

                    if (_queryItems.Count > 0)
                    {
                        _querySB.Append(" AND (");
                        if (_queryItems.Count == 1)
                        {
                            _querySB.Append(_queryItems[0]);
                        }
                        else
                        {
                            _querySB.Append(string.Join(" OR ", _queryItems.ToArray()));
                        }
                        _querySB.Append(") ");
                    }

                }
                Run();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            btnDel.Enabled = false;
            // 取得資料
            if (dgTeamData.SelectedRows.Count == 1)
            {
                if (dgTeamData.SelectedRows[0].Tag != null)
                {
                    if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除報名參賽選手資料，請問是否刪除？", "刪除報名資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string puid = dgTeamData.SelectedRows[0].Tag.ToString();
                        DeletePlayerRec(puid);
                        Run();
                    }
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("刪除發生錯誤:沒有uid");
                }
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            btnDel.Enabled = true;
        }

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
                    FISCA.Presentation.Controls.MsgBox.Show("刪除過程發生錯誤:" + ex.Message);
                }
            }
        }

        private void iptSchoolYear_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void dgTeamData_MouseClick(object sender, MouseEventArgs e)
        {
            if(dgTeamData.SelectedRows.Count == 1)
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
                    dgPlayerData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colRegDate.Index].Value = dr["player_last_update"].ToString();
                    dgPlayerData.Rows[rowIdx].Cells[colRegAccount.Index].Value = dr["created_by"].ToString();
                }

                // 統計數
                lblPlayerCount.Text = "共 " + _playerDict[uid].Count + " 筆";
            }
        }
    }
}
