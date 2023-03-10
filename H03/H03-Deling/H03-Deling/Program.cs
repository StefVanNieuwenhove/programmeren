

Console.Write("Geef getal 1: ");
decimal getal1 = Convert.ToDecimal(Console.ReadLine());
Console.Write("Geef getal 2: ");
decimal getal2 = Convert.ToDecimal(Console.ReadLine());

try {
    decimal resultaat = getal1 / getal2;
    Console.WriteLine("Resultaat: " + resultaat);
}
catch (DivideByZeroException ex) {
    throw new DivideByZeroException("Je kan niet delen door 0!");
}
catch (Exception ex) {
    Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
}