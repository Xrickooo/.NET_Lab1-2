using MyLib; 

public class ValuesTests
{
    [Theory]
    [InlineData(1, "Value1",2, "Value2",3, "Value3")]
    public void Values_ReturnsCorrectCollectionOfValues(int key1, string value1,int key2, string value2,int key3, string value3)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key1, value1);
        dictionary.Add(key2, value2);
        dictionary.Add(key3, value3);
        
        var values = dictionary.Values;
        
        Assert.Equal(new[] { value1, value2, value3 }, values);
    }
}