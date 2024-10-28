using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace MsTestUser.MVP.Views
{
    public interface IUsersView
    {
        void DisplayUsers(List<User> users);
    }
}
