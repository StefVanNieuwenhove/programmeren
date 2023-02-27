namespace H01_Veelhoeken; 

public class VeelhoekApp {

    private int AantalVormen = 0;
    private int RechthoekOpp = 0; 
    private int RechthoekigeDriehoek = 0; 


    public void Main() {
        Console.WriteLine("Rechthoeken en Driehoeken");
        Console.WriteLine("-------------------------");
        Console.Write("Wil je graag nog een vorm ingeven (1 = rechthoek, 2 = driehoek, 3 = stoppen): ");
        int keuze = int.Parse(Console.ReadLine());

        while (keuze != 0) {
            if (keuze == 1) {
                Rechthoek();
                Console.Write("Wil je graag nog een vorm ingeven (1 = rechthoek, 2 = driehoek, 3 = stoppen): ");
                keuze = int.Parse(Console.ReadLine());
            }
            else if (keuze == 2) {
                Driehoek();
                Console.Write("Wil je graag nog een vorm ingeven (1 = rechthoek, 2 = driehoek, 3 = stoppen): ");
                keuze = int.Parse(Console.ReadLine());
            }

        }

        Overzicht();

    }

    private void Rechthoek() {
        AantalVormen++;
        Console.Write("Geef de lengte van de rechthoek in: ");
        double lengte = double.Parse(Console.ReadLine());
        Console.Write("Geef de breedte van de rechthoek in: ");
        double breedte = double.Parse(Console.ReadLine());


        Rechthoek rechthoek = new Rechthoek(lengte, breedte);
        double opp = rechthoek.BerekenOppervlakte();

        if (opp >= 50)
            RechthoekOpp++;

    }

    private void Driehoek() {
        AantalVormen++;
        Console.Write("Geef de zijde A van de driehoek in: ");
        double zijdeA = double.Parse(Console.ReadLine());
        Console.Write("Geef de zijde B van de driehoek in: ");
        double zijdeB = double.Parse(Console.ReadLine());
        Console.Write("Geef de zijde C van de driehoek in: ");
        double zijdeC = double.Parse(Console.ReadLine());

        Driehoek driehoek = new Driehoek(zijdeA, zijdeB, zijdeC);
        if (driehoek.IsRechthoekigeDriehoek())
            RechthoekigeDriehoek++;
    }

    private void Overzicht() {
        Console.WriteLine("Overzicht vormen:");
        Console.WriteLine($"Totaal aantal vormen: {AantalVormen}");
        Console.WriteLine($"Aantal rechthoeken met oppervlakte > 50: {RechthoekOpp}");
        Console.WriteLine($"Aantal rechthoekige driehoeken: {RechthoekigeDriehoek}");
        
    }
}
