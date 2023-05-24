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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window {

        public event EventHandler<string> SearchingUser;
        public event EventHandler<UserDTO> CreatingDayPlan;

        public List<UserDTO> Users {
            set => UsersList.ItemsSource = value;
            get => UsersList.ItemsSource as List<UserDTO>;
        }

        private UserDTO _selectedUser { get; set; }

        public UserWindow() {
            InitializeComponent();

            SearchingUser?.Invoke(this, SearchUserTextBox.Text);
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            _selectedUser = UsersList.SelectedItem as UserDTO;

            if (_selectedUser != null) {
                string output = $"Id: {_selectedUser.Id}\n" + $"Firstname: {_selectedUser.FirstName}\n" + $"Lastname: {_selectedUser.LastName}\n" + $"Budget: {_selectedUser.Budget}\n";
                UserInfoTextBox.Text = output;
            }
        }

        private void SearchUserTextBox_TextChanged(object sender, EventArgs e) {
           SearchingUser?.Invoke(this, SearchUserTextBox.Text); 
        }

        private void MakeDayPlanButton_Click(object sender, RoutedEventArgs e) {
            if (_selectedUser != null) {
                CreatingDayPlan?.Invoke(this, _selectedUser);
            } else MessageBox.Show("Select an user to create a dayplan");
        }
    }
}
