using Pokedex.Domain.Model;
using Pokedex.Domain.Repository;

namespace Pokedex.Domain; 

public class DomainManager {

    private const int MaxTeamSize = 6;
    private readonly IPokemonRepository _pokemon;
    private readonly ITeamRepository _team;

    public DomainManager(IPokemonRepository pokemon, ITeamRepository team) {
        _pokemon = pokemon;
        _team = team;
    }

    public List<string> GetAllPokemons() {
        List<string> pokemons = new ();
        foreach (Pokemon pokemon in _pokemon.GetAll()) {
            pokemons.Add(pokemon.ToString());
        }

        return pokemons;
    }

    public List<string> GetPokemonsByType(string type) {
        List<string> pokemons = new ();
        foreach (Pokemon pokemon in _pokemon.GetByType(type)) {
            pokemons.Add(pokemon.ToString());
        }

        return pokemons;
    }

    public Pokemon GetPokemonById(string id) {
        return _pokemon.GetById(id);
    }

    public List<string> GetTeam() {
        List<string> team = new ();
        foreach (Pokemon pokemon in _team.GetTeam()) {
             team.Add(pokemon.ToString());
        }
        return team;
    }

    public void AddPokemonToTeam(Pokemon pokemon) {
        try {
            if (_team.GetTeam().Count < MaxTeamSize) {
                _team.AddPokemonToTeam(pokemon);
            }
        }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public void RemovePokemonFromTeam(Pokemon pokemon) {
        try {
            _team.RemovePokemonFromTeam(pokemon);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }


}