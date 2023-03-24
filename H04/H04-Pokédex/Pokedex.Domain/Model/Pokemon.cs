namespace Pokedex.Domain.Model; 

public class Pokemon {
    
    private string _id;
    private string _name;
    private List<PokemonType> _type;

    public Pokemon(string id, string name, List<PokemonType> type) {
        Id = id;
        Name = name;
        Type = type;
    }

    #region props

    public string Id {
        get => _id;
        set => _id = value;
    }

    public string Name {
        get => _name;
        set => _name = value;
    }

    public List<PokemonType> Type {
        get => _type;
        set => _type = value;
    }

    #endregion

    public override bool Equals(object? obj) {
        return obj is Pokemon pokemon && pokemon.Id == Id;
    }

    public override int GetHashCode() {
        return HashCode.Combine(Id);
    }

    public override string ToString() {
        return $"#{Id} {Name} ({string.Join("/", _type)})";
    }
}