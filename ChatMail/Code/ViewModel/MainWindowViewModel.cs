using ChatMail.Code.Models;
using ChatMail.Code.ViewModelService;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.ViewModel
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
