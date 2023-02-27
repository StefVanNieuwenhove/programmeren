namespace H01_Veelhoeken; 

public class Rechthoek {

    private double _lengte;
    private double _breedte;

    public Rechthoek() {
        Lengte = 10.0;
        Breedte = 7.0;
    }

    public Rechthoek(double lengte, double breedte) {
        Lengte = lengte;
        Breedte = breedte;
    }

    #region Properties
    public double Lengte {
        get => _lengte;
        set {
            if (value <= 0)
                _lengte = 1;
            _lengte = value;
        }
    }

    public double Breedte {
        get => _breedte;
        set {
            if (value <= 0)
                _lengte = 1;
            _breedte = value;
        }
    }
    #endregion

    #region Methodes
    public double BerekenOppervlakte() {
        return Lengte * Breedte;
    }

    public double BerekenOmtrek() {
        return 2 * (Lengte + Breedte);
    }
    #endregion
}