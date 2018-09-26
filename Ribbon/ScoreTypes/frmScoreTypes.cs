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
    public partial class frmScoreTypes : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        List<UDT.ScoreTypes> _ScoreTypesList = new List<UDT.ScoreTypes>();

        public frmScoreTypes()
        {
            InitializeComponent();
        }

        private void frmScoreTypes_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            this.btnSave.Enabled = false;
            LoadData();
            LoadDataToDataGridView();
        }

        private void LoadData()
        {
            _ScoreTypesList = _access.Select<UDT.ScoreTypes>();
        }

        private void LoadDataToDataGridView()
        {
            dgData.Rows.Clear();
            foreach (UDT.ScoreTypes st in _ScoreTypesList)
            {
                int rowIdx = dgData.Rows.Add();
                dgData.Rows[rowIdx].Tag = st;
                dgData.Rows[rowIdx].Cells[colName.Index].Value = st.Name;
                dgData.Rows[rowIdx].Cells[colKey.Index].Value = st.Key;
                dgData.Rows[rowIdx].Cells[colCreated_by.Index].Value = st.CreatedBy;
                dgData.Rows[rowIdx].Cells[colCreated_by.Index].Style.BackColor = Color.LightGray;
            }
            btnSave.Enabled = true;
        }

        private bool CheckData()
        {
            // 檢查 key ,key+name 不重複
            List<string> check_kn = new List<string>();
            List<string> check_key = new List<string>();
            List<string> check_name = new List<string>();
            bool nullErr = false, knErr = false, keyErr = false, nameErr = false;
            foreach (DataGridViewRow drv in dgData.Rows)
            {
                if (drv.IsNewRow)
                    continue;

                if (drv.Cells[colCreated_by.Index].Value == null)
                {
                    drv.Cells[colCreated_by.Index].Value = _userAccount;
                }

                if (drv.Cells[colName.Index].Value == null || drv.Cells[colKey.Index].Value == null)
                {
                    nullErr = true;
                }
                else
                {
                    string key = "", name = "";
                    if (drv.Cells[colName.Index].Value != null)
                    {
                        name = drv.Cells[colName.Index].Value.ToString();
                    }
                    if (drv.Cells[colKey.Index].Value != null)
                    {
                        key = drv.Cells[colKey.Index].Value.ToString();
                    }

                    if (!check_key.Contains(key))
                    {
                        check_key.Add(key);
                    }
                    else
                    {
                        keyErr = true;
                    }

                    if (!check_name.Contains(name))
                    {
                        check_name.Add(name);
                    }
                    else
                    {
                        nameErr = true;
                    }

                    string kn = key + name;
                    if (!check_kn.Contains(kn))
                    {
                        check_kn.Add(kn);
                    }
                    else
                    {
                        knErr = true;
                    }
                }
            }

            if (nullErr)
            {
                FISCA.Presentation.Controls.MsgBox.Show("空白資料無法儲存。");
                return false;
            }

            if (knErr)
            {
                FISCA.Presentation.Controls.MsgBox.Show("名稱與代號有重複無法儲存。");
                return false;
            }

            if (keyErr)
            {
                FISCA.Presentation.Controls.MsgBox.Show("代號有重複無法儲存。");
                return false;
            }

            if (nameErr)
            {
                FISCA.Presentation.Controls.MsgBox.Show("名稱有重複無法儲存。");
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                try
                {
                    List<string> hasDataUID = new List<string>();
                    List<UDT.ScoreTypes> ScoreTypesList = new List<UDT.ScoreTypes>();
                    List<UDT.ScoreTypes> delDataList = new List<UDT.ScoreTypes>();
                    foreach (DataGridViewRow drv in dgData.Rows)
                    {
                        if (drv.IsNewRow)
                            continue;

                        UDT.ScoreTypes st = drv.Tag as UDT.ScoreTypes;
                        if (st == null)
                        {
                            st = new UDT.ScoreTypes();
                            st.CreatedBy = _userAccount;
                        }
                        else
                        {
                            hasDataUID.Add(st.UID);
                        }
                        st.Name = drv.Cells[colName.Index].Value.ToString();
                        st.Key = drv.Cells[colKey.Index].Value.ToString();
                        st.CreatedBy = drv.Cells[colCreated_by.Index].Value.ToString();
                        ScoreTypesList.Add(st);
                    }

                    // 比對來源元件沒有 uid 需要刪除
                    foreach (var sdata in _ScoreTypesList)
                    {
                        if (!hasDataUID.Contains(sdata.UID))
                            delDataList.Add(sdata);
                    }

                    if (delDataList.Count > 0)
                    {
                        foreach (var data in delDataList)
                        {
                            data.Deleted = true;
                            ScoreTypesList.Add(data);
                        }
                    }

                    ScoreTypesList.SaveAll();
                    FISCA.Presentation.Controls.MsgBox.Show("儲存完成");
                    this.Close();
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("儲存失敗，" + ex.Message);
                    return;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
