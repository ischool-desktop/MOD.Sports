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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.colSchoolYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaxMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMinMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsDrawLots = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDrawLotsDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlthleticOnly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.colEventName,
            this.colEventItem,
            this.colEventStartDate,
            this.colEventEndDate,
            this.colRegStartDate,
            this.colRegEndDate,
            this.colGroupType,
            this.colEventCategory,
            this.colMaxMember,
            this.colMinMember,
            this.colGameType,
            this.colIsTeam,
            this.colIsDrawLots,
            this.colDrawLotsDate,
            this.colEventDesc,
            this.colAlthleticOnly,
            this.colCreatedBy});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgData.Location = new System.Drawing.Point(22, 23);
            this.dgData.Name = "dgData";
            this.dgData.RowTemplate.Height = 24;
            this.dgData.Size = new System.Drawing.Size(1052, 311);
            this.dgData.TabIndex = 0;
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
            // colSchoolYear
            // 
            this.colSchoolYear.HeaderText = "學年度";
            this.colSchoolYear.Name = "colSchoolYear";
            // 
            // colEventName
            // 
            this.colEventName.HeaderText = "競賽名稱";
            this.colEventName.Name = "colEventName";
            // 
            // colEventItem
            // 
            this.colEventItem.HeaderText = "競賽項目";
            this.colEventItem.Name = "colEventItem";
            // 
            // colEventStartDate
            // 
            this.colEventStartDate.HeaderText = "活動開始日期";
            this.colEventStartDate.Name = "colEventStartDate";
            // 
            // colEventEndDate
            // 
            this.colEventEndDate.HeaderText = "活動結束日期";
            this.colEventEndDate.Name = "colEventEndDate";
            // 
            // colRegStartDate
            // 
            this.colRegStartDate.HeaderText = "報名開始日期";
            this.colRegStartDate.Name = "colRegStartDate";
            // 
            // colRegEndDate
            // 
            this.colRegEndDate.HeaderText = "報名結束日期";
            this.colRegEndDate.Name = "colRegEndDate";
            // 
            // colGroupType
            // 
            this.colGroupType.HeaderText = "參賽組別";
            this.colGroupType.Name = "colGroupType";
            // 
            // colEventCategory
            // 
            this.colEventCategory.HeaderText = "競賽類型";
            this.colEventCategory.Name = "colEventCategory";
            // 
            // colMaxMember
            // 
            this.colMaxMember.HeaderText = "報名人數上限";
            this.colMaxMember.Name = "colMaxMember";
            // 
            // colMinMember
            // 
            this.colMinMember.HeaderText = "報名人數下限";
            this.colMinMember.Name = "colMinMember";
            // 
            // colGameType
            // 
            this.colGameType.HeaderText = "賽制";
            this.colGameType.Name = "colGameType";
            // 
            // colIsTeam
            // 
            this.colIsTeam.HeaderText = "是否團體賽";
            this.colIsTeam.Name = "colIsTeam";
            // 
            // colIsDrawLots
            // 
            this.colIsDrawLots.HeaderText = "是否抽籤";
            this.colIsDrawLots.Name = "colIsDrawLots";
            // 
            // colDrawLotsDate
            // 
            this.colDrawLotsDate.HeaderText = "抽籤時間";
            this.colDrawLotsDate.Name = "colDrawLotsDate";
            // 
            // colEventDesc
            // 
            this.colEventDesc.HeaderText = "競賽說明";
            this.colEventDesc.Name = "colEventDesc";
            // 
            // colAlthleticOnly
            // 
            this.colAlthleticOnly.HeaderText = "僅體育股長報名";
            this.colAlthleticOnly.Name = "colAlthleticOnly";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.HeaderText = "建立者";
            this.colCreatedBy.Name = "colCreatedBy";
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 400);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgData);
            this.DoubleBuffered = true;
            this.Name = "frmEvents";
            this.Text = "管理競賽";
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dgData;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaxMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMinMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsDrawLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDrawLotsDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlthleticOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedBy;
    }
}