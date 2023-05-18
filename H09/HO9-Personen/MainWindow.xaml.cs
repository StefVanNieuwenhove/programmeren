using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HO9_Personen {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void RadioButton_Claude(object sender, RoutedEventArgs e) {
            output.Content = "Claude";
        }

        private void RadioButton_Pierre(object sender, RoutedEventArgs e) {
            output.Content = "Pierre";
        }

        private void RadioButton_Jean(object sender, RoutedEventArgs e) {
            output.Content = "Jean-Jaque";
        }

        private void RadioButton_Alfred(object sender, RoutedEventArgs e) {
            output.Content = "Alfred";
        }
    }
}
