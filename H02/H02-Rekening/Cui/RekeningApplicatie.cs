using Domein;

namespace Cui; 

public class RekeningApplicatie {
    
    public static void Main(string[] args)
    {
        Start();
    }

    public static void Start()
    {
        Rekening[] rekeningen = new Rekening[3];

        string[] namen = new string[] { "jan", "an", "piet" };
        long[] rekeningnrs = new long[] { 123456789911L, 123123456784L, 123123456986L };

        for (int i = 0; i < rekeningen.Length; i++)
        {
            rekeningen[i] = new Rekening(rekeningnrs[i], namen[i]);
        }

        rekeningen[0].StortOp(1000);
        rekeningen[1].StortOp(50);
        rekeningen[2].StortOp(500);

        if (rekeningen[0].StortOp(200))
        {
            Console.WriteLine("Jan heeft 200 euro op zijn rekening gestort!");
        }

        if (rekeningen[1].HaalAf(30))
        {
            Console.WriteLine("An heeft 30 euro van haar rekening gehaald!");
        }

        if (rekeningen[2].SchrijfBedragOverNaar(50, rekeningen[1]))
        {
            Console.WriteLine("De overschrijving van 50 euro van Piet naar An is gelukt!");
        }

        Console.Write($"Piet heeft momenteel {rekeningen[2].Saldo:F2} als saldo\n");
        Console.Write($"An heeft momenteel {rekeningen[1].Saldo:F2} als saldo\n");
        Console.Write($"Jan heeft momenteel {rekeningen[0].Saldo:F2} als saldo\n");

        foreach (Rekening r in rekeningen)
        {
            Console.Write($"{r}\n");
        }
        Console.WriteLine();

    }
}