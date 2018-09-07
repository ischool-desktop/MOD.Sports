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
        StringBuilder _sbText = new StringBuilder();
        int _maxCount = 0;
        string _genderFilter = "";
        string _gradeYearFilter = "";
        int? _team_id = null;


        public frmRegRecordAddPlayer()
        {
            InitializeComponent();
            _bgLoadData.WorkerReportsProgress = true;
            _bgLoadData.DoWork += _bgLoadData_DoWork;
            _bgLoadData.RunWorkerCompleted += _bgLoadData_RunWorkerCompleted;
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

            if( _gradeYearFilter != "")
            {
                _sbText.Append(" AND class.grade_year = "+_gradeYearFilter + " ");
            }

            QueryHelper qh = new QueryHelper();
            string strSQL = "SELECT student.id as sid,class.class_name,student.seat_no,student.name,sa_login_name FROM student LEFT JOIN class ON student.ref_class_id = class.id WHERE student.status in(1,2) "+_sbText.ToString()+" ORDER By class.class_name,seat_no";
            _dtStudent = qh.Select(strSQL);
        }

        public void SetTeamID(int? teamID)
        {
            _team_id = teamID;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmRegRecordAddPlayer_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _bgLoadData.RunWorkerAsync();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if( dgSearch.SelectedRows.Count > 0)
            {
                Save();
            }

            this.DialogResult = DialogResult.Yes;


        }

        private void Save()
        {
            try
            {
                List<UDT.Players> addplayers = new List<UDT.Players>();
                foreach (DataGridViewRow drv in dgSearch.SelectedRows)
                {
                    UDT.Players p = new UDT.Players();
                    p.RefStudentId = int.Parse(drv.Tag.ToString());
                    p.ClassName = drv.Cells[colClassName.Index].Value.ToString();
                    p.SeatNo = int.Parse(drv.Cells[colSeatNo.Index].Value.ToString());
                    p.Name = drv.Cells[colName.Index].Value.ToString();
                    p.CreatedBy = drv.Cells[colAccount.Index].Value.ToString();
                    p.RefTeamId = _team_id;
                    addplayers.Add(p);
                }
                addplayers.SaveAll();
            }
            catch(Exception ex)
            {
                
            }
           
        }
    }
}
