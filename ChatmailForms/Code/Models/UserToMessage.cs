// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ChatMail.Code.Models
{
    public class UserToMessage
    {
        #region Private Variables
        /// <summary>
        /// Die ID des Eintrages in der UserToMessage Tabelle
        /// </summary>
        private int id;

        /// <summary>
        /// Die ID des Users von der die Message stammt
        /// </summary>
        private int userID;

        /// <summary>
        /// Die ID der Messages die von dem User stammt
        /// </summary>
        private int messageID;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="UserToMessage.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID des UserToMessage Eintrages</param>
        /// <param name="userid">Die ID des Users der die Message versendet hat</param>
        /// <param name="messageid">Die Nachrichten ID</param>
        public UserToMessage(int id, int userid, int messageid)
        {
            this.id = id;
            this.userID = userid;
            this.messageID = messageid;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="UserToMessage.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID des UserToMessage Eintrages</param>
        /// <param name="userid">Die ID des Users der die Message versendet hat</param>
        /// <param name="messageid">Die Nachrichten ID</param>
        public UserToMessage(int userid, int messageid)
        {
            this.userID = userid;
            this.messageID = messageid;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Holt oder setzt die ID des UserToMessage Eintrages
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Holt oder setzt die UserID des UserToMessage Eintrages
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// Holt oder setzt die MessageID des UserToMessage Eintrages
        /// </summary>
        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }
        #endregion

    }
}
