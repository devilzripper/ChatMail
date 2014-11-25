// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserController.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ChatMail.Code.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using ChatMail.Code.Models;
    using ChatMail.Services;

    /// <summary>
    /// Der Controller der User
    /// </summary>
    public class UserController
    {
        private static User currentUser;

        /// <summary>
        /// Ein Instanz der Datenbank
        /// </summary>
        private Database db = new Database();

        /// <summary>
        /// Eine Liste der aktuellen Benutzer
        /// </summary>
        private List<User> userListe = new List<User>();
        
        /// <summary>
        /// Die Login Methode die einen User einloggt
        /// </summary>
        /// <param name="username">Der eingetragene Name des Users</param>
        /// <param name="password">Das eingetragene Passwort des Users</param>
        /// <returns>einen booleschen Wert ob der Login Vorngang erfolgreich war</returns>
        public bool Login(string username, string password)
        {
            userListe = db.getUserList();
            foreach (User user in userListe)
            {
                if(user.Name == username)
                {
                    if(user.Password == password)
                    {
                        currentUser = user;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Falsches Passwort für den User " + user.Name);
                    }
                }
            }
            return false;
        }
        
        /// <summary>
        /// Loggt einen Nutzer aus dem Programm aus.
        /// </summary>
        /// <param name="userid"></param>
        public void Logout(int userid)
        {
           this.db.Alter(this.db.getUserbyID(userid));
           currentUser = null;
        }

        /// <summary>
        /// Registriert einen Nutzer in dem Programm
        /// </summary>
        /// <param name="username">Der Nutzername des Users</param>
        /// <param name="password">Das Passwort des Users</param>
        public void Register(string username, string password)
        {
            this.db.Insert(new User(username, password));
        }

        public List<User> getUserList()
        {
            return this.db.getUserList();
        }

        public static User CurrentUser
        {
            get { return UserController.currentUser; }
            set { UserController.currentUser = value; }
        }
    }
}
