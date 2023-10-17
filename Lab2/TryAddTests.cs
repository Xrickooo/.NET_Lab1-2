using MyLib;

public class TryAddTests
{
    [Fact]
    public void TryAdd_AddsItemForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        var item = new Item<int, string> { Key = 1, Value = "Value1" };

        // Act
        dictionary.TryAdd(item);

        // Assert
        Assert.Equal("Value1", dictionary[1]);
    }

    [Fact]
    public void TryAdd_ThrowsExceptionForExistingKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        var item = new Item<int, string> { Key = 1, Value = "Value2" }; // Попытка добавить существующий ключ

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => dictionary.TryAdd(item));
    }
}