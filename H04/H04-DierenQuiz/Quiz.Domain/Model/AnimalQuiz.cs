namespace Quiz.Domain.Model; 

public class AnimalQuiz {

    private List<Animal> _animals;
    private int _score = 0;

    public AnimalQuiz(List<Animal> animals) {
        _animals = animals;
    }

    public void StoreAnwser(bool anwser) {
         if (anwser) 
            _score++;
    }

    public Animal GetNextAnimal() {
        Animal animal = _animals.First();
        _animals.Remove(animal);
        return animal;
    }

    public bool HasMoreAnimals() {
        return _animals.Count > 0;
    }

    public int GetScore() {
        return _score;
    }
}