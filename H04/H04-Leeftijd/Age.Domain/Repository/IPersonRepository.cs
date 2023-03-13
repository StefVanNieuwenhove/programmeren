using Age.Domain.Model;

namespace Age.Persistence; 

public interface IPersonRepository {

    Person GetPersonebyName(string name);
}