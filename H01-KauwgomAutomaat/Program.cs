using H01_KauwgomAutomaat;

KauwgumAutomaat kauwgumAutomaat1 = new ();
kauwgumAutomaat1.Kleur = "Rood";

KauwgumAutomaat kauwgumAutomaat2 = new (50);
kauwgumAutomaat2.Kleur = "Rood";

Console.WriteLine(kauwgumAutomaat1);
Console.WriteLine(kauwgumAutomaat2);

kauwgumAutomaat1.Vergrendeld = false;
kauwgumAutomaat1.VulBij(20);
kauwgumAutomaat1.Vergrendeld = true;

Console.WriteLine(kauwgumAutomaat1);
Console.WriteLine(kauwgumAutomaat2);

kauwgumAutomaat1.VulBij(75);

Console.WriteLine(kauwgumAutomaat1);
Console.WriteLine(kauwgumAutomaat2);