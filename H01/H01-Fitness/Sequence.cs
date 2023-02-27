namespace H01_Fitness; 

public class Sequence {
    
    private int _sequenceId;
    private int _sequenceDuration;
    private double _sequenceSpeed;

    public Sequence(int sequenceId, int sequenceDuration, double sequenceSpeed) {
        SequenceId = sequenceId;
        SequenceDuration = sequenceDuration;
        SequenceSpeed = sequenceSpeed;
    }

    #region MyRegion
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

    public override string ToString() {
        return $"   SeqNr: {SequenceId}, Snelheid: {SequenceSpeed}, Duur: {SequenceDuration}\n";
    }
}