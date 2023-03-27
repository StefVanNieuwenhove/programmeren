namespace Pythagoras.Domain.Exception; 

public class EquelOrBelowZeroException : System.Exception {

    public decimal InvalidValue { get; init; }

    public EquelOrBelowZeroException(string message, decimal invalidValue) : base(message) {
        InvalidValue = invalidValue;
    }
    
}