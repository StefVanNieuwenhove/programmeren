using Cars.Domain;
using Cars.Domain.Repository;
using Cars.Persistence;
using Cars.Presentation;

namespace H04.Car.Cars.StartUp {
    public class StartUp {
        public static void Main(string[] args) {

            ICarRepository repository = new CarMapper();
            DomainController controller = new(repository);
            CarsApplication application = new(controller);
        }
    }
}