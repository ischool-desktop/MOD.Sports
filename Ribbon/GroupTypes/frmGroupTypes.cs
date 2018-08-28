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
    public partial class frmGroupTypes : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();

        List<UDT.GroupTypes> _GroupTypesList = new List<UDT.GroupTypes>();
        public frmGroupTypes()
        {
            InitializeComponent();
        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            _GroupTypesList = _access.Select<UDT.GroupTypes>();

            foreach (var data in _GroupTypesList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = data;
                dgData.Rows[rowIdx].Cells[colName.Index].Value = data.Name;
                dgData.Rows[rowIdx].Cells[colGender.Index].Value = data.Gender;
                dgData.Rows[rowIdx].Cells[colGrade.Index].Value = data.Grade;
                dgData.Rows[rowIdx].Cells[colCreatedBy.Index].Value = data.CreatedBy;
            }

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            //  檢查資料是否空白
            bool hasError = false;
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;

                foreach (DataGridViewCell cell in drv.Cells)
                {
                    if (cell.Value == null)
                    {
                        hasError = true;
                    }
                }
            }

            if (hasError)
            {
                FISCA.Presentation.Controls.MsgBox.Show("不能空白");
                return;
            }

            // 需要儲存資料
            List<UDT.GroupTypes> saveDataList = new List<UDT.GroupTypes>();
            List<UDT.GroupTypes> delDataList = new List<UDT.GroupTypes>();
            List<string> hasDataUID = new List<string>();

            // 比對取得資料與畫面資料，進行新增修改刪除動作
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;

                UDT.GroupTypes data = null;

                if (drv.Tag == null)
                {
                    // 新增
                    data = new UDT.GroupTypes();
                }
                else
                {
                    data = drv.Tag as UDT.GroupTypes;
                    hasDataUID.Add(data.UID);
                }

                data.Name = drv.Cells[colName.Index].Value.ToString();
                data.CreatedBy = _userAccount;
                data.Grade = parseGrade(drv.Cells[colGrade.Index]);

                if (drv.Cells[colGender.Index].Value == null)
                {
                    data.Gender = "";
                }
                else
                {
                    data.Gender = drv.Cells[colGender.Index].Value.ToString();
                }

                saveDataList.Add(data);
            }

            // 比對來源元件沒有 uid 需要刪除
            foreach (var sdata in _GroupTypesList)
            {
                if (!hasDataUID.Contains(sdata.UID))
                    delDataList.Add(sdata);
            }

            if (delDataList.Count > 0)
            {
                foreach (var data in delDataList)
                {
                    data.Deleted = true;
                    saveDataList.Add(data);
                }
            }

            try
            {
                saveDataList.SaveAll();
                FISCA.Presentation.Controls.MsgBox.Show("儲存完成");
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗," + ex.Message);
            }

        }

        private int? parseGrade(DataGridViewCell cell)
        {
            int? value = null;
            if (cell.Value != null)
            {
                value = int.Parse(cell.Value.ToString());
            }
            return value;
        }

        private void frmGroupTypes_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void dgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
