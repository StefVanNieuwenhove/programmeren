namespace Domein.Wandel.Model; 

public abstract class GeorganiseerdeTocht : Tocht {

    private string _organistor;
    private string _plaats;
    private DateTime _datum;

    protected GeorganiseerdeTocht(int referentie, string naam, string organistor, string plaats, DateTime datum) : base(referentie, naam) {
        Organistor = organistor;
        Plaats = plaats;
        Datum = datum;
    }

    public override string UitegebreideBeschrijving {
        get => $"{this.GetType().Name} \nGeorganiseerd door: {_organistor} \nTe: {_plaats} \nOp datum: {_datum} \nAfstand: {AantalKm}";
    }
                                      
    public string Organistor {
        get => _organistor;
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ongelidge orginastor");
            _organistor = value;
        }
    }

    public string Plaats {
        get => _plaats;
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ongeldige plaats");
            _plaats = value;
        }
    }

    public DateTime Datum {
        get => _datum;
        set => _datum = value;
    }

    public override string ToString() {
        return $"{this.GetType().Name} {base.Referentie} - {Naam} ({AantalKm}) (Geschikt voor kinderen: {(IsGeschiktVoorkinderen ? "ja" : "nee")})";
    }
}