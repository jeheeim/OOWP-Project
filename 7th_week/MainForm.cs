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

		#region URL, URL프로퍼티

		string registerURL = "http://210.94.194.100:20151/registerUser.asp";
		string logURL = "http://210.94.194.100:20151/log.asp";

		public string RegisterURL { get { return registerURL; } set { registerURL = value; } }
		public string LogURL { get { return logURL; } set { logURL = value; } }
		
		#endregion

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

		#region 서버 ip, 포트(변수, 프로퍼티)

		string ip = "210.94.194.100";
		int portNum = 20151;

		public string IP { get { return ip; } set { ip = value; } }
		public int PortNum { get { return portNum; } set { portNum = value; } }
		
		#endregion

		public string id;
		
		bool firstOrNot = true;
		bool initialized = false;

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
		
		System.Timers.Timer selectedExecuteTimer;
		System.Timers.Timer autoExecuteTimer;

		ProgressBarForm pbarForm;

		bool toolStripEnabled;

		// 옵션 탭에서 지정한 시간이 지나면 자동으로 지정한 옵션이 실행된다.
		// 그걸 위한 시간 카운트용 변수
		// 디폴트 값은 절전모드, 30분
		int autoCount = 0;
		MOD autoExecute = MOD.suspend;
		int autoExecuteTime = 1800;

		public MOD AutoExecute { set { autoExecute = value; } }
		public int AutoExecuteTime { set { autoExecuteTime = value; } }

		// 메소드

		public MainForm()
		{
			InitializeComponent();

			tboxLog.ScrollBars = ScrollBars.Vertical;

			string fName = "option.txt"; // 전체경로를 지정해 줘야함
			string resultString;

			try
			{
				FileStream open = new FileStream(fName, FileMode.Open);

				StreamReader read = new StreamReader(open, Encoding.Default);

				resultString = read.ReadToEnd();

				string[] result = resultString.Split('/');
				id = result[0];
				ip = result[1];
				portNum = int.Parse(result[2]);
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

			// 프로그램 실행시 자동실행 카운트다운 시작
			SetTimerForAutoExecution();

			// 프로그램 시작시 마스터 서버에 연결
			ConnectToServer();
		}

		/***** 메소드 종류 *****
		 * 사용자 등록
		 * 서버 연결(커맨드 대기)
		 * 대기모드
		 * 최대 절전모드
		 * 컴퓨터 종료
		 * 예약하기
		 * 로그 저장
		 * 로그 출력
		 * 툴스트립의 취소버튼
		 ***********************/
		#region button click

		// 옵션
		private void BtnOption_Click(object sender, EventArgs e)
		{
			OptionForm optionForm = new OptionForm(this);

			optionForm.ShowDialog();

			MessageBox.Show(id + " " + ip + " " + portNum);
			MessageBox.Show(autoExecute.ToString() + autoExecuteTime);
		}

		#region 절전모드, 최대 절전모드, 컴퓨터 종료

		//standby force
		private void BtnSuspend_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "절전모드";
			
			SetToolStripEnabled();

			executeMod = MOD.suspend;

			SetTimerForDelayedExecution();
		}

		// 최대 절전모드
		private void BtnHibernate_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "최대절전모드";

			SetToolStripEnabled();

			executeMod = MOD.hibernate;

			SetTimerForDelayedExecution();
		}

		// computer turn off
		private void BtnShutDown_Click(object sender, EventArgs e)
		{
			tStripLbl.Text = "컴퓨터 종료";

			SetToolStripEnabled();

			executeMod = MOD.shutdown;

			SetTimerForDelayedExecution();
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

		#region mouse and keyboard events

		// 절전모드에서 마우스를 움직이는 경우 서버로 로그를 전송하는 이벤트
		public void MainForm_MouseMove_SUSPENDED(object sender, MouseEventArgs e)
		{
			string message = cmdWrite + "&" + wakeUp;
			string URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);
			
			MouseMove -= new MouseEventHandler(MainForm_MouseMove_SUSPENDED);
			KeyPress += new KeyPressEventHandler(MainForm_KeyPressed);
		}

		// 기본적으로 자동실행을 지연하는 마우스 이벤트
		public void MouseMoveDelaysAutoExecution(object sender, MouseEventArgs e)
		{
			autoExecuteTime = 0;
		}

		// 키보드 이벤트 역시 자동으로 자동실행을 지연한다.
		public void KeyboardPressDelaysAutoExecution(object sender, KeyPressEventArgs e)
		{
			autoExecuteTime = 0;
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
			server.Disconnect();
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

		// 서버 연결하는 메소드
		// 연결해제는 종료시
		public void ConnectToServer()
		{
			if (server.Connent(ip, portNum))
			{
				server.Start();

				MessageBox.Show("서버 연결");
			}
			else
			{
				MessageBox.Show("서버 연결 실패");
			}
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

		#region 타이머
		#region 자동 종료 타이머

		void SetTimerForAutoExecution()
		{
			autoExecuteTimer = new System.Timers.Timer();

			autoExecuteTimer.Interval = 1000;
			autoExecuteTimer.Elapsed += new ElapsedEventHandler(TimerBodyForAutoExecution);

			autoExecuteTimer.Start();

			MouseMove += new MouseEventHandler(MouseMoveDelaysAutoExecution);
			KeyPress += new KeyPressEventHandler(KeyboardPressDelaysAutoExecution);
		}

		void TimerBodyForAutoExecution(object sender, ElapsedEventArgs e)
		{
			autoCount++;

			if(autoCount == autoExecuteTime)
			{
				autoExecuteTimer.Stop();
				Execute();
			}
		}

		// 자동실행 종료
		void TurnOffAutoExecution()
		{
			MouseMove -= new MouseEventHandler(MouseMoveDelaysAutoExecution);
			KeyPress -= new KeyPressEventHandler(KeyboardPressDelaysAutoExecution);
		}

		#endregion
		#region 지연실행 타이머

		// 타이머 실행
		void SetTimerForDelayedExecution()
		{
			selectedExecuteTimer = new System.Timers.Timer();

			selectedExecuteTimer.Interval = 1000;
			selectedExecuteTimer.Elapsed += new ElapsedEventHandler(Timer_bodyForDelayedExecution);

			tStripProgBar.Minimum = 0;
			tStripProgBar.Maximum = SetMaximum();

			selectedExecuteTimer.Start();
			TurnOffAutoExecution();
		}

		// 1초마다 실행되는 timer의 내용
		void Timer_bodyForDelayedExecution(object sender, ElapsedEventArgs e)
		{
			tStripProgBar.Value++;

			if (tStripProgBar.Value == tStripProgBar.Maximum)
			{
				selectedExecuteTimer.Stop();

				Execute();
			}
		}
		#endregion
		#endregion

		#region 버튼 클릭시 실제 실행되는 메소드

		public void Suspend()
		{
			string message = cmdWrite + "&" + suspend;
			string URL = logURL + "?id=" + id + "&" + message;
			string argument = "standby force";

			SendRequest(message, URL);

			Process.Start(fileName: @"C:\Users\jay\Downloads\nircmd-x64\nircmd.exe", arguments: argument);
		}

		public void Hibernate()
		{
			string message = cmdWrite + "&" + hibernate;
			string URL = logURL + "?id=" + id + "&" + message;

			SendRequest(message, URL);

			Process.Start(fileName: "rundll32", arguments: "powrprof.dll, SetSuspendState");
		}

		public void ShutDown()
		{
			String message = cmdWrite + "&" + shutdown;
			String URL = logURL + "?id=" + id + "&" + message;
			String argument = "exitwin poweroff";

			SendRequest(message, URL);

			Process.Start(fileName: @"C:\Users\jay\Downloads\nircmd-x64\nircmd.exe", arguments: argument);
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

		public void ChangeID(string id)
		{
			this.id = id;
			tboxID.Text = id;
		}

		// 서버 ip나 포트번호가 바뀔 경우에 실행되는 메소드
		public bool ReconnectToServer(string ip, int portNum)
		{
			server.Disconnect();
			MessageBox.Show("서버 연결 해제");

			this.ip = ip;
			this.portNum = portNum;
			
			if (server.Connent(ip, portNum))
			{
				MessageBox.Show(ip + " " + portNum + " 연결");

				server.Start();

				return true;
			}
			else
			{
				MessageBox.Show("연결 실패");

				return false;
			}
		}
	}
}