using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMail.Code.Models
{
    public class UserToMessage
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private int messageID;

        public int MessageID
        {
            get { return messageID; }
            set { messageID = value; }
        }

        public UserToMessage(int id, int userid, int messageid)
        {
            this.id = id;
            this.userID = userid;
            this.messageID = messageid;
        }
    }
}
