using ChatMail.Code.Models;
using ChatMail.Code.ViewModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.ViewModel
{
    public class MailOverviewViewModel : BaseModelService
    {
        private List<Message> messages;

        public List<Message> Messages
        {
            get { return messages; }
            set { messages = value;
                RaisePropertyChanged("Messages");
            }
        }

    }
}
