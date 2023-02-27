namespace H01_Veelhoeken; 

public class Driehoek {

    private double _zijdeA;
    private double _zijdeB;
    private double _zijdeC;

    public Driehoek(double a, double b, double c) {
        ZijdeA = a;
        ZijdeB = b;
        ZijdeC = c;
    }

    public double ZijdeA {
        init {
            if (value <= 0)
                _zijdeA = 1;
        }
    }

    public double ZijdeB {
        init {
            if (value <= 0)
                _zijdeB = 1;
        }
    }

    public double ZijdeC {
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