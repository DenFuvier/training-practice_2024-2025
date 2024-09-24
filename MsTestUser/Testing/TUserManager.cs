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

        public void Delete()
        {
            string cs = @"server=localhost;userid=DenFuvier;password=N1PGKt1mT3UAlRRa;database=boyk";
            try
            {
                var con = new MySqlConnection(cs);
                con.Open();



                string stm = String.Format("DELETE FROM users");


                var cmd = new MySqlCommand(stm, con);
                MySqlDataReader Reader = cmd.ExecuteReader();

                con.Close();
            }
            catch (Exception Exept)
            {

                Console.WriteLine(Exept.Message);

            }
        }
    }

}
///1edwaqr