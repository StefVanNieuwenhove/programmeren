namespace H03_Deling; 

public class DivideByZeroException : Exception {
    
    public DivideByZeroException() : base("Division by zero is not allowed") {
    }
}