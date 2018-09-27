namespace ischool.Sports
{
    partial class frmEvents
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsDrawLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawLotsStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawLotsEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlthleticOnly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnouncementDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnCopyItem = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgData
            // 
            this.dgData.AllowUserToAddRows = false;
            this.dgData.AllowUserToDeleteRows = false;
            this.dgData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSchoolYear,
            this.colEventCategory,
            this.colEventName,
            this.colGroupType,
            this.colEventStartDate,
            this.colEventEndDate,
            this.colGameType,
            this.colRegStartDate,
            this.colRegEndDate,
            this.colMaxMember,
            this.colMinMember,
            this.colIsTeam,
            this.colIsDrawLots,
            this.colDrawLotsStartDate,
            this.colDrawLotsEndDate,
            this.colEventDesc,
            this.colAlthleticOnly,
            this.colCreatedBy,
            this.colAnnouncementDate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgData.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgData.Location = new System.Drawing.Point(22, 23);
            this.dgData.MultiSelect = false;
            this.dgData.Name = "dgData";
            this.dgData.RowTemplate.Height = 24;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(1052, 311);
            this.dgData.TabIndex = 0;
            // 
            // colSchoolYear
            // 
            this.colSchoolYear.HeaderText = "學年度";
            this.colSchoolYear.Name = "colSchoolYear";
            this.colSchoolYear.ReadOnly = true;
            // 
            // colEventCategory
            // 
            this.colEventCategory.HeaderText = "競賽類別";
            this.colEventCategory.Name = "colEventCategory";
            this.colEventCategory.ReadOnly = true;
            // 
            // colEventName
            // 
            this.colEventName.HeaderText = "競賽名稱";
            this.colEventName.Name = "colEventName";
            this.colEventName.ReadOnly = true;
            // 
            // colGroupType
            // 
            this.colGroupType.HeaderText = "參賽組別";
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.ReadOnly = true;
            // 
            // colEventStartDate
            // 
            this.colEventStartDate.HeaderText = "活動開始日期";
            this.colEventStartDate.Name = "colEventStartDate";
            this.colEventStartDate.ReadOnly = true;
            // 
            // colEventEndDate
            // 
            this.colEventEndDate.HeaderText = "活動結束日期";
            this.colEventEndDate.Name = "colEventEndDate";
            this.colEventEndDate.ReadOnly = true;
            // 
            // colGameType
            // 
            this.colGameType.HeaderText = "賽制";
            this.colGameType.Name = "colGameType";
            this.colGameType.ReadOnly = true;
            // 
            // colRegStartDate
            // 
            this.colRegStartDate.HeaderText = "報名開始日期";
            this.colRegStartDate.Name = "colRegStartDate";
            this.colRegStartDate.ReadOnly = true;
            // 
            // colRegEndDate
            // 
            this.colRegEndDate.HeaderText = "報名結束日期";
            this.colRegEndDate.Name = "colRegEndDate";
            this.colRegEndDate.ReadOnly = true;
            // 
            // colMaxMember
            // 
            this.colMaxMember.HeaderText = "報名人數上限";
            this.colMaxMember.Name = "colMaxMember";
            this.colMaxMember.ReadOnly = true;
            // 
            // colMinMember
            // 
            this.colMinMember.HeaderText = "報名人數下限";
            this.colMinMember.Name = "colMinMember";
            this.colMinMember.ReadOnly = true;
            // 
            // colIsTeam
            // 
            this.colIsTeam.HeaderText = "是否團體賽";
            this.colIsTeam.Name = "colIsTeam";
            this.colIsTeam.ReadOnly = true;
            // 
            // colIsDrawLots
            // 
            this.colIsDrawLots.HeaderText = "是否抽籤";
            this.colIsDrawLots.Name = "colIsDrawLots";
            this.colIsDrawLots.ReadOnly = true;
            // 
            // colDrawLotsStartDate
            // 
            this.colDrawLotsStartDate.HeaderText = "抽籤開始日期";
            this.colDrawLotsStartDate.Name = "colDrawLotsStartDate";
            this.colDrawLotsStartDate.ReadOnly = true;
            // 
            // colDrawLotsEndDate
            // 
            this.colDrawLotsEndDate.HeaderText = "抽籤結束日期";
            this.colDrawLotsEndDate.Name = "colDrawLotsEndDate";
            this.colDrawLotsEndDate.ReadOnly = true;
            // 
            // colEventDesc
            // 
            this.colEventDesc.HeaderText = "競賽說明";
            this.colEventDesc.Name = "colEventDesc";
            this.colEventDesc.ReadOnly = true;
            // 
            // colAlthleticOnly
            // 
            this.colAlthleticOnly.HeaderText = "僅體育股長報名";
            this.colAlthleticOnly.Name = "colAlthleticOnly";
            this.colAlthleticOnly.ReadOnly = true;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.HeaderText = "建立者";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.ReadOnly = true;
            // 
            // colAnnouncementDate
            // 
            this.colAnnouncementDate.HeaderText = "公告日期";
            this.colAnnouncementDate.Name = "colAnnouncementDate";
            this.colAnnouncementDate.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(695, 356);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Location = new System.Drawing.Point(797, 356);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "修改";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(895, 356);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "刪除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(999, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopyItem
            // 
            this.btnCopyItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopyItem.AutoSize = true;
            this.btnCopyItem.BackColor = System.Drawing.Color.Transparent;
            this.btnCopyItem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopyItem.Location = new System.Drawing.Point(22, 356);
            this.btnCopyItem.Name = "btnCopyItem";
            this.btnCopyItem.Size = new System.Drawing.Size(91, 25);
            this.btnCopyItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCopyItem.TabIndex = 5;
            this.btnCopyItem.Text = "複製競賽項目";
            this.btnCopyItem.Click += new System.EventHandler(this.btnCopyItem_Click);
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 400);
            this.Controls.Add(this.btnCopyItem);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgData);
            this.DoubleBuffered = true;
            this.Name = "frmEvents";
            this.Text = "管理競賽";
            this.Load += new System.EventHandler(this.frmEvents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgData;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsDrawLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawLotsStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawLotsEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlthleticOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnouncementDate;
        private DevComponents.DotNetBar.ButtonX btnCopyItem;
    }
}