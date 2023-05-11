using H08_Dataprocessor.model;

Console.Write("Sum, Substract, Multiply: ");
string method = Console.ReadLine();

Dataprocessor processor = new();

processor.setMethode(method);
Console.WriteLine($"{processor.Result}");
