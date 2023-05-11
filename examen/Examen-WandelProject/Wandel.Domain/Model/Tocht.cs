using Domein.Wandel.Interfaces;

namespace Domein.Wandel.Model;

public abstract class Tocht : IUitgebreideBeschrijving, IComparable<Tocht> {

    private int _referentie;
    private string _naam;
    

    protected Tocht(int referentie, string naam) {
        _referentie = referentie;
        _naam = naam;
    }

    public int Referentie {
        get { return _referentie; }
        init { _referentie = value; }
    }

    public string Naam {
        get => _naam;
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("De naam van een tocht mag niet leeg zijn");
            _naam = value;
        }
    }

    public double AantalKm { get; }
    public bool IsGeschiktVoorkinderen { get; }
    public abstract string UitegebreideBeschrijving { get; }

    public int CompareTo(Tocht other) {
        return this.Naam.CompareTo(other.Naam);
    }

    public override string ToString() {
        return base.ToString();
    }

   
}