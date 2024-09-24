using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
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

        /// REVIEW. a.boikov. 25.09.2024. Метод может выдать исключение. Лучше, чтобы он возвращал bool,
        /// а его результат можно проверить в тесте
        public void Delete()
        {
            /// REVIEW. a.boikov. 25.09.2024. Эти настройки соединения лучше вынести в отдельный класс
            /// который бы содержал отдельные данные по хост, userid, password и database.
            /// Есть метод там, который возвращает строку соединения на основе этих данных.
            /// Используем его здесь и во всех других частях библиотеки классов, т.е. он становится полноценным
            /// классом самой библиотеки.
            string cs = @"server=localhost;userid=DenFuvier;password=N1PGKt1mT3UAlRRa;database=boyk";
            try
            {
                var con = new MySqlConnection(cs);
                con.Open();

                /// REVIEW. a.boikov. 25.09.2024. Не нужны такие большие пробелы в коде между командами

                string stm = String.Format("DELETE FROM users");


                var cmd = new MySqlCommand(stm, con);

                /// REVIEW. a.boikov. 25.09.2024. Объект никак не используется. Можно смело удалить
                MySqlDataReader Reader = cmd.ExecuteReader(); 

                con.Close();
            }
            catch (Exception Exept)
            {
                /// REVIEW. a.boikov. 25.09.2024. Не нужны такие большие пробелы в коде между командами
                Console.WriteLine(Exept.Message);

            }
        }
    }

}
///1edwaqr