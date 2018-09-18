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

namespace ischool.Sports
{
    public partial class frmEventTemplates : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        List<UDT.EventTemplates> _EventTemplatesList = new List<UDT.EventTemplates>();
        List<UDT.ScoreTypes> _ScoreTypesList = new List<UDT.ScoreTypes>();
        Dictionary<string, UDT.ScoreTypes> _ScoreTypesDict = new Dictionary<string, UDT.ScoreTypes>();
        BackgroundWorker _bgwLoadData = new BackgroundWorker();


        public frmEventTemplates()
        {
            InitializeComponent();
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadDataToDataGridView();
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = true;
        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            foreach(UDT.EventTemplates temp in _EventTemplatesList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = temp;
                dgData.Rows[rowIdx].Cells[colEventCategory.Index].Value = temp.Category;
                dgData.Rows[rowIdx].Cells[colEventName.Index].Value = temp.Name;
                string stid = temp.RefScoreTypeId.ToString();
                dgData.Rows[rowIdx].Cells[colScoreType.Index].Value = "";
                if (_ScoreTypesDict.ContainsKey(stid))
                {
                    dgData.Rows[rowIdx].Cells[colScoreType.Index].Value = _ScoreTypesDict[stid].Name;
                }

                dgData.Rows[rowIdx].Cells[colMaxMember.Index].Value = temp.MaxMemberCount;
                dgData.Rows[rowIdx].Cells[colMinMember.Index].Value = temp.MinMemberCount;
                dgData.Rows[rowIdx].Cells[colIsTeam.Index].Value = temp.IsTeam ? "是":"否";
                dgData.Rows[rowIdx].Cells[colAlthleticOnly.Index].Value = temp.AthleticOnly ? "是":"否";
                dgData.Rows[rowIdx].Cells[colCreatedBy.Index].Value = temp.CreatedBy;
            }
        }

        /// <summary>
        /// 載入計分方式
        /// </summary>
        private void LoadScoreTypes()
        {
            _ScoreTypesDict.Clear();
            _ScoreTypesList = _access.Select<UDT.ScoreTypes>();
            
            foreach( UDT.ScoreTypes st in _ScoreTypesList)
            {
                if (!_ScoreTypesDict.ContainsKey(st.Name))
                    _ScoreTypesDict.Add(st.Name, st);

                if (!_ScoreTypesDict.ContainsKey(st.UID))
                    _ScoreTypesDict.Add(st.UID, st);
            }
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadScoreTypes();
            LoadEventTemplates();
        }

        private void LoadEventTemplates()
        {
            _EventTemplatesList = _access.Select<UDT.EventTemplates>();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count == 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            else
            {
                UDT.EventTemplates selectEventTemplates = dgData.SelectedRows[0].Tag as UDT.EventTemplates;

                if (FISCA.Presentation.Controls.MsgBox.Show("當選「是」將刪除競賽樣板，請問是否刪除？", "刪除競賽樣板", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    selectEventTemplates.Deleted = true;
                    selectEventTemplates.Save();
                    // 資料重整
                    _bgwLoadData.RunWorkerAsync();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgData.SelectedRows.Count == 0)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇項目");
            }
            else
            {
                UDT.EventTemplates selectEventTemplates = dgData.SelectedRows[0].Tag as UDT.EventTemplates;
                
                frmSetEventTemplate editFrom = new frmSetEventTemplate();
                editFrom.SetIsAdd(false);
                editFrom.SetEventTemplates(selectEventTemplates);
                editFrom.setScoreTypesList(_ScoreTypesList);
                
                if (editFrom.ShowDialog() == DialogResult.OK)
                {

                    // 資料重整
                    _bgwLoadData.RunWorkerAsync();
                }
            }
        }

        private void frmEventTemplates_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            btnAdd.Enabled = btnEdit.Enabled = btnDel.Enabled = false;
            _bgwLoadData.RunWorkerAsync();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UDT.EventTemplates addEventtemplates = null;

            frmSetEventTemplate addFrom = new frmSetEventTemplate();
            addFrom.SetEventTemplates(addEventtemplates);
            addFrom.SetIsAdd(true);           
            addFrom.setScoreTypesList(_ScoreTypesList);
            if (addFrom.ShowDialog() == DialogResult.OK)
            {
                // 資料重整
                _bgwLoadData.RunWorkerAsync();
            }
        }
    }
}
