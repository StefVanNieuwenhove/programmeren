namespace Airport.Domain
{
    public class DomeinController
    {
        private readonly AircraftPlanner _planner = new();
        private readonly IDestinationRepository _repository;

        public DomeinController(IDestinationRepository repository)
        {
            _repository = repository;
        }

        public List<string> GetAvailableDestinations()
        {
            return _repository.GetAllDestinations();
        }

        public void PlaceAircraftOnPlanner(int destinationIndex, string loadAmount, string type)
        {
            string destination = _repository.GetDestinationByIndex(destinationIndex);
            int distance = _repository.GetDistanceByDestination(destination);
            Aircraft aircraft = null;
            if (type == "Passenger")
            {
                aircraft = new PassengerAircraft(destination, distance, int.Parse(loadAmount));
            }
            else if (type == "Cargo")
            {
                aircraft = new CargoAircraft(destination, distance, int.Parse(loadAmount));
            }
            else
            {
                throw new ArgumentException("Invalid aircraft type");
            }

            PlaceAircraftOnPlanner(aircraft);
        }

        public void PlaceHelicopterOnPlanner(double fuelAmount)
        {
            Helicopter helicopter = new(fuelAmount);
            PlaceAircraftOnPlanner(helicopter);
        }

        public List<string> GetAircraftOnPlanner()
        {
            List<string> result = new();

            foreach (IFuelableAircraft fuelableAircraft in _planner.GetAircrafts())
            {
                result.Add(fuelableAircraft.ToString());
            }

            return result;
        }

        public double GetTotalFuelAmount()
        {
            double result = 0;

            foreach (IFuelableAircraft fuelableAircraft in _planner.GetAircrafts())
            {
                result += fuelableAircraft.GetKerosineToFuel();
            }

            return result;
        }

        private void PlaceAircraftOnPlanner(IFuelableAircraft aircraft)
        {
            _planner.AddToPlanner(aircraft);
        }
    }
}