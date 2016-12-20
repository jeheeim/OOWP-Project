namespace PowerSaver
{
	partial class MainForm
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnRegisterUser = new System.Windows.Forms.Button();
			this.btnSuspend = new System.Windows.Forms.Button();
			this.tboxLog = new System.Windows.Forms.TextBox();
			this.btnShutDown = new System.Windows.Forms.Button();
			this.tboxID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnSaveLog = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.hibernateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCallLog = new System.Windows.Forms.Button();
			this.btnConnectServer = new System.Windows.Forms.Button();
			this.btnHibernate = new System.Windows.Forms.Button();
			this.rdbtn5Min = new System.Windows.Forms.RadioButton();
			this.rdbtn10Min = new System.Windows.Forms.RadioButton();
			this.rdbtn30Min = new System.Windows.Forms.RadioButton();
			this.rdbtn45Min = new System.Windows.Forms.RadioButton();
			this.rdbtn15Min = new System.Windows.Forms.RadioButton();
			this.rdbtn1Hour = new System.Windows.Forms.RadioButton();
			this.rdbtnNow = new System.Windows.Forms.RadioButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tStripLbl = new System.Windows.Forms.ToolStripLabel();
			this.tStripProgBar = new System.Windows.Forms.ToolStripProgressBar();
			this.tStripBtnCancel = new System.Windows.Forms.ToolStripButton();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnRegisterUser
			// 
			this.btnRegisterUser.Location = new System.Drawing.Point(258, 14);
			this.btnRegisterUser.Name = "btnRegisterUser";
			this.btnRegisterUser.Size = new System.Drawing.Size(103, 25);
			this.btnRegisterUser.TabIndex = 1;
			this.btnRegisterUser.Text = "register user";
			this.btnRegisterUser.UseMnemonic = false;
			this.btnRegisterUser.UseVisualStyleBackColor = true;
			this.btnRegisterUser.Click += new System.EventHandler(this.BtnRegisterUser_Click);
			// 
			// btnSuspend
			// 
			this.btnSuspend.Location = new System.Drawing.Point(12, 84);
			this.btnSuspend.Name = "btnSuspend";
			this.btnSuspend.Size = new System.Drawing.Size(145, 32);
			this.btnSuspend.TabIndex = 2;
			this.btnSuspend.Text = "절전 모드";
			this.btnSuspend.UseVisualStyleBackColor = true;
			this.btnSuspend.Click += new System.EventHandler(this.BtnSuspend_Click);
			// 
			// tboxLog
			// 
			this.tboxLog.Location = new System.Drawing.Point(12, 197);
			this.tboxLog.Multiline = true;
			this.tboxLog.Name = "tboxLog";
			this.tboxLog.ReadOnly = true;
			this.tboxLog.Size = new System.Drawing.Size(458, 140);
			this.tboxLog.TabIndex = 6;
			this.tboxLog.TabStop = false;
			// 
			// btnShutDown
			// 
			this.btnShutDown.Location = new System.Drawing.Point(314, 84);
			this.btnShutDown.Name = "btnShutDown";
			this.btnShutDown.Size = new System.Drawing.Size(156, 32);
			this.btnShutDown.TabIndex = 4;
			this.btnShutDown.Text = "컴퓨터 종료";
			this.btnShutDown.UseVisualStyleBackColor = true;
			this.btnShutDown.Click += new System.EventHandler(this.BtnShutDown_Click);
			// 
			// tboxID
			// 
			this.tboxID.Location = new System.Drawing.Point(65, 16);
			this.tboxID.Name = "tboxID";
			this.tboxID.Size = new System.Drawing.Size(184, 25);
			this.tboxID.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "UserID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 15);
			this.label2.TabIndex = 8;
			this.label2.Text = "기능";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 168);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 15);
			this.label3.TabIndex = 9;
			this.label3.Text = "Log 출력";
			// 
			// btnSaveLog
			// 
			this.btnSaveLog.Location = new System.Drawing.Point(360, 160);
			this.btnSaveLog.Name = "btnSaveLog";
			this.btnSaveLog.Size = new System.Drawing.Size(110, 31);
			this.btnSaveLog.TabIndex = 5;
			this.btnSaveLog.Text = "File 저장";
			this.btnSaveLog.UseVisualStyleBackColor = true;
			this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLog_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "PowerSave";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suspendToolStripMenuItem,
            this.hibernateToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(174, 146);
			// 
			// suspendToolStripMenuItem
			// 
			this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
			this.suspendToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.suspendToolStripMenuItem.Text = "절전모드";
			this.suspendToolStripMenuItem.Click += new System.EventHandler(this.SuspendToolStripMenuItem_Click);
			// 
			// hibernateToolStripMenuItem
			// 
			this.hibernateToolStripMenuItem.Name = "hibernateToolStripMenuItem";
			this.hibernateToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.hibernateToolStripMenuItem.Text = "최대 절전모드";
			this.hibernateToolStripMenuItem.Click += new System.EventHandler(this.HibernateToolStripMenuItem_Click);
			// 
			// shutdownToolStripMenuItem
			// 
			this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
			this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.shutdownToolStripMenuItem.Text = "종료";
			this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.ShutdownToolStripMenuItem_Click);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.showToolStripMenuItem.Text = "show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			this.exitToolStripMenuItem.Text = "exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
			// 
			// btnCallLog
			// 
			this.btnCallLog.Location = new System.Drawing.Point(244, 160);
			this.btnCallLog.Name = "btnCallLog";
			this.btnCallLog.Size = new System.Drawing.Size(110, 31);
			this.btnCallLog.TabIndex = 13;
			this.btnCallLog.Text = "Log 출력";
			this.btnCallLog.UseVisualStyleBackColor = true;
			this.btnCallLog.Click += new System.EventHandler(this.BtnCallLog_Click);
			// 
			// btnConnectServer
			// 
			this.btnConnectServer.Location = new System.Drawing.Point(367, 14);
			this.btnConnectServer.Name = "btnConnectServer";
			this.btnConnectServer.Size = new System.Drawing.Size(103, 25);
			this.btnConnectServer.TabIndex = 14;
			this.btnConnectServer.Text = "서버 연결";
			this.btnConnectServer.UseVisualStyleBackColor = true;
			this.btnConnectServer.Click += new System.EventHandler(this.BtnConnectServer_Click);
			// 
			// btnHibernate
			// 
			this.btnHibernate.Location = new System.Drawing.Point(163, 84);
			this.btnHibernate.Name = "btnHibernate";
			this.btnHibernate.Size = new System.Drawing.Size(145, 32);
			this.btnHibernate.TabIndex = 15;
			this.btnHibernate.Text = "최대 절전 모드";
			this.btnHibernate.UseVisualStyleBackColor = true;
			this.btnHibernate.Click += new System.EventHandler(this.BtnHibernate_Click);
			// 
			// rdbtn5Min
			// 
			this.rdbtn5Min.AutoSize = true;
			this.rdbtn5Min.Location = new System.Drawing.Point(76, 122);
			this.rdbtn5Min.Name = "rdbtn5Min";
			this.rdbtn5Min.Size = new System.Drawing.Size(51, 19);
			this.rdbtn5Min.TabIndex = 16;
			this.rdbtn5Min.Text = "5분";
			this.rdbtn5Min.UseVisualStyleBackColor = true;
			this.rdbtn5Min.CheckedChanged += new System.EventHandler(this.Rdbtn5Min_CheckedChanged);
			// 
			// rdbtn10Min
			// 
			this.rdbtn10Min.AutoSize = true;
			this.rdbtn10Min.Location = new System.Drawing.Point(137, 122);
			this.rdbtn10Min.Name = "rdbtn10Min";
			this.rdbtn10Min.Size = new System.Drawing.Size(59, 19);
			this.rdbtn10Min.TabIndex = 17;
			this.rdbtn10Min.Text = "10분";
			this.rdbtn10Min.UseVisualStyleBackColor = true;
			this.rdbtn10Min.CheckedChanged += new System.EventHandler(this.Rdbtn10Min_CheckedChanged);
			// 
			// rdbtn30Min
			// 
			this.rdbtn30Min.AutoSize = true;
			this.rdbtn30Min.Location = new System.Drawing.Point(267, 122);
			this.rdbtn30Min.Name = "rdbtn30Min";
			this.rdbtn30Min.Size = new System.Drawing.Size(59, 19);
			this.rdbtn30Min.TabIndex = 18;
			this.rdbtn30Min.Text = "30분";
			this.rdbtn30Min.UseVisualStyleBackColor = true;
			this.rdbtn30Min.CheckedChanged += new System.EventHandler(this.Rdbtn30Min_CheckedChanged);
			// 
			// rdbtn45Min
			// 
			this.rdbtn45Min.AutoSize = true;
			this.rdbtn45Min.Location = new System.Drawing.Point(332, 122);
			this.rdbtn45Min.Name = "rdbtn45Min";
			this.rdbtn45Min.Size = new System.Drawing.Size(59, 19);
			this.rdbtn45Min.TabIndex = 19;
			this.rdbtn45Min.Text = "45분";
			this.rdbtn45Min.UseVisualStyleBackColor = true;
			this.rdbtn45Min.CheckedChanged += new System.EventHandler(this.Rdbtn45Min_CheckedChanged);
			// 
			// rdbtn15Min
			// 
			this.rdbtn15Min.AutoSize = true;
			this.rdbtn15Min.Location = new System.Drawing.Point(202, 122);
			this.rdbtn15Min.Name = "rdbtn15Min";
			this.rdbtn15Min.Size = new System.Drawing.Size(59, 19);
			this.rdbtn15Min.TabIndex = 20;
			this.rdbtn15Min.Text = "15분";
			this.rdbtn15Min.UseVisualStyleBackColor = true;
			this.rdbtn15Min.CheckedChanged += new System.EventHandler(this.Rdbtn15Min_CheckedChanged);
			// 
			// rdbtn1Hour
			// 
			this.rdbtn1Hour.AutoSize = true;
			this.rdbtn1Hour.Location = new System.Drawing.Point(397, 122);
			this.rdbtn1Hour.Name = "rdbtn1Hour";
			this.rdbtn1Hour.Size = new System.Drawing.Size(66, 19);
			this.rdbtn1Hour.TabIndex = 21;
			this.rdbtn1Hour.Text = "1시간";
			this.rdbtn1Hour.UseVisualStyleBackColor = true;
			this.rdbtn1Hour.CheckedChanged += new System.EventHandler(this.Rdbtn1Hour_CheckedChanged);
			// 
			// rdbtnNow
			// 
			this.rdbtnNow.AutoSize = true;
			this.rdbtnNow.Checked = true;
			this.rdbtnNow.Location = new System.Drawing.Point(12, 122);
			this.rdbtnNow.Name = "rdbtnNow";
			this.rdbtnNow.Size = new System.Drawing.Size(58, 19);
			this.rdbtnNow.TabIndex = 22;
			this.rdbtnNow.TabStop = true;
			this.rdbtnNow.Text = "즉시";
			this.rdbtnNow.UseVisualStyleBackColor = true;
			this.rdbtnNow.CheckedChanged += new System.EventHandler(this.RdbtnNow_CheckedChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStripLbl,
            this.tStripProgBar,
            this.tStripBtnCancel});
			this.toolStrip1.Location = new System.Drawing.Point(0, 346);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(482, 27);
			this.toolStrip1.TabIndex = 23;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tStripLbl
			// 
			this.tStripLbl.Name = "tStripLbl";
			this.tStripLbl.Size = new System.Drawing.Size(169, 24);
			this.tStripLbl.Text = "기능을 선택해 주십시오";
			// 
			// tStripProgBar
			// 
			this.tStripProgBar.Name = "tStripProgBar";
			this.tStripProgBar.Size = new System.Drawing.Size(170, 24);
			// 
			// tStripBtnCancel
			// 
			this.tStripBtnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tStripBtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("tStripBtnCancel.Image")));
			this.tStripBtnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tStripBtnCancel.Name = "tStripBtnCancel";
			this.tStripBtnCancel.Size = new System.Drawing.Size(59, 24);
			this.tStripBtnCancel.Text = "Cancel";
			this.tStripBtnCancel.Click += new System.EventHandler(this.tStipBtnCancel_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(482, 373);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.rdbtnNow);
			this.Controls.Add(this.rdbtn1Hour);
			this.Controls.Add(this.rdbtn15Min);
			this.Controls.Add(this.rdbtn45Min);
			this.Controls.Add(this.rdbtn30Min);
			this.Controls.Add(this.rdbtn10Min);
			this.Controls.Add(this.rdbtn5Min);
			this.Controls.Add(this.btnHibernate);
			this.Controls.Add(this.btnConnectServer);
			this.Controls.Add(this.btnCallLog);
			this.Controls.Add(this.btnSaveLog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tboxID);
			this.Controls.Add(this.btnShutDown);
			this.Controls.Add(this.tboxLog);
			this.Controls.Add(this.btnSuspend);
			this.Controls.Add(this.btnRegisterUser);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.Text = "Power Save";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnRegisterUser;
		private System.Windows.Forms.Button btnSuspend;
		private System.Windows.Forms.TextBox tboxLog;
		private System.Windows.Forms.Button btnShutDown;
		private System.Windows.Forms.TextBox tboxID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnSaveLog;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
		private System.Windows.Forms.Button btnCallLog;
		private System.Windows.Forms.Button btnConnectServer;
		private System.Windows.Forms.Button btnHibernate;
		private System.Windows.Forms.ToolStripMenuItem hibernateToolStripMenuItem;
		private System.Windows.Forms.RadioButton rdbtn5Min;
		private System.Windows.Forms.RadioButton rdbtn10Min;
		private System.Windows.Forms.RadioButton rdbtn30Min;
		private System.Windows.Forms.RadioButton rdbtn45Min;
		private System.Windows.Forms.RadioButton rdbtn15Min;
		private System.Windows.Forms.RadioButton rdbtn1Hour;
		private System.Windows.Forms.RadioButton rdbtnNow;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel tStripLbl;
		private System.Windows.Forms.ToolStripProgressBar tStripProgBar;
		private System.Windows.Forms.ToolStripButton tStripBtnCancel;
	}
}

