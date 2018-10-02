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
using FISCA.Data;

namespace ischool.Sports
{
    public partial class frmEventLimitStudent : BaseForm
    {
        int _EventID = 0;
        int _SchoolYear = 0;
        string _Category = "";
        string _EventName = "";
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        BackgroundWorker _bgwSaveData = new BackgroundWorker();
        AccessHelper _AccessHelper = new AccessHelper();
        List<DataRow> _CanSelectStudentList = new List<DataRow>();
        List<DataRow> _SearchSelectStudentList = new List<DataRow>();
        List<DataRow> _SelectedStudentLimitList = new List<DataRow>();
        UDT.GroupTypes _GroupTypes = new UDT.GroupTypes();
        StringBuilder _sbFilter = new StringBuilder();

        public frmEventLimitStudent()
        {
            InitializeComponent();
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
            _bgwSaveData.DoWork += _bgwSaveData_DoWork;
            _bgwSaveData.RunWorkerCompleted += _bgwSaveData_RunWorkerCompleted;
        }

        private void _bgwSaveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void _bgwSaveData_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnRemove.Enabled = btnAdd.Enabled = true;
            // 可選學生
            LoadCanSelectToDataGridView();
            // 已選學生
            LoadSelectedToDataGridView();
        }

        private void LoadCanSelectToDataGridView()
        {
            dgSearch.Rows.Clear();
            foreach (DataRow dr in _SearchSelectStudentList)
            {
                int rowIdx = dgSearch.Rows.Add();
                // Student id
                dgSearch.Rows[rowIdx].Tag = dr["student_id"].ToString();
                // 年級
                dgSearch.Rows[rowIdx].Cells[colSerGradeYear.Index].Value = dr["grade_year"].ToString();
                // 班級
                dgSearch.Rows[rowIdx].Cells[colSerClassName.Index].Value = dr["class_name"].ToString();
                // 座號
                dgSearch.Rows[rowIdx].Cells[colSerSeatNo.Index].Value = dr["seat_no"].ToString();
                // 姓名
                dgSearch.Rows[rowIdx].Cells[colSerName.Index].Value = dr["student_name"].ToString();
                // 學號
                dgSearch.Rows[rowIdx].Cells[colSerStudentNumber.Index].Value = dr["student_number"].ToString();
                // 帳號
                dgSearch.Rows[rowIdx].Cells[colSerAccount.Index].Value = dr["sa_login_name"].ToString();
            }
            lblCanSelCount.Text = $"可選 {_SearchSelectStudentList.Count} 人";
        }

        private void LoadSelectedToDataGridView()
        {
            dgData.Rows.Clear();
            foreach (DataRow dr in _SelectedStudentLimitList)
            {
                int rowIdx = dgData.Rows.Add();
                // Student id
                dgData.Rows[rowIdx].Tag = dr["student_id"].ToString();
                // 年級
                dgData.Rows[rowIdx].Cells[colGradeYear.Index].Value = dr["grade_year"].ToString();
                // 班級
                dgData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                // 座號
                dgData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                // 姓名
                dgData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                // 學號
                dgData.Rows[rowIdx].Cells[colStudentNumber.Index].Value = dr["student_number"].ToString();
                // 帳號
                dgData.Rows[rowIdx].Cells[colAccount.Index].Value = dr["sa_login_name"].ToString();
            }
            lblSelectCount.Text = $"已選 {_SelectedStudentLimitList.Count} 人";
        }


        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            _sbFilter.Clear();
            _CanSelectStudentList.Clear();
            _SelectedStudentLimitList.Clear();
            _SearchSelectStudentList.Clear();
            List<string> selectIDList = new List<string>();
            QueryHelper qh = new QueryHelper();
            // 取得限制人員資料
            string qryLimit = $"SELECT class.grade_year AS grade_year,class.class_name,student.id " +
                $"AS student_id,student.seat_no,student.name AS student_name,student_number,sa_login_name " +
                $"FROM student INNER JOIN class ON student.ref_class_id = class.id INNER JOIN $ischool.sports.sports_registration ON $ischool.sports.sports_registration.ref_student_id " +
                $"= student.id WHERE $ischool.sports.sports_registration.ref_event_id = {_EventID} " +
                $"ORDER BY class.grade_year,class.class_name,student.seat_no";
            DataTable dtL = qh.Select(qryLimit);
            foreach (DataRow dr in dtL.Rows)
            {
                _SelectedStudentLimitList.Add(dr);
                selectIDList.Add(dr["student_id"].ToString());
            }

            // 處理 group type 條件
            if (_GroupTypes.Grade.HasValue)
            {
                _sbFilter.Append($" AND class.grade_year = {_GroupTypes.Grade.Value}");
            }
            else
            {
                _sbFilter.Append(" AND class.grade_year IN (1,2,3) ");
            }

            if (_GroupTypes.Gender == "M")
            {
                // 男
                _sbFilter.Append(" AND student.gender = '1'");
            }
            else if (_GroupTypes.Gender == "F")
            {
                // 女
                _sbFilter.Append(" AND student.gender = '0'");
            }
            else
            {
                // 不限
            }

            // 取得可以選的學生
            string qry = $"SELECT class.grade_year AS grade_year,class.class_name,student.id " +
                $"AS student_id,student.seat_no,student.name AS student_name,student_number,sa_login_name " +
                $"FROM student INNER JOIN class ON student.ref_class_id = class.id WHERE " +
                $"(student.status in(1,2) {_sbFilter.ToString()}) " +
                $"ORDER BY class.grade_year,class.class_name,student.seat_no";

            DataTable dt = qh.Select(qry);
            foreach (DataRow dr in dt.Rows)
            {
                // 過濾已選 id 不加入
                string sid = dr["student_id"].ToString();
                if (selectIDList.Contains(sid))
                    continue;

                _CanSelectStudentList.Add(dr);
                _SearchSelectStudentList.Add(dr);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmEventLimitStudent_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            string gpName = "";
            if (_GroupTypes != null)
            {
                gpName = _GroupTypes.Name;
            }
            lblName.Text = $"{_SchoolYear}學年度 競賽類別：{_Category},競賽名稱：{_EventName},參賽組別：{gpName}";
            LoadData();
        }

        public void SetDefaultData(int EventID, int SchoolYear, string Category, string EventName, UDT.GroupTypes gpType)
        {
            _EventID = EventID;
            _SchoolYear = SchoolYear;
            _Category = Category;
            _EventName = EventName;
            _GroupTypes = gpType;
        }

        private void LoadData()
        {
            btnAdd.Enabled = btnRemove.Enabled = false;
            _bgwLoadData.RunWorkerAsync();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // 移除限制人員
            if (dgData.SelectedRows.Count < 1)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇學生");
                return;
            }

            btnRemove.Enabled = false;
            List<string> studentIDList = new List<string>();
            foreach (DataGridViewRow drv in dgData.SelectedRows)
            {
                string id = drv.Tag.ToString();
                if (!studentIDList.Contains(id))
                    studentIDList.Add(id);
            }

            DeleteSportsRegistration(studentIDList);
            _bgwLoadData.RunWorkerAsync();
        }

        private void AddSportsRegistration(Dictionary<string, string> studentIDDict)
        {
            // 新增人員
            try
            {
                if (studentIDDict.Count > 0)
                {
                    List<UDT.SportsRegistration> srNew = new List<UDT.SportsRegistration>();
                    foreach (string id in studentIDDict.Keys)
                    {
                        UDT.SportsRegistration sr = new UDT.SportsRegistration();
                        sr.Account = studentIDDict[id];
                        sr.RefEventID = _EventID;
                        sr.RefStudentID = int.Parse(id);
                        srNew.Add(sr);                       
                    }
                    srNew.SaveAll();
                }
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show($"新增限制人員發生錯誤：{ex.Message}");
            }
        }

        private void DeleteSportsRegistration(List<string> studentIDList)
        {
            // 刪除人員
            try
            {
                if (studentIDList.Count > 0)
                {
                    string qry = $"DELETE FROM $ischool.sports.sports_registration WHERE ref_event_id = {_EventID} AND ref_student_id IN ({string.Join(",", studentIDList.ToArray())});";
                    K12.Data.UpdateHelper uh = new K12.Data.UpdateHelper();
                    uh.Execute(qry);
                }
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show($"刪除限制人員發生錯誤：{ex.Message}");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgSearch.SelectedRows.Count < 1)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇學生");
                return;
            }

            btnAdd.Enabled = false;
            Dictionary<string, string> studentIDDict = new Dictionary<string, string>();
            foreach (DataGridViewRow drv in dgSearch.SelectedRows)
            {
                string account = "";
                string id = drv.Tag.ToString();
                if (drv.Cells[colAccount.Index].Value != null)
                    account = drv.Cells[colAccount.Index].Value.ToString();

                if (!studentIDDict.ContainsKey(id))
                    studentIDDict.Add(id, account);
            }

            AddSportsRegistration(studentIDDict);
            _bgwLoadData.RunWorkerAsync();
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSerach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _SearchSelectStudentList.Clear();
                foreach (DataRow dr in _CanSelectStudentList)
                {
                    string name = dr["student_name"].ToString();                    
                    string studentNumber = dr["student_number"].ToString();
                    string className = dr["class_name"].ToString();
                    if (name.Contains(txtSerach.Text) || studentNumber.Contains(txtSerach.Text) || className.Contains(txtSerach.Text))
                    {
                        _SearchSelectStudentList.Add(dr);
                    }
                }
                LoadCanSelectToDataGridView();
            }
        }

        private void dgSearch_Click(object sender, EventArgs e)
        {
            lblCanSelCount.Text = $"選 {dgSearch.SelectedRows.Count} 人";
        }
    }
}
