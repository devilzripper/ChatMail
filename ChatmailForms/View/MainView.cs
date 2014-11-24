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
        List<string> msgToRecipentList = new List<string>();
        int i = 0;
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
                this.toolStripStatusLabel_Logged.Text = "Logged In";
                this.timer_GetMessagesAndUser.Enabled = true;
                currentUserList = usc.getUserList();
                this.bindingSource1.DataSource = currentUserList;
                this.listBox1_Users.DataSource = bindingSource1;
                this.comboBox_Users.DataSource = bindingSource1;
                bindingSource_Message.DataSource = this.msgToRecipentList;
                this.listBox_Messages.DataSource = bindingSource_Message;
                msg = new MessageController(Login.CurrentUser);
            }
        }

        public void fillListBoxUser()
        {
            listBox1_Users.Items.Clear();
            foreach (User us in currentUserList)
            {
                if (us.State == State.Online)
                {
                    listBox1_Users.Items.Add(us);
                }
            }
        }

        public void FillMessagesListBox()
        {
            var msgfromuser = msg.getMessageGotForUserList();
            foreach (Messages msgToRecipent in msgfromuser.Where(m => m.IsShown == false))
            {
                
                if (i < 1)
                {
                    msgToRecipentList.Add(builtChatOverViewString(msgToRecipent, 1));
                    msgToRecipent.IsShown = true;
                }
            }
            var msgfromuserlist = msg.getMessageFromUserList();
            foreach (var item in msgfromuserlist.Where(m => m.IsShown == false))
            {
                if (i < 1)
                {
                    msgToRecipentList.Add(builtChatOverViewString(item, 0));
                    item.IsShown = true;
                }
            }
            i++;
        }

        private void timer_GetMessagesAndUser_Tick(object sender, EventArgs e)
        {
            this.currentUserList = usc.getUserList();
            FillMessagesListBox();
        }

        private void listBox1_Users_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (listBox1_Users.SelectedItem != null)
                {
                    this.listBox1_Users.ContextMenuStrip = contextMenuStrip1;
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
                    msg.Send(msgToSend, Login.CurrentUser.ID, RecipentUser.ID);
                    listBox_Messages.Items.Add(builtChatOverViewString(msgToSend, 0));
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
                    strB.Append(Message.Text);
                    break;
            }
            return string.Empty;
        }
    }
}
