using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Users;



namespace Testing.TestClasses;
[TestClass]
public class TestAvtorization
{
    List<User> testUsers_ = new List<User>() { new User() {Login = "DenF", Password = 887799, Name = "Vasya" , Surname = "OPDFGHJ" },
                                              new User() {Login = "Boyk", Password = 987654, Name = "Petya" , Surname = "POIUY" }};


    [DataRow("DenF", "887799", true)]
    [DataRow("Boyk", "987654", true)]
    [DataRow("ArictT", "boller", false)]
    [DataRow("Pabel", "ModedGun", false)]
    [TestMethod]
    public void TestUserAvtorizate(string Login, string Password, bool expected)
    {
        UserManager userManager = new UserManager();
        userManager.Delete();
        userManager.Write(testUsers_);
        bool Actual = userManager.Avtorizate(Login, Password);
        Assert.AreEqual(expected, Actual);

    }

}
