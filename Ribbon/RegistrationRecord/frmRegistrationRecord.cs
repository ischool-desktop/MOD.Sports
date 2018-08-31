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

namespace ischool.Sports { 

    public partial class frmRegistrationRecord : BaseForm
    {
        private string _currentSchoolYear = "";
        BackgroundWorker _bgwLoad = new BackgroundWorker();
        DataTable _dtData = new DataTable();
      

        public frmRegistrationRecord()
        {
            InitializeComponent();
            _bgwLoad.WorkerReportsProgress = true;
            _bgwLoad.DoWork += _bgwLoad_DoWork;
            _bgwLoad.RunWorkerCompleted += _bgwLoad_RunWorkerCompleted;
        }

        private void _bgwLoad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 統計數
            lblRowCount.Text = "共 "+_dtData.Rows.Count.ToString()+" 筆";
            LoadDataToGridView();
        }

        private void _bgwLoad_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        private void LoadDataToGridView()
        {
            dgData.Rows.Clear();
            foreach(DataRow dr in _dtData.Rows)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Cells[colEventItem.Index].Value = dr["event_name"].ToString();
                dgData.Rows[rowIdx].Cells[colGroupType.Index].Value = dr["group_types_name"].ToString();
                dgData.Rows[rowIdx].Cells[colTeamName.Index].Value = dr["team_name"].ToString();
                string className = dr["class_name"].ToString();
                if (chkByClassName.Checked)
                {
                    
                }
                dgData.Rows[rowIdx].Cells[colClassName.Index].Value = className;
                dgData.Rows[rowIdx].Cells[colSeatNo.Index].Value = dr["seat_no"].ToString();
                dgData.Rows[rowIdx].Cells[colName.Index].Value = dr["student_name"].ToString();
                dgData.Rows[rowIdx].Cells[colRegAccount.Index].Value = dr["created_by"].ToString();
                dgData.Rows[rowIdx].Cells[colRegDate.Index].Value = dr["player_last_update"].ToString();
            }
        }

        private void LoadData()
        {
            
            QueryHelper qh = new QueryHelper();
            string strSQL = "select category,$ischool.sports.events.name as event_name,$ischool.sports.group_types.name as group_types_name ,$ischool.sports.teams.name as team_name,$ischool.sports.players.name as student_name,class_name,seat_no,$ischool.sports.players.created_by,$ischool.sports.players.last_update as player_last_update from $ischool.sports.events inner join $ischool.sports.teams on $ischool.sports.events.uid = $ischool.sports.teams.ref_event_id inner join $ischool.sports.players on $ischool.sports.teams.uid = $ischool.sports.players.ref_team_id inner join  $ischool.sports.group_types on $ischool.sports.events.ref_group_type_id= $ischool.sports.group_types.uid where $ischool.sports.events.school_year = "+_currentSchoolYear+" order by category,event_name,team_name,class_name,seat_no";
            _dtData = qh.Select(strSQL);

        }       

        

        private void frmRegistrationRecord_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _currentSchoolYear = K12.Data.School.DefaultSchoolYear;
            lblSchoolYear.Text = _currentSchoolYear;
            _bgwLoad.RunWorkerAsync();
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
                FISCA.Presentation.Controls.MsgBox.Show("hi");
            }
        }
    }
}
