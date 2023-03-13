namespace Age.Domain.Model; 

public class Person {

    public string Name { get; set; }
    private DateTime _birthDate;

    public int Age {
        get {
            DateTime today = DateTime.Today;
            int age = today.Year - _birthDate.Year;
            if (_birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }

    public Person(string name, DateTime birthDate){
        _birthDate = birthDate;
        Name = name;
    }
}