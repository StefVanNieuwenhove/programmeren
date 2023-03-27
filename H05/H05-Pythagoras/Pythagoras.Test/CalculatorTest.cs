using Pythagoras.Domain.Exception;
using Pythagoras.Domain.Model;

namespace Pythagoras.Test; 

public class CalculatorTest {

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(5, 12, 13)]
    public void Calculator_ValidValues_ReturnTrue(decimal value1, decimal value2, decimal expectedResult) {
        // arrange
        Calculator cal = new ();

        // act
        decimal result = cal.Calculate(value1, value2);

        // assert
        Assert.Equal(expectedResult, result);
        
    }

    [Theory]
    [InlineData(-1, 4)]
    [InlineData(5, -12)]
    [InlineData(0, 4)]
    [InlineData(5, -0)]
    public void Calculator_InvalidValues_ThrowExpection(decimal value1, decimal value2) {
        // arrange
        Calculator cal = new ();

        // act & assert
        Assert.Throws<EquelOrBelowZeroException>(() => cal.Calculate(value1, value2));

    }
}