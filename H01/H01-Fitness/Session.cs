namespace H01_Fitness; 

public class Session {

    private int _sessieId;
    private DateTime _date;
    private int _customerId;
    private int _sessionTime;
    private double _averageSpeed;
    public List<Sequence> Sequences { get; set; }

    public Session(int sessionId, DateTime date, int customerId, int sessionTime, double averageSpeed) {
        SessionId = sessionId;
        Date = date;
        CustomerId = customerId;
        SessionTime = sessionTime;
        AverageSpeed = averageSpeed;
        Sequences = new();
    }

    #region properties
    public int SessionId {
        get { return _sessieId; }
        set {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(("Error sessionId"));
            else _sessieId = value;
        }
    }

    public DateTime Date {
        get { return _date; }
        set { _date = value; }
    }

    public int CustomerId {
        get { return _customerId; }
        set {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(("Error customerId"));
            else _customerId = value;
        }
    }

    /// <summary>
    /// Total of duration of the session in minutes
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int SessionTime {
        get { return _sessionTime; }
        set {
            if (value <= 5 || value >= 60 * 3)
                throw new ArgumentOutOfRangeException(("Error duration"));
            else _sessionTime = value;
        }
    }

    /// <summary>
    /// Average speed during the session in km/h
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public double AverageSpeed {
        get { return _averageSpeed; }
        set {
            if (value <= 5 || value > 22)
                throw new ArgumentOutOfRangeException(("Error averageSpeed"));
            else _averageSpeed = value;
        }
    }
    #endregion

    public override bool Equals(object? obj) {
        return obj is Session session && session.SessionId == this.SessionId;
    }

    public override int GetHashCode() {
        return HashCode.Combine(SessionId);
    }

    public override string ToString() {
        string output = $"Sessie: {SessionId}, {_date}, KLant: {CustomerId}, Duur: {SessionTime}, snelheid: {AverageSpeed}\n";
        foreach (Sequence sequence in Sequences) {
            output += sequence.ToString();
        }

        return output;
    }
}