using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Users;



namespace Testing.TestClasses;

[TestClass]
public class TUserManager
{

    [TestMethod]
    public void TestWrite()
    {
        UserManager userManager = new UserManager();
        userManager.Delete();
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
}
///1edwaqr