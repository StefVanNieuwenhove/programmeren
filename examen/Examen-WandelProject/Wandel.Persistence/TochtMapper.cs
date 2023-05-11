using Domein.Wandel.Interfaces;
using Domein.Wandel.Model;

namespace Wandel.Persistence; 

public class TochtMapper : ITochtRepository {
    private List<Tocht> _tochtList;

		public TochtMapper()
		{
			_tochtList = new List<Tocht>
			{
				new VrijeTocht(3056, "Stadswandeling", 3000, 0.5),
				new GeorganiseerdeZoektocht(845, "Kerstzoektocht", "Gezinsbond", "Gent", new DateTime(2023, 12, 24), 3.5, true),
				new GeorganiseerdeWandeling(292, "Wandeling in het groen", "Natuurpunt", "Kempen", new DateTime(2023, 5, 27), "kort"),
				new GeorganiseerdeWandeling(1001, "Lentezonnetocht", "Wandelclub De Schoenmaten", "Ardennen", new DateTime(2023, 4, 15), "mars"),
				new GeorganiseerdeZoektocht(24, "Zomerzoektocht", "Toerisme Vlaanderen", "Oostende", new DateTime(2023, 7, 15), 10.0, true),
				new GeorganiseerdeWandeling(207, "Wandeling in het bos", "Natuurvereniging XYZ", "Nationaal Park", new DateTime(2023, 4, 1), "kort"),
				new GeorganiseerdeZoektocht(789, "Paaszoektocht", "KWB", "Brugge", new DateTime(2023, 4, 10), 5.2, true),
				new VrijeTocht(2005, "Kustwandeling", 8000, 0.7),
				new GeorganiseerdeWandeling(0, "Boswandeling", "Natuurvereniging XYZ", "Provinciaal Domein", new DateTime(2023, 6, 3), "mars"),
				new GeorganiseerdeWandeling(925, "Fietstocht langs de kust", "Fietsclub De Trappers", "Oostende", new DateTime(2023, 4, 22), "middellang"),
				new GeorganiseerdeZoektocht(899, "Familiezoektocht", "ANWB", "Maastricht", new DateTime(2023, 6, 5), 8.5, true),
				new VrijeTocht(1001, "Boswandeling", 5000, 0.6),
				new VrijeTocht(8100, "Natuurwandeling", 10000, 0.5),
				new GeorganiseerdeWandeling(16, "Historische wandeling", "Gidsenbond Gent", "Gent", new DateTime(2023, 4, 29), "kort"),
				new VrijeTocht(5298, "Duinenwandeling", 6000, 0.6),
				new GeorganiseerdeWandeling(18, "Bergtocht", "Klimclub De Berggeiten", "Alpen", new DateTime(2023, 5, 6), "mars"),
				new GeorganiseerdeWandeling(578, "Culturele wandeling", "Toeristische Dienst Brugge", "Brugge", new DateTime(2023, 5, 20), "middellang"),
				new VrijeTocht(7001, "Avondwandeling", 2000, 1.2),
				new VrijeTocht(6547, "Polderwandeling", 4000, 1.1),
				new GeorganiseerdeZoektocht(7, "Zoektocht in het park", "Natuurpunt", "Mechelen", new DateTime(2023, 5, 1), 2.3, true),
				new GeorganiseerdeWandeling(825, "City Walk", "Stadstoerisme BV", "Brussel", new DateTime(2023, 4, 8), "middellang"),
				new GeorganiseerdeZoektocht(55, "Halloweenzoektocht", "Scouts", "Leuven", new DateTime(2023, 10, 31), 6.1, true),
				new VrijeTocht(9086, "Zonsondergangwandeling", 3000, 1.1),
				new GeorganiseerdeZoektocht(18, "Winterzoektocht", "Stad Brussel", "Brussel", new DateTime(2023, 1, 15), 4.7, false),
				new GeorganiseerdeZoektocht(945, "Kinderzoektocht", "Kind en Gezin", "Hasselt", new DateTime(2023, 8, 20), 3.2, true),
				new GeorganiseerdeZoektocht(465, "Sinterklaaszoektocht", "Chiro", "Antwerpen", new DateTime(2023, 12, 5), 7.8, true),
				new GeorganiseerdeZoektocht(205, "Stadswandeling", "VVV", "Utrecht", new DateTime(2023, 9, 1), 4.9, false),
				new VrijeTocht(4102, "Bergwandeling", 12000, 0.8),
				new GeorganiseerdeWandeling(506, "Wandeling in de duinen", "Natuurpunt", "Koksijde", new DateTime(2023, 5, 13), "kort"),
				new VrijeTocht(10234, "Buitenlandse wandeling", 15000, 0.7)
			};
		}

		public List<Tocht> GeefAlleTochten()
		{
			return _tochtList;
		}

		public Tocht ZoekTocht(int referentie)
		{
			foreach (Tocht t in _tochtList)
			{
				if (t.Referentie == referentie)
				{
					return t;
				}
			}

			return null;
		}

		public List<Tocht> ZoekTochten(string zoekterm)
		{
			List<Tocht> gevondenTochten = new List<Tocht>();

			foreach (Tocht t in _tochtList)
			{
				if (t.Naam.Contains(zoekterm))
				{
					Console.WriteLine(t);
					gevondenTochten.Add(t);
					
				}
			}



			return gevondenTochten;
		}
	}