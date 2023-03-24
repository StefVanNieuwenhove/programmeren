namespace Restaurant.Test;
using Domain.Model;

public class RestuarantTest {

    private Restaurant Restaurant;

    public RestuarantTest() {
        Restaurant = new Restaurant();
    }

    [Fact]
    public void Restaurant_ServeDish_True() {
        // arrange

        // act
        Restaurant.ServedDish();

        // assert
        Assert.True(Restaurant.IsServed);
    }
}