using MsTestUser.MVP.Models;
using MsTestUser.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;

namespace MsTestUser.MVP.Presenters
{
    public class UserPresenter
    {
        private IUserModel _model;
        private IUsersView _view;

        public UserPresenter(IUserModel model, IUsersView view)
        {
            _model = model;
            _view = view;
        }

        public void LoadUsers()
        {
            List<User> users = _model.GetUsers();
            _view.DisplayUsers(users);
        }
    }

}
