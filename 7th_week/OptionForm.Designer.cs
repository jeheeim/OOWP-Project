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
			this.SuspendLayout();
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Location = new System.Drawing.Point(12, 14);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(42, 12);
			this.lblID.TabIndex = 10;
			this.lblID.Text = "UserID";
			// 
			// tboxID
			// 
			this.tboxID.Location = new System.Drawing.Point(14, 34);
			this.tboxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tboxID.Name = "tboxID";
			this.tboxID.ReadOnly = true;
			this.tboxID.Size = new System.Drawing.Size(162, 21);
			this.tboxID.TabIndex = 8;
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(12, 83);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(56, 12);
			this.lblServer.TabIndex = 11;
			this.lblServer.Text = "Server IP";
			// 
			// tboxServerIP
			// 
			this.tboxServerIP.Location = new System.Drawing.Point(14, 103);
			this.tboxServerIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tboxServerIP.Name = "tboxServerIP";
			this.tboxServerIP.ReadOnly = true;
			this.tboxServerIP.Size = new System.Drawing.Size(162, 21);
			this.tboxServerIP.TabIndex = 12;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(14, 175);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.btnAccept.TabIndex = 14;
			this.btnAccept.Text = "확인";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(101, 175);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "취소";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// OptionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(198, 228);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.tboxServerIP);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.lblID);
			this.Controls.Add(this.tboxID);
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
	}
}