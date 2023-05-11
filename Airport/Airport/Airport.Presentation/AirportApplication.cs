using Airport.Domain;

namespace Airport.Presentation
{
    public class AirportApplication
    {
        private readonly DomeinController _domeinController;
        private List<string> _mainMenuOptions = new()
        {
            "Add aircraft",
            "Add helicopter"
        };
        private List<string> _airCraftTypes = new()
        {
            "Passenger",
            "Cargo"
        };
        private bool _applicationRunning = true;

        public AirportApplication(DomeinController domeinController)
        {
            _domeinController = domeinController;

            PlanAircraft();
        }

        public void PlanAircraft()
        {
            while (_applicationRunning)
            {
                try
                {
                    Console.WriteLine("Menu");
                    int result = MakeChoiceFromOptions("Pick an option", _mainMenuOptions, "Stop");

                    if (result == 0)
                    {
                        AddAirplane();
                    }
                    else if (result == 1)
                    {
                        AddHelicopter();
                    }
                    else if (result == -1)
                    {
                        _applicationRunning = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintReport();
        }

        private void AddAirplane()
        {
            int destinationIndex = MakeChoiceFromOptions("Pick a destination", _domeinController.GetAvailableDestinations(), "Don't select a destination");
            int typeIndex = MakeChoiceFromOptions("Pick an aircraft type", _airCraftTypes, "Don't select a type");
            string prompt = "Please provide a ";
            if (typeIndex == 0)
            {
                prompt += "number of persons";
            }
            else if (typeIndex == 1)
            {
                prompt += "cargo weight";
            }
            string loadAmount = AskForInput(prompt);

            _domeinController.PlaceAircraftOnPlanner(destinationIndex, loadAmount, _airCraftTypes[typeIndex]);
        }

        private void AddHelicopter()
        {
            string fuelAmount = AskForInput("Please provide amount of fuel");

            _domeinController.PlaceHelicopterOnPlanner(double.Parse(fuelAmount));
        }

        private void PrintReport()
        {
            if (_domeinController.GetAircraftOnPlanner().Count > 0)
            {
                foreach (string aircraft in _domeinController.GetAircraftOnPlanner())
                {
                    Console.WriteLine(aircraft);
                }

                Console.WriteLine($"Total fuel required {_domeinController.GetTotalFuelAmount()} litres");
            }
            else
            {
                Console.WriteLine("No flights were added to planner!");
            }
        }

        private string AskForInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }

        private int MakeChoiceFromOptions(string prompt, List<string> options, string cancelOption)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine($"0. {cancelOption}");

            bool success = int.TryParse(Console.ReadLine(), out int result);
            if (!success)
            {
                throw new FormatException("Input string was not in a correct format.");
            }
            else if (result < 0 || result > options.Count)
            {
                throw new ArgumentException($"Choice must be between 0 & {options.Count}");
            }
            else
            {
                return result - 1;
            }
        }
    }
}