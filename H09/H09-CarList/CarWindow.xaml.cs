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

namespace H09_CarList {
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window {
        public event EventHandler<Car> InputSubmitted;
        private Car _car;

        public Car Car { get => _car; set {
                _car = value;
                CarNameInput.Text = value.Name;
            } 
        }

        public CarWindow() {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e) {
            if (!string.IsNullOrWhiteSpace(CarNameInput.Text)) { 
                if (_car != null) {
                    _car.Name = CarNameInput.Text;
                    InputSubmitted?.Invoke(this, _car);
                } else {
                    InputSubmitted?.Invoke(this, new Car(1, CarNameInput.Text));
                }
            } else {
                MessageBox.Show("Please enter a car name");
            }
        }
    }
}
