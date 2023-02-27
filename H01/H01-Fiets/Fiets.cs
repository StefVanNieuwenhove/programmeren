namespace H01_Fiets; 

public class Fiets {

    private string _kleur;
    private string _merk;
    private int _aantalVersnellingen;
    private bool _herenFiets;
    private float _snelheid;

    public Fiets(string kleur) {    
        Kleur = kleur;
    }

    public string Kleur {
        get => _kleur;
        set => _kleur = value;
    }

    public string Merk {
        get => _merk;
        set => _merk = value;
    }

    public int AantalVersnellingen {
        set => _aantalVersnellingen = value;
    }

    public bool HerenFiets {
        get => _herenFiets;
        set => _herenFiets = value;
    }

    public float Snelheid {
        get => _snelheid;
        set => _snelheid = value;
    }

    public void Versnel(float versnelling) {
        Snelheid += versnelling;
    }

    public override string ToString() {
        return $"Kleur: {Kleur}";
    }
}