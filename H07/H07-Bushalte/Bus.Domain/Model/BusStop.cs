namespace BusStops.Domain.Model
{
	public class BusStop
	{
		public const string SplitCharacter = ";";
		public int StopNumber { get; set; }
		public string StopName { get; set; }
		public string StopAccessibilities { get; set; }
		public string Municipality { get; set; }

		public List<Accessibility> StopAccessibilitiesList {
			get {
				return StopAccessibilities.Split(SplitCharacter)
					.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => (Accessibility)Enum.Parse(typeof(Accessibility), x))
					.ToList();
			}
		}

		public override string ToString()
		{
			return $"{Municipality} - {StopName}";
		}
	}

	public enum Accessibility {
		MOTORISCH_MET_ASSIST,
		MOTORISCHE_BEPERKING,
		VISUELE_BEPERKING,
	}
}
