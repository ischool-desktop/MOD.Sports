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
    public partial class frmSubEvents : BaseForm
    {
         UDT.Events _EventData = null;

        bool _IsAddMode = true;

        BackgroundWorker _bgw = new BackgroundWorker();

        // 對照表
        Dictionary<string, UDT.GroupTypes> _GroupTypesDict = new Dictionary<string, UDT.GroupTypes>();
        Dictionary<string, UDT.GameTypes> _GameTypesDict = new Dictionary<string, UDT.GameTypes>();

        public frmSubEvents()
        {
            InitializeComponent();
            _bgw.WorkerReportsProgress = true;
            _bgw.DoWork += _bgw_DoWork;
            _bgw.RunWorkerCompleted += _bgw_RunWorkerCompleted;
        }

        private void _bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = true;
            BindData();
        }

        private void _bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        public void SetGroupTypesDict(Dictionary<string, UDT.GroupTypes> dict)
        {
            _GroupTypesDict = dict;
        }

        public void SetGameTypesDict(Dictionary<string, UDT.GameTypes> dict)
        {
            _GameTypesDict = dict;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void SetEvents(UDT.Events data)
        {
            if (data == null)
            {
                _EventData = new UDT.Events();
            }else
            {
                _EventData = data;
            }            
        }

        public UDT.Events GetEventData()
        {
            return _EventData;
        }
        

        public void SetIsAddMode(bool isAdd)
        {
            _IsAddMode = isAdd;
        }

        private void frmSubEvents_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            this.btnSave.Enabled = false;
            if (_IsAddMode)
            {
                this.Text = "新增";
            }else
            {
                this.Text = "修改";
            }
            _bgw.RunWorkerAsync();
        }

        private void BindData()
        {
            if (_EventData == null)
                _EventData = new UDT.Events();

            iptSchoolYear.Value = _EventData.SchoolYear;
            txtCategory.Text = _EventData.Category;
            txtName.Text = _EventData.Name;
            dtEventStartDate.Value = _EventData.EventStartDate;
            dtEventEndDate.Value = _EventData.EventEndDate;
            // 對照放到畫面
            string RefGameTypeId = _EventData.RefGameTypeId.ToString();
            if (_GameTypesDict.ContainsKey(RefGameTypeId))
                cbxGameType.Text = _GameTypesDict[RefGameTypeId].Name;

            dtRegStartDate.Value = _EventData.RegStartDate;
            dtRegEndDate.Value = _EventData.RegEndDate;
            iptMaxMemberCount.Value = _EventData.MaxMemberCount;
            iptMinMemberCount.Value = _EventData.MinMemberCount;
            string RefGroupTypeId = _EventData.RefGroupTypeId.ToString();

            if (_GroupTypesDict.ContainsKey(RefGroupTypeId))
                cbxGroupType.Text = _GroupTypesDict[RefGroupTypeId].Name;
            chkIsTeam.Checked = _EventData.IsTeam;
            chkAthleticOnly.Checked = _EventData.AthleticOnly;
            chkIsDrawLots.Checked = _EventData.IsDrawLots;
            dtDrawLotsDate.Value = _EventData.DrawLotsDate;
            txtEventDescription.Text = _EventData.EventDescription;

        }
    }
}
