using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMail.Code.Controller;
using ChatMail.Code.Models;
using ChatMail.Code.ViewModelService;
using System.Security;

namespace ChatMail.Code.ViewModel
{
    public class UserViewModel : BaseModelService
    {
        private string username;

        public string Username
        {
            get { return username; }
            set { username = value;
                RaisePropertyChanged("Username");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                RaisePropertyChanged("Password");
            }
        }


        UserController usc = new UserController();
        public UserViewModel()
        {
           
        }

        public void Login(string name, string password)
        {
            this.usc.Login(name, password);
        }
    }
}
