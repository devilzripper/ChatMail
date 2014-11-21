using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatMail.Code.Controller;
using ChatMail.Code.Models;

namespace ChatMail.Code.ViewModel
{
    public class UserViewModel 
    {
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
