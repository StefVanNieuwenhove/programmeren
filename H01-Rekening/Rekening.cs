namespace H01_Rekening; 

public class Rekening {
    
    private int _rekeningnummer = 123456789;
    private double _saldo = 0.0;
    private string _naam = "onbekend";

    public Rekening() {

    }
    public Rekening(int rekeningnummer) {
        Rekeningnummer = rekeningnummer;

    }
    public Rekening(int rekeningnummer, string houder) {
        Rekeningnummer = rekeningnummer;
        Naam = houder;
    }

    public int Rekeningnummer {
        get => _rekeningnummer;
        private set {
            if (value.ToString().Length == 15)
                _rekeningnummer = value;
        }
    }

    public double Saldo {
        get => _saldo;
    }

    public string Naam {
        get => _naam;
        set => _naam = value;
    }

    public bool Storten(double bedrag) {
        if (bedrag > 0) {
            _saldo += bedrag;
            return true;
        }
        return false;
    }

    public bool Afhalen(double bedrag) {
        if (bedrag > 0 && bedrag <= _saldo) {
            _saldo -= bedrag;
            return true;
        }
        return false;
    }
}