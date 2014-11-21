using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.Models
{
    public class Message
    {
        private int id;

        private string text;

        private DateTime sendTime;

        private bool isSend;

        public Message(int id, string text, DateTime sendTime, bool isSend)
        {
            this.id = id;
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
