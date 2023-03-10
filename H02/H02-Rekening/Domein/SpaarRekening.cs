namespace Domein; 

public class SpaarRekening : Rekening {

    private double _aangroeiIntrest = 1.5;

    public SpaarRekening(long rekeningNr, string houder) : base(rekeningNr, houder) { }
}