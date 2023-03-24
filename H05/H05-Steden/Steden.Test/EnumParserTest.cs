using Stede.Domain.Model;

namespace Steden.Test; 

public class EnumParserTest {
    
    [Theory]
    [InlineData("Gent", Stede.Domain.Model.Steden.Gent)]
    [InlineData("Ghent", Stede.Domain.Model.Steden.Gent)]
     public void Parser_CoreectValue_StedenEnum(string input, Stede.Domain.Model.Steden expected) {
            Stede.Domain.Model.Steden actual = Parser.Parse(input);
         Assert.Equal(expected, actual);
     }

    [Fact]
    public void Parser_InvalidValue_ThrowsArgumentException() {
        // ReSharper disable once HeapView.BoxingAllocation
        Assert.Throws<ArgumentException>(() => Parser.Parse("Invalid"));
    }
}                                                                    