using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace MsTestUser.MVP.Models
{
    public class InfoUsersModel : IUserModel
    {
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
