
using Pokedex.Domain;
using Pokedex.Persistence;
using Pokedex.Presentation;

PokemonMapper mapper = new();   
TeamMapper  teamMapper = new();
DomainManager manager = new(mapper, teamMapper);
PokemonApplication application = new(manager);