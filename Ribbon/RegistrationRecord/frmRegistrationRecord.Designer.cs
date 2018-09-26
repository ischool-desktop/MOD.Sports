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
            this.dgTeamData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEventItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeamLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.iptSchoolYear = new DevComponents.Editors.IntegerInput();
            this.lblTeamCount = new DevComponents.DotNetBar.LabelX();
            this.dgPlayerData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlayerLotNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPlayerCount = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbxEventItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbxClassName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnAddTeam = new DevComponents.DotNetBar.ButtonX();
            this.btnEditTeam = new DevComponents.DotNetBar.ButtonX();
            this.btnDelTeam = new DevComponents.DotNetBar.ButtonX();
            this.btnAddPlayer = new DevComponents.DotNetBar.ButtonX();
            this.btnEditPlayer = new DevComponents.DotNetBar.ButtonX();
            this.btnDelPlayer = new DevComponents.DotNetBar.ButtonX();
            this.lblTeamType = new DevComponents.DotNetBar.LabelX();
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
            // dgTeamData
            // 
            this.dgTeamData.AllowUserToAddRows = false;
            this.dgTeamData.AllowUserToDeleteRows = false;
            this.dgTeamData.BackgroundColor = System.Drawing.Color.White;
            this.dgTeamData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTeamData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventItem,
            this.colGroupType,
            this.colTeamName,
            this.colTeamLotNo,
            this.colCategory});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTeamData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgTeamData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgTeamData.Location = new System.Drawing.Point(22, 100);
            this.dgTeamData.MultiSelect = false;
            this.dgTeamData.Name = "dgTeamData";
            this.dgTeamData.RowTemplate.Height = 24;
            this.dgTeamData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTeamData.Size = new System.Drawing.Size(500, 401);
            this.dgTeamData.TabIndex = 1;
            this.dgTeamData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgTeamData_MouseClick);
            // 
            // colEventItem
            // 
            this.colEventItem.HeaderText = "競賽項目";
            this.colEventItem.Name = "colEventItem";
            this.colEventItem.ReadOnly = true;
            // 
            // colGroupType
            // 
            this.colGroupType.HeaderText = "參賽組別";
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.ReadOnly = true;
            // 
            // colTeamName
            // 
            this.colTeamName.HeaderText = "隊名";
            this.colTeamName.Name = "colTeamName";
            this.colTeamName.ReadOnly = true;
            this.colTeamName.Width = 150;
            // 
            // colTeamLotNo
            // 
            this.colTeamLotNo.HeaderText = "抽籤號";
            this.colTeamLotNo.Name = "colTeamLotNo";
            this.colTeamLotNo.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "競賽類別";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(1091, 518);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            // lblTeamCount
            // 
            this.lblTeamCount.AutoSize = true;
            this.lblTeamCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTeamCount.BackgroundStyle.Class = "";
            this.lblTeamCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTeamCount.Location = new System.Drawing.Point(22, 71);
            this.lblTeamCount.Name = "lblTeamCount";
            this.lblTeamCount.Size = new System.Drawing.Size(34, 21);
            this.lblTeamCount.TabIndex = 10;
            this.lblTeamCount.Text = "隊伍";
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
            this.colPlayerLotNo,
            this.colLeader,
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
            this.dgPlayerData.Location = new System.Drawing.Point(550, 103);
            this.dgPlayerData.MultiSelect = false;
            this.dgPlayerData.Name = "dgPlayerData";
            this.dgPlayerData.RowTemplate.Height = 24;
            this.dgPlayerData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPlayerData.Size = new System.Drawing.Size(613, 398);
            this.dgPlayerData.TabIndex = 11;
            this.dgPlayerData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgPlayerData_MouseClick);
            // 
            // colClassName
            // 
            this.colClassName.HeaderText = "班級";
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            // 
            // colSeatNo
            // 
            this.colSeatNo.HeaderText = "座號";
            this.colSeatNo.Name = "colSeatNo";
            this.colSeatNo.ReadOnly = true;
            this.colSeatNo.Width = 70;
            // 
            // colName
            // 
            this.colName.HeaderText = "姓名";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colPlayerLotNo
            // 
            this.colPlayerLotNo.HeaderText = "抽籤號";
            this.colPlayerLotNo.Name = "colPlayerLotNo";
            this.colPlayerLotNo.ReadOnly = true;
            // 
            // colLeader
            // 
            this.colLeader.HeaderText = "隊長";
            this.colLeader.Name = "colLeader";
            this.colLeader.ReadOnly = true;
            // 
            // colRegDate
            // 
            this.colRegDate.HeaderText = "報名時間";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.ReadOnly = true;
            // 
            // colRegAccount
            // 
            this.colRegAccount.HeaderText = "報名者帳號";
            this.colRegAccount.Name = "colRegAccount";
            this.colRegAccount.ReadOnly = true;
            this.colRegAccount.Width = 200;
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPlayerCount.BackgroundStyle.Class = "";
            this.lblPlayerCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPlayerCount.Location = new System.Drawing.Point(550, 69);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(60, 21);
            this.lblPlayerCount.TabIndex = 12;
            this.lblPlayerCount.Text = "參賽人員";
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
            this.labelX2.Location = new System.Drawing.Point(199, 23);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(60, 21);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "競賽項目";
            // 
            // cbxEventItem
            // 
            this.cbxEventItem.DisplayMember = "Text";
            this.cbxEventItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxEventItem.FormattingEnabled = true;
            this.cbxEventItem.ItemHeight = 19;
            this.cbxEventItem.Location = new System.Drawing.Point(266, 21);
            this.cbxEventItem.Name = "cbxEventItem";
            this.cbxEventItem.Size = new System.Drawing.Size(256, 25);
            this.cbxEventItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxEventItem.TabIndex = 15;
            this.cbxEventItem.WatermarkText = "請選擇競賽項目";
            this.cbxEventItem.SelectedIndexChanged += new System.EventHandler(this.cbxEventItem_SelectedIndexChanged);
            // 
            // cbxClassName
            // 
            this.cbxClassName.DisplayMember = "Text";
            this.cbxClassName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxClassName.FormattingEnabled = true;
            this.cbxClassName.ItemHeight = 19;
            this.cbxClassName.Location = new System.Drawing.Point(694, 21);
            this.cbxClassName.Name = "cbxClassName";
            this.cbxClassName.Size = new System.Drawing.Size(156, 25);
            this.cbxClassName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxClassName.TabIndex = 17;
            this.cbxClassName.WatermarkText = "請選班級名稱";
            this.cbxClassName.SelectedIndexChanged += new System.EventHandler(this.cbxClassName_SelectedIndexChanged);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(654, 23);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(34, 21);
            this.labelX5.TabIndex = 16;
            this.labelX5.Text = "班級";
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddTeam.AutoSize = true;
            this.btnAddTeam.BackColor = System.Drawing.Color.Transparent;
            this.btnAddTeam.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddTeam.Location = new System.Drawing.Point(247, 518);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(75, 25);
            this.btnAddTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddTeam.TabIndex = 19;
            this.btnAddTeam.Text = "新增隊伍";
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // btnEditTeam
            // 
            this.btnEditTeam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditTeam.AutoSize = true;
            this.btnEditTeam.BackColor = System.Drawing.Color.Transparent;
            this.btnEditTeam.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditTeam.Location = new System.Drawing.Point(343, 518);
            this.btnEditTeam.Name = "btnEditTeam";
            this.btnEditTeam.Size = new System.Drawing.Size(75, 25);
            this.btnEditTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditTeam.TabIndex = 20;
            this.btnEditTeam.Text = "修改隊伍";
            this.btnEditTeam.Click += new System.EventHandler(this.btnEditTeam_Click);
            // 
            // btnDelTeam
            // 
            this.btnDelTeam.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelTeam.AutoSize = true;
            this.btnDelTeam.BackColor = System.Drawing.Color.Transparent;
            this.btnDelTeam.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelTeam.Location = new System.Drawing.Point(435, 518);
            this.btnDelTeam.Name = "btnDelTeam";
            this.btnDelTeam.Size = new System.Drawing.Size(75, 25);
            this.btnDelTeam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelTeam.TabIndex = 21;
            this.btnDelTeam.Text = "刪除隊伍";
            this.btnDelTeam.Click += new System.EventHandler(this.btnDelTeam_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddPlayer.AutoSize = true;
            this.btnAddPlayer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPlayer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddPlayer.Location = new System.Drawing.Point(807, 518);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 25);
            this.btnAddPlayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddPlayer.TabIndex = 22;
            this.btnAddPlayer.Text = "新增人員";
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnEditPlayer
            // 
            this.btnEditPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEditPlayer.AutoSize = true;
            this.btnEditPlayer.BackColor = System.Drawing.Color.Transparent;
            this.btnEditPlayer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEditPlayer.Location = new System.Drawing.Point(901, 518);
            this.btnEditPlayer.Name = "btnEditPlayer";
            this.btnEditPlayer.Size = new System.Drawing.Size(75, 25);
            this.btnEditPlayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEditPlayer.TabIndex = 23;
            this.btnEditPlayer.Text = "修改人員";
            this.btnEditPlayer.Click += new System.EventHandler(this.btnEditPlayer_Click);
            // 
            // btnDelPlayer
            // 
            this.btnDelPlayer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelPlayer.AutoSize = true;
            this.btnDelPlayer.BackColor = System.Drawing.Color.Transparent;
            this.btnDelPlayer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelPlayer.Location = new System.Drawing.Point(995, 518);
            this.btnDelPlayer.Name = "btnDelPlayer";
            this.btnDelPlayer.Size = new System.Drawing.Size(75, 25);
            this.btnDelPlayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDelPlayer.TabIndex = 24;
            this.btnDelPlayer.Text = "刪除人員";
            this.btnDelPlayer.Click += new System.EventHandler(this.btnDelPlayer_Click);
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
            this.lblTeamType.Location = new System.Drawing.Point(550, 23);
            this.lblTeamType.Name = "lblTeamType";
            this.lblTeamType.Size = new System.Drawing.Size(47, 21);
            this.lblTeamType.TabIndex = 25;
            this.lblTeamType.Text = "團體賽";
            // 
            // frmRegistrationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 558);
            this.Controls.Add(this.lblTeamType);
            this.Controls.Add(this.btnDelPlayer);
            this.Controls.Add(this.btnEditPlayer);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.btnDelTeam);
            this.Controls.Add(this.btnEditTeam);
            this.Controls.Add(this.btnAddTeam);
            this.Controls.Add(this.cbxClassName);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.cbxEventItem);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.dgPlayerData);
            this.Controls.Add(this.lblTeamCount);
            this.Controls.Add(this.iptSchoolYear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgTeamData);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmRegistrationRecord";
            this.Text = "管理報名記錄";
            this.Load += new System.EventHandler(this.frmRegistrationRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTeamData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlayerData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgTeamData;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.Editors.IntegerInput iptSchoolYear;
        private DevComponents.DotNetBar.LabelX lblTeamCount;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgPlayerData;
        private DevComponents.DotNetBar.LabelX lblPlayerCount;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxEventItem;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxClassName;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX btnAddTeam;
        private DevComponents.DotNetBar.ButtonX btnEditTeam;
        private DevComponents.DotNetBar.ButtonX btnDelTeam;
        private DevComponents.DotNetBar.ButtonX btnAddPlayer;
        private DevComponents.DotNetBar.ButtonX btnEditPlayer;
        private DevComponents.DotNetBar.ButtonX btnDelPlayer;
        private DevComponents.DotNetBar.LabelX lblTeamType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeamLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlayerLotNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegAccount;
    }
}