// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" company="ITS-Schule Stuttgart">
//  ITS-Schule Stuttgart
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace ChatMail.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;
    using ChatMail.Code.Models;

    /// <summary>
    /// Die Klasse der Datenbankzugriffe
    /// </summary>
    public class Database
    {
        #region private Variables
        /// <summary>
        /// Die Verbindung zum SQL Server
        /// </summary>
        private SqlConnection sqlConnection;

        /// <summary>
        /// Der Befehl der auf die Datenbank ausgeführt werden soll
        /// </summary>
        private SqlCommand cmd;

        /// <summary>
        /// Der ConnectionString zum verbinden in die Datenbank
        /// </summary>
        private string connString = "Data Source=localhost;Initial Catalog=ChatMail;Integrated Security=True;";
        #endregion

        #region Constructor
        /// <summary>
        /// Initialisert eine neue Instanz der <see cref="Database.cs"/> Klasse.
        /// </summary>
        public Database()
        {
            sqlConnection = new SqlConnection(connString);
        }
        #endregion

        #region public Methods

        /// <summary>
        /// Fügt einen Nutzer in die Datenbank ein
        /// </summary>
        /// <param name="user">Der zu eintragende Nutzer</param>
        public void Insert(User user)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "INSERT INTO News(Name, Password) VALUES(@Name, @Password)";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@State", user.State);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim erstellen des Users ");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Fügt eine Nachricht in die Datenbank ein 
        /// </summary>
        /// <param name="msg">Die Nachricht die eingetragen werden soll.</param>
        public int Insert(Message msg)
        {
            int id = 0;
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "INSERT INTO Message(MessageText, SendTime, IsSend) VALUES(@Text, @SendTIme, @isSend) " + "SELECT SCOPE_IDENTITY()";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@Text", msg.Text);
                cmd.Parameters.AddWithValue("@SendTIme", msg.SendTime);
                cmd.Parameters.AddWithValue("@isSend", msg.IsShown);
                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim erstellen der Messages");
            }
            finally
            {
                Close();
            }
            return id;
        }

        /// <summary>
        /// Trägt einen Eintrag in die Verbindungstabelle ein
        /// </summary>
        /// <param name="user2msg">Das Objekt zur Verbindungstabelle</param>
        public void Insert(UserToMessage user2msg)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "INSERT INTO UserToMessage(UserID_FK, MessageID_FK, Recipent_ID_FK) VALUES(@UserID_FK, @MessageID_FK, @Recipent_ID_FK)";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@UserID_FK", user2msg.UserID);
                cmd.Parameters.AddWithValue("@MessageID_FK", user2msg.MessageID);
                cmd.Parameters.AddWithValue("@Recipent_ID_FK", user2msg.Recipent_ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim versenden der Nachricht");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Verändert einen Nutzer in der Datenbank
        /// </summary>
        /// <param name="user"></param>
        public void Alter(User user)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "UPDATE User Set Name=@Name, Password=@Password State=@State WHERE ID=@ID";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@State", GetNrFromState(user.State));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim ändern des Users");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Holt eine Liste von Benutzern aus der Datenbank
        /// </summary>
        /// <returns>Die Liste der Benutzer</returns>
        public List<User> getUserList()
        {
            List<User> userListe = new List<User>();
            try
            {
                string sqlstring = "SELECT * FROM [User]";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Close();
                sqlConnection.ConnectionString = connString;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userListe.Add(new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), GetState(Convert.ToInt32(reader[3]))));

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der Userdaten", "Fehlermeldung");
            }
            finally
            {
                Close();
            }

            return userListe;
        }

        /// <summary>
        /// Holt einen Nutzer anhand seiner ID aus der Datenbank
        /// </summary>
        /// <param name="id">Die ID des Users</param>
        /// <returns>Den User</returns>
        public User getUserbyID(int id)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT * FROM User WHERE ID=@ID";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), GetState(Convert.ToInt32(reader[3])));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der Userdaten", "Fehlermeldung");
            }
            finally
            {
                Close();
            }

            return null;
        }

        /// <summary>
        /// Holt einen Namen eines User einer Messages aus der Datenbank
        /// </summary>
        /// <param name="messageid">Die ID Der Nachricht</param>
        /// <returns>Den Usernamen</returns>
        public string getUserNameByMessage(int messageid)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT Name FROM [User] WHERE ID=(SELECT Top 1 UserID_FK FROM UserToMessage WHERE MessageID_FK=@ID)";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@ID", messageid));
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return Convert.ToString(reader[0]);
                    }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim laden der Userdaten: " + ex.Message, "Fehlermeldung");
            }
            finally
            {
                Close();
            }

            return string.Empty;
        }

        /// <summary>
        /// Holt einen User ID für einer ID von einer Nachricht
        /// </summary>
        /// <param name="messageid">Die Nachrichten ID von der der User </param>
        /// <returns>Holt die</returns>
        public int getUserIDByMessage(int messageid)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT ID FROM User WHERE ID=(SELECT UserID_FK FROM UserToMessage WHERE MessageID_FK=@ID)";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@ID", messageid));
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return Convert.ToInt32(reader[0]);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der Userdaten", "Fehlermeldung");
            }
            finally
            {
                Close();
            }

            return -1;
        }


        /// <summary>
        /// Holt die Liste der UserToMessages Einträge aus der Datenbank
        /// </summary>
        /// <returns></returns>
        public List<UserToMessage> getUserToMessageList()
        {
            List<UserToMessage> userToMessageListe = new List<UserToMessage>();
            try
            {
               string sqlstring = "SELECT * FROM UserToMessage";
               cmd = new SqlCommand(sqlstring, sqlConnection);
               sqlConnection.Close();
               sqlConnection.ConnectionString = connString;
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userToMessageListe.Add(new UserToMessage(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim laden der UserToMessage Daten: " + ex.Message, "Fehlermeldung");
                throw;
            }
            finally
            {
                Close();
            }

            return userToMessageListe;
        }

        /// <summary>
        /// Holt die Nachrichtenliste aus der Datenbank
        /// </summary>
        /// <returns>Eine Messageliste</returns>
        public List<Message> getMessageList()
        {
            List<Message> messageListe = new List<Message>();
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT * FROM Message";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messageListe.Add(new Message(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDateTime(reader[2])));
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der Messagedaten", "Fehlermeldung");
            }
            finally
            {
                Close();
            }
            return messageListe;
        }
        #endregion 

        #region private Methods
        /// <summary>
        /// Schließt die Verbindung
        /// </summary>
        private void Close()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        /// <summary>
        /// Holt den Status aus der Nummer die in der Datenbank steht (Enumeration)
        /// </summary>
        /// <param name="stateNr">Der Status des Nutzers als Zahl</param>
        /// <returns>Den Status</returns>
        private State GetState(int stateNr)
        {
            State state = State.Offline;
            switch (stateNr)
            {
                case 1:
                    state = State.Offline;
                    break;
                case 2:
                    state = State.Online;
                    break;
                case 3:
                    state = State.Away;
                    break;
            }
            return state;
        }

        /// <summary>
        /// Geht die Enumeration durch und liefert eine Zahl zurück
        /// </summary>
        /// <param name="state">Der Status in dem der User sich gerade befindet</param>
        /// <returns>Die Nummer des Statuses wie sie in der Datenbank steht</returns>
        private int GetNrFromState(State state)
        {
            switch (state)
            {
                case State.Offline:
                    return 1;
                case State.Online:
                    return 2;
                case State.Away:
                    return 3;
            }
            return -1;
        }

        #endregion
    }
}