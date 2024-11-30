using System;
using System.Collections.Generic;
using Users;

namespace MsTestUser.MVP.Models
{
    public interface IUserModel
    {
        /// <summary>
        /// предоставляет информацию обо всех пользователях
        /// </summary>
        /// <returns>список с минформацией о клиентах</returns>
        List<User> GetUsers();
        event Action UpdateUserInfo;
    }
}
