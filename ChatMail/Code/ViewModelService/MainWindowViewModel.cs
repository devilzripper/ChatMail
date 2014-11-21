using ChatMail.Code.Models;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.ViewModelService
{
    class MainWindowViewModel : BaseModelService
    {
        private User currentUser;

        public User CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                base.RaisePropertyChanged("CurrentUser");
            }
        }
        
        public MainWindowViewModel()
        {
            
        }
    }
}
