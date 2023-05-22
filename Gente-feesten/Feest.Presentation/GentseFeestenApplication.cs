using Feest.Domain.DTO;
using Feest.Domain.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Feest.Presentation {
    public class GentseFeestenApplication {

        private UserWindow window;

        private readonly DomainManager _manager;

        public GentseFeestenApplication(DomainManager manager) {
            _manager = manager;

            window = new UserWindow();
            window.SearchingUser += SearchUser;
            window.Show();

            window.Users = GetAllUsers();

        }
        // EVENTS

        // USERS
        public List<UserDTO> GetAllUsers() {
            return _manager.GetAllUsers(); ;
        }

        public UserDTO GetUserById(int id) {
            return _manager.GetUserById(0);
        }

        public void SearchUser(object? sender, string username) {
            window.UsersSeach = _manager.SearchUser(username.ToString());
        }
    }
}
