using Feest.Domain.DTO;
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

namespace Feest.Presentation {
    /// <summary>
    /// Interaction logic for DayplanWindow.xaml
    /// </summary>
    public partial class DayplanWindow : Window {

        public event EventHandler<string> SearchingEvent;

        public List<EventDTO> Events {
            set => Eventslist.ItemsSource = value;
            get => Eventslist.ItemsSource as List<EventDTO>;
        }

        public List<EventDTO> EventsSearch {
            set => SearchEventList.ItemsSource = value;
            get => SearchEventList.ItemsSource as List<EventDTO>;
        }

        private UserDTO _user;
        private EventDTO _selectedEvent;

        public DayplanWindow(UserDTO user) {
            InitializeComponent();

            _user = user;

            UserDetails.Content = $"{_user} - {_user.Budget}";
        }

        private void Eventslist_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _selectedEvent = Eventslist.SelectedItem as EventDTO;

            if (_selectedEvent != null) {
                EventInfoTextBox.Text = _selectedEvent.ShowDetails();
            }
        }

        private void SearchEventTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(SearchEventTextBox.Text)) {
                SearchingEvent?.Invoke(this, SearchEventTextBox.Text);
            }
        }

        private void SearchEventLis_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            EventInfoTextBox.Clear();

            _selectedEvent = SearchEventList.SelectedItem as EventDTO;

            if (_selectedEvent != null) {
                EventInfoTextBox.Text = _selectedEvent.ShowDetails();
            }
        }
    }
}
