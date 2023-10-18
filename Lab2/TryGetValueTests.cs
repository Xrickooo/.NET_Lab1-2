using MyLib;

public class TryGetValueTests
{
    [Theory]
    [InlineData(1, "Value1")]
    public void TryGetValue_ReturnsTrueAndSetsValueForExistingKey(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var result = dictionary.TryGetValue(1, out var value2);
        
        Assert.True(result);
        Assert.Equal(value, value2);
    }
    
    [Fact]
    public void TryGetValue_ThrowsInvalidOperationExceptionForNonExistentKey()
    {
        var dictionary = new MyDictionary<int, string>();
        
        Assert.Throws<InvalidOperationException>(() => dictionary.TryGetValue(1, out var value));
    }
}