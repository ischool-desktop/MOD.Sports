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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblSchoolYear = new DevComponents.DotNetBar.LabelX();
            this.gp1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkByEventName = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkByClassName = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgData = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEventItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeatNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRegAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.lblRowCount = new DevComponents.DotNetBar.LabelX();
            this.gp1.SuspendLayout();
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
            this.labelX1.Location = new System.Drawing.Point(25, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "學年度";
            // 
            // lblSchoolYear
            // 
            this.lblSchoolYear.AutoSize = true;
            this.lblSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSchoolYear.BackgroundStyle.Class = "";
            this.lblSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSchoolYear.Location = new System.Drawing.Point(75, 23);
            this.lblSchoolYear.Name = "lblSchoolYear";
            this.lblSchoolYear.Size = new System.Drawing.Size(30, 21);
            this.lblSchoolYear.TabIndex = 1;
            this.lblSchoolYear.Text = "107";
            // 
            // gp1
            // 
            this.gp1.BackColor = System.Drawing.Color.Transparent;
            this.gp1.CanvasColor = System.Drawing.SystemColors.Control;
            this.gp1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gp1.Controls.Add(this.chkByEventName);
            this.gp1.Controls.Add(this.chkByClassName);
            this.gp1.Location = new System.Drawing.Point(449, 23);
            this.gp1.Name = "gp1";
            this.gp1.Size = new System.Drawing.Size(262, 62);
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
            // chkByEventName
            // 
            // 
            // 
            // 
            this.chkByEventName.BackgroundStyle.Class = "";
            this.chkByEventName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkByEventName.Location = new System.Drawing.Point(123, 3);
            this.chkByEventName.Name = "chkByEventName";
            this.chkByEventName.Size = new System.Drawing.Size(100, 23);
            this.chkByEventName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByEventName.TabIndex = 1;
            this.chkByEventName.Text = "依競賽項目";
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
            this.chkByClassName.Size = new System.Drawing.Size(67, 21);
            this.chkByClassName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkByClassName.TabIndex = 0;
            this.chkByClassName.Text = "依班級";
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
            this.txtSearch.TabIndex = 4;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.colEventItem,
            this.colGroupType,
            this.colTeamName,
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
            this.dgData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgData.Location = new System.Drawing.Point(14, 104);
            this.dgData.Name = "dgData";
            this.dgData.RowTemplate.Height = 24;
            this.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgData.Size = new System.Drawing.Size(842, 287);
            this.dgData.TabIndex = 5;
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
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(781, 407);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblRowCount.BackgroundStyle.Class = "";
            this.lblRowCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRowCount.Location = new System.Drawing.Point(752, 77);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(104, 18);
            this.lblRowCount.TabIndex = 8;
            this.lblRowCount.Text = "107";
            // 
            // frmRegistrationRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 455);
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dgData);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.gp1);
            this.Controls.Add(this.lblSchoolYear);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmRegistrationRecord";
            this.Text = "管理報名記錄";
            this.Load += new System.EventHandler(this.frmRegistrationRecord_Load);
            this.gp1.ResumeLayout(false);
            this.gp1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.GroupPanel gp1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgData;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByEventName;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkByClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeatNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRegAccount;
        private DevComponents.DotNetBar.LabelX lblRowCount;
    }
}