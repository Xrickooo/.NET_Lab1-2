using MyLib; 

public class ContainsTests
{
    [Fact]
    public void ContainsKey_ReturnsTrueForExistingKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.ContainsKey(1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ContainsKey_ThrowsKeyNotFoundExceptionForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<KeyNotFoundException>(() => dictionary.ContainsKey(1));
    }
    
    
    
    
    
    
    
    [Fact]
    public void Contains_ReturnsTrueForExistingKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.Contains(new KeyValuePair<int, string>(1, "Value1"));

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Contains_ReturnsFalseForNonExistentKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        
        Assert.Throws<Exception>(()=>dictionary.Contains(new KeyValuePair<int, string>(1, "Value2")));
    }

    [Fact]
    public void Contains_ThrowsExceptionForNonExistentKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<Exception>(() => dictionary.Contains(new KeyValuePair<int, string>(1, "Value1")));
    }
    
    
    
    
    
    
    [Fact]
    public void ContainsValue_ReturnsTrueForExistingValue()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var result = dictionary.ContainsValue("Value1");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ContainsValue_ReturnsFalseForNonExistentValue()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        
        Assert.Throws<Exception>(() => dictionary.ContainsValue("Value2"));
    }

    [Fact]
    public void ContainsValue_ThrowsExceptionForNonExistentValue()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act and Assert
        Assert.Throws<Exception>(() => dictionary.ContainsValue("Value1"));
    }
}
