using MsTestUser.MVP.Models;
using MsTestUser.MVP.Views;                     
using System.Collections.Generic; 
using Users;

namespace MsTestUser.MVP.Presenters
{
    public class UserPresenter
    {
        private IUserModel _model;
        private IUsersView _view;


        /// REVIEW. a.boikov. 2014/10/29. Вспомнить, что за метод, как называется, когда вызывается
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
