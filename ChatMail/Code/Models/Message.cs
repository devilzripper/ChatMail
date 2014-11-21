using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.Models
{
    public class Message
    {
        public Message(int id, string text, DateTime sendTime, bool isSend)
        {
            this.id = id;
            this.text = text;
            this.sendTime = sendTime;
            this.isSend = isSend;
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private DateTime sendTime;

        public DateTime SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        private bool isSend;

        public bool IsSend
        {
            get { return isSend; }
            set { isSend = value; }
        }
    }
}
