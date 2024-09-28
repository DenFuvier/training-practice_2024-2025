using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using Users;
namespace UserTesting;

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
        Assert.AreEqual(expectedUsers.Count, actualUsers.Count);


        for (int i = 0; i < expectedUsers.Count; i++)
        {
            User exp = expectedUsers[i];
            User Act = actualUsers[i];

            Assert.AreEqual(exp.Login, Act.Login);
            Assert.AreEqual(exp.Password, Act.Password);
            Assert.AreEqual(exp.Surname, Act.Surname);
            Assert.AreEqual(exp.Name, Act.Name);
        }

    }

   
        
        public bool Delete()
        {
            ConnectSettings M = new ConnectSettings();
            string cs = M.GetConnect();
            try
            {
                var con = new MySqlConnection(cs);
                con.Open();
                string stm = "DELETE FROM users";
                var cmd = new MySqlCommand(stm, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception Exept)
            {
                Console.WriteLine(Exept.Message);
                return false;
            }
            return true;
        }
}
///1edwaqr