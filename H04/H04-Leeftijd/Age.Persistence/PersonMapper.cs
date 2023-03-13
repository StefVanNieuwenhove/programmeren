using Age.Domain.Model;
using Age.Persistence;

namespace Age.Presentation; 

public class PersonMapper : IPersonRepository {

    private Dictionary<string, Person> _persons;

    public PersonMapper() {
        _persons = new() {
            {"Stef", new Person("Stef", new DateTime(2002, 4, 19))},
            { "wojciech", new Person("Wojciecj", new DateTime(1998, 8, 12))}       ,
            { "kyran", new Person("Kyran", new DateTime(2000, 1, 1))},
            { "claude", new Person("Claude", new DateTime(1945, 11, 11))},
        };

    }

    public Person GetPersonebyName(string name) {
        if (_persons.ContainsKey(name))
            return _persons[name];
        else throw new ArgumentException($"{name} was not found");
    }
}