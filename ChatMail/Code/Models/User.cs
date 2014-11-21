
namespace ChatMail.Code.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum State
    {
        Online,
        Offline,
        Away
    }

    public class User
    {
        private int id;

        private string name;

        private string password;

        private State state = State.Offline;

        public User(int id, string name, string password, State currentState)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.state = currentState;
        }

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public State State
        {
            get { return state; }
            set { state = value; }
        }


    }
}
