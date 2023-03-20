using Quiz.Domain.Model;

namespace Quiz.Domain.Repository; 

public interface IAnimalRepository {
    
    List<Animal> GetAllAnimals();
    Animal GetAnimalByName(string name);
}