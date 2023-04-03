namespace Calculator.Test; 
using Calculator.Domain.Model;

public class CalculatorTest {

    [Theory]
    [InlineData("", 0)]
    [InlineData("7", 7)]
    [InlineData("5,7", 12)]
    public void Calculator_ParseableString_ValidInteger(string input, int expected) {
        Calculator calculator = new Calculator();

        Assert.Equal(expected, calculator.Add(input));
    }

}