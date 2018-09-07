namespace ischool.Sports
{
    partial class frmRegRecordUpdatePlayer
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
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.chkIsLeader = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.iptLotNo = new DevComponents.Editors.IntegerInput();
            this.lblStudentText = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.iptLotNo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(122, 115);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "確定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(221, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
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
            this.labelX1.Location = new System.Drawing.Point(139, 65);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(47, 21);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "抽籤號";
            // 
            // chkIsLeader
            // 
            this.chkIsLeader.AutoSize = true;
            this.chkIsLeader.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkIsLeader.BackgroundStyle.Class = "";
            this.chkIsLeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkIsLeader.Location = new System.Drawing.Point(43, 65);
            this.chkIsLeader.Name = "chkIsLeader";
            this.chkIsLeader.Size = new System.Drawing.Size(67, 21);
            this.chkIsLeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIsLeader.TabIndex = 3;
            this.chkIsLeader.Text = "是隊長";
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
            this.iptLotNo.Location = new System.Drawing.Point(193, 63);
            this.iptLotNo.Name = "iptLotNo";
            this.iptLotNo.ShowUpDown = true;
            this.iptLotNo.Size = new System.Drawing.Size(99, 25);
            this.iptLotNo.TabIndex = 4;
            // 
            // lblStudentText
            // 
            this.lblStudentText.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblStudentText.BackgroundStyle.Class = "";
            this.lblStudentText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblStudentText.Location = new System.Drawing.Point(12, 23);
            this.lblStudentText.Name = "lblStudentText";
            this.lblStudentText.Size = new System.Drawing.Size(298, 23);
            this.lblStudentText.TabIndex = 5;
            // 
            // frmRegRecordUpdatePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 150);
            this.Controls.Add(this.lblStudentText);
            this.Controls.Add(this.iptLotNo);
            this.Controls.Add(this.chkIsLeader);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.DoubleBuffered = true;
            this.Name = "frmRegRecordUpdatePlayer";
            this.Text = "修改學生資料";
            this.Load += new System.EventHandler(this.frmRegRecordUpdatePlayer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iptLotNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.CheckBoxX chkIsLeader;
        private DevComponents.Editors.IntegerInput iptLotNo;
        private DevComponents.DotNetBar.LabelX lblStudentText;
    }
}