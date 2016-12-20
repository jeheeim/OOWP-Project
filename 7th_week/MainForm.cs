using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Timers;

namespace PowerSaver
{
	public enum MOD
	{
		suspend,
		hibernate,
		shutdown
	}


	public partial class MainForm : Form
	{
		// 멤버 변수

		public string registerURL = "http://210.94.194.100:20151/registerUser.asp";
		public string logURL = "http://210.94.194.100:20151/log.asp";

		#region command list

		/*
		 *  로그 쓰기
		 *  로그 읽기
		 *  액션 절전모드
		 *  액션 최대 절전모드
		 *  액션 프로그램 작동
		 *  액션 컴퓨터 종료
		 */

		string cmdWrite = "cmd=write";
		string cmdRead = "cmd=read";
		string suspend = "action=suspend";
		string hibernate = "action=hibernate";
		string wakeUp = "action=wakeup";
		string shutdown = "action=shutdown";
		
		public string CmdWrit { get { return cmdWrite; } }
		public string CmdRead { get { return cmdRead; } }
		public string ActSusp { get { return suspend; } }
		public string ActHibr { get { return hibernate; } }
		public string ActWake { get { return wakeUp; } }
		public string ActShut { get { return shutdown; } }

		#endregion

		public string id;
		
		bool firstOrNot = true;
		bool initialized = false;
		bool serverConnected = false;

		public enum RadiobuttonSelected
		{
			now,
			min5,
			min10,
			min15,
			min30,
			min45,
			hour1,
		}

		RadiobuttonSelected reservationTime;

		MOD executeMod;

		NotifyIcon ntfIcon;
		Timer_TCPServer.TCPServer server;
		
		System.Timers.Timer timer;

		ProgressBarForm pbarForm;

		bool toolStripEnabled;

		// 메소드

		public MainForm()
		{
			InitializeComponent();

			tboxLog.ScrollBars = ScrollBars.Vertical;

			string fName = "userid.txt"; // 전체경로를 지정해 줘야함

			try
			{
				FileStream open = new FileStream(fName, FileMode.Open);

				StreamReader read = new StreamReader(open, Encoding.Default);

				id = read.ReadToEnd();
			}
			catch (FileLoadException e)
			{
				id = null;

				MessageBox.Show(e.ToString());
			}

			ntfIcon = notifyIcon1;

			if (id != null)
			{
				string message = cmdWrite + "&" + wakeUp;
				string URL = logURL + "?id=" + id + "&" + message;

				SendRequest(message, URL);

				firstOrNot = false;
			}

			tboxID.Text = id;
			
			server = new Timer_TCPServer.TCPServer(this);

			SetToolStripEnabled();
		}

		#region button click

		/* 사용자 등록
		 * 서버 연결(커맨드 대기)
		 * 대기모드
		 * 최대 절전모드
		 * 컴퓨터 종료
		 * 예약하기
		 * 로그 저장
		 * 로그 출력
		 * 툴스트립의 취소버튼
		 */

		// register user
		private void BtnRegisterUser_Click(object sender, EventArgs e)
		{
			id = tboxID.Text;
			string URL = registerURL + "?id=" + id;
			string[] returnMessage = SendRequest(id, URL).Split(':');

			if (returnMessage[0] == "OK")
			{
				MessageBox.Show("등록되었습니다!");

				SaveUser(id);
			}
			else if (returnMessage[0] == "ERROR")
			{
				MessageBox.Show(returnMessage[1].Trim());

				SaveUser(id);
			}
			else
			{
				MessageBox.Show("에러!");
			}

			string message = cmdWrite + "&" + wakeUp;
			URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);
		}

		// 서버 연결
		private void BtnConnectServer_Click(object sender, EventArgs e)
		{
			if (!serverConnected)
			{
				if (server.Connent("210.94.194.100", 20151))
				{
					serverConnected = true;

					btnConnectServer.Text = "서버 연결 해체";

					server.Start();

					MessageBox.Show("서버 연결");
				}
				else
				{
					MessageBox.Show("서버 연결 실패");
				}
			}
			else
			{
				server.Disconnect();
				btnConnectServer.Text = "서버 연결";
			}
		}

		#region 절전모드, 최대 절전모드, 컴퓨터 종료

		//standby force
		private void BtnSuspend_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "절전모드";
			
			SetToolStripEnabled();

			executeMod = MOD.suspend;

			SetTimer();
		}

		// 최대 절전모드
		private void BtnHibernate_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "최대절전모드";

			SetToolStripEnabled();

			executeMod = MOD.hibernate;

			SetTimer();
		}

		// computer turn off
		private void BtnShutDown_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "컴퓨터 종료";

			SetToolStripEnabled();

			executeMod = MOD.shutdown;

			SetTimer();
		}

		#endregion

		// save log
		private void BtnSaveLog_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
;
			saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			saveFileDialog1.Filter = "Log File|*.log|All File|*.*";
			saveFileDialog1.Title = "Save an Log File";

			// If the file name is not an empty string open it for saving.
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{

				FileStream fileStream = new FileStream(saveFileDialog1.FileName,
					FileMode.Create, FileAccess.Write);

				StreamWriter streamWriter = new StreamWriter(fileStream);
				streamWriter.WriteLine(tboxLog.Text);
				streamWriter.Close();
			}
		}

		// 로그 출력
		private void BtnCallLog_Click(object sender, EventArgs e)
		{
			string message = cmdRead;
			string URL = logURL + "?id=" + id + "&" + message;
			string returnMessage = SendRequest(message, URL);

			returnMessage = returnMessage.Replace("<BR>", "\r\n");

			tboxLog.Text = returnMessage;

			tboxLog.SelectionStart = tboxLog.Text.Length;
			tboxLog.ScrollToCaret();
		}

		private void tStipBtnCancel_Click(object sender, EventArgs e)
		{
			SetToolStripEnabled();

			tStripLbl.Text = "기능을 선택해 주십시오";

			tStripProgBar.Value = 0;
		}

		#endregion

		// 통신을 담당하는 메소드
		public string SendRequest(string message, string URL)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
			byte[] sendData = UTF8Encoding.UTF8.GetBytes(message);
			request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
			request.ContentLength = sendData.Length;
			request.Method = "POST";

			StreamWriter sw = new StreamWriter(request.GetRequestStream());
			sw.Write(message);
			sw.Close();

			HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
			StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
			string result = streamReader.ReadToEnd();
			streamReader.Close();
			httpWebResponse.Close();

			return result;
		}

		#region manage user

		void SaveUser(string userID)
		{
			string directory = "userid.txt";
			FileInfo fileInfo = new FileInfo(directory);

			if (fileInfo.Exists) { return; }
			else { File.WriteAllText(directory, userID);}
		}

		#endregion

		#region mouse and keyboard events

		// 절전모드에서 마우스를 움직이는 경우 서버로 로그를 전송하는 이벤트
		public void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			string message = cmdWrite + "&" + wakeUp;
			string URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);
			
			MouseMove -= new MouseEventHandler(MainForm_MouseMove);
			KeyPress += new KeyPressEventHandler(MainForm_KeyPressed);
		}

		// 단축키 이벤트
		private void MainForm_KeyPressed(object sender, KeyPressEventArgs e)
		{
			string message = cmdWrite + "&" + wakeUp;
			string URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			Keys key = keyData = keyData & ~(Keys.Shift | Keys.Control | Keys.Alt);

			switch (key)
			{
				case Keys.R:
					btnRegisterUser.PerformClick();
					break;
				case Keys.M:
					btnSuspend.PerformClick();
					break;
				case Keys.O:
					btnShutDown.PerformClick();
					break;
				case Keys.S:
					btnSaveLog.PerformClick();
					break;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		#endregion

		#region StripMenu

		private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Show();
			ntfIcon.Visible = false;
			ShowInTaskbar = true;
		}

		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void SuspendToolStripMenuItem_Click(object sender, EventArgs e)
		{
			executeMod = MOD.suspend;

			pbarForm = new ProgressBarForm(this, executeMod);
			pbarForm.Show();
		}

		private void HibernateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			executeMod = MOD.hibernate;

			pbarForm = new ProgressBarForm(this, executeMod);
			pbarForm.Show();
		}

		private void ShutdownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			executeMod = MOD.shutdown;

			pbarForm = new ProgressBarForm(this, executeMod);
			pbarForm.Show();
		}

		#endregion

		#region form closing and minimize

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
			ntfIcon.Visible = true;
			ShowInTaskbar = false;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				ntfIcon.Visible = true;
				this.ShowInTaskbar = false;
			}
		}
		#endregion

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (firstOrNot == false && initialized == false)
			{
				Hide();
				ShowInTaskbar = false;

				initialized = true;
			}

			KeyPress += new KeyPressEventHandler(MainForm_KeyPressed);
		}

		#region 라디오버튼 선택 이벤트

		private void RdbtnNow_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.now;
		}

		private void Rdbtn5Min_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.min5;
		}

		private void Rdbtn10Min_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.min10;
		}

		private void Rdbtn15Min_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.min15;
		}

		private void Rdbtn30Min_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.min30;
		}

		private void Rdbtn45Min_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.min45;
		}

		private void Rdbtn1Hour_CheckedChanged(object sender, EventArgs e)
		{
			reservationTime = RadiobuttonSelected.hour1;
		}

		#endregion

		// 프로그레스바의 최대값을 결정하기위한 메소드
		int SetMaximum()
		{
			int result = 0;

			switch ((int)reservationTime)
			{
				case 1:
					result = 5 * 60;
					break;
				case 2:
					result = 10 * 60;
					break;
				case 3:
					result = 15 * 60;
					break;
				case 4:
					result = 30 * 60;
					break;
				case 5:
					result = 45 * 60;
					break;
				case 6:
					result = 60 * 60;
					break;
			}

			return result;
		}

		// 툴 스트립 프로그레스바, 취소버튼 활성화 / 비활성화
		void SetToolStripEnabled()
		{
			if (!toolStripEnabled)
			{
				tStripProgBar.Enabled = false;
				tStripProgBar.Visible = false;
				tStripBtnCancel.Enabled = false;
				tStripBtnCancel.Visible = false;

				toolStripEnabled = true;
			}
			else
			{
				tStripProgBar.Enabled = true;
				tStripProgBar.Visible = true;
				tStripBtnCancel.Enabled = true;
				tStripBtnCancel.Visible = true;

				toolStripEnabled = false;
			}
		}

		#region 타이머 관련

		// 타이머 실행
		void SetTimer()
		{
			timer = new System.Timers.Timer();

			timer.Interval = 1000;
			timer.Elapsed += new ElapsedEventHandler(Timer_body);

			tStripProgBar.Minimum = 0;
			tStripProgBar.Maximum = SetMaximum();

			timer.Start();
		}

		// 1초마다 실행되는 timer의 내용
		void Timer_body(object sender, ElapsedEventArgs e)
		{
			tStripProgBar.Value++;

			if (tStripProgBar.Value == tStripProgBar.Maximum)
			{
				timer.Stop();

				Execute();
			}
		}

		#endregion

		#region 버튼 클릭시 실제 실행되는 메소드

		public void ButtonAction(string message, string URL, string argument)
		{
			SendRequest(message, URL);

			Process.Start(fileName: @"C:\Users\jay\Downloads\nircmd-x64\nircmd.exe", arguments: argument);
		}

		void Suspend()
		{
			string message = cmdWrite + "&" + suspend;
			string URL = logURL + "?id=" + id + "&" + message;
			string argument = "standby force";

			MouseMove += new MouseEventHandler(MainForm_MouseMove);

			ButtonAction(message, URL, argument);
		}

		void Hibernate()
		{
			string message = cmdWrite + "&" + hibernate;
			string URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);

			Process.Start(fileName: "rundll32", arguments: "powrprof.dll, SetSuspendState");
		}

		void ShutDown()
		{
			String message = cmdWrite + "&" + shutdown;
			String URL = logURL + "?id=" + id + "&" + message;
			String argument = "exitwin poweroff";

			ButtonAction(message, URL, argument);
		}

		void Execute()
		{
			switch (executeMod)
			{
				case MOD.suspend:
					Suspend();
					break;
				case MOD.hibernate:
					Hibernate();
					break;
				case MOD.shutdown:
					ShutDown();
					break;
			}
		}

		#endregion

	}
}