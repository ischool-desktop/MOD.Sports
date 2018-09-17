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
    public partial class frmSetSportsChief : BaseForm
    {
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        QueryHelper _qh = new QueryHelper();

        int _SchoolYear = 0;
        int _defaultSchoolYear = 0;
        List<DataRow> _dataRowList = new List<DataRow>();

        public frmSetSportsChief()
        {
            InitializeComponent();
            _bgwLoadData.WorkerReportsProgress = true;
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // 檢查是否有選取
            if (dgData.SelectedRows.Count > 0)
            {
                // 確認與執行刪除
                if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除體育股長，請問是否刪除？", "刪除班級體育股長資料", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<string> uidList = new List<string>();
                    foreach (DataGridViewRow dr in dgData.SelectedRows)
                    {
                        string id = dr.Tag.ToString();
                        uidList.Add(id);
                    }
                    DeleteItem(uidList);
                    _bgwLoadData.RunWorkerAsync();
                }               
            }
            else
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇學生");
            }


        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            lblStudentCount.Text = "共0人";
            lblStudentCount.Text = "共"+_dataRowList.Count+"人";

            foreach(DataRow dr in _dataRowList)
            {                
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = dr["uid"].ToString();
                dgData.Rows[rowIdx].Cells[colGradeYear.Index].Value = dr["grade_year"].ToString();
                dgData.Rows[rowIdx].Cells[colClassName.Index].Value = dr["class_name"].ToString();
                dgData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                dgData.Rows[rowIdx].Cells[colStudentNumber.Index].Value = dr["student_number"].ToString();
                dgData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                dgData.Rows[rowIdx].Cells[colAccount.Index].Value = dr["sa_login_name"].ToString();
            }
        }

        private void DeleteItem(List<string> uidList)
        {
            try
            {
                if (uidList.Count > 0)
                {
                    K12.Data.UpdateHelper uh = new K12.Data.UpdateHelper();
                    
                    string delStr = "DELETE FROM $ischool.sports.sports_chief WHERE uid in(" + string.Join(",", uidList.ToArray()) + ");";
                    uh.Execute(delStr);
                }
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("刪除資料失敗，" + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSetSportsChiefAdd fssca = new frmSetSportsChiefAdd();
            fssca.SetSchoolYear(_SchoolYear);
            if (fssca.ShowDialog() == DialogResult.Yes)
            {
                // 新增後重新整理
                _bgwLoadData.RunWorkerAsync();
            }
        }


        private void frmSetSportsChief_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _defaultSchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
            iptSchoolYear.Value = _defaultSchoolYear;
            _bgwLoadData.RunWorkerAsync();
        }

        private void iptSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            _SchoolYear = _defaultSchoolYear = iptSchoolYear.Value;
            if (_defaultSchoolYear != _SchoolYear)
            {

            }
        }



        private void LoadData()
        {
            _dataRowList.Clear();
            // 依所選學年度取得體育股長
            string qryStr = "SELECT $ischool.sports.sports_chief.uid AS uid,class.grade_year AS grade_year,class.class_name,student.seat_no,student_number,student.name AS student_name,sa_login_name FROM  $ischool.sports.sports_chief INNER JOIN student ON $ischool.sports.sports_chief.ref_student_id = student.id INNER JOIN class ON $ischool.sports.sports_chief.ref_class_id = class.id WHERE $ischool.sports.sports_chief.school_year = " + _SchoolYear + " ORDER BY class.grade_year,class.display_order,class.class_name,student.seat_no;";
            DataTable dt = _qh.Select(qryStr);
            foreach (DataRow dr in dt.Rows)
            {
                _dataRowList.Add(dr);
            }
        }

        private void SetButton1Enable(bool value)
        {
            btnAdd.Enabled = btnDel.Enabled = value;
        }
    }
}
