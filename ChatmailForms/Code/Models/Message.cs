// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Message.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ChatMail.Code.Models
{
    using System;

    /// <summary>
    /// Die Klasse der Nachrichten
    /// </summary>
    public class Messages
    {
        #region private Variables
        /// <summary>
        /// Die ID des Users
        /// </summary>
        private int id;

        /// <summary>
        /// Der Text der Message
        /// </summary>
        private string text;

        /// <summary>
        /// Die Uhrzeit des Versends
        /// </summary>
        private DateTime sendTime;

        /// <summary>
        /// Ist die Nachricht versandt?
        /// </summary>
        private bool isSend;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Messages.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID der Message</param>
        /// <param name="text">Der Text der Message</param>
        /// <param name="sendTime">Der Zeitpunkt als die Nachricht versandt wurde</param>
        /// <param name="isSend">Ist die Nachricht versendet?</param>
        public Messages(int id, string text, DateTime sendTime, bool isSend)
        {
            this.id = id;
            this.text = text;
            this.sendTime = sendTime;
            this.isSend = isSend;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Holt oder setzt die ID der Message
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Holt oder setzt den Text der Message
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// Holt oder setzt den Zeitpunkt des Versends
        /// </summary>
        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        /// <summary>
        /// Holt oder setzt den Wert ob es gesendet wurden ist.
        /// </summary>
        public bool IsSend
        {
            get { return isSend; }
            set { isSend = value; }
        }
        #endregion
    }
}
