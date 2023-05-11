using BusStops.Domain.Repository;

namespace BusStops.Domain
{
	public class DomainController
    {
        private IBusStopsRepository _repository;
        public DomainController(IBusStopsRepository repository)
        {
            _repository = repository;
        }

        public int GetBusStopCount() {
            return _repository.GetBusStopCount();
        }

        public List<string> GetBusStopNames() {
            return _repository.GetBusStopNames();
        }

        public List<string> GetListMunicipalityOrder() {
            return _repository.GetListMunicipalityOrder();
        }

        public List<string> GetHaltesByMunicpality(string input) {
            return _repository.GetHaltesByMunicpality(input);
        }

        public List<string> GetHaltesWithNonAccessibilities() {
            return _repository.GetHaltesWithNonAccessibilities();
        }

        public string GetMunicipalityWithMaxHaltes() {
            KeyValuePair<string, int> data = _repository.GetMunicipalityWithMaxHaltes();
            return $"{data.Key} - {data.Value}";
        }

        public List<string> GetCountHaltesOfMunicipality() {
            return _repository.GetCountHaltesOfMunicipality();
        }

        public List<string> GetDistinctStopAccessibilities() {
            return _repository.GetDistinctStopAccessibilities();
        }
    }
}
