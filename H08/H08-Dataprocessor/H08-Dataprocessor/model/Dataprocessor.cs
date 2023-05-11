namespace H08_Dataprocessor.model; 

public class Dataprocessor {

    private List<int> _list;
    private delegate double Calculate(List<int> list);
    public double Result { get; private set; }

    public Dataprocessor() {
        _list = new List<int>() {
            8, 12, 16,
        };
    }

    public void setMethode(string methode) {
        Calculate calculate;
        switch (methode) {
           case "sum":
               calculate = Sum;
               break; 
           case "substract":
               calculate = Subtract;
               break; 
           case "multiply":
               calculate = Multiply;
               break; 
           default: calculate = null;
               break;
        }

        if (calculate != null) {
            double? result = CalculateResult(calculate);
            if (result.HasValue)
                Result = result.Value;
            else Result = 0;
        }
            
    }

    public void PrintValues() {
        Calculate calculate = null;

        CalculateResult(calculate);
        Console.WriteLine($"result: {Result}");

    }

    private double? CalculateResult(Calculate method) {
        return method?.Invoke(_list);
    }

    private double Sum(List<int> list) {
        return list.Sum(i => i);
    }

    private double Subtract(List<int> list) {
        return list.Aggregate((acc, i) => acc - i);
    }

    private double Multiply(List<int> list) {
        return list.Aggregate((acc, i) => acc * i);
    }
}