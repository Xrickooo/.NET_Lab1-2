using MyLib;

public class RemoveUnitTests
{
    [Fact]
    public void Remove_ThrowsExceptionForNonExistentKey()
    {
        var dictionary = new MyDictionary<int, string>();
        
        Assert.Throws<InvalidOperationException>(() => dictionary.Remove(1));
    }
    
    [Theory]
    [InlineData(1, "Value1")]
    public void RemoveKeyValuePair_ReturnsTrueAndRemovesItemForExistingKeyValuePair(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var result = dictionary.Remove(new KeyValuePair<int, string>(key, value));
        
        Assert.True(result);
        Assert.Throws<KeyNotFoundException>(() =>
            Assert.False(dictionary.ContainsKey(key))); 
    }

    [Fact]
    public void RemoveKeyValuePair_ReturnsFalseForNonExistentKeyValuePair()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        Assert.Throws<Exception>(()=>dictionary.Remove(new KeyValuePair<int, string>(1, "Value1")));
    }
}