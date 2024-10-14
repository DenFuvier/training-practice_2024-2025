using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
