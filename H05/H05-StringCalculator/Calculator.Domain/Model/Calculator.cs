using System.Text.RegularExpressions;

namespace Calculator.Domain.Model; 

public class Calculator {

    private const string DELIMITER = ",";

    public int Add(string value) {

        string[] values = value.Split(DELIMITER);
        Regex regex = new Regex(@"[0-9]");
        int result = 0;

        foreach (string item in values) {
            if (regex.IsMatch(item))
                result+= int.Parse(item);
        }

        return result;
    }
}