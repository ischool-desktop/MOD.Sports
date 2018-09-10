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
    public partial class frmRegRecordAddPlayer : BaseForm
    {
        DataTable _dtStudent = new DataTable();
        BackgroundWorker _bgLoadData = new BackgroundWorker();
        BackgroundWorker _bgwSave = new BackgroundWorker();
        StringBuilder _sbText = new StringBuilder();
        StringBuilder _sbError = new StringBuilder();
        int _maxCount = 0;
        string _genderFilter = "";
        string _gradeYearFilter = "";
        int _refEventID = 0;
        int? _team_id = null;
        string _teamName = "";


        public frmRegRecordAddPlayer()
        {
            InitializeComponent();
            _bgLoadData.WorkerReportsProgress = true;
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
            _bgwSave.WorkerReportsProgress = true;
            _bgwSave.RunWorkerCompleted += _bgwSave_RunWorkerCompleted;
            _bgwSave.DoWork += _bgwSave_DoWork;
        }

        private void _bgwSave_DoWork(object sender, DoWorkEventArgs e)
        {
            Save();
        }

        private void _bgwSave_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            if (_sbError.Length > 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("");

            }
        }

        private void _bgLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        public void SetMaxCount(int c)
        {
            _maxCount = c;
        }

        public void SetGenderFilter(string g)
        {
            _genderFilter = g;
        }

        public void SetEventID(int id)
        {
            _refEventID = id;
        }

        public void SetGradeYearFilter(string g)
        {
            _gradeYearFilter = g;
        }

        private void _bgLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            _sbText.Clear();
            if (_genderFilter != "")
            {
                if (_genderFilter == "M")
                {
                    _sbText.Append(" AND student.gender = '1' ");
                }

                if (_genderFilter == "F")
                {
                    _sbText.Append(" AND student.gender = '0' ");
                }
            }

            if (_gradeYearFilter != "")
            {
                _sbText.Append(" AND class.grade_year = " + _gradeYearFilter + " ");
            }

            QueryHelper qh = new QueryHelper();
            string strSQL = "SELECT student.id as sid,class.class_name,student.seat_no,student.name,sa_login_name FROM student LEFT JOIN class ON student.ref_class_id = class.id WHERE student.status in(1,2) " + _sbText.ToString() + " ORDER By class.class_name,seat_no";
            _dtStudent = qh.Select(strSQL);
        }

        public void SetTeamID(int? teamID)
        {
            _team_id = teamID;
        }

        public void SetTeamName(string name)
        {
            _teamName = name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmRegRecordAddPlayer_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            lblTeamName.Text = _teamName;
            _bgLoadData.RunWorkerAsync();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            _sbError.Clear();
            if (dgSearch.SelectedRows.Count > 0)
            {
                if (dgSearch.SelectedRows.Count > _maxCount)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("最多新增" + _maxCount + "人，已超過無法新增。");
                    btnOk.Enabled = true;
                    return;
                }
                else
                {
                    _bgwSave.RunWorkerAsync();
                }

            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇1筆資料。");
                btnOk.Enabled = true;
                return;
            }

            this.DialogResult = DialogResult.Yes;
        }

        private void Save()
        {
            try
            {
                // 取得已有資料 student id
                List<int> hasSids = GetDBData();
                List<UDT.Players> addplayers = new List<UDT.Players>();
                foreach (DataGridViewRow drv in dgSearch.SelectedRows)
                {
                    int sid = int.Parse(drv.Tag.ToString());

                    // 已有資料跳出
                    if (hasSids.Contains(sid))
                        continue;

                    UDT.Players p = new UDT.Players();
                    p.RefStudentId = sid;
                    p.ClassName = drv.Cells[colClassName.Index].Value.ToString();
                    p.SeatNo = int.Parse(drv.Cells[colSeatNo.Index].Value.ToString());
                    p.Name = drv.Cells[colName.Index].Value.ToString();
                    p.CreatedBy = drv.Cells[colAccount.Index].Value.ToString();
                    p.RefTeamId = _team_id;
                    p.RefEventId = _refEventID;
                    addplayers.Add(p);
                }
                addplayers.SaveAll();
            }
            catch (Exception ex)
            {
               _sbError.Append("參賽人員儲存錯誤," + ex.Message);
            }

        }

        private void dgSearch_SelectionChanged(object sender, EventArgs e)
        {
            lblCount.Text = "已選 " + dgSearch.SelectedRows.Count.ToString() + " 人";
        }

        private List<int> GetDBData()
        {
            List<int> value = new List<int>();
            string strSQL = "SELECT ref_student_id FROM $ischool.sports.players WHERE  ref_event_id = " + _refEventID;
            if (_team_id.HasValue)
            {
                strSQL += " AND  ref_team_id = " + _team_id.Value;
            }
            else
            {
                strSQL += " AND  ref_team_id IS NULL";
            }
            QueryHelper qh = new QueryHelper();
            DataTable dt = qh.Select(strSQL);
            foreach(DataRow dr in dt.Rows)
            {
                int sid = int.Parse(dr["ref_student_id"].ToString());
                value.Add(sid);
            }
            return value;
        }
    }
}
