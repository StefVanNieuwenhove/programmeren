namespace H03_Jackpot.Model; 

public class DomeinManager {
    
    private Jackpot _jackpot;

    public DomeinManager() {
        _jackpot = new Jackpot();
    }

    public void StartNieuwJackpot() {

    }

    public List<int> GeefGetallenVanWielen() {
        return null;
    }

    public void Speel() {

    }

    public int geefScore() {
        return 0;
    }

    public Jackpot Jackpot {
        get => _jackpot;
        set => _jackpot = value ?? throw new ArgumentNullException(nameof(value));
    }
}