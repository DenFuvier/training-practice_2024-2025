using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsTestUser.MVP.Models;
using Moq;
using MsTestUser.MVP.Presenters;
using MsTestUser.MVP.Views;
using System.IO;
using System;
using System.Collections.Generic;
using Users;

namespace TestPresenter
{
    [TestClass]
    public class TestPresenter
    {

        [TestMethod]
        public void Test()
        {
            // Мокируем интерфейс IUserModel
            var mock = new Mock<IUserModel>();
            var view = new FileUsersView();

            var presenter = new UserPresenter(mock.Object, view);

            // Настройка мока для возвращения тестового списка пользователей
            mock.Raise(m => m.UpdateUserInfo += null);

            // Путь к файлу, получаем его из представления
            string filePath = view.GetFile();
            string fileContent = File.ReadAllText(filePath);

            // Ожидаемое содержимое файла
            string expectedContent = "Список пользователей:\nID\tLogin\tPassword\tName\tSurname\n--------------------------------------------------\n" +
                                     "1\tDenF\t12345\tDen\tFuvier\n" +
                                     "2\tBoyk\t67890\tAlex\tBoykov\n";

            // Проверяем, что содержимое файла соответствует ожидаемому
            Assert.AreEqual(expectedContent, fileContent);

            // Удаляем файл после теста
            File.Delete(filePath);
        
        }

}
}
