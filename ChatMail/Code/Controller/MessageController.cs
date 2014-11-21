
namespace ChatMail.Code.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Timers;
    using ChatMail.Code.Models;
    using ChatMail.Services;

    /// <summary>
    /// Der Controller der Nachrichten klasse (Model: Message)
    /// </summary>
    public class MessageController
    {
        /// <summary>
        /// Der Timer der die Daten neu Holt
        /// </summary>
        private Timer time;

        /// <summary>
        /// Liste der Nachrichten für die interne Bearbeitung
        /// </summary>
        private List<Message> messageliste;

        /// <summary>
        /// Die Liste der Messages die der User verschickt hat 
        /// </summary>
        public List<Message> messageFromUserList;

        private List<int> messageIDList;

        private User currentUser;

        public MessageController(User user)
        {
            currentUser = user;
        }

        private Database db = new Database();

        public void time_Tick(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                messageFromUserList = this.getMessageByUser();
            }
        }

        public void StartTimer()
        {
            if (time == null)
            {
                time = new Timer(5000);
            }
            time.Elapsed += time_Tick;
            time.Start();
        }

        public void EndTimer()
        {
            time.EndInit();
            time.Dispose();
        }
        public void Send(Message msg)
        {
            this.db.Insert(msg);
        }

        public List<Message> getMessageListe()
        {
            return messageFromUserList;
        }

        private List<Message> getMessageByUser()
        {
            messageIDList = new List<int>();
            messageliste = new List<Message>();
            foreach (UserToMessage item in db.getUserToMessageList())
            {
                if (item.UserID == currentUser.ID)
                {
                    messageIDList.Add(item.MessageID);
                }
            }
            foreach (int id in messageIDList)
            {
                foreach (Message msg in db.getMessageList())
                {
                    if (msg.ID == id)
                    {
                        messageliste.Add(msg);
                    }
                }
            }
            return messageliste;
        }
    }
}
