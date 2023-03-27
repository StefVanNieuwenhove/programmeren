namespace Period.Domain.Model; 

public class Interval {
    
    public DateTime Startdatum { get; init; }
    public DateTime Enddatum { get; init; }

    public Interval(DateTime startdatum, DateTime enddatum) {
        if (!IsStartbeforeEndDate(startdatum, enddatum))
            throw new ArgumentException("Start date cannot be after the end date");
        Startdatum = startdatum;
        Enddatum = enddatum;             


    }

    private bool IsStartbeforeEndDate(DateTime start, DateTime end) {
        return end > start;
    }

    public bool OverlapsWith(Interval other) {
        return (Startdatum <= other.Startdatum && Enddatum >= other.Startdatum);
    }


}