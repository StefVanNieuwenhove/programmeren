using System.Text.RegularExpressions;
using System.Xml;
using Domein.Wandel;

namespace Presentation.Wandel; 

public class WandelApp {

    private readonly DomeinManager _manager;
    private  bool flage = true;

    public WandelApp(DomeinManager manager) {
        _manager = manager;
        Start();
    }

    public void Start() {

        Regex regex = new Regex(@"[0-9]");
        while (flage) {
            try {
                Console.WriteLine("1. Toon overzicht van de tocht");
                Console.WriteLine("2. Zoek een tocht");
                Console.WriteLine("3. Geef de details van een tocht");
                Console.WriteLine("0. Stop de applicatie");
                Console.WriteLine("");
                Console.Write("keuze: ");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input) {
                    case 1:
                        OverzichtTochten(); break;
                    case 2: ZoekTocht();
                        break;
                    case 3: DetailsTocht();
                        break;
                    case 0: Console.WriteLine("Applicatie is gestopt"); flage = false; break;
                    default: flage = false; break;

                }
            }
            catch (Exception ex) {
                 Console.WriteLine();
            }
        }
    }

    private void OverzichtTochten() {
        Console.WriteLine();
        Console.WriteLine("Overzicht tochten");
        
        foreach (string item in _manager.GeefAlleTochten()) {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }

    private void ZoekTocht() {

        try {
            Console.WriteLine();
            Console.Write("Geen een zoekterm in: ");
            string zoekterm = Console.ReadLine();

            foreach (string item in _manager.ZoekTochten(zoekterm)) {
                Console.WriteLine(item);
            }
        }
        catch (Exception ex) {

        }
    }

    private void DetailsTocht() {

        try {
            Console.WriteLine();
            Console.WriteLine("Geef een referentie in :");
            int referentie = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(_manager.GeefBeschrijving(referentie));
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
    }
    
    
}