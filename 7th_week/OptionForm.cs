using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			if(tboxID.Text != mainForm.id)
			{
				string id = tboxID.Text;
				string URL = mainForm.RegisterURL+ "?id=" + id;
				string[] returnMessage = mainForm.SendRequest(id, URL).Split(':');

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

				string message = mainForm.CmdWrit + "&" + mainForm.ActWake;
				URL = mainForm.LogURL + "?id=" + id + "&" + message;

				mainForm.SendRequest(message, URL);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		void SaveUser(string userID)
		{
			string directory = "userid.txt";
			FileInfo fileInfo = new FileInfo(directory);

			if (fileInfo.Exists) { return; }
			else { File.WriteAllText(directory, userID); }
		}
	}
}
