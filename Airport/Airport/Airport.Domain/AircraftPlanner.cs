namespace Airport.Domain
{
    public class AircraftPlanner
    {
        private HashSet<IFuelableAircraft> _aircrafts;
        public AircraftPlanner()
        {
            _aircrafts = new HashSet<IFuelableAircraft>();
        }

        public void AddToPlanner(IFuelableAircraft aircraft)
        {
            _aircrafts.Add(aircraft);
        }

        public HashSet<IFuelableAircraft> GetAircrafts()
        {
            return _aircrafts;
        }
    }
}
