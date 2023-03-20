using Quiz.Domain;
using Quiz.Domain.Repository;
using Quiz.Persistence;
using Quiz.Presentation;

IAnimalRepository repository = new AnimalMapper();
DomainManager manager = new (repository);
QuizApplication application = new(manager);