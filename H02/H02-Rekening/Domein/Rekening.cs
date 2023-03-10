namespace Domein; 

public abstract class Rekening {

    private long _rekeningNr;
    private string _houder;

    public Rekening() {
        RekeningNr = 0L;
        Houder = "Onbekend";
    }

    public Rekening(long rekeningNr, string houder)
    {
        RekeningNr = rekeningNr;
        Houder = houder;
    }

    private void ControleerRekeningNr(long rekeningNr)
    {
        long eerste10 = rekeningNr / 100;
        int rest = (int)(rekeningNr % 100);

        if (!(eerste10 % 97 == rest || (eerste10 % 97 == 0 && rest == 97)))
        {
            throw new System.ArgumentException("Rekeningnummer moet correct zijn");
        }
    }

    private string Houder
    {
        set
        {
            if (value is null || value.Equals(""))
            {
                throw new System.ArgumentException("Houder mag niet leeg zijn");
            }
            this._houder = value;
        }
        get
        {
            return _houder;
        }
    }

    private long RekeningNr
    {
        init
        {
            ControleerRekeningNr(value);
            this._rekeningNr = value;
        }
        get
        {
            return _rekeningNr;
        }
    }

    public double Saldo { get; set; }

    public override string ToString()
    {
        long eerste3 = RekeningNr / 1000000000;
        long rest = RekeningNr % 100;
        long midden7 = (RekeningNr / 100) % 10000000;

        return string.Format($"{this.GetType().Name}{" met rekeningnummer"} {eerste3:D3}-{midden7:D7}-{rest:D2}\n" +
                             $"{"staat op naam van"} {Houder}\n{"en bevat "}{Saldo:F2} {"euro"}");
    }

    public bool StortOp(double bedrag)
    {
        bool succes = false;
        if (bedrag > 0)
        {
            Saldo += bedrag;
            succes = true;
        }
        return succes;
    }

    public bool HaalAf(double bedrag)
    {
        bool succes = false;
        if (bedrag > 0)
        {
            Saldo -= bedrag;
            succes = true;
        }

        return succes;
    }

    public bool SchrijfBedragOverNaar(double bedrag, Rekening naarRek)
    {
        bool succes = false;
        if (naarRek != null && HaalAf(bedrag))
        {
            succes = naarRek.StortOp(bedrag);
            if (!succes)
            {
                StortOp(bedrag);
            }
        }
        return succes;
    }
}