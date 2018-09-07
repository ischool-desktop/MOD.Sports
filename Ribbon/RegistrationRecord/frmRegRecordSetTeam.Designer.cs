namespace ischool.Sports
{
    partial class frmRegRecordSetTeam
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
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblEventItem = new DevComponents.DotNetBar.LabelX();
            this.txtTeamName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.iptLotNo = new DevComponents.Editors.IntegerInput();
            ((System.ComponentModel.ISupportInitialize)(this.iptLotNo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(253, 147);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "確定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(349, 147);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.labelX1.Location = new System.Drawing.Point(44, 54);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(34, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "隊名";
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
            this.labelX2.Location = new System.Drawing.Point(31, 92);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(47, 21);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "抽籤號";
            // 
            // lblEventItem
            // 
            this.lblEventItem.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblEventItem.BackgroundStyle.Class = "";
            this.lblEventItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblEventItem.Location = new System.Drawing.Point(22, 16);
            this.lblEventItem.Name = "lblEventItem";
            this.lblEventItem.Size = new System.Drawing.Size(402, 23);
            this.lblEventItem.TabIndex = 4;
            this.lblEventItem.Text = "競賽項目";
            // 
            // txtTeamName
            // 
            // 
            // 
            // 
            this.txtTeamName.Border.Class = "TextBoxBorder";
            this.txtTeamName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTeamName.Location = new System.Drawing.Point(85, 52);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(337, 25);
            this.txtTeamName.TabIndex = 5;
            // 
            // iptLotNo
            // 
            this.iptLotNo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.iptLotNo.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iptLotNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iptLotNo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iptLotNo.Location = new System.Drawing.Point(85, 90);
            this.iptLotNo.MinValue = 0;
            this.iptLotNo.Name = "iptLotNo";
            this.iptLotNo.ShowUpDown = true;
            this.iptLotNo.Size = new System.Drawing.Size(130, 25);
            this.iptLotNo.TabIndex = 6;
            // 
            // frmRegRecordSetTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 183);
            this.Controls.Add(this.iptLotNo);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.lblEventItem);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.Name = "frmRegRecordSetTeam";
            this.Text = "隊";
            this.Load += new System.EventHandler(this.frmRegRecordSetTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iptLotNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblEventItem;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTeamName;
        private DevComponents.Editors.IntegerInput iptLotNo;
    }
}