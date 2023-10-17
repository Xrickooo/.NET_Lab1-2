using MyLib;

public class TryGetValueTests
{
    [Fact]
    public void TryGetValue_ReturnsTrueAndSetsValueForExistingKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.TryGetValue(1, out var value);

        // Assert
        Assert.True(result);
        Assert.Equal("Value1", value);
    }

    [Fact]
    public void TryGetValue_ReturnsFalseAndDoesNotSetValueForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        Assert.Throws<InvalidOperationException>(() => dictionary.TryGetValue(1, out var value)); // Значение не должно быть изменено
    }

    [Fact]
    public void TryGetValue_ThrowsInvalidOperationExceptionForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => dictionary.TryGetValue(1, out var value));
    }
}