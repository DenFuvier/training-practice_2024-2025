using System.Collections.Generic;
using Users;

namespace MsTestUser.MVP.Models
{
    public class InfoUsersModel : IUserModel
    {
        /// <summary>
        ///  REVIEW. a.boikov. 2024/10/29. определить данные простой модели
        /// </summary>
        private List<User> users_ = new List<User>();
        public InfoUsersModel()
        {

        }
        public List<User> GetUsers()
        {
            return users_;
        }
    }
}
