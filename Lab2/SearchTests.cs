using MyLib; 

public class SearchTests
{
    [Fact]
    public void Search_ReturnsValueForExistingKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var value = dictionary.Search(1);

        // Assert
        Assert.Equal("Value1", value);
    }

    [Fact]
    public void Search_ThrowsKeyNotFoundExceptionForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<KeyNotFoundException>(() => dictionary.Search(1));
    }

    [Fact]
    public void Search_ReturnsValueForCollidingKeys()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(101, "Value2"); // 1 и 101 хешируются в одну ячейку

        // Act
        var value = dictionary.Search(101);

        // Assert
        Assert.Equal("Value2", value);
    }

    [Fact]
    public void Search_ThrowsKeyNotFoundExceptionForCollidingNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act and Assert
        Assert.Throws<KeyNotFoundException>(() => dictionary.Search(101)); // 101 хешируется в ту же ячейку, где нет значения
    }
}