// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ChatMail.Code.Models
{
    /// <summary>
    /// Die Enumeration des Statuses des Users
    /// </summary>
    public enum State
    {
        Online,
        Offline,
        Away
    }

    /// <summary>
    /// Die Klasse des Users
    /// </summary>
    public class User
    {
        #region private Variables
        /// <summary>
        /// Die ID des Users
        /// </summary>
        private int id;

        /// <summary>
        /// Der Name des Users
        /// </summary>
        private string name;

        /// <summary>
        /// Das Passwort des Users
        /// </summary>
        private string password;

        /// <summary>
        /// Der Status des Users
        /// </summary>
        private State state = State.Offline;

        #endregion

        #region Constructor
        /// <summary>
        /// Initialisert eine neue Instanz der <see cref="User.cs"/> Klasse.
        /// </summary>
        /// <param name="id">Die ID des Users</param>
        /// <param name="name">Der Name des Users</param>
        /// <param name="password">das Passwort des Users</param>
        /// <param name="currentState">der Status des Users</param>
        public User(int id, string name, string password, State currentState)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.state = currentState;
        }

        /// <summary>
        /// Initialisert eine neue Instanz der <see cref="User.cs"/> Klasse.
        /// </summary>
        /// <param name="name">Der Name des Users</param>
        /// <param name="password">das Passwort des Users</param>
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        #endregion

        #region Propertys
        /// <summary>
        /// Holt oder Setzt die ID des Users
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Der Name des Users
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Das Passwort des Users
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Der Status des Users
        /// </summary>
        public State State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion
    }
}
