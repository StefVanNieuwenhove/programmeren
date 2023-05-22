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

        public List<UserDTO> Users {
            set => UsersList.ItemsSource = value;
            get => UsersList.ItemsSource as List<UserDTO>;
        }

        public List<UserDTO> UsersSeach {
            set => SearchUserList.ItemsSource = value;
            get => SearchUserList.ItemsSource as List<UserDTO>;
        }

        public UserWindow() {
            InitializeComponent();
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UserDTO user = UsersList.SelectedItem as UserDTO;

            if (user != null) {
                string output = $"Id: {user.Id}\n" + $"Firstname: {user.FirstName}\n" + $"Lastname: {user.LastName}\n" + $"Budget: {user.Budget}\n";
                UserInfoTextBox.Text = output;
            }
        }

        private void SearchUserTextBox_TextChanged(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(SearchUserTextBox.Text)) {

                SearchingUser?.Invoke(this, SearchUserTextBox.Text);
            }
        }

        private void SearchUserList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UserInfoTextBox.Clear();

            UserDTO user = SearchUserList.SelectedItem as UserDTO;

            if (user != null) {
                string output = $"Id: {user.Id}\n" + $"Firstname: {user.FirstName}\n" + $"Lastname: {user.LastName}\n" + $"Budget: {user.Budget}\n";
                UserInfoTextBox.Text = output;
            }
        }
    }
}
