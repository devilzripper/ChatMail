using ChatMail.Code.Models;
using ChatMail.Code.ViewModelService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatMail.Code.ViewModel
{
    public class MailOverviewViewModel : BaseModelService
    {
        #region Binding Fields

        private string responseMessageText;

        public string ResponseMessageText
        {
            get { return responseMessageText; }
            set { responseMessageText = value;
                RaisePropertyChanged("ResponseMessageText");
            }
        }

        private int messageListSelectedIndex;

        public int MessageListSelectedIndex
        {
            get { return messageListSelectedIndex; }
            set
            {
                messageListSelectedIndex = value;
                SelectedMessage = Messages[value];
                RaisePropertyChanged("MessageListSelectedIndex");
            }
        }

        private Message selectedMessage;

        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                selectedMessage = value;
                RaisePropertyChanged("SelectedMessage");
            }
        }

        #endregion

        private ObservableCollection<Message> messages;
        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { messages = value;
            }
        }



        public void SendResponse()
        {
            
        }
    }
}
