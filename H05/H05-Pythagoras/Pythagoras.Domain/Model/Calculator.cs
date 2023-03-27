using Pythagoras.Domain.Exception;

namespace Pythagoras.Domain.Model; 

public class Calculator {

    public decimal Calculate(decimal value1, decimal value2) {
        if (value1 <= 0 || value2 <= 0)
            throw new EquelOrBelowZeroException("Value cannot be below zero", value1 <= 0 ? value1 : value2);
        return (decimal) Math.Sqrt(Math.Pow((double)value1, 2) + Math.Pow((double)value2, 2));
    }
}