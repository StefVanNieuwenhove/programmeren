using Feest.Domain.DTO;
using Feest.Domain.Managers;
using Feest.Presentation.EventsArg;
using Feest.Presentation.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Feest.Presentation {
    public class GentseFeestenApplication {

        private UserWindow _userWindow;
        private DayPlanWindow _dayplanWindow;

        private readonly DomainManager _manager;

        public GentseFeestenApplication(DomainManager manager) {
            _manager = manager;

            _userWindow = new UserWindow();
            _userWindow.DatesDayPlan = _manager.GetStartDateEndDateEvents();
            _userWindow.SearchingUser += OnSearchUser;
            _userWindow.CreatingDayPlan += OnCreatingDayPlan;
            _userWindow.ReadingDayPlan += OnReadingDayPlan;
            _userWindow.Show();

            _userWindow.Users = GetAllUsers();
        }

        // changing window
        private void OnCreatingDayPlan(object? sender, UserEventArgs e) {
            // create dayplan
            try {
                int dayplanId = _manager.CreateDayPlan(e.User, e.Date);
                _dayplanWindow = new DayPlanWindow(dayplanId, e.User, e.Date);
                _dayplanWindow.SearchingEvent += OnSearchEvent;
                _dayplanWindow.GettingEventDetails += OnGettingEventDetails;
                _dayplanWindow.AddingEvent += OnAddingEvent;
                _dayplanWindow.Show();
                _userWindow.Hide();

                _dayplanWindow.Closed += OnClosedDayPlanWindow;

                _dayplanWindow.Events = GetAllEventByDate(e.Date);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnClosedDayPlanWindow(object? sender, EventArgs args) {
            try {
                _dayplanWindow.Close();
                _userWindow.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // EVENTS
        private List<EventDTO> GetAllEventByDate(DateTime date) {
           try {
                return _manager.GetAllEventByDate(date);
           } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
           }
        }

        private void OnSearchEvent(object? sender, EventDayPlanArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(e.Title)) {
                    _dayplanWindow.Events = _manager.GetAllEventByDate(e.Date);

                }
                _dayplanWindow.Events = _manager.SearchEvent(e.Title, e.Date);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnGettingEventDetails(object? sender, EventDayPlanArgs e) {
            try {
                if (!string.IsNullOrWhiteSpace(e.Title)) {
                    _dayplanWindow.EventDateDetails = _manager.GetEventsByTitle(e.Title, e.Date).Select(x => $"{x.StartDate} - {x.EndDate}").ToList();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        // USERS
        private List<UserDTO> GetAllUsers() {
           try {
                return _manager.GetAllUsers();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
            }
        }

        private void OnSearchUser(object? sender, string username) {
            try {
                if (string.IsNullOrWhiteSpace(username)) {
                    _userWindow.Users = _manager.GetAllUsers();
                }
                _userWindow.Users = _manager.SearchUser(username.ToString());
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // DAYPLAN
        private void OnReadingDayPlan(object? sender, UserDTO user) {
            try {
                _userWindow.DayPlans = _manager.GetUserDayplan(user.Id);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
            }
        }

        private void OnAddingEvent(object? sender, DayPlanArgs e) {
            _dayplanWindow.DayPlanEvents = _manager.AddEventToDayPlan(e.DayPlanId, e.Event, e.User, e.DayPlanDate);
        }

        
    }
}
