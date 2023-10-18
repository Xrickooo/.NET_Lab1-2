using MyLib;
public class AddTests 
{
    [Theory]
    [InlineData(0, "hey2")]
    [InlineData(250, "hey3")]
    [InlineData(26.1, "hey4")]
    [InlineData(101, null)]
    public void ValidItemAdded(int key, string value)
    {
        MyDictionary<int, string> dict = new MyDictionary<int, string>();
        dict.Add(key, value);
        Assert.False(dict.IsReadOnly);
    }
    
    [Theory]
    [InlineData(1, "hey2")]
    public void ExistingItemAdded(int key, string value)    
    { 
        var dict = new MyDictionary<int, string>(){};
        dict.Add(key, value);
        Assert.Throws<ArgumentException>(() =>  dict.Add(key, value));
    }
    
    [Theory]
    [InlineData(-10, "hey2")]
    public void NegativeItemAdded(int key, string value)    
    { 
        var dict = new MyDictionary<int, string>(){};
        Assert.Throws<ArgumentException>(() => dict.Add(key,value));
    }
   
    
    [Theory]
    [InlineData(1, "Value1")]
    public void AddKeyValuePair_AddsItemForNonExistentKey(int key, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        var item = new KeyValuePair<int, string>(key, value);
        
        dictionary.Add(item);
        
        Assert.Equal(value, dictionary[1]);
    }
}
    

