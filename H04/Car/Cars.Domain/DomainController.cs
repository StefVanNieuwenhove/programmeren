using Cars.Domain.Repository;

namespace Cars.Domain; 

public class DomainController {

    private readonly ICarRepository _repository;

    public DomainController(ICarRepository repository) {
        _repository = repository;
    }
}