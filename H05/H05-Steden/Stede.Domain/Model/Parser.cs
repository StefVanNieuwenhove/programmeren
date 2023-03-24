namespace Stede.Domain.Model; 

public static class Parser {

    private static readonly Dictionary<string, Steden> _cities = new () {
        { "Ghent", Steden.Gent},
        { "Hasselt", Steden.Hasselt},
        { "Brussels", Steden.Brussel}  ,
        { "Antwerp", Steden.Antwerpen},
        { "Louvrain", Steden.Leuven},
        { "Bruges", Steden.Brugge},
    };

    public static Steden Parse(string input) {
        Steden steden;

        if (!Enum.TryParse(input, out steden)) {
            if (_cities.ContainsKey(input)) {
                steden = _cities[input];
            }
            else {
                throw new ArgumentException("Invalid city name");
            }
        }

        return steden;
    }
}