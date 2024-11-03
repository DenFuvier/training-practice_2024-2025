using MySqlX.XDevAPI;
using System.Collections.Generic;
using Users;

namespace MsTestUser.MVP.Models
{
    public class InfoUsersModel : IUserModel
    {

        // REVIEW. a.boikov. 2024/10/29. определить данные простой модели


        /// <summary>
        /// Список пользователей.
        /// </summary>

        private List<User> users_ = new List<User>();
        public InfoUsersModel()
        {
            // Добавление первого пользователя
            users_.Add(new User
            {
                id = 1,
                Login = "DenF",
                Password = 1587413,
                Surname = "Fuvier"

            });
            // Добавление второго пользователя

            users_.Add(new User
            {
                id = 2,
                Login = "Boyk",
                Password = 00000000,
                Surname = "Boykov"
            });
            // Добавление третьего пользователя
            users_.Add(new User
            {
                id = 3,
                Login = "PapiK",
                Password = 11221133,
                Surname = "Papikyan"
            });
            // Добавление четвертого  пользователя
            users_.Add(new User
            {
                id = 4,
                Login = "Bot01",
                Password = 12345678,
                Surname = "TestUsers"
            });

        }

        /// <summary>
        /// Метод для получения списка пользователей.
        /// </summary>
        /// <returns>Список пользователей.</returns>
        public List<User> GetUsers()
        {
            // вернуть всех пользователей.
            return users_;
        }
    }
}