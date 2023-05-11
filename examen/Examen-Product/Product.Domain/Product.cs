namespace Product.Domain; 

public class Product {
    private string _naam;
    private decimal _prijs;

    public Product(string naam, decimal prijs) {
        Naam = naam;
        Prijs = prijs;
    }

    public string Naam {
        get => _naam;
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Naam mag niet leeg zijn");
            _naam = value;
        }
    }

    public decimal Prijs {
        get => _prijs;
        set {
            if (value <= 0)
                throw new ArgumentException("prijs mag niet negatief zijn en moet groter zijn dan nul");
            _prijs = value;
        }
    }
}