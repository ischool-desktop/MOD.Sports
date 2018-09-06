namespace ischool.Sports
{
    partial class frmSubAddRegistrationRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtTeamName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cbxEventCategory = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxEventName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgSearch = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelPlayerCount = new DevComponents.DotNetBar.LabelX();
            this.dgSelectedStudent = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colSelClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSelAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddMember = new DevComponents.DotNetBar.ButtonX();
            this.btnRemoveMember = new DevComponents.DotNetBar.ButtonX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblTeamType = new DevComponents.DotNetBar.LabelX();
            this.lblMinCount = new DevComponents.DotNetBar.LabelX();
            this.lblMaxCount = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(27, 30);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "競賽類別";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(385, 30);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "競賽項目";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(53, 72);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "隊名";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(27, 114);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(60, 21);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "查詢文字";
            // 
            // txtTeamName
            // 
            // 
            // 
            // 
            this.txtTeamName.Border.Class = "TextBoxBorder";
            this.txtTeamName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTeamName.Location = new System.Drawing.Point(93, 70);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(259, 25);
            this.txtTeamName.TabIndex = 2;
            this.txtTeamName.WatermarkText = "請輸入隊名";
            // 
            // cbxEventCategory
            // 
            this.cbxEventCategory.DisplayMember = "Text";
            this.cbxEventCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxEventCategory.FormattingEnabled = true;
            this.cbxEventCategory.ItemHeight = 19;
            this.cbxEventCategory.Location = new System.Drawing.Point(93, 28);
            this.cbxEventCategory.Name = "cbxEventCategory";
            this.cbxEventCategory.Size = new System.Drawing.Size(259, 25);
            this.cbxEventCategory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxEventCategory.TabIndex = 0;
            this.cbxEventCategory.WatermarkText = "請選競賽類別";
            this.cbxEventCategory.SelectedIndexChanged += new System.EventHandler(this.cbxEventCategory_SelectedIndexChanged);
            // 
            // cbxEventName
            // 
            this.cbxEventName.DisplayMember = "Text";
            this.cbxEventName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxEventName.FormattingEnabled = true;
            this.cbxEventName.ItemHeight = 19;
            this.cbxEventName.Location = new System.Drawing.Point(451, 28);
            this.cbxEventName.Name = "cbxEventName";
            this.cbxEventName.Size = new System.Drawing.Size(259, 25);
            this.cbxEventName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxEventName.TabIndex = 1;
            this.cbxEventName.WatermarkText = "請選競賽項目";
            this.cbxEventName.SelectedIndexChanged += new System.EventHandler(this.cbxEventName_SelectedIndexChanged);
            // 
            // dgSearch
            // 
            this.dgSearch.AllowUserToAddRows = false;
            this.dgSearch.AllowUserToDeleteRows = false;
            this.dgSearch.AllowUserToResizeRows = false;
            this.dgSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClassName,
            this.colSeatNo,
            this.colName,
            this.colAccount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSearch.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSearch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSearch.Location = new System.Drawing.Point(27, 150);
            this.dgSearch.Name = "dgSearch";
            this.dgSearch.RowTemplate.Height = 24;
            this.dgSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSearch.Size = new System.Drawing.Size(683, 130);
            this.dgSearch.TabIndex = 4;
            // 
            // colClassName
            // 
            this.colClassName.HeaderText = "班級";
            this.colClassName.Name = "colClassName";
            // 
            // colSeatNo
            // 
            this.colSeatNo.HeaderText = "座號";
            this.colSeatNo.Name = "colSeatNo";
            this.colSeatNo.Width = 70;
            // 
            // colName
            // 
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            // 
            // colAccount
            // 
            this.colAccount.HeaderText = "帳號";
            this.colAccount.Name = "colAccount";
            this.colAccount.Width = 200;
            // 
            // lblSelPlayerCount
            // 
            this.lblSelPlayerCount.AutoSize = true;
            this.lblSelPlayerCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSelPlayerCount.BackgroundStyle.Class = "";
            this.lblSelPlayerCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSelPlayerCount.Location = new System.Drawing.Point(36, 316);
            this.lblSelPlayerCount.Name = "lblSelPlayerCount";
            this.lblSelPlayerCount.Size = new System.Drawing.Size(60, 21);
            this.lblSelPlayerCount.TabIndex = 8;
            this.lblSelPlayerCount.Text = "已選隊員";
            // 
            // dgSelectedStudent
            // 
            this.dgSelectedStudent.AllowUserToAddRows = false;
            this.dgSelectedStudent.AllowUserToDeleteRows = false;
            this.dgSelectedStudent.AllowUserToResizeRows = false;
            this.dgSelectedStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgSelectedStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSelectedStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelClassName,
            this.colSelSeatNo,
            this.colSelName,
            this.colSelAccount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSelectedStudent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgSelectedStudent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSelectedStudent.Location = new System.Drawing.Point(32, 343);
            this.dgSelectedStudent.Name = "dgSelectedStudent";
            this.dgSelectedStudent.RowTemplate.Height = 24;
            this.dgSelectedStudent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSelectedStudent.Size = new System.Drawing.Size(683, 156);
            this.dgSelectedStudent.TabIndex = 6;
            // 
            // colSelClassName
            // 
            this.colSelClassName.HeaderText = "班級";
            this.colSelClassName.Name = "colSelClassName";
            // 
            // colSelSeatNo
            // 
            this.colSelSeatNo.HeaderText = "座號";
            this.colSelSeatNo.Name = "colSelSeatNo";
            this.colSelSeatNo.Width = 70;
            // 
            // colSelName
            // 
            this.colSelName.HeaderText = "姓名";
            this.colSelName.Name = "colSelName";
            // 
            // colSelAccount
            // 
            this.colSelAccount.HeaderText = "帳號";
            this.colSelAccount.Name = "colSelAccount";
            this.colSelAccount.Width = 200;
            // 
            // btnAddMember
            // 
            this.btnAddMember.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddMember.AutoSize = true;
            this.btnAddMember.BackColor = System.Drawing.Color.Transparent;
            this.btnAddMember.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddMember.Location = new System.Drawing.Point(635, 286);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(75, 25);
            this.btnAddMember.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddMember.TabIndex = 5;
            this.btnAddMember.Text = "加入隊員";
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // btnRemoveMember
            // 
            this.btnRemoveMember.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemoveMember.AutoSize = true;
            this.btnRemoveMember.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveMember.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemoveMember.Location = new System.Drawing.Point(640, 505);
            this.btnRemoveMember.Name = "btnRemoveMember";
            this.btnRemoveMember.Size = new System.Drawing.Size(75, 25);
            this.btnRemoveMember.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemoveMember.TabIndex = 7;
            this.btnRemoveMember.Text = "移除隊員";
            this.btnRemoveMember.Click += new System.EventHandler(this.btnRemoveMember_Click);
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(93, 112);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(508, 25);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.WatermarkText = "請輸入班級或姓名";
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(451, 545);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(558, 545);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTeamType
            // 
            this.lblTeamType.AutoSize = true;
            this.lblTeamType.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTeamType.BackgroundStyle.Class = "";
            this.lblTeamType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTeamType.Location = new System.Drawing.Point(385, 72);
            this.lblTeamType.Name = "lblTeamType";
            this.lblTeamType.Size = new System.Drawing.Size(47, 21);
            this.lblTeamType.TabIndex = 10;
            this.lblTeamType.Text = "個人賽";
            // 
            // lblMinCount
            // 
            this.lblMinCount.AutoSize = true;
            this.lblMinCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMinCount.BackgroundStyle.Class = "";
            this.lblMinCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMinCount.Location = new System.Drawing.Point(471, 72);
            this.lblMinCount.Name = "lblMinCount";
            this.lblMinCount.Size = new System.Drawing.Size(55, 21);
            this.lblMinCount.TabIndex = 11;
            this.lblMinCount.Text = "最少1人";
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblMaxCount.BackgroundStyle.Class = "";
            this.lblMaxCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMaxCount.Location = new System.Drawing.Point(558, 72);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(55, 21);
            this.lblMaxCount.TabIndex = 12;
            this.lblMaxCount.Text = "最多1人";
            // 
            // frmSubAddRegistrationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 579);
            this.Controls.Add(this.lblMaxCount);
            this.Controls.Add(this.lblMinCount);
            this.Controls.Add(this.lblTeamType);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRemoveMember);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.dgSelectedStudent);
            this.Controls.Add(this.lblSelPlayerCount);
            this.Controls.Add(this.dgSearch);
            this.Controls.Add(this.cbxEventName);
            this.Controls.Add(this.cbxEventCategory);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmSubAddRegistrationRecord";
            this.Text = "新增報名單";
            this.Load += new System.EventHandler(this.frmSubAddRegistrationRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSelectedStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTeamName;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxEventCategory;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxEventName;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSearch;
        private DevComponents.DotNetBar.LabelX lblSelPlayerCount;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSelectedStudent;
        private DevComponents.DotNetBar.ButtonX btnAddMember;
        private DevComponents.DotNetBar.ButtonX btnRemoveMember;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSelAccount;
        private DevComponents.DotNetBar.LabelX lblTeamType;
        private DevComponents.DotNetBar.LabelX lblMaxCount;
        private DevComponents.DotNetBar.LabelX lblMinCount;
    }
}