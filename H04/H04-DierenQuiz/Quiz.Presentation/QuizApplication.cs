using Quiz.Domain;
using Quiz.Domain.Model;

namespace Quiz.Presentation; 

public class QuizApplication {
    private readonly DomainManager _manager;

    public QuizApplication(DomainManager manager) {
        _manager = manager;
        Console.WriteLine($"Welcome to our animal quiz, please sort {_manager.maxAmoutOfList} animals!");
        StartQuiz();
    }

    private void StartQuiz() {
        while (_manager.HasMoreAnimals()) {
            string animal = _manager.GetNextAnimal();
            Console.Write($"What type of animal is {animal}: ");
            string input = Console.ReadLine();
            _manager.StoreAnwser(animal, input);
        }
        
        Console.WriteLine($"Score: {_manager.GetScore()} / 10");
    }
}