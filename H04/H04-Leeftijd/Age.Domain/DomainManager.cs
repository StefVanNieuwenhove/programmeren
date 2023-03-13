using Age.Persistence;

namespace Age.Domain; 

public class DomainManager {

    private readonly IPersonRepository _repository;

    public DomainManager(IPersonRepository repository) {
        _repository = repository;
    }

    public int GetPersoneAge(string input) {
        return _repository.GetPersonebyName(input.ToLower()).Age;
    }
}