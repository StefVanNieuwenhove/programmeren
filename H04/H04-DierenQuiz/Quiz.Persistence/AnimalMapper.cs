using Quiz.Domain;
using Quiz.Domain.Model;
using Quiz.Domain.Repository;

namespace Quiz.Persistence; 

public class AnimalMapper : IAnimalRepository {

    private Dictionary<string, Animal> _animals;

    public AnimalMapper() {
        _animals = new ();
        ReadFile();
    }

    private void ReadFile() {
        string path = @"/Users/stefvannieuwenhove/Documents/Hogent/2022-2023/Programmeren/Docs/H04/animals.csv";

        try {
            using (StreamReader reader = new StreamReader(path)) {
                while (!reader.EndOfStream) {
                    string dataLine = reader.ReadLine();
                    string[] fields = dataLine.Split(';');
                    Enum.TryParse(fields[1], out AnimalGroup group);
                    _animals.Add(fields[0], new Animal(fields[0], group));
                }
            }
        }
        catch (Exception e) {
            throw new Exception(e.Message);
        }                                        
        

    }

    public List<Animal> GetAllAnimals() {
        return _animals.Values.ToList();
    }

    public Animal GetAnimalByName(string name) {
        if (!_animals.ContainsKey(name))
            throw new Exception("Error in AnimalMapper: animal not found");
        return _animals[name];
    }
}