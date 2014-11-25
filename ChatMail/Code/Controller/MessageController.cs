// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageController.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
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
        #region Private Variables
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

        /// <summary>
        /// Die id  List der Messages
        /// </summary>
        private List<int> messageIDList;

        /// <summary>
        /// Der aktuelle User des Programms
        /// </summary>
        private User currentUser;

        /// <summary>
        /// Die Instanz der Datenbank
        /// </summary>
        private Database db = new Database();
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="MessageController.cs"/> Klasse.
        /// </summary>
        /// <param name="user">Der aktuell eingeloggte Nutzer</param>
        public MessageController(User user)
        {
            currentUser = user;
        }
        #endregion

        #region public Methods
        /// <summary>
        /// Das Event des Timers dasd alle 5000ms ausgelöst wird und die Daten aktualisiert
        /// </summary>
        /// <param name="sender">Der Event Sender</param>
        /// <param name="e">Wird nicht benutzt.</param>
        public void time_Tick(object sender, EventArgs e)
        {
            if (this.currentUser != null)
            {
                this.messageFromUserList = this.getMessageGotForUserList();
            }
        }

        /// <summary>
        /// Startet den Timer mit 5000ms Zeitspanne
        /// </summary>
        public void StartTimer()
        {
            if (this.time == null)
            {
                this.time = new Timer(5000);
            }
            this.time.Elapsed += time_Tick;
            this.time.Start();
        }

        /// <summary>
        /// Beendet den Timer
        /// </summary>
        public void EndTimer()
        {
            time.EndInit();
            time.Dispose();
        }

        /// <summary>
        /// Versendet eine Nachricht und trägt sie somit in die Datenbank ein
        /// </summary>
        /// <param name="msg">Die Nachricht die übertragen werden sollen</param>
        public void Send(Message msg, int recipent_Id)
        {
            int messageid = this.db.Insert(msg);
            this.db.Insert(new UserToMessage(this.currentUser.ID, recipent_Id, messageid));
        }

        /// <summary>
        /// Holt eine Liste von Nachrichten.
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        public List<Message> getMessageGotForUserList()
        {
            return this.getMessageGotForUser();
        }

        /// <summary>
        /// Holt eine Liste von Nachrichten.
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        public List<Message> getMessageFromUserList()
        {
            return this.getMessageSentByUser();
        }

        /// <summary>
        /// Holt einen Usernamen von einer gesendeten Nachricht
        /// </summary>
        /// <param name="id">Die ID der Message</param>
        /// <returns>Den Username der versendeten Nachricht</returns>
        public string getUserNameByMessage(int id)
        {
            return this.db.getUserNameByMessage(id);
        }

        /// <summary>
        /// Holt eine UserID von der Message
        /// </summary>
        /// <param name="id">Die Message ID</param>
        /// <returns>Die User ID</returns>
        public int getUserIDByMessage(int id)
        {
            return this.db.getUserIDByMessage(id);
        }
        #endregion

        #region private Methods

        /// <summary>
        /// Holt eine Liste von Nachrichten die nur von dem Nutzer sind
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        private List<Message> getMessageSentByUser()
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

        /// <summary>
        /// Holt eine Liste von Nachrichten die nur von dem Nutzer sind
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        private List<Message> getMessageGotForUser()
        {
            messageIDList = new List<int>();
            messageliste = new List<Message>();
            foreach (UserToMessage item in db.getUserToMessageList())
            {
                if (item.Recipent_ID == currentUser.ID)
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
        #endregion
    }
}
