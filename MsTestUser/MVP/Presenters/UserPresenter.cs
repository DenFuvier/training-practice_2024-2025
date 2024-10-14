using MsTestUser.MVP.Models;
using MsTestUser.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTestUser.MVP.Presenters
{
    public class UserPresenter
    {
        private IUserModel model_;
        private List<IUsersView> views_ = new List<IUsersView>();
        public  UserPresenter(IUserModel model)
        { 
         model_ = model;
        }
    }
}
