namespace H03_Jackpot.Model; 

public class Jackpot {

    private const int AANTAL_WIELEN = 3;
    // 3 wielen in een array
    private Wiel[] _wielen = new Wiel[AANTAL_WIELEN];

    public Jackpot() { }

    public List<int> GeefGetallenVanWiel() {
        return null;
    }

    public void Speel() {
        for (int i = 0; i < AANTAL_WIELEN; i++) {
            _wielen[i].Draai();
        }
    }

    public int GeefScore() {
        return 0;
    }
}