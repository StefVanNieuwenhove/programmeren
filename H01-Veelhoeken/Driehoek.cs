namespace H01_Veelhoeken; 

public class Driehoek {

    private int _zijdeA;
    private int _zijdeB;
    private int _zijdeC;

    public Driehoek() {

    }

    public int ZijdeA {
        init {
            if (value <= 0)
                _zijdeA = 1;
        }
    }

    public int ZijdeB {
        init {
            if (value <= 0)
                _zijdeB = 1;
        }
    }

    public int ZijdeC {
        init {
            if (value <= 0)
                _zijdeC = 1;
        }
    }

    public bool IsRechthoekigeDriehoek() {
        if (Math.Pow(_zijdeA, 2) + Math.Pow(_zijdeB, 2) == Math.Pow(_zijdeC, 2))
            return true;
        if (Math.Pow(_zijdeB, 2) + Math.Pow(_zijdeC, 2) == Math.Pow(_zijdeA, 2))
            return true;
        if (Math.Pow(_zijdeC, 2) + Math.Pow(_zijdeA, 2) == Math.Pow(_zijdeB, 2))
            return true;
        else return false;
    }
}