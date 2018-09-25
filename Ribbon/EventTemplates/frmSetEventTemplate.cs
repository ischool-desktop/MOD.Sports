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
    public partial class frmSetEventTemplate : BaseForm
    {
        private AccessHelper _access = new AccessHelper();
        private string _userAccount = DAO.Actor.Instance().GetUserAccount();
        bool _isAdd = false;
        UDT.EventTemplates _EventTemplates = null;
        List<UDT.ScoreTypes> _ScoreTypesList = new List<UDT.ScoreTypes>();

        public frmSetEventTemplate()
        {
            InitializeComponent();
        }

        private void frmSetEventTemplate_Load(object sender, EventArgs e)
        {
            cbxScoreType.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadScoreType();

            if (_isAdd)
            {
                _EventTemplates = new UDT.EventTemplates();
            }
            else
            {
                // 編輯模式
                txtCategory.Enabled = txtName.Enabled = false;
                txtCategory.Text = _EventTemplates.Category;
                txtName.Text = _EventTemplates.Name;
                foreach (UDT.ScoreTypes x in _ScoreTypesList)
                {
                    int uid = int.Parse(x.UID);
                    if (uid == _EventTemplates.RefScoreTypeId)
                    {
                        cbxScoreType.Text = x.Name;
                    }
                }
                chkIsTeam.Checked = _EventTemplates.IsTeam;
                chkAthleticOnly.Checked = _EventTemplates.AthleticOnly;
                iptMaxMemberCount.Value = _EventTemplates.MaxMemberCount;
                iptMinMemberCount.Value = _EventTemplates.MinMemberCount;
            }
        }

        public void SetIsAdd(bool value)
        {
            _isAdd = value;
        }

        public void SetEventTemplates(UDT.EventTemplates data)
        {
            _EventTemplates = data;
        }

        public void setScoreTypesList(List<UDT.ScoreTypes> data)
        {
            _ScoreTypesList = data;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void LoadScoreType()
        {
            cbxScoreType.Items.Clear();
            foreach (var x in _ScoreTypesList)
            {
                cbxScoreType.Items.Add(x.Name);
            }
        }

        private bool CheckHasEventTemplates()
        {
            bool value = false;

            string strQry = " category ='" + _EventTemplates.Category + "' AND name ='" + _EventTemplates.Name + "'";
            List<UDT.EventTemplates> dd = _access.Select<UDT.EventTemplates>(strQry);
            if (dd.Count > 0)
                value = true;
            return value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;

                // 檢查資料
                if (iptMaxMemberCount.IsEmpty || iptMinMemberCount.IsEmpty)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("報名人數上限與下限必填。");
                    return;
                }

                if (string.IsNullOrWhiteSpace(cbxScoreType.Text))
                {
                    FISCA.Presentation.Controls.MsgBox.Show("計算方式必填。");
                    return;
                }

                int rstUid = 0;
                foreach (var x in _ScoreTypesList)
                {
                    if (x.Name == cbxScoreType.Text)
                    {
                        rstUid = int.Parse(x.UID);
                    }
                }

                if (rstUid == 0)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("計算方式無法對應，無法儲存。");
                    return;
                }

                _EventTemplates.AthleticOnly = chkAthleticOnly.Checked;
                _EventTemplates.Category = txtCategory.Text;
                _EventTemplates.CreatedBy = _userAccount;
                _EventTemplates.IsTeam = chkIsTeam.Checked;
                _EventTemplates.MaxMemberCount = iptMaxMemberCount.Value;
                _EventTemplates.MinMemberCount = iptMinMemberCount.Value;
                _EventTemplates.Name = txtName.Text;
                _EventTemplates.RefScoreTypeId = rstUid;

                // 有重複名稱無法新增
                if (CheckHasEventTemplates())
                {
                    FISCA.Presentation.Controls.MsgBox.Show("類別+名稱 不能重複。");
                    return;
                }

                _EventTemplates.Save();

                this.DialogResult = DialogResult.OK;              
            }
            catch (Exception ex)
            {
                FISCA.Presentation.Controls.MsgBox.Show("儲存失敗," + ex.Message);
                btnSave.Enabled = true;
                return;
            }
        }
    }
}
