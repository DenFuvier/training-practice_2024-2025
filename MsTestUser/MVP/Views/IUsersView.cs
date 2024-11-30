using System;
using System.Collections.Generic;
using Users;

namespace MsTestUser.MVP.Views
{

    public interface IUsersView
    {
        void DisplayUsers(List<User> users);
    }
}
