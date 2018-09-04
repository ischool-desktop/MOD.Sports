namespace ischool.Sports
{
    partial class frmRegistrationRecord
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
            this.gp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkByName = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkByEventName = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkByClassName = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgTeamData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblTeamCount = new DevComponents.DotNetBar.LabelX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnDel = new DevComponents.DotNetBar.ButtonX();
            this.iptSchoolYear = new DevComponents.Editors.IntegerInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgPlayerData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblPlayerCount = new DevComponents.DotNetBar.LabelX();
            this.gp1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTeamData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayerData)).BeginInit();
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
            this.labelX1.Location = new System.Drawing.Point(25, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "學年度";
            // 
            // gp1
            // 
            this.gp1.BackColor = System.Drawing.Color.Transparent;
            this.gp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.gp1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp1.Controls.Add(this.chkByName);
            this.gp1.Controls.Add(this.chkByEventName);
            this.gp1.Controls.Add(this.chkByClassName);
            this.gp1.Location = new System.Drawing.Point(449, 23);
            this.gp1.Name = "gp1";
            this.gp1.Size = new System.Drawing.Size(267, 62);
            // 
            // 
            // 
            this.gp1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gp1.Style.BackColorGradientAngle = 90;
            this.gp1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gp1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp1.Style.BorderBottomWidth = 1;
            this.gp1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gp1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp1.Style.BorderLeftWidth = 1;
            this.gp1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp1.Style.BorderRightWidth = 1;
            this.gp1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gp1.Style.BorderTopWidth = 1;
            this.gp1.Style.Class = "";
            this.gp1.Style.CornerDiameter = 4;
            this.gp1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gp1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gp1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gp1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gp1.StyleMouseDown.Class = "";
            this.gp1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gp1.StyleMouseOver.Class = "";
            this.gp1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gp1.TabIndex = 2;
            this.gp1.Text = "查詢方式";
            // 
            // chkByName
            // 
            this.chkByName.AutoSize = true;
            // 
            // 
            // 
            this.chkByName.BackgroundStyle.Class = "";
            this.chkByName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkByName.Location = new System.Drawing.Point(190, 4);
            this.chkByName.Name = "chkByName";
            this.chkByName.Size = new System.Drawing.Size(54, 21);
            this.chkByName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByName.TabIndex = 2;
            this.chkByName.Text = "姓名";
            // 
            // chkByEventName
            // 
            this.chkByEventName.AutoSize = true;
            // 
            // 
            // 
            this.chkByEventName.BackgroundStyle.Class = "";
            this.chkByEventName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkByEventName.Location = new System.Drawing.Point(99, 4);
            this.chkByEventName.Name = "chkByEventName";
            this.chkByEventName.Size = new System.Drawing.Size(80, 21);
            this.chkByEventName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByEventName.TabIndex = 1;
            this.chkByEventName.Text = "競賽項目";
            // 
            // chkByClassName
            // 
            this.chkByClassName.AutoSize = true;
            // 
            // 
            // 
            this.chkByClassName.BackgroundStyle.Class = "";
            this.chkByClassName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkByClassName.Location = new System.Drawing.Point(23, 4);
            this.chkByClassName.Name = "chkByClassName";
            this.chkByClassName.Size = new System.Drawing.Size(54, 21);
            this.chkByClassName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByClassName.TabIndex = 0;
            this.chkByClassName.Text = "班級";
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
            this.labelX2.Location = new System.Drawing.Point(14, 62);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "查詢文字";
            // 
            // txtSearch
            // 
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(79, 60);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(352, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgTeamData
            // 
            this.dgTeamData.AllowUserToAddRows = false;
            this.dgTeamData.AllowUserToDeleteRows = false;
            this.dgTeamData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTeamData.BackgroundColor = System.Drawing.Color.White;
            this.dgTeamData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTeamData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCategory,
            this.colEventItem,
            this.colGroupType,
            this.colTeamName});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTeamData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgTeamData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgTeamData.Location = new System.Drawing.Point(14, 129);
            this.dgTeamData.Name = "dgTeamData";
            this.dgTeamData.RowTemplate.Height = 24;
            this.dgTeamData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTeamData.Size = new System.Drawing.Size(842, 149);
            this.dgTeamData.TabIndex = 1;
            this.dgTeamData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgTeamData_MouseClick);
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "競賽類別";
            this.colCategory.Name = "colCategory";
            // 
            // colEventItem
            // 
            this.colEventItem.HeaderText = "競賽項目";
            this.colEventItem.Name = "colEventItem";
            // 
            // colGroupType
            // 
            this.colGroupType.HeaderText = "參賽組別";
            this.colGroupType.Name = "colGroupType";
            // 
            // colTeamName
            // 
            this.colTeamName.HeaderText = "隊名";
            this.colTeamName.Name = "colTeamName";
            this.colTeamName.Width = 150;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(781, 550);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTeamCount
            // 
            this.lblTeamCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTeamCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTeamCount.BackgroundStyle.Class = "";
            this.lblTeamCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTeamCount.Location = new System.Drawing.Point(752, 100);
            this.lblTeamCount.Name = "lblTeamCount";
            this.lblTeamCount.Size = new System.Drawing.Size(104, 18);
            this.lblTeamCount.TabIndex = 8;
            this.lblTeamCount.Text = "107";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(449, 550);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Location = new System.Drawing.Point(551, 550);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 25);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "修改";
            // 
            // btnDel
            // 
            this.btnDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.AutoSize = true;
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDel.Location = new System.Drawing.Point(655, 550);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "刪除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // iptSchoolYear
            // 
            this.iptSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.iptSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iptSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iptSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iptSchoolYear.Location = new System.Drawing.Point(79, 21);
            this.iptSchoolYear.Name = "iptSchoolYear";
            this.iptSchoolYear.ShowUpDown = true;
            this.iptSchoolYear.Size = new System.Drawing.Size(92, 25);
            this.iptSchoolYear.TabIndex = 9;
            this.iptSchoolYear.ValueChanged += new System.EventHandler(this.iptSchoolYear_ValueChanged);
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
            this.labelX3.Location = new System.Drawing.Point(14, 100);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(34, 21);
            this.labelX3.TabIndex = 10;
            this.labelX3.Text = "隊伍";
            // 
            // dgPlayerData
            // 
            this.dgPlayerData.AllowUserToAddRows = false;
            this.dgPlayerData.AllowUserToDeleteRows = false;
            this.dgPlayerData.BackgroundColor = System.Drawing.Color.White;
            this.dgPlayerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlayerData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClassName,
            this.colSeatNo,
            this.colName,
            this.colRegDate,
            this.colRegAccount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPlayerData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPlayerData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgPlayerData.Location = new System.Drawing.Point(14, 316);
            this.dgPlayerData.Name = "dgPlayerData";
            this.dgPlayerData.RowTemplate.Height = 24;
            this.dgPlayerData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayerData.Size = new System.Drawing.Size(842, 218);
            this.dgPlayerData.TabIndex = 11;
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
            // 
            // colName
            // 
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            // 
            // colRegDate
            // 
            this.colRegDate.HeaderText = "報名時間";
            this.colRegDate.Name = "colRegDate";
            // 
            // colRegAccount
            // 
            this.colRegAccount.HeaderText = "報名者帳號";
            this.colRegAccount.Name = "colRegAccount";
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
            this.labelX4.Location = new System.Drawing.Point(14, 289);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 12;
            this.labelX4.Text = "隊員";
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPlayerCount.BackgroundStyle.Class = "";
            this.lblPlayerCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPlayerCount.Location = new System.Drawing.Point(752, 290);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(104, 18);
            this.lblPlayerCount.TabIndex = 13;
            this.lblPlayerCount.Text = "107";
            // 
            // frmRegistrationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 598);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.dgPlayerData);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.iptSchoolYear);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTeamCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgTeamData);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.gp1);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmRegistrationRecord";
            this.Text = "管理報名記錄";
            this.Load += new System.EventHandler(this.frmRegistrationRecord_Load);
            this.gp1.ResumeLayout(false);
            this.gp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTeamData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel gp1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgTeamData;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByEventName;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByClassName;
        private DevComponents.DotNetBar.LabelX lblTeamCount;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnDel;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByName;
        private DevComponents.Editors.IntegerInput iptSchoolYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeamName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgPlayerData;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegAccount;
        private DevComponents.DotNetBar.LabelX lblPlayerCount;
    }
}