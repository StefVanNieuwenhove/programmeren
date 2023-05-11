namespace Product.testen; 

public class ProductTest {

    private Domain.Product product;

    [Theory]
    [InlineData("test", 12.3)]
    public void Product_CorrectValues_True(string naam, decimal prijs) {
        //arrange

        // act
        Domain.Product prod = new Domain.Product(naam, prijs);
        // assert
        Assert.Equal(naam, prod.Naam);
        Assert.Equal(prijs, prod.Prijs);
    }

    [Theory]
    [InlineData("", 12.3)]
    [InlineData(null, 12.3)]
    public void Product_InCorrectValuesNaam_True(string naam, decimal prijs) {
        //arrange

        // act
        // assert
        Assert.Throws<ArgumentException>(() => new Domain.Product(naam, prijs));
    }

    [Theory]
    [InlineData("tewt", -12.3)]
    public void Product_InCorrectValuesPrijs_True(string naam, decimal prijs) {
        //arrange

        // act
        // assert
        Assert.Throws<ArgumentException>(() => new Domain.Product(naam, prijs));
    }

}