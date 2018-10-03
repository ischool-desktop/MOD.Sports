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
    public partial class frmCopyEventItem : BaseForm
    {
        int _selectSchoolYear = 0, _defaultSchoolYear = 0;
        // 來源
        List<UDT.Events> _SourceEventsList = new List<UDT.Events>();
        // copy to
        List<UDT.Events> _TargetEventsList = new List<UDT.Events>();
        Dictionary<int, UDT.GroupTypes> _GroupTypesDict = new Dictionary<int, UDT.GroupTypes>();

        // source index
        Dictionary<string, UDT.Events> _SourceItemDict = new Dictionary<string, UDT.Events>();
        Dictionary<string, UDT.Events> _SelectedItemDict = new Dictionary<string, UDT.Events>();

        Dictionary<string, UDT.Events> _TargetItemDict = new Dictionary<string, UDT.Events>();
        AccessHelper _AccessHelper = new AccessHelper();
        BackgroundWorker _bgwLoadData = new BackgroundWorker();
        BackgroundWorker _bgwSaveData = new BackgroundWorker();
        bool IsbgwLoadDataBusy = false;

        public frmCopyEventItem()
        {
            InitializeComponent();
            _bgwLoadData.DoWork += _bgwLoadData_DoWork;
            _bgwLoadData.RunWorkerCompleted += _bgwLoadData_RunWorkerCompleted;
            _bgwSaveData.DoWork += _bgwSaveData_DoWork;
            _bgwSaveData.RunWorkerCompleted += _bgwSaveData_RunWorkerCompleted;
        }

        private void _bgwSaveData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                FISCA.Presentation.Controls.MsgBox.Show($"複製過程發生錯誤:{e.Error.Message}");
                btnCopy.Enabled = true;
                return;
            }

            this.DialogResult = DialogResult.Yes;
        }

        private void _bgwSaveData_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _TargetEventsList.SaveAll();
            }
            catch (Exception ex)
            {
                e.Cancel = true;               
            }

        }

        private void _bgwLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (IsbgwLoadDataBusy)
            {
                IsbgwLoadDataBusy = false;
                _bgwLoadData.RunWorkerAsync();
                return;
            }

            BindSourceData();
        }

        private void BindSourceData()
        {
            _SourceItemDict.Clear();
            foreach (UDT.Events ev in _SourceEventsList)
            {
                string gpName = "";
                if (_GroupTypesDict.ContainsKey(ev.RefGroupTypeId))
                {
                    gpName = _GroupTypesDict[ev.RefGroupTypeId].Name;
                }
                string itemName = $"{ev.Category}_{ev.Name}_{gpName}";
                if (!_SourceItemDict.ContainsKey(itemName))
                    _SourceItemDict.Add(itemName, ev);
            }

            dgSource.Rows.Clear();
            foreach (string name in _SourceItemDict.Keys)
            {
                int rowIdx = dgSource.Rows.Add();
                dgSource.Rows[rowIdx].Tag = _SourceItemDict[name];
                dgSource.Rows[rowIdx].Cells[colEventItem.Index].Value = name;
            }

            iptSSchoolYear.Enabled = btnPreView.Enabled = btnCopy.Enabled = btnRemove.Enabled = true;
            lblSourceCount.Text = $"共 {dgSource.Rows.Count} 筆";
        }

        private void _bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadGroupType();
            LoadEventData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            btnCopy.Enabled = false;
            _TargetEventsList.Clear();

            foreach (DataGridViewRow drv in dgTarget.Rows)
            {
                UDT.Events ev = drv.Tag as UDT.Events;
                if (ev != null)
                {
                    _TargetEventsList.Add(ev);
                }
            }

            _bgwSaveData.RunWorkerAsync();
        }

        private void frmCopyEventItem_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            try
            {
                iptSSchoolYear.Value = iptTSchoolYear.Value = _selectSchoolYear = _defaultSchoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);

                rbGroupType.Checked = true;
                rbSchoolYear.Checked = false;
                iptTSchoolYear.Enabled = false;
            }
            catch (Exception ex)
            {

            }

            LoadData();
        }

        private void LoadData()
        {
            iptSSchoolYear.Enabled = btnPreView.Enabled = btnCopy.Enabled = btnRemove.Enabled = false;
            if (_bgwLoadData.IsBusy)
            {
                IsbgwLoadDataBusy = true;
            }
            else
            {
                _bgwLoadData.RunWorkerAsync();
            }
        }

        private void LoadGroupType()
        {
            _GroupTypesDict.Clear();
            List<UDT.GroupTypes> gpList = _AccessHelper.Select<UDT.GroupTypes>();
            foreach (UDT.GroupTypes data in gpList)
            {
                int uid = int.Parse(data.UID);
                if (!_GroupTypesDict.ContainsKey(uid))
                    _GroupTypesDict.Add(uid, data);
            }
        }


        private void LoadEventData()
        {
            _SourceEventsList.Clear();
            // 依學年度過濾
            _SourceEventsList = _AccessHelper.Select<UDT.Events>($"school_year = {_selectSchoolYear}");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgTarget.SelectedRows.Count < 1)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目");
                return;
            }
            btnRemove.Enabled = false;

            List<string> removeNameList = new List<string>();
            // 取得要移除項目名稱
            foreach (DataGridViewRow drv in dgTarget.SelectedRows)
            {
                removeNameList.Add(drv.Cells[colTEventName.Index].Value.ToString());
            }
            // 移除項目名稱

            foreach (string name in removeNameList)
            {
                _TargetItemDict.Remove(name);
            }

            // 重新載入畫面
            LoadTargetItemToDataGridView();
            btnRemove.Enabled = true;
        }

        private void rbGroupType_CheckedChanged(object sender, EventArgs e)
        {
            iptTSchoolYear.Enabled = false;
        }

        private void rbSchoolYear_CheckedChanged(object sender, EventArgs e)
        {
            iptTSchoolYear.Enabled = rbSchoolYear.Checked;
        }

        private void iptSSchoolYear_ValueChanged(object sender, EventArgs e)
        {
            _selectSchoolYear = iptSSchoolYear.Value;
            LoadData();
        }

        private void btnPreView_Click(object sender, EventArgs e)
        {
            if (dgSource.SelectedRows.Count < 1)
            {
                FISCA.Presentation.Controls.MsgBox.Show("請選擇競賽項目");
                return;
            }

            btnPreView.Enabled = false;
            _SelectedItemDict.Clear();
            _TargetItemDict.Clear();

            foreach (DataGridViewRow drv in dgSource.SelectedRows)
            {
                string itemName = drv.Cells[colEventItem.Index].Value.ToString();
                UDT.Events ev = drv.Tag as UDT.Events;
                if (!_SelectedItemDict.ContainsKey(itemName))
                    _SelectedItemDict.Add(itemName, ev);
            }

            // 使用參賽組別
            if (rbGroupType.Checked)
            {
                List<string> NewItemNameList = new List<string>();
                foreach (UDT.Events ev in _SelectedItemDict.Values)
                {
                    foreach (int key in _GroupTypesDict.Keys)
                    {
                        // 相同不複製
                        if (ev.RefGroupTypeId == key)
                            continue;

                        string gpName = _GroupTypesDict[key].Name;

                        string itemName = $"{ev.Category}_{ev.Name}_{gpName}";
                        UDT.Events newEvent = CopyItem(ev, ev.SchoolYear, ev.Category, ev.Name, key);

                        if (!_TargetItemDict.ContainsKey(itemName))
                            _TargetItemDict.Add(itemName, newEvent);
                    }
                }

                LoadTargetItemToDataGridView();
            }

            // 使用學年度
            if (rbSchoolYear.Checked)
            {
                // 取得所選學年度
                int newSchoolYear = iptTSchoolYear.Value;
                if (newSchoolYear == iptSSchoolYear.Value)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("與來源相同學年度無法複製。");
                    btnPreView.Enabled = true;
                    return;
                }

                List<string> NewItemNameList = new List<string>();
                foreach (UDT.Events ev in _SelectedItemDict.Values)
                {
                    if (_GroupTypesDict.ContainsKey(ev.RefGroupTypeId))
                    {
                        string gpName = _GroupTypesDict[ev.RefGroupTypeId].Name;
                        string itemName = $"{ev.Category}_{ev.Name}_{gpName}";
                        UDT.Events newEvent = CopyItem(ev, newSchoolYear, ev.Category, ev.Name, ev.RefGroupTypeId);

                        if (!_TargetItemDict.ContainsKey(itemName))
                            _TargetItemDict.Add(itemName, newEvent);
                    }
                }

                LoadTargetItemToDataGridView();

            }

            btnPreView.Enabled = true;
        }

        private void LoadTargetItemToDataGridView()
        {
            dgTarget.Rows.Clear();
            foreach (string name in _TargetItemDict.Keys)
            {
                int rowIdx = dgTarget.Rows.Add();
                dgTarget.Rows[rowIdx].Cells[colTEventName.Index].Value = name;
                dgTarget.Rows[rowIdx].Tag = _TargetItemDict[name];
            }
            lblTargetCount.Text = $"共 {dgTarget.Rows.Count} 筆";
        }

        private void dgSource_Click(object sender, EventArgs e)
        {
            lblSourceCount.Text = $"選 {dgSource.SelectedRows.Count} 筆";
        }

        private void dgTarget_Click(object sender, EventArgs e)
        {
            lblTargetCount.Text = $"選 {dgTarget.SelectedRows.Count} 筆";
        }

        private UDT.Events CopyItem(UDT.Events sourceEvent, int NewSchoolYear, string Category, string Name, int GroupTypeID)
        {
            UDT.Events evItem = new UDT.Events();
            evItem.SchoolYear = NewSchoolYear;
            evItem.Category = Category;
            evItem.Name = Name;
            evItem.RefGroupTypeId = GroupTypeID;
            return evItem;
        }
    }
}
