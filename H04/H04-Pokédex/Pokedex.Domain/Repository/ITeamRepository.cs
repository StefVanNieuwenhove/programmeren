using Pokedex.Domain.Model;

namespace Pokedex.Domain.Repository; 

public interface ITeamRepository {
    
    void AddPokemonToTeam(Pokemon pokemon);
    void RemovePokemonFromTeam(Pokemon pokemon);
    List<Pokemon> GetTeam();
}