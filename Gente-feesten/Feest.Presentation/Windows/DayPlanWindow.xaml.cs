using Feest.Domain.DTO;
using Feest.Presentation.EventsArg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Feest.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for DayPlanWindow.xaml
    /// </summary>
    public partial class DayPlanWindow : Window
    {

        public event EventHandler<EventDayPlanArgs> SearchingEvent;
        public event EventHandler<EventDayPlanArgs> GettingEventDetails;
        public event EventHandler<DayPlanArgs> AddingEvent;

        public List<EventDTO> Events {
            get => EventList.ItemsSource as List<EventDTO>;
            set => EventList.ItemsSource = value;
        }

        public List<string> EventDateDetails {
            get => DateList.ItemsSource as List<string>;
            set => DateList.ItemsSource = value;
        }

        public List<string> DayPlanEvents {
            get => EventsDayPlanList.ItemsSource as List<string>;
            set => EventsDayPlanList.ItemsSource = value;
        }

        private UserDTO _user;
        private EventDTO _selectedEvent;
        private DateTime _date;
        private int _dayPlanId;

        public DayPlanWindow(int dayPlanId, UserDTO user, DateTime date)
        {
            InitializeComponent();

            _dayPlanId = dayPlanId;
            _user = user;
            _date = date;
            UserDetails.Content = $"Name: {_user} - Budget: €{_user.Budget} - Date: {_date.ToShortDateString()}";
        }

        private void SearchUserTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            try {
                SearchingEvent?.Invoke(this, new EventDayPlanArgs(SearchUserTextBox.Text, _date));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EventList_SelectionChanged(object sender, SelectionChangedEventArgs e) { 
            try {
                _selectedEvent = EventList.SelectedItem as EventDTO;

                if (_selectedEvent != null) {
                    EventDetail.Text = _selectedEvent.ShowDetails();
                    GettingEventDetails?.Invoke(this, new EventDayPlanArgs(_selectedEvent.Title, _date));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                throw ex;
            }
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e) {
            try {
                AddingEvent?.Invoke(this, new DayPlanArgs(_dayPlanId, _selectedEvent, _user, _date));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
