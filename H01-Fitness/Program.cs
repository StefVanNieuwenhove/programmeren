const string path = @"/Users/stefvannieuwenhove/Documents/Hogent/2022-2023/Programmeren/H01-Fitness/insertRunningTest.txt";

StreamReader reader = new (path);

while (!reader.EndOfStream) {
    string line = reader.ReadLine();
    string result = line.Split('(', ')');
    string[] lineArray = result.Split(',');
    Console.WriteLine(string.join("-", lineArray));
}