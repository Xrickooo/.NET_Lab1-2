using MyLib;
public class AddTests 
{
    
    [Theory]
    [InlineData(0, "hey2")]
    [InlineData(250, "hey3")]
    [InlineData(26.1, "hey4")]
    [InlineData(26.1, "hey4")]
    [InlineData(26.1, null)]
    [InlineData(1, null)]
    [InlineData(101, null)]
    public void ValidItemAdded(int key, string value)
    {
        MyDictionary<int, string> dict = new MyDictionary<int, string>();
        dict.Add(key, value);
        Assert.False(dict.IsReadOnly);
    }
    
    [Fact]
    public void ExistingItemAdded()    
    { 
        var dict = new MyDictionary<int, string>(){};
        dict.Add(1, null);
        Assert.Throws<ArgumentException>(() => dict.Add(1,null));
    }
    
    [Fact]
    public void InvalidItemAdded()    
    { 
        var dict = new MyDictionary<int, string>(){};
        Assert.Throws<ArgumentException>(() => dict.Add(-10,null));
    }
   
    
    [Fact]
    public void AddKeyValuePair_AddsItemForNonExistentKey()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        var item = new KeyValuePair<int, string>(1, "Value1");

        // Act
        dictionary.Add(item);

        // Assert
        Assert.Equal("Value1", dictionary[1]);
    }
}
    

