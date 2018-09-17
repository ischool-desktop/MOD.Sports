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
    public partial class frmSetSportsChiefAdd : BaseForm
    {
        int _SchoolYear = 0;
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        QueryHelper _qh = new QueryHelper();
        AccessHelper _ah = new AccessHelper();
        List<DataRow> _dataRowList = new List<DataRow>();
        Dictionary<int, int> _classStudentIDDict = new Dictionary<int, int>();
        Dictionary<int, string> _studentAccountDict = new Dictionary<int, string>();
        public frmSetSportsChiefAdd()
        {
            InitializeComponent();
            _bgwLoadData.WorkerReportsProgress = true;
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnOk.Enabled = true;
            LoadDataToDataGridView();
        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            foreach (DataRow dr in _dataRowList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = dr;
                dgData.Rows[rowIdx].Cells[colGradeYear.Index].Value = dr["grade_year"].ToString();
                dgData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                dgData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                dgData.Rows[rowIdx].Cells[colStudentNumber.Index].Value = dr["student_number"].ToString();
                dgData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
            }
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        public void SetSchoolYear(int sc)
        {
            _SchoolYear = sc;
        }

        private void LoadData()
        {
            _dataRowList.Clear();
            string qrySQL = "SELECT class.grade_year AS grade_year,class.class_name,student.seat_no,student_number,student.name AS student_name,class.id AS class_id,student.id AS student_id,sa_login_name FROM student INNER JOIN class ON student.ref_class_id = class.id WHERE student.ref_class_id NOT IN (SELECT ref_class_id FROM  $ischool.sports.sports_chief WHERE school_year = " + _SchoolYear + ") AND student.status IN(1,2) ORDER BY class.grade_year,class.display_order,class.class_name,student.seat_no;";

            DataTable dt = _qh.Select(qrySQL);

            foreach (DataRow dr in dt.Rows)
            {
                _dataRowList.Add(dr);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _classStudentIDDict.Clear();
            _studentAccountDict.Clear();
            // 重複被加入
            List<string> dClassName = new List<string>();
            // 檢查資料是否有重複新增
            foreach (DataGridViewRow drv in dgData.SelectedRows)
            {
                if (drv.IsNewRow)
                    continue;

                DataRow dr = drv.Tag as DataRow;
                if (dr != null)
                {
                    // class id 
                    int class_id = int.Parse(dr["class_id"].ToString());

                    // student id
                    int student_id = int.Parse(dr["student_id"].ToString());
                    if (!_classStudentIDDict.ContainsKey(class_id))
                    {
                        _classStudentIDDict.Add(class_id, student_id);
                        string account = dr["sa_login_name"].ToString();
                        _studentAccountDict.Add(student_id, account);
                    }
                    else
                    {
                        string dcName = dr["class_name"].ToString();
                        if (!dClassName.Contains(dcName))
                            dClassName.Add(dcName);
                    }
                }
            }

            // 有重複不能能新增
            if (dClassName.Count > 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show(string.Join(",", dClassName.ToArray()) + "班級選超過1位體育股長，請重新選擇。");
                return;
            }

            List<UDT.SportsChief> AddSportsChiefList = new List<UDT.SportsChief>();
            // 加入班級體育股長
            foreach (var x in _classStudentIDDict.Keys)
            {
                UDT.SportsChief sc = new UDT.SportsChief();
                sc.SchoolYear = _SchoolYear;
                sc.RefClassID = x;
                int sid = _classStudentIDDict[x];
                sc.RefStudentID = sid;

                if (_studentAccountDict.ContainsKey(sid))
                {
                    sc.Account = _studentAccountDict[sid];
                }
                AddSportsChiefList.Add(sc);
            }

            if (AddSportsChiefList.Count > 0)
            {
                AddSportsChiefList.SaveAll();
            }

            this.DialogResult = DialogResult.Yes;
        }

        private void frmSetSportsChiefAdd_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            btnOk.Enabled = false;
            _bgwLoadData.RunWorkerAsync();
        }

        private void dgData_MouseClick(object sender, MouseEventArgs e)
        {
            lblSelectCount.Text = "已選擇"+dgData.SelectedRows.Count+"位";
        }
    }
}
