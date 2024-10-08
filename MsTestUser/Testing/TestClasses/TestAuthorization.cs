using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Users;



namespace Testing.TestClasses;
[TestClass]
public class TestAuthorization
{
    List<User> testUsers_ = new List<User>() { new User() {Login = "DenF", Password = 887799, Name = "Vasya" , Surname = "OPDFGHJ" },
                                              new User() {Login = "Boyk", Password = 987654, Name = "Petya" , Surname = "POIUY" }};


    [DataRow("DenF", "887799", true)]
    [DataRow("Boyk", "987654", true)]
    [DataRow("ArictT", "boller", false)]
    [DataRow("Pabel", "ModedGun", false)]
    [DataRow("DenF", "wrongpass", false)]  // Верный логин, но неправильный пароль
    /// REVIEW. a.boikov. 2024/10/08. Не хватает кейса, где указан верный логин, но неправильный пароль -- done 
    [TestMethod]
    public void TestUserAuthorization(string Login, string Password, bool expected)
    {
        UserManager userManager = new UserManager();
        userManager.Delete();
        userManager.Write(testUsers_);
        /// REVIEW. a.boikov. 2024/10/08. Avtorizate -> Authorization .. Следовательно и файл тоже -- done 
        bool Actual = userManager.Authorization(Login, Password);
        Assert.AreEqual(expected, Actual);

    }

}
