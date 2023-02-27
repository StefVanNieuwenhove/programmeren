namespace H01_Fitness; 

public class Session {

    private int _sessieId;
    private DateTime _date { get; set; }
    private int _customerId;
    private int _sessionTime;
    private double _averageSpeed;
    private int _sequenceId;
    private int _sequenceDuration;
    private double _sequenceSpeed;

    #region properties
    public int SessieId {
        get { return _sessieId; }
        set {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(("Error sessionId"));
            else _sessieId = value;
        }
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

    public int SequenceId {
        get { return _sequenceId; }
        set {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(("Error sequenceId"));
            else _sequenceId = value;
        }
    }

    /// <summary>
    /// The duration of the sequence in seconds
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public int SequenceDuration {
        get { return _sequenceDuration; }
        set {
            if (value <= 5 || value >= 60 * 60 * 3)
                throw new ArgumentOutOfRangeException(("Error sequenceDuration"));
            else _sequenceDuration = value;
        }
    }

    /// <summary>
    /// Speed of the sequence in km/h
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public double SequenceSpeed {
        get { return _sequenceSpeed; }
        set {
            if (value <= 5 || value > 22)
                throw new ArgumentOutOfRangeException(("Error sequenceSpeed"));
            else _sequenceSpeed = value;
        }
    }
    #endregion
}