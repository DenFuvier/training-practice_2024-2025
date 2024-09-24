using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Users
{
    public class UserManager
    {

        /// REVIEW. a.boikov. 25.09.2024. Не нужны такие большие пробелы в коде
        public void Add(User u)
        {

        }

        public bool Write(List<User> users)
        {
            /// REVIEW. a.boikov. 25.09.2024. Повторение. См. комментарий, что оставил по этому поводу
            /// в методе Delete тестов.
            string cs = @"server=localhost;userid=DenFuvier;password=N1PGKt1mT3UAlRRa;database=boyk";
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


                        /// REVIEW. a.boikov. 25.09.2024. Не нужны такие большие пробелы в коде

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
            /// REVIEW. a.boikov. 25.09.2024. переменные называются с малекой буквой в camelCase
            List<User> Users = new List<User>();

            /// REVIEW. a.boikov. 25.09.2024. Повторение. См. комментарий, что оставил по этому поводу
            /// в методе Delete тестов.
            string cs = @"server=localhost;userid=DenFuvier;password=N1PGKt1mT3UAlRRa;database=boyk";
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