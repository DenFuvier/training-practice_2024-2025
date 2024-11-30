using MsTestUser.MVP.Models;
using MsTestUser.MVP.Views;                     
using System.Collections.Generic;
using Users;

namespace MsTestUser.MVP.Presenters
{
    public class UserPresenter
    {
        private IUserModel model_;
        private IUsersView view_;


        // REVIEW. a.boikov. 2014/10/29. Вспомнить, что за метод, как называется, когда вызываетсяa
        public UserPresenter(IUserModel model, IUsersView view)
        {
            model_ = model;
            view_ = view;
            model_.UpdateUserInfo += model__UpdateUserInfo;
        }

        public void model__UpdateUserInfo()
        {
            List<User> UUser = model_.GetUsers();
            view_.DisplayUsers(UUser);
        }
        /// <summary>
        ///  Модель ниже
        /// </summary>

    }

}
