namespace Restaurant.Domain.Model; 

public class Restaurant {
    
    public bool IsServed { get; private set; }
    public bool IsCleaned { get; private set; }

    public void ServedDish() {
        IsServed = true;
    }

    public void CleanRestaurant() {
        IsCleaned = true;
    }
}