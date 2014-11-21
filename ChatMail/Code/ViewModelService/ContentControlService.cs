using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ChatMail.Code.ViewModelService
{
    class ContentControlService : BaseModelService
    {
        private int showedWindow;

        public int ShowedWindow
        {
            get { return showedWindow; }
            set { showedWindow = value;
                RaisePropertyChanged("ShowedWindow");
            }
        }
    }
}
