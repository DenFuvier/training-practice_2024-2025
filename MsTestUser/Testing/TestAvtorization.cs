using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Resultset;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using Users;

[TestClass]
public class TestAvtorization
{
    [TestMethod]
    [DataRow(1, 1, 2 , 4)]
    [DataRow(2, 2, 4)]
    [DataRow(3, 3, 6)]
    [DataRow(0, 0, 1)]
    public void  UserAvtorizate ()
    {



    }
}
