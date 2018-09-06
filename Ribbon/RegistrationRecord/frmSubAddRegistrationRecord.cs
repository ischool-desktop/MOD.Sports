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
    public partial class frmSubAddRegistrationRecord : BaseForm
    {
        AccessHelper _accHelper = new AccessHelper();
        BackgroundWorker _bgwLoadEventData = new BackgroundWorker();
        BackgroundWorker _bgwLoadSearchStudent = new BackgroundWorker();
        List<string> _checkAddSid = new List<string>();
        string _currentSchoolYear = "";
        string _searchText = "";
        DataTable _dtStudent = new DataTable();
        UDT.Events _selectedEvent = null;
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        Dictionary<string, List<UDT.Events>> _eventDict = new Dictionary<string, List<UDT.Events>>();
        public frmSubAddRegistrationRecord()
        {
            InitializeComponent();
            _bgwLoadEventData.WorkerReportsProgress = true;
            _bgwLoadEventData.DoWork += _bgwLoadEventData_DoWork;
            _bgwLoadEventData.RunWorkerCompleted += _bgwLoadEventData_RunWorkerCompleted;
            _bgwLoadSearchStudent.WorkerReportsProgress = true;
            _bgwLoadSearchStudent.DoWork += _bgwLoadSearchStudent_DoWork;
            _bgwLoadSearchStudent.RunWorkerCompleted += _bgwLoadSearchStudent_RunWorkerCompleted;
        }

        /// <summary>
        /// 設定學年度
        /// </summary>
        /// <param name="sc"></param>
        public void setSchoolYear(string sc)
        {
            this._currentSchoolYear = sc;
        }

        private void _bgwLoadSearchStudent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgSearch.Rows.Clear();
            foreach (DataRow dr in _dtStudent.Rows)
            {
                int rowIdx = dgSearch.Rows.Add();
                dgSearch.Rows[rowIdx].Tag = dr["sid"].ToString();
                dgSearch.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                dgSearch.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                dgSearch.Rows[rowIdx].Cells[colName.Index].Value = dr["name"].ToString();
                dgSearch.Rows[rowIdx].Cells[colAccount.Index].Value = dr["sa_login_name"].ToString();
            }
        }

        private void _bgwLoadSearchStudent_DoWork(object sender, DoWorkEventArgs e)
        {
            QueryHelper qh = new QueryHelper();
            string strSQL = "SELECT student.id as sid,class.class_name,student.seat_no,student.name,sa_login_name FROM student LEFT JOIN class ON student.ref_class_id = class.id WHERE student.status in(1,2) AND (class.class_name like '%" + _searchText + "%' OR student.name like '%" + _searchText + "%') ORDER By class.class_name,seat_no";
            _dtStudent = qh.Select(strSQL);

        }

        private void _bgwLoadEventData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cbxEventCategory.Enabled = true;
            cbxEventName.Enabled = true;
            foreach (string key in _eventDict.Keys)
            {
                cbxEventCategory.Items.Add(key);
            }

        }

        private void _bgwLoadEventData_DoWork(object sender, DoWorkEventArgs e)
        {
            _eventDict.Clear();
            // 取得競賽項目
            List<UDT.Events> events = _accHelper.Select<UDT.Events>(" school_year = " + _currentSchoolYear);
            foreach (var data in events)
            {
                string key = data.Category;
                if (!_eventDict.ContainsKey(key))
                    _eventDict.Add(key, new List<UDT.Events>());

                _eventDict[key].Add(data);
            }
        }


        private void frmSubAddRegistrationRecord_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            this.Text = "新增" + _currentSchoolYear + "學年度競賽報名";
            lblMaxCount.Visible = lblMinCount.Visible = lblTeamType.Visible = false;
            LoadEventDataAndBind();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeamName.Text))
            {
                FISCA.Presentation.Controls.MsgBox.Show("請輸入隊名");
                return;
            }

            if(_selectedEvent == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目");
                return;
            }
            // 沒有重複可以輸入
            if (CheckTeamNamePass(txtTeamName.Text))
            {
                // 新增隊
                int? uid = AddTeam(txtTeamName.Text, _selectedEvent.UID);

                // 新增隊員

            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("已有相同隊名，無法新增。");
                return;
            }
            
            this.DialogResult = DialogResult.Yes;
        }

        private void cbxEventCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxEventName.Items.Clear();
            if (_eventDict.ContainsKey(cbxEventCategory.Text))
            {
                foreach (var item in _eventDict[cbxEventCategory.Text])
                {
                    cbxEventName.Items.Add(item.Name);
                }
            }
        }

        private void cbxEventName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedEvent = null;
            if (_eventDict.ContainsKey(cbxEventCategory.Text))
            {
                foreach (var item in _eventDict[cbxEventCategory.Text])
                {
                    if (item.Name == cbxEventName.Text)
                        _selectedEvent = item;
                }
            }

            if (_selectedEvent != null)
            {
                if (_selectedEvent.IsTeam)
                {
                    lblTeamType.Text = "團體賽";
                }
                else
                {
                    lblTeamType.Text = "個人賽";
                }

                lblMinCount.Text = "最少" + _selectedEvent.MinMemberCount + "人";
                lblMaxCount.Text = "最多" + _selectedEvent.MaxMemberCount + "人";

            }
        }

        private void LoadEventDataAndBind()
        {
            cbxEventCategory.Items.Clear();
            cbxEventName.Items.Clear();
            cbxEventCategory.Enabled = cbxEventName.Enabled = false;

            _bgwLoadEventData.RunWorkerAsync();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _searchText = txtSearch.Text;
                dgSearch.Rows.Clear();
                _bgwLoadSearchStudent.RunWorkerAsync();
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            // 檢查目前已選人數與要新增人數是否超過最多人數
            if (_selectedEvent == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目。");
                return;
            }

            int count = dgSearch.SelectedRows.Count + dgSelectedStudent.Rows.Count;

            if (count > _selectedEvent.MaxMemberCount)
            {
                FISCA.Presentation.Controls.MsgBox.Show("加入人數超過最多人數，無法新增。");
                return;
            }

            if (dgSearch.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow drv in dgSearch.SelectedRows)
                {
                    string sid = drv.Tag.ToString();
                    if (!_checkAddSid.Contains(sid))
                    {
                        int rowIdx = dgSelectedStudent.Rows.Add();
                        dgSelectedStudent.Rows[rowIdx].Tag = sid;
                        dgSelectedStudent.Rows[rowIdx].Cells[colSelClassName.Index].Value = drv.Cells[colClassName.Index].Value;
                        dgSelectedStudent.Rows[rowIdx].Cells[colSelSeatNo.Index].Value = drv.Cells[colSeatNo.Index].Value;
                        dgSelectedStudent.Rows[rowIdx].Cells[colSelName.Index].Value = drv.Cells[colName.Index].Value;
                        dgSelectedStudent.Rows[rowIdx].Cells[colSelAccount.Index].Value = drv.Cells[colAccount.Index].Value;
                        _checkAddSid.Add(sid);
                    }
                }
            }

            lblSelPlayerCount.Text = "已加入" + dgSelectedStudent.Rows.Count + "位隊員";
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            List<int> rmIndex = new List<int>();
            if (dgSelectedStudent.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow drv in dgSelectedStudent.SelectedRows)
                {
                    string sid = drv.Tag.ToString();
                    _checkAddSid.Remove(sid);
                    rmIndex.Add(drv.Index);
                }

            }

            foreach (var dd in rmIndex)
            {
                dgSelectedStudent.Rows.RemoveAt(dd);
            }
            lblSelPlayerCount.Text = "已加入" + dgSelectedStudent.Rows.Count + "位隊員";
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
        private int? AddTeam(string name,string refEventID)
        {
            int? uid = null;
            string strSQL = "INSERT INTO $ischool.sports.teams(ref_event_id,name,created_by) VALUES("+refEventID+",'"+name+"','"+_userAccount+"')  RETURNING uid;";
            QueryHelper qh = new QueryHelper();
            DataTable dt = qh.Select(strSQL);

            if (dt.Rows[0][0] != null)
            {
                uid = int.Parse(dt.Rows[0][0].ToString());
            }

            return uid;
        }     
        
    }
}
