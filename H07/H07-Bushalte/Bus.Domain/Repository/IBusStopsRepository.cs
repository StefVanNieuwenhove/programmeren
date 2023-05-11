namespace BusStops.Domain.Repository
{
	public interface IBusStopsRepository {
		int GetBusStopCount();
		List<string> GetBusStopNames();
		List<string> GetListMunicipalityOrder();
		List<string> GetHaltesByMunicpality(string input);
		List<string> GetHaltesWithNonAccessibilities();
		KeyValuePair<string, int> GetMunicipalityWithMaxHaltes();
		List<string> GetCountHaltesOfMunicipality();
		List<string> GetDistinctStopAccessibilities();
	}
}
