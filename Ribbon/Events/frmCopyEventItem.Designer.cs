namespace ischool.Sports
{
    partial class frmCopyEventItem
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
            this.btnCopy = new DevComponents.DotNetBar.ButtonX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.dgSource = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colEventItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.iptSSchoolYear = new DevComponents.Editors.IntegerInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.dgTarget = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.iptTSchoolYear = new DevComponents.Editors.IntegerInput();
            this.rbSchoolYear = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbGroupType = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnPreView = new DevComponents.DotNetBar.ButtonX();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.colTEventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSourceCount = new DevComponents.DotNetBar.LabelX();
            this.lblTargetCount = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dgSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptSSchoolYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTarget)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iptTSchoolYear)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.AutoSize = true;
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCopy.Location = new System.Drawing.Point(541, 526);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 25);
            this.btnCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Text = "開始複製";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSize = true;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExit.Location = new System.Drawing.Point(631, 526);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "離開";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgSource
            // 
            this.dgSource.AllowUserToAddRows = false;
            this.dgSource.AllowUserToDeleteRows = false;
            this.dgSource.AllowUserToResizeRows = false;
            this.dgSource.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgSource.BackgroundColor = System.Drawing.Color.White;
            this.dgSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSource.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEventItem});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgSource.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSource.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgSource.Location = new System.Drawing.Point(22, 151);
            this.dgSource.Name = "dgSource";
            this.dgSource.RowTemplate.Height = 24;
            this.dgSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSource.Size = new System.Drawing.Size(328, 355);
            this.dgSource.TabIndex = 3;
            this.dgSource.Click += new System.EventHandler(this.dgSource_Click);
            // 
            // colEventItem
            // 
            this.colEventItem.HeaderText = "競賽項目";
            this.colEventItem.Name = "colEventItem";
            this.colEventItem.ReadOnly = true;
            this.colEventItem.Width = 85;
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
            this.labelX1.Location = new System.Drawing.Point(22, 50);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 21);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "來源學年度";
            // 
            // iptSSchoolYear
            // 
            this.iptSSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.iptSSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iptSSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iptSSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iptSSchoolYear.Location = new System.Drawing.Point(102, 48);
            this.iptSSchoolYear.MaxValue = 999;
            this.iptSSchoolYear.MinValue = 1;
            this.iptSSchoolYear.Name = "iptSSchoolYear";
            this.iptSSchoolYear.ShowUpDown = true;
            this.iptSSchoolYear.Size = new System.Drawing.Size(80, 25);
            this.iptSSchoolYear.TabIndex = 0;
            this.iptSSchoolYear.Value = 1;
            this.iptSSchoolYear.ValueChanged += new System.EventHandler(this.iptSSchoolYear_ValueChanged);
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
            this.labelX2.Location = new System.Drawing.Point(22, 122);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(114, 21);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "請選來源競賽項目";
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
            this.labelX3.Location = new System.Drawing.Point(380, 122);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(221, 21);
            this.labelX3.TabIndex = 8;
            this.labelX3.Text = "複製競賽項目預覽，不需要請移除。";
            // 
            // dgTarget
            // 
            this.dgTarget.AllowUserToAddRows = false;
            this.dgTarget.AllowUserToDeleteRows = false;
            this.dgTarget.AllowUserToResizeRows = false;
            this.dgTarget.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgTarget.BackgroundColor = System.Drawing.Color.White;
            this.dgTarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTEventName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTarget.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTarget.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgTarget.Location = new System.Drawing.Point(380, 151);
            this.dgTarget.Name = "dgTarget";
            this.dgTarget.RowTemplate.Height = 24;
            this.dgTarget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTarget.Size = new System.Drawing.Size(328, 355);
            this.dgTarget.TabIndex = 7;
            this.dgTarget.Click += new System.EventHandler(this.dgTarget_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.iptTSchoolYear);
            this.groupPanel1.Controls.Add(this.rbSchoolYear);
            this.groupPanel1.Controls.Add(this.rbGroupType);
            this.groupPanel1.Location = new System.Drawing.Point(252, 21);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(328, 77);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 9;
            this.groupPanel1.Text = "複製條件";
            // 
            // iptTSchoolYear
            // 
            this.iptTSchoolYear.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.iptTSchoolYear.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iptTSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iptTSchoolYear.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iptTSchoolYear.Location = new System.Drawing.Point(219, 12);
            this.iptTSchoolYear.MaxValue = 999;
            this.iptTSchoolYear.MinValue = 1;
            this.iptTSchoolYear.Name = "iptTSchoolYear";
            this.iptTSchoolYear.ShowUpDown = true;
            this.iptTSchoolYear.Size = new System.Drawing.Size(80, 25);
            this.iptTSchoolYear.TabIndex = 6;
            this.iptTSchoolYear.Value = 1;
            // 
            // rbSchoolYear
            // 
            // 
            // 
            // 
            this.rbSchoolYear.BackgroundStyle.Class = "";
            this.rbSchoolYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbSchoolYear.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbSchoolYear.Location = new System.Drawing.Point(131, 12);
            this.rbSchoolYear.Name = "rbSchoolYear";
            this.rbSchoolYear.Size = new System.Drawing.Size(100, 23);
            this.rbSchoolYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbSchoolYear.TabIndex = 1;
            this.rbSchoolYear.Text = "依學年度";
            this.rbSchoolYear.CheckedChanged += new System.EventHandler(this.rbSchoolYear_CheckedChanged);
            // 
            // rbGroupType
            // 
            // 
            // 
            // 
            this.rbGroupType.BackgroundStyle.Class = "";
            this.rbGroupType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbGroupType.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbGroupType.Location = new System.Drawing.Point(25, 12);
            this.rbGroupType.Name = "rbGroupType";
            this.rbGroupType.Size = new System.Drawing.Size(100, 23);
            this.rbGroupType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbGroupType.TabIndex = 0;
            this.rbGroupType.Text = "依參賽組別";
            this.rbGroupType.CheckedChanged += new System.EventHandler(this.rbGroupType_CheckedChanged);
            // 
            // btnPreView
            // 
            this.btnPreView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPreView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreView.AutoSize = true;
            this.btnPreView.BackColor = System.Drawing.Color.Transparent;
            this.btnPreView.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPreView.Location = new System.Drawing.Point(22, 526);
            this.btnPreView.Name = "btnPreView";
            this.btnPreView.Size = new System.Drawing.Size(75, 25);
            this.btnPreView.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPreView.TabIndex = 1;
            this.btnPreView.Text = "複製預覽";
            this.btnPreView.Click += new System.EventHandler(this.btnPreView_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.AutoSize = true;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(380, 526);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 25);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "移除";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // colTEventName
            // 
            this.colTEventName.HeaderText = "競賽項目";
            this.colTEventName.Name = "colTEventName";
            this.colTEventName.ReadOnly = true;
            this.colTEventName.Width = 85;
            // 
            // lblSourceCount
            // 
            this.lblSourceCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSourceCount.BackgroundStyle.Class = "";
            this.lblSourceCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSourceCount.Location = new System.Drawing.Point(273, 122);
            this.lblSourceCount.Name = "lblSourceCount";
            this.lblSourceCount.Size = new System.Drawing.Size(75, 23);
            this.lblSourceCount.TabIndex = 10;
            this.lblSourceCount.Text = "共0筆";
            // 
            // lblTargetCount
            // 
            this.lblTargetCount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblTargetCount.BackgroundStyle.Class = "";
            this.lblTargetCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTargetCount.Location = new System.Drawing.Point(631, 122);
            this.lblTargetCount.Name = "lblTargetCount";
            this.lblTargetCount.Size = new System.Drawing.Size(75, 23);
            this.lblTargetCount.TabIndex = 11;
            this.lblTargetCount.Text = "共0筆";
            // 
            // frmCopyEventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 563);
            this.Controls.Add(this.lblTargetCount);
            this.Controls.Add(this.lblSourceCount);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnPreView);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.dgTarget);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.iptSSchoolYear);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.dgSource);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopy);
            this.DoubleBuffered = true;
            this.Name = "frmCopyEventItem";
            this.Text = "複製競賽項目";
            this.Load += new System.EventHandler(this.frmCopyEventItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iptSSchoolYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTarget)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iptTSchoolYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnCopy;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventItem;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.IntegerInput iptSSchoolYear;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgTarget;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbGroupType;
        private DevComponents.Editors.IntegerInput iptTSchoolYear;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbSchoolYear;
        private DevComponents.DotNetBar.ButtonX btnPreView;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTEventName;
        private DevComponents.DotNetBar.LabelX lblSourceCount;
        private DevComponents.DotNetBar.LabelX lblTargetCount;
    }
}