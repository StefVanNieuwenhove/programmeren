using Age.Domain;
using Age.Persistence;
using Age.Presentation;

namespace Age.StartUp; 

public class StartUp {
    
    public static void Main(string[] args) {

        IPersonRepository _repository = new PersonMapper();
        DomainManager manager = new DomainManager(_repository);
        PersonApplication application = new PersonApplication(manager);
    }
}