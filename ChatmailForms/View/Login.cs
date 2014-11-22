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
    public partial class Login : Form
    {
        private static User currentUser;

        public Login()
        {
            InitializeComponent();
        }

        private void button_Senden_Click(object sender, EventArgs e)
        {
            UserController usc = new UserController();
            currentUser = usc.Login(this.textBox_Name.Text, this.textBox_Password.Text);
            if (currentUser != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        public static User CurrentUser
        {
            get { return Login.currentUser; }
            set { Login.currentUser = value; }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void textBox_Password_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                button_Senden.PerformClick();
            }
        }

    }
}
