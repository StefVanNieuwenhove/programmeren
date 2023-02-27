using System.Globalization;

namespace H01_Fitness;

public class FitnessApplication {

    private const string FilePath =
        @"/Users/stefvannieuwenhove/Documents/Hogent/2022-2023/Programmeren/H01/H01-Fitness/insertRunning.sql";

    private Dictionary<int, Session> _sessions = new();
    private List<string> errors = new();

    public void Main() {
        StreamReader reader = new(FilePath);
        while(!reader.EndOfStream) {
            string line = reader.ReadLine();
            string result = line.Split('(', ')')[1];
            string[] values = result.Split((','));
            try {
                ParseSession(values);
            }
            catch (Exception e) {
                  errors.Add(values[0] + " " + e.Message);
            }
        }

        Console.WriteLine("Filteren op dag of op klanternummer");
        string input = Console.ReadLine();

        if (input == "dag") 
            FilterByDay();
          else if (input == "nummer") 
            FilterByCustomer();
        if (errors.Count > 0) {
            Console.WriteLine("errors during parsing");
            foreach (string error in errors) {
                Console.WriteLine(error);
            }
        }
        
    }

    public void ParseSession(string[] values) {
        int sessionId = int.Parse(values[0]);
        DateTime date = DateTime.ParseExact(values[1].Replace("'", string.Empty), "yyyy-MM-dd HH:mm:ss", null);
        int customerId = int.Parse(values[2]);
        int sessionTime = int.Parse(values[3]);
        double averageSpeed = double.Parse(values[4], CultureInfo.InvariantCulture);
        int sequenceId = int.Parse(values[5]);
        int sequenceDuration = int.Parse(values[6]);
        double sequenceSpeed = double.Parse(values[7], CultureInfo.InvariantCulture);

        Session session = new(sessionId, date, customerId, sessionTime, averageSpeed);
        Sequence sequence = new(sequenceId, sequenceDuration, sequenceSpeed);
        if (_sessions.ContainsKey(session.SessionId)) {
            session = _sessions[session.SessionId];
        }
        else {
            _sessions.Add(session.SessionId, session);
            
        }
        session.Sequences.Add(sequence);
    }

    private void FilterByDay() {
        Console.WriteLine("Please enter date in the format (dd-mm-yyyy): ");
        string input = Console.ReadLine();
        DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", null);

        foreach (Session session in _sessions.Values) {
            if (date == session.Date.Date) {
                Console.WriteLine(session);
            }
        }
    }

    private void FilterByCustomer() {
        Console.WriteLine("Please enter customer number: ");
        string input = Console.ReadLine();
        int id = int.Parse(input);

        foreach (Session session in _sessions.Values) {
            if (id == session.CustomerId) {
                Console.WriteLine(session);
            }
        }
    }
}

