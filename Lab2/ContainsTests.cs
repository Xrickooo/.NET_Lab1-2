using MyLib; 

public class ContainsTests
{
    [Theory]
    [InlineData(1, "Value1")]
    public void ContainsKey_ReturnsTrueForExistingKey(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var result = dictionary.ContainsKey(1);
        
        Assert.True(result);
    }
    
    [Theory]
    [InlineData(1, "Value1")]
    public void Contains_ReturnsTrueForExistingKeyValuePair(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var result = dictionary.Contains(new KeyValuePair<int, string>(key, value));
        
        Assert.True(result);
    }

    [Theory]
    [InlineData(1, "Value1","Value2")]
    public void Contains_ReturnsFalseForNonExistentKeyValuePair(int key,string value,string value2)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        Assert.Throws<Exception>(()=>dictionary.Contains(new KeyValuePair<int, string>(key, value2)));
    }
    
    [Theory]
    [InlineData(1, "Value1")]
    public void ContainsValue_ReturnsTrueForExistingValue(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var result = dictionary.ContainsValue(value);
        
        Assert.True(result);
    }

    [Theory]
    [InlineData(1, "Value1", "Value2")]
    public void ContainsValue_ReturnsFalseForNonExistentValue(int key,string value,string value2)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        Assert.Throws<Exception>(() => dictionary.ContainsValue(value2));
    }
}
