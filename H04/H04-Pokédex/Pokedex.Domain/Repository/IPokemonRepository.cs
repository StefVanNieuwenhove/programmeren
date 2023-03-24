using Pokedex.Domain.Model;

namespace Pokedex.Domain.Repository; 

public interface IPokemonRepository {
    
    List<Pokemon> GetAll();
    Pokemon GetById(string id);
    List<Pokemon> GetByType(string type);
}