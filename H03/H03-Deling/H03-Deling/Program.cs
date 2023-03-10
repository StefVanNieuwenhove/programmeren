

Console.Write("Geef getal 1: ");
int getal1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Geef getal 2: ");
int getal2 = Convert.ToInt32(Console.ReadLine());

try {
    int resultaat = getal1 / getal2;
    Console.WriteLine("Resultaat: " + resultaat);
}
catch (DivideByZeroException ex) {
    Console.WriteLine("Je kan niet delen door nul!");
}
catch (Exception ex) {
    Console.WriteLine("Er is een fout opgetreden!");
}