using Cars.Domain;

namespace Cars.Presentation; 

public class CarsApplication {
    
    private readonly DomainController _controller;

    public CarsApplication(DomainController controller) {
        _controller = controller;
    }
}