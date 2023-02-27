namespace H01_KauwgomAutomaat; 

public class KauwgumAutomaat {

    private int _aantalBallen;
    private string _kleur;
    private bool _vergrendeld;

    public KauwgumAutomaat() {
        Vergrendeld = true;
    }

    public KauwgumAutomaat(int aantalBallen) {
        AantalBallen = aantalBallen;
        Vergrendeld = true;
    }

    public int AantalBallen {
        get => _aantalBallen; 
        private set {
            if(!Vergrendeld)
                _aantalBallen = value;
        }
    }

    public string Kleur {
        get => _kleur;
        set => _kleur = value;
    }

    public bool Vergrendeld {
        get => _vergrendeld;
        set => _vergrendeld = value;
    }

    public bool IsLeeg() {
        return AantalBallen == 0;
    }

    public void VulBij(int aantalBallen) {
           this.AantalBallen += aantalBallen;
    }

    public override string ToString() {
        return $"Kleur: {Kleur}, Aantal ballen: {AantalBallen}";
    }
}