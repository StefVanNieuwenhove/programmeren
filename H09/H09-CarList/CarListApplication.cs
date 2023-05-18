using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H09_CarList {
    internal class CarListApplication {

        private MainWindow _mainWindow;
        private CarWindow _carWindow;

        public CarListApplication() {
           _mainWindow = new MainWindow();
            _mainWindow.CreatingNewCar += OnCreatingNewCar;
            _mainWindow.EditingCar += OnEditingCar;
            _mainWindow.Show();

        }

        private void OnCreatingNewCar(object? sender, EventArgs e) {
            _carWindow = new CarWindow();
            _carWindow.InputSubmitted += OnInputSubmitted;
            _carWindow.Show();
            _mainWindow.Hide();
        }

        private void OnEditingCar(object? sender, Car e) {
            _carWindow = new CarWindow();
            _carWindow.Car = e;
            _carWindow.InputSubmitted += OnInputSubmitted;
            _carWindow.Show();
            _mainWindow.Hide();
        }

        private void OnInputSubmitted(object? sender, Car car) {
            _carWindow.Close();
            _mainWindow.Show();
            _mainWindow.SetCar(car);
        }
    }
}
