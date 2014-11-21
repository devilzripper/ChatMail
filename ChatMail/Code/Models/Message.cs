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
        private int id;

        private string text;

        private DateTime sendTime;

        private bool isSend;
        #endregion
        public Message(int id, string text, DateTime sendTime, bool isSend)
        {
            this.id = id;
            this.text = text;
            this.sendTime = sendTime;
            this.isSend = isSend;
        }
        public Message(string text, DateTime sendTime, bool isSend)
        {
            this.text = text;
            this.sendTime = sendTime;
            this.isSend = isSend;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }
        public bool IsSend
        {
            get { return isSend; }
            set { isSend = value; }
        }
    }
}
