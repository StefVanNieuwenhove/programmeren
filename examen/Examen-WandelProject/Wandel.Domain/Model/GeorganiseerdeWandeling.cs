namespace Domein.Wandel.Model; 

public class GeorganiseerdeWandeling : GeorganiseerdeTocht {

    private static Dictionary<string, double> _afstanden;
    public bool IsGeschiktVoorKinderen { get; }
    public double AantalKm { get;  }

    public GeorganiseerdeWandeling(int referentie, string naam, string organistor, string plaats, DateTime datum, string afstandOptie) :
        base(referentie, naam, organistor, plaats, datum) {
        _afstanden = new Dictionary<string, double> {
            {"kort", 5.0},
            {"middellang", 10.0},
            {"mars", 30.0},
        };

        if (afstandOptie.Equals("mars"))
            IsGeschiktVoorKinderen = false;

        AantalKm = _afstanden[afstandOptie] / 100;
    }


}