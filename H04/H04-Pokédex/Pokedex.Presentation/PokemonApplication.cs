using Pokedex.Domain;
using Pokedex.Domain.Model;

namespace Pokedex.Presentation; 

public class PokemonApplication {

    private readonly DomainManager _manager;

    public PokemonApplication(DomainManager manager) {
        _manager = manager;
        Run();
    }

    public void Run() {
        Console.WriteLine("Please pick an action");
        Console.WriteLine("[1] Show team");
        Console.WriteLine("[2] Add pokemon to team");
        Console.WriteLine("[3] Remove pokemon from team");
        string input = Console.ReadLine();

        switch (input) {
            case "1": ShowTeam(); break;
            case "2": AddToTeam(); break;
            case "3": RemovefromTeam(); break;
        }        
    }

    private void ShowTeam() {
        List<string> teams = _manager.GetTeam();
        if (teams.Count == 0) {
            Console.WriteLine("Your team is empty");
            return;
        }
        foreach (string team in teams) {
             Console.WriteLine(team);
        }
    }

    private void AddToTeam() {
        List<string> types = Enum.GetValues(typeof(PokemonType)).Cast<PokemonType>().Select(v => $"{v}").ToList();
      

        Console.WriteLine("please pick a pokemon to add to your team");
        Console.WriteLine("Please pick a type: ");
        for (int i = 0; i < types.Count; i++) {
            Console.WriteLine($"[{i+1}] {types[i]}");
        }

        Console.Write("Type: ");
        string input = Console.ReadLine();
        string type = types[int.Parse(input) - 1];

        List<string> pokemons = _manager.GetPokemonsByType(type);

        Console.WriteLine($"Pokemons of the type {type}");
        for (int i = 0; i < pokemons.Count; i++) {
            Console.WriteLine($"{pokemons[i]}");
        }

    Console.Write("Id of the pokemon: ");
        string id = Console.ReadLine();
        Pokemon pokemon = _manager.GetPokemonById(id);
        _manager.AddPokemonToTeam(pokemon);

    }

    private void RemovefromTeam() {
        throw new NotImplementedException();
    }
}