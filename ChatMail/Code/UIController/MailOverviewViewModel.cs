using ChatMail.Code.Controller;
using ChatMail.Code.Models;
using ChatMail.Code.ViewModelService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChatMail.Code.UIController
{
    public class MailOverviewViewModel : BaseModelService
    {
        #region Binding Fields


        private ObservableCollection<Message> messageList;

        public ObservableCollection<Message> MessageList
        {
            get { return messageList; }
            set { messageList = value; }
        }
        

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
                SelectedMessage = messageList[messageListSelectedIndex];
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

        MessageController msc;

        public MailOverviewViewModel()
        {
            if (UserController.CurrentUser != null)
            {
                msc = new MessageController(UserController.CurrentUser);
            }
        }

        public void SendResponse()
        {
        }
    }
}
