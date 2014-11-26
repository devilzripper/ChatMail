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
    using ChatmailForms.Code.ViewModel;

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
        private List<Messages> messageliste;

        /// <summary>
        /// Die Liste der Messages die der User verschickt hat 
        /// </summary>
        public List<Messages> messageFromUserList;

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
        /// Versendet eine Nachricht und trägt sie somit in die Datenbank ein
        /// </summary>
        /// <param name="msg">Die Nachricht die übertragen werden sollen</param>
        public void Send(Messages msg, int recipent_Id)
        {
            int messageid = this.db.Insert(msg);
            this.db.Insert(new UserToMessage(this.currentUser.ID, recipent_Id, messageid));
        }

        /// <summary>
        /// Holt eine Liste von Nachrichten.
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        public List<MessageViewModel> getMessageGotForUserList(int id)
        {
            return this.db.getMessageForUser(id);
        }

        /// <summary>
        /// Holt eine Liste von Nachrichten.
        /// </summary>
        /// <returns>Die gefüllte Liste an Nachrichten</returns>
        public List<Messages> getMessageFromUserList(int userid)
        {
            return this.db.getMessageSentByUser(userid);
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

        #endregion
    }
}
