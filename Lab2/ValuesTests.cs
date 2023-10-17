using MyLib; 

public class ValuesTests
{
    [Fact]
    public void Values_ReturnsCorrectCollectionOfValues()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(2, "Value2");
        dictionary.Add(3, "Value3");

        // Act
        var values = dictionary.Values;

        // Assert
        Assert.Equal(new[] { "Value1", "Value2", "Value3" }, values);
    }
}