using Pokedex.Domain;
using Pokedex.Domain.Model;
using Pokedex.Domain.Repository;

namespace Pokedex.Persistence; 

public class PokemonMapper : IPokemonRepository {

    private Dictionary<string, Pokemon> _pokemons;

    public PokemonMapper() {
        _pokemons = new();
        ReadFile();
    }

    public void Add(Pokemon pokemon) {
        throw new NotImplementedException();
    }

    public List<Pokemon> GetAll() {
        return _pokemons.Values.ToList();
    }

    public Pokemon GetById(string id) {
        return _pokemons[id];
    }

    public List<Pokemon> GetByType(string type) {
        List<Pokemon> pokemons = new();
        foreach (Pokemon pokemon in _pokemons.Values) {
            if (type.Contains(type))
                pokemons.Add(pokemon);
        }
        return pokemons;
    }

    private void ReadFile() {
        string path = @"/Users/stefvannieuwenhove/Documents/Hogent/2022-2023/Programmeren/Docs/H04/pokemon.csv";
        List<PokemonType> _types;

        using (StreamReader reader = new(path)) {
            while (!reader.EndOfStream) {
                string dataLine = reader.ReadLine();
                string[] fields = dataLine.Split(';');

                _types = new();

                string id = fields[0];
                string name = fields[1];
                Enum.TryParse(fields[2], out PokemonType type1);
                _types.Add(type1);
                if (!string.IsNullOrWhiteSpace(fields[3])) {
                    Enum.TryParse(fields[3], out PokemonType type2);
                    _types.Add(type2);
                }
                    
                _pokemons.Add(id, new Pokemon(id, name, _types));
            }
        }

    }
}