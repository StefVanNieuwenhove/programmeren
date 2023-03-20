namespace Quiz.Domain.Model; 

public class Animal {
    
    public string Name { get; set; }
    public AnimalGroup Group { get; set; }

    public Animal(string name, AnimalGroup group) {
        Name = name;
        Group = group;
    }
}