using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Users
{
    public class UserManager
    {
        public void Add(User u)
        {

        }
        public bool Write(List<User> users)
        {
            ConnectSettings M = new ConnectSettings();
            string cs = M.GetConnect();
            try
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();
                    for (int i = 0; i < users.Count; i++)
                    {
                        User user = users[i];
                        string login = user.Login;
                        string name = user.Name; ;
                        string surname = user.Surname;
                        int password = user.Password;

                        var stm = String.Format("INSERT INTO users (login, name, surname, password) VALUES ('{0}', '{1}', '{2}', '{3}')",
                                                 login, name, surname, password);
                        using (var cmd = new MySqlCommand(stm, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public List<User> ReadAll()
        {
            ConnectSettings M = new ConnectSettings();
            List<User> Users = new List<User>();
            string cs = M.GetConnect();
            try
            {

                var con = new MySqlConnection(cs);

                con.Open();

                var stm = String.Format("SELECT Name, Surname , password , login FROM users");

                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {

                    string name = Reader.GetString(0);
                    string surname = Reader.GetString(1);
                    int password = Reader.GetInt32(2);
                    string login = Reader.GetString(3);
                    Users.Add(new User { Name = name, Surname = surname, Login = login, Password = password });

                }

            }
            catch (Exception Exept)
            {


                Console.WriteLine(Exept.Message);
                return new List<User>();

            }
            return Users;

        }
    }
}