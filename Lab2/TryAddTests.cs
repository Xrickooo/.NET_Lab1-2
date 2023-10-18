using MyLib;

public class TryAddTests
{
    [Theory]
    [InlineData(1, "Value1")]
    public void TryAdd_AddsItemForNonExistentKey(int key, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        var item = new Item<int, string> { Key = key, Value = value };
        
        dictionary.TryAdd(item);
        
        Assert.Equal(value, dictionary[key]);
    }

    [Theory]
    [InlineData(1, "Value1","Value2")]
    public void TryAdd_ThrowsExceptionForExistingKey(int key, string value,string value2)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key,value);
        var item = new Item<int, string> { Key = key, Value = value2 }; 
        
        Assert.Throws<InvalidOperationException>(() => dictionary.TryAdd(item));
    }
}