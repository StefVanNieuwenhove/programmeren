using System.Diagnostics;
using Age.Domain;

namespace Age.Presentation; 

public class PersonApplication {
    
    private readonly DomainManager _manager;

    public PersonApplication(DomainManager manager) {
        _manager = manager;
        StartApplication();
    }

    private void StartApplication() {
        while (true) {
            try {
                Console.Write("Name: ");
                string name = Console.ReadLine();
                int age = _manager.GetPersoneAge(name);
                Console.WriteLine("Age: " + age);
                break;
            }
            catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
            }
        }
       
    }
}