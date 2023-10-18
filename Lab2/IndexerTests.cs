using MyLib;

public class IndexerTests
{
    [Theory]
    [InlineData(1, "Value1")]
    public void Indexer_SetValueByKey_AddsNewKeyValueToDictionary(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        
        dictionary[key] = value;
        
        Assert.Equal(value, dictionary[key]);
    }

    [Theory]
    [InlineData(1, "Value1")]
    public void Indexer_SetValueByKey_InvokesOnItemAddedEvent(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        bool eventRaised = false;
        dictionary.OnItemAdded += (key, value) => eventRaised = true;
        
        dictionary[key] = value;
        
        Assert.True(eventRaised);
    }
}