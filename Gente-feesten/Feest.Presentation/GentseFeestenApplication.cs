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

        private UserWindow _userWindow;
        private DayplanWindow _dayplanWindow;

        private readonly DomainManager _manager;

        public GentseFeestenApplication(DomainManager manager) {
            _manager = manager;

            _userWindow = new UserWindow();
            _userWindow.SearchingUser += OnSearchUser;
            _userWindow.CreatingDayPlan += OnCreatingDayPlan;
            _userWindow.Show();

            _userWindow.Users = GetAllUsers();
        }

        // changing window
        private void OnCreatingDayPlan(object? sender, UserDTO user) {
            _dayplanWindow = new DayplanWindow(user);
            _dayplanWindow.SearchingEvent += OnSearchEvent;
            _dayplanWindow.Show();
            _userWindow.Hide();

            _dayplanWindow.Events = GetAllDistinctEvents();
        }

        // EVENTS
        private List<EventDTO> GetAllDistinctEvents() {
            return _manager.GetAllDisctinctEvents();
        }

        private void OnSearchEvent(object? sender, string title) {
            _dayplanWindow.Events = _manager.SearchEvent(title);
        }

        // USERS
        private List<UserDTO> GetAllUsers() {
            return _manager.GetAllUsers(); 
        }

        private void OnSearchUser(object? sender, string username) {
            if (string.IsNullOrWhiteSpace(username)) {
                _userWindow.Users = _manager.GetAllUsers();
            }
            _userWindow.Users = _manager.SearchUser(username.ToString());
        }

        
    }
}
