using Pokedex.Domain.Model;
using Pokedex.Domain.Repository;

namespace Pokedex.Persistence; 

public class TeamMapper : ITeamRepository {

    List<Pokemon> _team;

    public TeamMapper() {
        _team = new ();
    }

    public List<Pokemon> GetTeam() {
        return _team;
    }

    public void AddPokemonToTeam(Pokemon pokemon) {
        _team.Add(pokemon);
    }

    public void RemovePokemonFromTeam(Pokemon pokemon) {
        _team.Remove(pokemon);
    }
}