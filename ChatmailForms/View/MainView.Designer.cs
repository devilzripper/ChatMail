namespace ChatmailForms.View
{
    partial class MainView
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Logged = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox1_Users = new System.Windows.Forms.ListBox();
            this.listBox_Messages = new System.Windows.Forms.ListBox();
            this.textBox_ChatText = new System.Windows.Forms.TextBox();
            this.btn_Senden = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer_GetMessagesAndUser = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.messageSchreibenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.loginToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Status,
            this.toolStripStatusLabel_Logged});
            this.statusStrip1.Location = new System.Drawing.Point(0, 406);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(761, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Status
            // 
            this.toolStripStatusLabel_Status.Name = "toolStripStatusLabel_Status";
            this.toolStripStatusLabel_Status.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel_Status.Text = "Status:";
            // 
            // toolStripStatusLabel_Logged
            // 
            this.toolStripStatusLabel_Logged.Name = "toolStripStatusLabel_Logged";
            this.toolStripStatusLabel_Logged.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel_Logged.Text = "Logged Out";
            // 
            // listBox1_Users
            // 
            this.listBox1_Users.DisplayMember = "Name";
            this.listBox1_Users.FormattingEnabled = true;
            this.listBox1_Users.Location = new System.Drawing.Point(12, 41);
            this.listBox1_Users.Name = "listBox1_Users";
            this.listBox1_Users.Size = new System.Drawing.Size(184, 342);
            this.listBox1_Users.TabIndex = 2;
            this.listBox1_Users.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBox1_Users_MouseUp);
            // 
            // listBox_Messages
            // 
            this.listBox_Messages.FormattingEnabled = true;
            this.listBox_Messages.Location = new System.Drawing.Point(202, 41);
            this.listBox_Messages.Name = "listBox_Messages";
            this.listBox_Messages.Size = new System.Drawing.Size(543, 277);
            this.listBox_Messages.TabIndex = 3;
            // 
            // textBox_ChatText
            // 
            this.textBox_ChatText.Location = new System.Drawing.Point(203, 325);
            this.textBox_ChatText.Multiline = true;
            this.textBox_ChatText.Name = "textBox_ChatText";
            this.textBox_ChatText.Size = new System.Drawing.Size(461, 58);
            this.textBox_ChatText.TabIndex = 4;
            // 
            // btn_Senden
            // 
            this.btn_Senden.Location = new System.Drawing.Point(670, 323);
            this.btn_Senden.Name = "btn_Senden";
            this.btn_Senden.Size = new System.Drawing.Size(75, 23);
            this.btn_Senden.TabIndex = 5;
            this.btn_Senden.Text = "Löschen";
            this.btn_Senden.UseVisualStyleBackColor = true;
            this.btn_Senden.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(670, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Senden";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timer_GetMessagesAndUser
            // 
            this.timer_GetMessagesAndUser.Interval = 1000;
            this.timer_GetMessagesAndUser.Tick += new System.EventHandler(this.timer_GetMessagesAndUser_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageSchreibenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 26);
            // 
            // messageSchreibenToolStripMenuItem
            // 
            this.messageSchreibenToolStripMenuItem.Name = "messageSchreibenToolStripMenuItem";
            this.messageSchreibenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.messageSchreibenToolStripMenuItem.Text = "Message Schreiben";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 428);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Senden);
            this.Controls.Add(this.textBox_ChatText);
            this.Controls.Add(this.listBox_Messages);
            this.Controls.Add(this.listBox1_Users);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainView";
            this.Text = "Chatmail";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox1_Users;
        private System.Windows.Forms.ListBox listBox_Messages;
        private System.Windows.Forms.TextBox textBox_ChatText;
        private System.Windows.Forms.Button btn_Senden;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Logged;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer_GetMessagesAndUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem messageSchreibenToolStripMenuItem;
    }
}

