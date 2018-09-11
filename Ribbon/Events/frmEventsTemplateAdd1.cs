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
using K12.Data;
namespace ischool.Sports
{
    public partial class frmEventsTemplateAdd1 : BaseForm
    {
        int _SchoolYear = 0;
        BackgroundWorker _bkw = new BackgroundWorker();
        List<UDT.EventTemplates> _EventTemplatesList = new List<UDT.EventTemplates>();
        private AccessHelper _access = new AccessHelper();
      
        // 新增項目
        UDT.Events _AddEvents = null;

        public frmEventsTemplateAdd1()
        {
            InitializeComponent();
            _bkw.WorkerReportsProgress = true;
            _bkw.DoWork += _bkw_DoWork;
            _bkw.RunWorkerCompleted += _bkw_RunWorkerCompleted;
        }

        private void LoadUDTData()
        {
            _EventTemplatesList = _access.Select<UDT.EventTemplates>();
        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            foreach(UDT.EventTemplates data in _EventTemplatesList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Cells[colCategory.Index].Value = data.Category;
                dgData.Rows[rowIdx].Cells[colName.Index].Value = data.Name;
                dgData.Rows[rowIdx].Tag = data;
            }
        }

        private void _bkw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnOk.Enabled = true;
            iptSchoolYear.Value = _SchoolYear;
            LoadDataToDataGridView();
        }

        private void _bkw_DoWork(object sender, DoWorkEventArgs e)
        {            
            // 取得預設學年度
            int.TryParse(School.DefaultSchoolYear, out _SchoolYear);
            // 取得樣板資料
            LoadUDTData();
        }

        private void frmEventsTemplateAdd1_Load(object sender, EventArgs e)
        {
            btnOk.Enabled = false;
            _bkw.RunWorkerAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(dgData.SelectedRows.Count == 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
                return;
            }else
            {
                UDT.EventTemplates temp = dgData.SelectedRows[0].Tag as UDT.EventTemplates;
                _AddEvents = new UDT.Events();
                _AddEvents.Category = temp.Category;
                _AddEvents.Name = temp.Name;
                _AddEvents.IsTeam = temp.IsTeam;
                _AddEvents.RefScoreTypeId = temp.RefScoreTypeId;
                _AddEvents.MaxMemberCount = temp.MaxMemberCount;
                _AddEvents.MinMemberCount = temp.MinMemberCount;
                _AddEvents.AthleticOnly = temp.AthleticOnly;
                _AddEvents.RefItemTemplateId = int.Parse(temp.UID);
                _AddEvents.SchoolYear = iptSchoolYear.Value;
                
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取得所選項目
        /// </summary>
        /// <returns></returns>
        public UDT.Events GetEvents()
        {
            return this._AddEvents;
        }
    }
}
