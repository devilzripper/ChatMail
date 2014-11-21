using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ChatMail.Code.Models;
using ChatMail.Services;

namespace ChatMail.Code.Controller
{
    public class UserController
    {
        Database db = new Database();

        List<User> userListe = new List<User>();

        List<UserToMessage> messageToUserList = new List<UserToMessage>();

        public bool Login(string username, string password)
        {
            userListe = db.getUserList();
            foreach (User user in userListe)
            {
                if(user.Name == username)
                {
                    if(user.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Falsches Passwort für den User " + user.Name);
                    }
                }
            }
            return false;
        }
        
        public void Logout()
        {
           // this.db.AlterUser(current);   
        }

        public void Register(string username, string password)
        {
            this.db.Insert(new User(username, password));
        }

    }
}
