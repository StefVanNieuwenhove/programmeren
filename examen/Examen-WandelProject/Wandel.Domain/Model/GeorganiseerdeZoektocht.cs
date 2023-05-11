namespace Domein.Wandel.Model; 

public class GeorganiseerdeZoektocht : GeorganiseerdeTocht {

       private double _afstand;
       private bool _kinderenToegelaten;

       public GeorganiseerdeZoektocht(int referentie, string naam, string organistor, string plaats, DateTime datum, double afstand, bool kinderenToegelaten) : base(referentie, naam, organistor, plaats, datum) {
              Afstand = afstand;
              KinderenToegelaten = kinderenToegelaten;
              AantalKm = afstand;
       }

       public double Afstand {
              get => _afstand;
              set {
                     if (value <= 0)
                            throw new ArgumentException("Afstand moet groter zijn als nul");
              }
       }

       public bool KinderenToegelaten {
              get => _kinderenToegelaten;
              set => _kinderenToegelaten = value;
       }

       public bool IsGeschiktVoorKinderen {
              get => _kinderenToegelaten;
       }

       public double AantalKm {
              get;
       }
}