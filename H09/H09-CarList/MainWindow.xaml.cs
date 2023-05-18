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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace H09_CarList {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public event EventHandler CreatingNewCar;
        public event EventHandler<Car> EditingCar;
        private List<Car> _cars;

        public MainWindow() {
            InitializeComponent();

            _cars = new List<Car>() {
                new Car(1, "mercedes"),
                new Car(2, "lightning mcqueen"),
                new Car(3, "herbie"),
                new Car(4, "optimus prime"),
            };

            CarList.ItemsSource = _cars;
        }

        private void NewCarButton_Click(object sender, RoutedEventArgs e) {
            CreatingNewCar?.Invoke(this, EventArgs.Empty);
        }

        public void SetCar(Car car) {
            if (_cars.Any(c => c.Id == car.Id)) {
                _cars.First(c => c.Id == car.Id).Name = car.Name;
            } else {
                _cars.Add(car);
            }
            CarList.Items.Refresh();
        }

        private void EditCarButton_Click(object sender, RoutedEventArgs e) {
            if (CarList.SelectedItem is Car car) {
                EditingCar?.Invoke(this, car);
            } else {
                MessageBox.Show("Please select a car");
            }
        }
    }
}
