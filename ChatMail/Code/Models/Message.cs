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
    public class Message
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
        private bool isShown;
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Messages.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID der Message</param>
        /// <param name="text">Der Text der Message</param>
        /// <param name="sendTime">Der Zeitpunkt als die Nachricht versandt wurde</param>
        /// <param name="isSend">Ist die Nachricht versendet?</param>
        public Message(int id, string text, DateTime sendTime, bool isShown)
        {
            this.id = id;
            this.text = text;
            this.sendTime = sendTime;
            this.isShown = isShown;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Messages.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID der Message</param>
        /// <param name="text">Der Text der Message</param>
        /// <param name="sendTime">Der Zeitpunkt als die Nachricht versandt wurde</param>
        /// <param name="isSend">Ist die Nachricht versendet?</param>
        public Message(int id, string text, DateTime sendTime)
        {
            this.id = id;
            this.text = text;
            this.sendTime = sendTime;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="Messages.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID der Message</param>
        /// <param name="text">Der Text der Message</param>
        /// <param name="sendTime">Der Zeitpunkt als die Nachricht versandt wurde</param>
        /// <param name="isSend">Ist die Nachricht versendet?</param>
        public Message(string text, DateTime sendTime, bool isShown)
        {
            this.text = text;
            this.sendTime = sendTime;
            this.isShown = isShown;
        }

        /// <summary>
        /// Parameterloser Kontruktor für Sample Data aus Blend
        /// </summary>
        public Message()
        {

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
        public bool IsShown
        {
            get { return isShown; }
            set { isShown = value; }
        }
        #endregion
    }
}
