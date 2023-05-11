using BusStops.Domain.Model;
using BusStops.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;

namespace BusStops.Persistence
{
	public class BusStopsMapper : IBusStopsRepository
	{
		private const string FileName = @"bushaltes-gent-short.json";
		private readonly string _projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;

		private List<BusStop> _bushaltes;
		public BusStopsMapper()
		{
			_bushaltes = JsonConvert.DeserializeObject<List<BusStop>>(File.ReadAllText(Path.Combine(_projectDirectory, FileName)));
		}

		public int GetBusStopCount() {
			return _bushaltes.Count();
		}

		public List<string> GetBusStopNames() {
			return _bushaltes.Select(b => b.StopName).ToList();
		}

		public List<string> GetListMunicipalityOrder() {
			return _bushaltes.Select(b => b.Municipality).Distinct().OrderBy(b => b).ToList();
			//return _bushaltes.GroupBy(b => b.Municipality).Select(b => b.Key).OrderBy(b => b).ToList();
		}

		public List<string> GetHaltesByMunicpality(string input) {
			return _bushaltes.Where(b => b.Municipality == input).Select(b => b.StopName).ToList();
		}

		public List<string> GetHaltesWithNonAccessibilities() {
			return _bushaltes.Where(b => !string.IsNullOrWhiteSpace(b.StopAccessibilities)).Select(b => b.StopName).ToList();
		}

		public KeyValuePair<string, int> GetMunicipalityWithMaxHaltes() {
			IGrouping<string, BusStop> result = _bushaltes.GroupBy(b => b.Municipality).OrderBy(g => g.Count()).Last();
			return new KeyValuePair<string, int>(result.Key, result.Count());
		}

		public List<string> GetCountHaltesOfMunicipality() {
			IGrouping<string, BusStop> result = _bushaltes.GroupBy(b => b.Municipality).OrderBy(g => g.Count()).Last();
			throw new NotImplementedException();
		}

		public List<string> GetDistinctStopAccessibilities() {
			return _bushaltes
				.Select(b => b.StopAccessibilities)
				.Where(a => a != null)
				.SelectMany(x => x.Split(BusStop.SplitCharacter))
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Distinct()
				.ToList();
		}

		public KeyValuePair<string, int> GetCountStopAccessibilitiesByMunicipality() {

		}
	}
}
