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


        // REVIEW. a.boikov. 2014/10/29. Вспомнить, что за метод, как называется, когда вызывается
        // Конструктор инициализирует UserPresenter, устанавливая модель (_model) и представление (_view), чтобы дать презентеру доступ к данным и способ показать их пользователю.
        //Когда вызывается :
        //Конструктор UserPresenter вызывается при создании экземпляра презентера.Это происходит обычно в момент инициализации представления(View), когда необходимо установить связь между пользовательским интерфейсом и логикой приложения.
        //Например, когда загружается окно или страница, требующая отображения данных
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
