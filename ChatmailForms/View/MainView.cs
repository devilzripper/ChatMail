using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatMail.Code.Controller;
using ChatMail.Code.Models;

namespace ChatmailForms.View
{
    public partial class MainView : Form
    {
        UserController usc = new UserController();
        MessageController msg;
        List<User> currentUserList = new List<User>();
        List<Messages> msgToRecipentList = new List<Messages>();
        public MainView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            if (log.ShowDialog() == DialogResult.OK)
            {
                this.msg = new MessageController(Login.CurrentUser);
                this.toolStripStatusLabel_Logged.Text = "Logged In";
                this.timer_GetMessagesAndUser.Enabled = true;
                this.currentUserList = this.usc.getUserList();
                this.bindingSource1.DataSource = currentUserList;
                this.msgToRecipentList = this.msg.getMessageGotForUserList(Login.CurrentUser.ID);
                this.bindingSource_Message.DataSource = msgToRecipentList;
                this.listBox_Users.DataSource = bindingSource1;
                this.comboBox_Users.DataSource = bindingSource1;
                this.dgvMessages.DataSource = bindingSource_Message;
            }
        }

        //public void FillMessagesListBox()
        //{
        //    var msgfromuser = msg.getMessageGotForUserList();
        //    if (i < 1)
        //    {
        //        foreach (Messages msgToRecipent in msgfromuser.Where(m => m.IsShown == false))
        //        {
        //            //msgToRecipentList.Add(new Messages(builtChatOverViewString(msgToRecipent, 1), DateTime.Now, false));
        //            //msgToRecipent.IsShown = true;
        //            this.richTextBox1.Text += (builtChatOverViewString(msgToRecipent, 1));
        //        }
        //        var msgfromuserlist = msg.getMessageFromUserList();
        //        foreach (var item in msgfromuserlist.Where(m => m.IsShown == false))
        //        {
        //            msgToRecipentList.Add(new Messages(builtChatOverViewString(item, 0), DateTime.Now, false));
        //            item.IsShown = true;
        //        }
        //    }
        //    i++;
        //}

        private void timer_GetMessagesAndUser_Tick(object sender, EventArgs e)
        {
            this.currentUserList = this.usc.getUserList();
            this.msgToRecipentList = this.msg.getMessageGotForUserList(Login.CurrentUser.ID);
            dgvMessages.DataSource = null;
            dgvMessages.DataSource = msgToRecipentList;
        }

        private void listBox1_Users_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (listBox_Users.SelectedItem != null)
                {
                    this.listBox_Users.ContextMenuStrip = contextMenuStrip1;
                    this.contextMenuStrip1.Show(Cursor.Position);

                }
            }
        }

        private void MainView_Load(object sender, EventArgs e)
        {
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (Login.CurrentUser != null)
            {
                if (comboBox_Users.SelectedItem != null)
                {
                    var RecipentUser = (User)comboBox_Users.SelectedItem;
                    var msgToSend = new Messages(this.textBox_ChatText.Text, DateTime.Now, false);
                    msg.Send(msgToSend, RecipentUser.ID);
                    this.textBox_ChatText.Text = string.Empty;
                }
            }
        }

        private string builtChatOverViewString(Messages Message, int Choice)
        {
            StringBuilder strB = new StringBuilder();
            switch (Choice)
            {
                case 0:
                    strB.Append("Die Nachricht wurde gesendet an: " + ((User)comboBox_Users.SelectedItem).Name);
                    return strB.ToString();
                case 1:
                    strB.Append("Neue Nachricht von ");
                    strB.Append(msg.getUserNameByMessage(Message.ID));
                    strB.Append(" Erhalten: ");
                    strB.Append(Message.Text + Environment.NewLine);
                    return strB.ToString();
            }
            return string.Empty;
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox_ChatText_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter && comboBox_Users.SelectedItem != null)
            {
                button_Send.PerformClick();
            }
        }
    }
}
