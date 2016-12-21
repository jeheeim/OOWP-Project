namespace PowerSaver
{
	partial class OptionForm
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
			this.lblID = new System.Windows.Forms.Label();
			this.tboxID = new System.Windows.Forms.TextBox();
			this.lblServer = new System.Windows.Forms.Label();
			this.tboxServerIP = new System.Windows.Forms.TextBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblPortNum = new System.Windows.Forms.Label();
			this.tboxPortNum = new System.Windows.Forms.TextBox();
			this.cboxAutoExecuteMode = new System.Windows.Forms.ComboBox();
			this.cboxAutoExecuteTime = new System.Windows.Forms.ComboBox();
			this.lblAutoExecuteMode = new System.Windows.Forms.Label();
			this.lblAutoExecuteTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Location = new System.Drawing.Point(14, 17);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(50, 15);
			this.lblID.TabIndex = 10;
			this.lblID.Text = "UserID";
			// 
			// tboxID
			// 
			this.tboxID.Location = new System.Drawing.Point(16, 42);
			this.tboxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tboxID.Name = "tboxID";
			this.tboxID.Size = new System.Drawing.Size(185, 25);
			this.tboxID.TabIndex = 8;
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(14, 89);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(67, 15);
			this.lblServer.TabIndex = 11;
			this.lblServer.Text = "Server IP";
			// 
			// tboxServerIP
			// 
			this.tboxServerIP.Location = new System.Drawing.Point(16, 114);
			this.tboxServerIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tboxServerIP.Name = "tboxServerIP";
			this.tboxServerIP.Size = new System.Drawing.Size(185, 25);
			this.tboxServerIP.TabIndex = 12;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(16, 441);
			this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(86, 29);
			this.btnAccept.TabIndex = 14;
			this.btnAccept.Text = "확인";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(115, 441);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(86, 29);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "취소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblPortNum
			// 
			this.lblPortNum.AutoSize = true;
			this.lblPortNum.Location = new System.Drawing.Point(13, 162);
			this.lblPortNum.Name = "lblPortNum";
			this.lblPortNum.Size = new System.Drawing.Size(67, 15);
			this.lblPortNum.TabIndex = 16;
			this.lblPortNum.Text = "포트번호";
			// 
			// tboxPortNum
			// 
			this.tboxPortNum.Location = new System.Drawing.Point(16, 188);
			this.tboxPortNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tboxPortNum.Name = "tboxPortNum";
			this.tboxPortNum.Size = new System.Drawing.Size(185, 25);
			this.tboxPortNum.TabIndex = 17;
			// 
			// cboxAutoExecuteMode
			// 
			this.cboxAutoExecuteMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxAutoExecuteMode.FormattingEnabled = true;
			this.cboxAutoExecuteMode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cboxAutoExecuteMode.Items.AddRange(new object[] {
            "절전모드",
            "최대절전모드",
            "컴퓨터 종료"});
			this.cboxAutoExecuteMode.Location = new System.Drawing.Point(17, 261);
			this.cboxAutoExecuteMode.Name = "cboxAutoExecuteMode";
			this.cboxAutoExecuteMode.Size = new System.Drawing.Size(184, 23);
			this.cboxAutoExecuteMode.TabIndex = 18;
			// 
			// cboxAutoExecuteTime
			// 
			this.cboxAutoExecuteTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboxAutoExecuteTime.FormattingEnabled = true;
			this.cboxAutoExecuteTime.Items.AddRange(new object[] {
            "10분",
            "15분",
            "30분",
            "45분",
            "1시간"});
			this.cboxAutoExecuteTime.Location = new System.Drawing.Point(17, 340);
			this.cboxAutoExecuteTime.Name = "cboxAutoExecuteTime";
			this.cboxAutoExecuteTime.Size = new System.Drawing.Size(184, 23);
			this.cboxAutoExecuteTime.TabIndex = 19;
			// 
			// lblAutoExecuteMode
			// 
			this.lblAutoExecuteMode.AutoSize = true;
			this.lblAutoExecuteMode.Location = new System.Drawing.Point(14, 234);
			this.lblAutoExecuteMode.Name = "lblAutoExecuteMode";
			this.lblAutoExecuteMode.Size = new System.Drawing.Size(102, 15);
			this.lblAutoExecuteMode.TabIndex = 20;
			this.lblAutoExecuteMode.Text = "자동실행 모드";
			// 
			// lblAutoExecuteTime
			// 
			this.lblAutoExecuteTime.AutoSize = true;
			this.lblAutoExecuteTime.Location = new System.Drawing.Point(14, 313);
			this.lblAutoExecuteTime.Name = "lblAutoExecuteTime";
			this.lblAutoExecuteTime.Size = new System.Drawing.Size(102, 15);
			this.lblAutoExecuteTime.TabIndex = 21;
			this.lblAutoExecuteTime.Text = "자동실행 시간";
			// 
			// OptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 518);
			this.Controls.Add(this.lblAutoExecuteTime);
			this.Controls.Add(this.lblAutoExecuteMode);
			this.Controls.Add(this.cboxAutoExecuteTime);
			this.Controls.Add(this.cboxAutoExecuteMode);
			this.Controls.Add(this.tboxPortNum);
			this.Controls.Add(this.lblPortNum);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.tboxServerIP);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.tboxID);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "OptionForm";
			this.Text = "OptionForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.TextBox tboxID;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.TextBox tboxServerIP;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblPortNum;
		private System.Windows.Forms.TextBox tboxPortNum;
		private System.Windows.Forms.ComboBox cboxAutoExecuteMode;
		private System.Windows.Forms.ComboBox cboxAutoExecuteTime;
		private System.Windows.Forms.Label lblAutoExecuteMode;
		private System.Windows.Forms.Label lblAutoExecuteTime;
	}
}