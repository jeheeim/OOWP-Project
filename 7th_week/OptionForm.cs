using System;
using System.IO;
using System.Windows.Forms;

namespace PowerSaver
{
	public partial class OptionForm : Form
	{
		MainForm mainForm;

		public OptionForm(MainForm mainForm)
		{
			InitializeComponent();

			this.mainForm = mainForm;

			tboxID.Text = mainForm.id;
			tboxServerIP.Text = mainForm.IP;
			tboxPortNum.Text = mainForm.PortNum.ToString();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			string id = tboxID.Text;
			string serverIP = tboxServerIP.Text;
			int portNum = int.Parse(tboxPortNum.Text);

			if(id != mainForm.id)
			{
				if (ChangeID(id)) { MessageBox.Show("변경되었습니다!"); }
				else { MessageBox.Show("이미 존재하는 아이디입니다!"); }
			}

			if (serverIP != mainForm.IP && portNum != mainForm.PortNum)
			{
				if (mainForm.ReconnectToServer(serverIP, portNum))
				{
					string directory = "option.txt";
					FileInfo fileInfo = new FileInfo(directory);

					File.WriteAllText(directory, id + "/" + serverIP + "/" + portNum);
				}
			}

			switch (cboxAutoExecuteMode.SelectedIndex)
			{
				case -1:
					break;
				case 0:
					mainForm.AutoExecute = MOD.suspend;
					break;
				case 1:
					mainForm.AutoExecute = MOD.hibernate;
					break;
				case 2:
					mainForm.AutoExecute = MOD.shutdown;
					break;
			}

			switch (cboxAutoExecuteTime.SelectedIndex)
			{
				case -1:
					break;
				case 0:
					mainForm.AutoExecuteTime = 600;
					break;
				case 1:
					mainForm.AutoExecuteTime = 15 * 60;
					break;
				case 2:
					mainForm.AutoExecuteTime = 30 * 60;
					break;
				case 3:
					mainForm.AutoExecuteTime = 45 * 60;
					break;
				case 4:
					mainForm.AutoExecuteTime = 60 * 60;
					break;
			}

			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		bool ChangeID(string id)
		{
			string URL = mainForm.RegisterURL + "?id=" + id;
			string[] returnMessage = mainForm.SendRequest(id, URL).Split(':');

			if (returnMessage[0] == "OK")
			{
				return true;
			}
			else { return false; }
		}
	}
}
