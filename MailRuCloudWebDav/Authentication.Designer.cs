namespace WDMRC.Form
{
	partial class Authentication
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentication));
			this.button1 = new System.Windows.Forms.Button();
			this.textBoxUserName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.SecondAuthPanel = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.textBoxAuthCode = new System.Windows.Forms.TextBox();
			this.AuthCodeLabel = new System.Windows.Forms.Label();
			this.SuccessPanel = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.loginSuccessLabel = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SecondAuthPanel.SuspendLayout();
			this.SuccessPanel.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(265, 295);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBoxUserName
			// 
			this.textBoxUserName.Location = new System.Drawing.Point(102, 70);
			this.textBoxUserName.Name = "textBoxUserName";
			this.textBoxUserName.Size = new System.Drawing.Size(238, 20);
			this.textBoxUserName.TabIndex = 1;
			this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "User name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(102, 114);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.Size = new System.Drawing.Size(238, 20);
			this.textBoxPassword.TabIndex = 3;
			this.textBoxPassword.UseSystemPasswordChar = true;
			this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
			// 
			// SecondAuthPanel
			// 
			this.SecondAuthPanel.Controls.Add(this.button2);
			this.SecondAuthPanel.Controls.Add(this.textBoxAuthCode);
			this.SecondAuthPanel.Controls.Add(this.AuthCodeLabel);
			this.SecondAuthPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SecondAuthPanel.Location = new System.Drawing.Point(0, 0);
			this.SecondAuthPanel.Name = "SecondAuthPanel";
			this.SecondAuthPanel.Size = new System.Drawing.Size(352, 330);
			this.SecondAuthPanel.TabIndex = 5;
			this.SecondAuthPanel.Visible = false;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(265, 295);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Login";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// textBoxAuthCode
			// 
			this.textBoxAuthCode.Location = new System.Drawing.Point(200, 117);
			this.textBoxAuthCode.Name = "textBoxAuthCode";
			this.textBoxAuthCode.Size = new System.Drawing.Size(125, 20);
			this.textBoxAuthCode.TabIndex = 1;
			this.textBoxAuthCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAuthCode_KeyDown);
			// 
			// AuthCodeLabel
			// 
			this.AuthCodeLabel.AutoSize = true;
			this.AuthCodeLabel.Location = new System.Drawing.Point(49, 120);
			this.AuthCodeLabel.Name = "AuthCodeLabel";
			this.AuthCodeLabel.Size = new System.Drawing.Size(57, 13);
			this.AuthCodeLabel.TabIndex = 0;
			this.AuthCodeLabel.Text = "Auth Code";
			// 
			// SuccessPanel
			// 
			this.SuccessPanel.Controls.Add(this.button3);
			this.SuccessPanel.Controls.Add(this.loginSuccessLabel);
			this.SuccessPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SuccessPanel.Location = new System.Drawing.Point(0, 0);
			this.SuccessPanel.Name = "SuccessPanel";
			this.SuccessPanel.Size = new System.Drawing.Size(352, 330);
			this.SuccessPanel.TabIndex = 6;
			this.SuccessPanel.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(250, 22);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 1;
			this.button3.Text = "Logout";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// loginSuccessLabel
			// 
			this.loginSuccessLabel.AutoSize = true;
			this.loginSuccessLabel.Location = new System.Drawing.Point(95, 142);
			this.loginSuccessLabel.Name = "loginSuccessLabel";
			this.loginSuccessLabel.Size = new System.Drawing.Size(114, 13);
			this.loginSuccessLabel.TabIndex = 0;
			this.loginSuccessLabel.Text = "Connecting successful";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "MailRu Cloud WebDav";
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 70);
			// 
			// userToolStripMenuItem
			// 
			this.userToolStripMenuItem.Enabled = false;
			this.userToolStripMenuItem.Name = "userToolStripMenuItem";
			this.userToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.userToolStripMenuItem.Text = "User";
			this.userToolStripMenuItem.Visible = false;
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// Authentication
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(352, 330);
			this.Controls.Add(this.SuccessPanel);
			this.Controls.Add(this.SecondAuthPanel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxUserName);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Authentication";
			this.Text = "MailRu Cloud WebDav";
			this.Resize += new System.EventHandler(this.Authentication_Resize);
			this.SecondAuthPanel.ResumeLayout(false);
			this.SecondAuthPanel.PerformLayout();
			this.SuccessPanel.ResumeLayout(false);
			this.SuccessPanel.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBoxUserName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxPassword;
		private System.Windows.Forms.Panel SecondAuthPanel;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBoxAuthCode;
		private System.Windows.Forms.Label AuthCodeLabel;
		private System.Windows.Forms.Panel SuccessPanel;
		private System.Windows.Forms.Label loginSuccessLabel;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}

