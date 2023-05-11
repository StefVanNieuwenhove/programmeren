namespace H03_Jackpot.Model; 

public class Wiel {

    private int _getal;

    public Wiel(int getal) {
        Getal = getal;
    }

    public void Draai() {
        _getal = Math.Random(1, 9) + 1;
        Console.WriteLine(_getal);
    }

    public int Getal {
        get { return _getal; }
        set { _getal = value; }
    }

}