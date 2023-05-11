namespace Domein.Wandel.Model; 

public class VrijeTocht : Tocht {
    
    private int _aantalStappen;
    private double _stapLengte;

    public VrijeTocht(int referentie, string naam, int aantalStappen, double stapLengte) : base(referentie, naam) {
        _aantalStappen = aantalStappen;
        _stapLengte = stapLengte;
    }

    public double AantalKm {
        get => _stapLengte * _aantalStappen;
    }

    public int AantalStappen {
        get => _aantalStappen;
        set {
            if (value < 0)
                throw new ArgumentException("Aantal stappen mag niet negatief zijn");
            _aantalStappen = value;
        }
    }

    public double StapLengte {
        get => _stapLengte;
        init {
            if (value < 0.4 && value > 1.2)
                throw new ArgumentException("Staplengte moet binnen de range van [0.5;1.2] liggen");
        }
    }

    public override string UitegebreideBeschrijving { get => $"VrijeTocht \nStapLengte: ${_stapLengte}m \n Aantal stappen: ${_aantalStappen} \nAfgelegde afstand: ${AantalKm}"; }

    public override string ToString() {
        return $"VrijeTocht {Referentie} - {Naam} ({AantalKm}) (Geschikt voor kinderen: {(base.IsGeschiktVoorkinderen ? "ja" : "nee")}";
    }                                       
}