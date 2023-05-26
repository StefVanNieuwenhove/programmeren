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

namespace Feest.Presentation {
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window {

        public event EventHandler<string> SearchingUser;
        public event EventHandler<UserEventArgs> CreatingDayPlan;
        public event EventHandler<UserDTO> ReadingDayPlan;

        public List<UserDTO> Users {
            set => UsersList.ItemsSource = value;
            get => UsersList.ItemsSource as List<UserDTO>;
        }

        public List<DayPlanDTO> DayPlans {
            set => DayPlanList.ItemsSource = value;
            get => DayPlanList.ItemsSource as List<DayPlanDTO>;
        }

        public List<DateTime> DatesDayPlan {
            get => CboDates.ItemsSource as List<DateTime>;
            set => CboDates.ItemsSource = value;
        }

        private UserDTO _selectedUser { get; set; }
        private DateTime _selectedDate { get; set; }

        public UserWindow() {
            InitializeComponent();
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _selectedUser = UsersList.SelectedItem as UserDTO;

            if (_selectedUser != null) {
                string output = $"Id: {_selectedUser.Id}\n" + $"Firstname: {_selectedUser.FirstName}\n" + $"Lastname: {_selectedUser.LastName}\n" + $"Budget: {_selectedUser.Budget}\n";
                UserInfoTextBox.Text = output;
                ReadingDayPlan?.Invoke(this, _selectedUser);
            }
        }

        private void SearchUserTextBox_TextChanged(object sender, EventArgs e) {
           SearchingUser?.Invoke(this, SearchUserTextBox.Text); 
        }

        private void UsersList_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (!DatesDayPlan.Contains(_selectedDate)) {
                MessageBox.Show("Pick a date!", "PICK A DATE", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
            else {
                MessageBoxResult result = MessageBox.Show($"Do you want to create a dayplay for {_selectedUser}\n on the date: {_selectedDate.ToShortDateString()}?", "Create Dayplan", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes);

                switch (result) {
                    case MessageBoxResult.Yes:
                        CreatingDayPlan?.Invoke(this, new UserEventArgs(_selectedUser, _selectedDate));
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void UsersList_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter && _selectedDate != null) {
                MessageBoxResult result = MessageBox.Show($"Do you want to create a dayplay for {_selectedUser}\n on the date: {_selectedDate.ToShortDateString()}?", "Create Dayplan", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.Yes);

                switch (result) {
                    case MessageBoxResult.Yes:
                        CreatingDayPlan?.Invoke(this, new UserEventArgs(_selectedUser, _selectedDate));
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void CboDates_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _selectedDate = (DateTime)CboDates.SelectedItem;
        }
    }
}
