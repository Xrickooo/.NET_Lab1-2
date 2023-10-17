using MyLib;

public class RemoveUnitTests
{
    [Fact]
    public void Remove_SuccessfullyRemovesItemFromDictionary()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.Remove(1);

        // Assert
        Assert.True(result);
        Assert.Throws<KeyNotFoundException>(() =>Assert.False(dictionary.ContainsKey(1)));
    }

    [Fact]
    public void Remove_ThrowsExceptionForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => dictionary.Remove(1));
    }

    [Fact]
    public void Remove_RemovesItemAtTheEndOfCollisionChain()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(101, "Value2");
        dictionary.Add(201, "Value3");

        // Act
        var result = dictionary.Remove(1);

        // Assert
        Assert.True(result);
        Assert.Throws<KeyNotFoundException>(() =>Assert.False(dictionary.ContainsKey(1)));
    }

    [Fact]
    public void Remove_RemovesItemAtTheBeginningOfCollisionChain()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(101, "Value2");
        dictionary.Add(201, "Value3");

        // Act
        var result = dictionary.Remove(101);

        // Assert
        Assert.True(result);
        Assert.Throws<KeyNotFoundException>(() =>Assert.False(dictionary.ContainsKey(101)));
    }
    
    
    
    
    [Fact]
    public void RemoveKeyValuePair_ReturnsTrueAndRemovesItemForExistingKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.Remove(new KeyValuePair<int, string>(1, "Value1"));

        // Assert
        Assert.True(result);
        Assert.Throws<KeyNotFoundException>(() =>
            Assert.False(dictionary.ContainsKey(1))); // Проверяем, что элемент был удален
    }

    [Fact]
    public void RemoveKeyValuePair_ReturnsFalseForNonExistentKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        Assert.Throws<Exception>(()=>dictionary.Remove(new KeyValuePair<int, string>(1, "Value1")));
    }

    [Fact]
    public void RemoveKeyValuePair_ThrowsExceptionForNonExistentKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<Exception>(() => dictionary.Remove(new KeyValuePair<int, string>(1, "Value1")));
    }
}