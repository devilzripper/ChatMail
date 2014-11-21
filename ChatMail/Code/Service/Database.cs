using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Timers;
using System.Web;
using System.Windows;
using ChatMail.Code.Models;

namespace ChatMail.Services
{
    public class Database
    {
        private SqlConnection sqlConnection;

        private SqlCommand cmd;

        private DataSet actualDataSet = new DataSet();

        private string connString = "Data Source=localhost;Initial Catalog=ChatMail;Integrated Security=True;";

        public Database()
        {
            sqlConnection = new SqlConnection(connString);
        }

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

        public void Insert(Message msg)
        {
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "INSERT INTO Message(Name, SendTime, IsSend) VALUES(@Text, @SendTIme, @isSend)";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                cmd.Parameters.AddWithValue("@Text", msg.Text);
                cmd.Parameters.AddWithValue("@SendTIme", msg.SendTime);
                cmd.Parameters.AddWithValue("@isSend", msg.IsSend);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim erstellen der Messages");
            }
            finally
            {
                Close();
            }
        }

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

        public List<User> getUserList()
        {
            List<User> userListe = new List<User>();
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT * FROM [User]";
                cmd = new SqlCommand(sqlstring, sqlConnection);
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

        private int GetNrFromState(State state)
        {
            switch (state)
            {
                case State.Online:
                    return 1;
                case State.Offline:
                    return 2;
                case State.Away:
                    return 3;
            }
            return -1;
        }

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

        public List<UserToMessage> getUserToMessageList()
        {
            List<UserToMessage> userToMessageListe = new List<UserToMessage>();
            try
            {
                sqlConnection.ConnectionString = connString;
                string sqlstring = "SELECT * FROM UserToMessage";
                cmd = new SqlCommand(sqlstring, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userToMessageListe.Add(new UserToMessage(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2])));
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fehler beim laden der UserToMessage Daten", "Fehlermeldung");
            }
            finally
            {
                Close();
            }

            return userToMessageListe;
        }

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
                        messageListe.Add(new Message(Convert.ToInt32(reader[0]), reader[1].ToString(), Convert.ToDateTime(reader[2]), Convert.ToBoolean(reader[0])));
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

        /// <summary>
        /// Schließt die Verbindung
        /// </summary>
        private void Close()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

    }
}