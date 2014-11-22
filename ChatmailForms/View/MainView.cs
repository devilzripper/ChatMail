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
        List<User> currentUserList = new List<User>();
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
            }
        }

        public void fillListBoxUser()
        {
            listBox1_Users.Items.Clear();
            foreach (User us in currentUserList)
            {
                if(us.State == State.Online)
                {
                    listBox1_Users.Items.Add(us);
                }
            }
        }

        private void timer_GetMessagesAndUser_Tick(object sender, EventArgs e)
        {
            this.currentUserList = usc.getUserList();
            fillListBoxUser();
        }

        private void listBox1_Users_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(e.X, e.Y);
            }
        }
    }
}
