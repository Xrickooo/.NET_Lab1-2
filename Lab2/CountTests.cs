using MyLib;

public class CountTests
{
    [Fact]
    public void Count_ReturnsZeroForEmptyDictionary()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act
        var count = dictionary.Count;

        // Assert
        Assert.Equal(0, count);
    }
}