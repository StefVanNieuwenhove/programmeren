using Period.Domain.Model;

namespace Period.Test; 

public class IntervalTest {

    [Theory]
    [InlineData(15, 20, 30, 31, false)]
    [InlineData(15, 30, 20, 31, true)]
    [InlineData(15, 30, 15, 30, true)]
    public void Interval_ValidInterval_OverlapsBooleanTrue(int start1, int end1, int start2, int end2, bool exceptedResult) {
        // arrange
        Interval interval = new (MakeDateTimeFromDay(start1), MakeDateTimeFromDay(end1));
        Interval otherInterval = new (MakeDateTimeFromDay(start2), MakeDateTimeFromDay(end2));
        // act
        bool result = interval.OverlapsWith(otherInterval);
        // assert
        Assert.Equal(exceptedResult, result);
    }

    [Fact]
    public void Interval_Constructor_ThrowException() {
        Assert.Throws<ArgumentException>(() => new Interval(MakeDateTimeFromDay(25), MakeDateTimeFromDay(20)));
    }

    [Fact]
    public void Interval_Constructor_NewInterval() {

        DateTime start = MakeDateTimeFromDay(3);
        DateTime end = MakeDateTimeFromDay(30);

        Interval interval = new Interval(start, end);

        Assert.Equal(start, interval.Startdatum);
        Assert.Equal(end, interval.Enddatum);
        //Assert.NotNull(interval);
        //Assert.IsType<Interval>(interval);
    }

    private DateTime MakeDateTimeFromDay(int value) => new DateTime(2023, 3, value);
}