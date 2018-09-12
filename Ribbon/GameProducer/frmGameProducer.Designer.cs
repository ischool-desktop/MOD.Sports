namespace ischool.Sports
{
    partial class frmGameProducer
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.iptSchoolYear = new DevComponents.Editors.IntegerInput();
            this.lblPlayerCount = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.cbxGameType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnRun = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.cbxEventItem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.colRoundNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGameNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOccurTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.iptSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
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
            this.labelX1.Location = new System.Drawing.Point(24, 24);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "學年度";
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
            this.iptSchoolYear.Location = new System.Drawing.Point(77, 22);
            this.iptSchoolYear.MaxValue = 9999;
            this.iptSchoolYear.MinValue = 1;
            this.iptSchoolYear.Name = "iptSchoolYear";
            this.iptSchoolYear.ShowUpDown = true;
            this.iptSchoolYear.Size = new System.Drawing.Size(80, 25);
            this.iptSchoolYear.TabIndex = 1;
            this.iptSchoolYear.Value = 1;
            this.iptSchoolYear.ValueChanged += new System.EventHandler(this.iptSchoolYear_ValueChanged);
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
            this.lblPlayerCount.Location = new System.Drawing.Point(779, 22);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(106, 21);
            this.lblPlayerCount.TabIndex = 2;
            this.lblPlayerCount.Text = "參賽隊伍/人員數";
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
            this.labelX4.Location = new System.Drawing.Point(541, 22);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(34, 21);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "賽制";
            // 
            // cbxGameType
            // 
            this.cbxGameType.DisplayMember = "Text";
            this.cbxGameType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxGameType.FormattingEnabled = true;
            this.cbxGameType.ItemHeight = 19;
            this.cbxGameType.Location = new System.Drawing.Point(591, 20);
            this.cbxGameType.Name = "cbxGameType";
            this.cbxGameType.Size = new System.Drawing.Size(172, 25);
            this.cbxGameType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxGameType.TabIndex = 7;
            // 
            // dgData
            // 
            this.dgData.BackgroundColor = System.Drawing.Color.White;
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRoundNo,
            this.colGameNo,
            this.colTeam1,
            this.colTeam2,
            this.colOccurTime,
            this.colPlace});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgData.Location = new System.Drawing.Point(24, 98);
            this.dgData.Name = "dgData";
            this.dgData.RowTemplate.Height = 24;
            this.dgData.Size = new System.Drawing.Size(861, 330);
            this.dgData.TabIndex = 8;
            // 
            // btnRun
            // 
            this.btnRun.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRun.AutoSize = true;
            this.btnRun.BackColor = System.Drawing.Color.Transparent;
            this.btnRun.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRun.Location = new System.Drawing.Point(801, 67);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 25);
            this.btnRun.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRun.TabIndex = 9;
            this.btnRun.Text = "產生賽程";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(810, 445);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxEventItem
            // 
            this.cbxEventItem.DisplayMember = "Text";
            this.cbxEventItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxEventItem.FormattingEnabled = true;
            this.cbxEventItem.ItemHeight = 19;
            this.cbxEventItem.Location = new System.Drawing.Point(269, 22);
            this.cbxEventItem.Name = "cbxEventItem";
            this.cbxEventItem.Size = new System.Drawing.Size(256, 25);
            this.cbxEventItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbxEventItem.TabIndex = 17;
            this.cbxEventItem.WatermarkText = "請選擇競賽項目";
            this.cbxEventItem.SelectedIndexChanged += new System.EventHandler(this.cbxEventItem_SelectedIndexChanged);
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
            this.labelX5.Location = new System.Drawing.Point(202, 24);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(60, 21);
            this.labelX5.TabIndex = 16;
            this.labelX5.Text = "競賽項目";
            // 
            // colRoundNo
            // 
            this.colRoundNo.HeaderText = "回合";
            this.colRoundNo.Name = "colRoundNo";
            this.colRoundNo.ReadOnly = true;
            // 
            // colGameNo
            // 
            this.colGameNo.HeaderText = "場次";
            this.colGameNo.Name = "colGameNo";
            this.colGameNo.ReadOnly = true;
            // 
            // colTeam1
            // 
            this.colTeam1.HeaderText = "隊伍1";
            this.colTeam1.Name = "colTeam1";
            this.colTeam1.ReadOnly = true;
            // 
            // colTeam2
            // 
            this.colTeam2.HeaderText = "隊伍2";
            this.colTeam2.Name = "colTeam2";
            this.colTeam2.ReadOnly = true;
            // 
            // colOccurTime
            // 
            this.colOccurTime.HeaderText = "比賽時間";
            this.colOccurTime.Name = "colOccurTime";
            this.colOccurTime.ReadOnly = true;
            // 
            // colPlace
            // 
            this.colPlace.HeaderText = "比賽地點";
            this.colPlace.Name = "colPlace";
            this.colPlace.ReadOnly = true;
            // 
            // frmGameProducer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 480);
            this.Controls.Add(this.cbxEventItem);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.cbxGameType);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.iptSchoolYear);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmGameProducer";
            this.Text = "管理賽程";
            this.Load += new System.EventHandler(this.frmGameProducer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iptSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput iptSchoolYear;
        private DevComponents.DotNetBar.LabelX lblPlayerCount;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxGameType;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgData;
        private DevComponents.DotNetBar.ButtonX btnRun;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbxEventItem;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoundNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeam2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOccurTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlace;
    }
}