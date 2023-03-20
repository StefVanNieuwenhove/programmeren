using Quiz.Domain.Model;
using Quiz.Domain.Repository;

namespace Quiz.Domain; 

public class DomainManager {

    private readonly IAnimalRepository _repository;
    public int maxAmoutOfList = 10;
    private AnimalQuiz _quiz;

    public DomainManager(IAnimalRepository repository) {
        _repository = repository;
         _quiz = new(FilterAnimals(_repository.GetAllAnimals()));
    }

    private List<Animal> FilterAnimals(List<Animal> animals) {
        Console.WriteLine(animals.Count());
        Random random = new();
        List<Animal> result = new();
        List<int> indexes = new();

        int i = 0;
        while (result.Count() < maxAmoutOfList) {
            int index = random.Next(animals.Count);
            if (!result.Contains(animals[index]))
                result.Add(animals[index]);
        }
        return result;
    }

    public bool HasMoreAnimals() {
        return _quiz.HasMoreAnimals();
    }

    public string GetNextAnimal() {
        return _quiz.GetNextAnimal().Name;
    }

    public void StoreAnwser(string animalName, string anwser) {
        Animal animal = _repository.GetAnimalByName(animalName);
        Enum.TryParse(anwser, out AnimalGroup group);
        _quiz.StoreAnwser(group == animal.Group);
    }

    public int GetScore() {
        return _quiz.GetScore();
    }

    public List<Animal> GetAllAnimals() {
        return _repository.GetAllAnimals();
    }

    public Animal GetAnimalByName(string name) {
        return _repository.GetAnimalByName(name);
    }
}