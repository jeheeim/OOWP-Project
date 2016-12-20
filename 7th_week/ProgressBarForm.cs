using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics;

namespace PowerSaver
{
	public partial class ProgressBarForm : Form
	{
		MainForm mainform;

		MOD executeMod;
		System.Timers.Timer timer;
		int time;
		string title;

		public ProgressBarForm(MainForm mainform, MOD executeMod)
		{
			InitializeComponent();

			this.mainform = mainform;
			this.executeMod = executeMod;

			progressBar1.Minimum = 0;
			progressBar1.Maximum = 15;

			time = 15;
			lblTitle.Text = "초 뒤에 ";

			switch (executeMod)
			{
				case MOD.suspend:
					lblTitle.Text += "절전모드가 실행됩니다.";
					break;
				case MOD.hibernate:
					lblTitle.Text += "최대절전모드가 실행됩니다.";
					break;
				case MOD.shutdown:
					lblTitle.Text += "종료됩니다.";
					break;
			}

			title = lblTitle.Text;

			lblTitle.Text = time + title;

			timer = new System.Timers.Timer();

			timer.Interval = 1000;
			timer.Elapsed += new ElapsedEventHandler(Timer_body);

			timer.Start();
		}

		// 매초 진행되는 타이머의 몸체 메소드
		void Timer_body(object sender, ElapsedEventArgs e)
		{
			progressBar1.Value++;

			lblTitle.Text = (--time) + title;

			if (progressBar1.Value == progressBar1.Maximum)
			{
				timer.Stop();

				Execute();
			}
		}

		#region 실행 메소드

		void Suspend()
		{
			string message = mainform.CmdWrit + "&" + mainform.ActSusp;
			string URL = mainform.logURL + "?id=" + mainform.id + "&" + message;
			string argument = "standby force";

			MouseMove += new MouseEventHandler(mainform.MainForm_MouseMove);
			
			mainform.SendRequest(message, URL);

			Process.Start(fileName: @"C:\Users\jay\Downloads\nircmd-x64\nircmd.exe", arguments: argument);
		}

		void Hibernate()
		{
			string message = mainform.CmdWrit + "&" + mainform.ActHibr;
			string URL = mainform.logURL + "?id=" + mainform.id + "&" + message;

			Process.Start(fileName: "rundll32", arguments: "powrprof.dll, SetSuspendState");
		}

		void ShutDown()
		{
			String message = mainform.CmdWrit + "&" + mainform.ActShut;
			String URL = mainform.logURL + "?id=" + mainform.id + "&" + message;
			String argument = "exitwin poweroff";

			mainform.SendRequest(message, URL);

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

		#region button click

		private void Button1_Click(object sender, EventArgs e)
		{
			timer.Stop();
			Execute();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			timer.Stop();
			Close();
		}

		#endregion

	}
}
