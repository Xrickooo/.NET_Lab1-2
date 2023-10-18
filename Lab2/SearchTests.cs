using MyLib; 

public class SearchTests
{
    [Theory]
    [InlineData(1, "Value1",101, "Value2")]
    public void Search_ReturnsValueForCollidingKeys(int key, string value, int key2, string  value2)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        dictionary.Add(key2, value2); 
        
        var value3 = dictionary.Search(101);
        
        Assert.Equal(value2, value3);
    }

    [Theory]
    [InlineData(1, 101,"Value1")]
    public void Search_ThrowsKeyNotFoundExceptionForCollidingNonExistentKey(int key, int key2, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key,value);
        
        Assert.Throws<KeyNotFoundException>(() => dictionary.Search(key2));
    }
}