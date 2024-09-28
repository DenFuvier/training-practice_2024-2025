using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using Users;

namespace UserTesting
{
    [TestClass]
    public class TUserManager
    {

        [TestMethod]
        public void TestWrite()
        {
            Delete();
            UserManager userManager = new UserManager();
            List<User> expectedUsers = new List<User>() { new User() {Login = "abc", Password = 2234, Name = "Vasya" , Surname = "OPDFGHJ" },
                                                  new User() {Login = "cbd", Password = 43554, Name = "Petya" , Surname = "POIUY" }};

            bool success = userManager.Write(expectedUsers);
            Assert.IsTrue(success);
            List<User> actualUsers = userManager.ReadAll();
            expectedUsers.Sort(delegate (User x, User y)
            {
                return x.Login.CompareTo(y.Login);

            });
            Assert.AreEqual(expectedUsers.Count, actualUsers.Count);
            CollectionAssert.AreEqual(expectedUsers, actualUsers, Convert.ToString(expectedUsers[0].Password));

        }

        public class Connect
        {
            public string server = "localhost";
            public string userid = "DenFuvier";
            public string password = "N1PGKt1mT3UAlRRa";
            public string database = "boyk";

            public string GetConnect()
            {
                return $"server={server};userid={userid};password={password};database={database}";
            }
        }
        public class useConnect
        {
            private Connect _Con = new Connect();
            public bool Delete()
            {

                /// REVIEW. a.boikov. 25.09.2024. Ёти настройки соединени€ лучше вынести в отдельный класс
                /// который бы содержал отдельные данные по хост, userid, password и database.
                /// ≈сть метод там, который возвращает строку соединени€ на основе этих данных.
                /// »спользуем его здесь и во всех других част€х библиотеки классов, т.е. он становитс€ полноценным
                /// классом самой библиотеки.
                string cs = _Con.GetConnect();
                try
                {
                    var con = new MySqlConnection(cs);
                    con.Open();
                    string stm = String.Format("DELETE FROM users");
                    var cmd = new MySqlCommand(stm, con);
                    con.Close();
                }
                catch (Exception Exept)
                {
                    Console.WriteLine(Exept.Message);
                }
                return false;
            }
        }
    }
}
///1edwaqr