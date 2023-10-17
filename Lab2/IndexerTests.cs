using MyLib;

public class IndexerTests
{
    [Fact]
    public void Indexer_GetValueByKey_ReturnsCorrectValue()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");

        // Act
        var value = dictionary[1];

        // Assert
        Assert.Equal("Value1", value);
    }

    [Fact]
    public void Indexer_SetValueByKey_AddsNewKeyValueToDictionary()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();

        // Act
        dictionary[1] = "Value1";

        // Assert
        Assert.Equal("Value1", dictionary[1]);
    }

    [Fact]
    public void Indexer_SetValueByKey_InvokesOnItemAddedEvent()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        bool eventRaised = false;
        dictionary.OnItemAdded += (key, value) => eventRaised = true;

        // Act
        dictionary[1] = "Value1";

        // Assert
        Assert.True(eventRaised);
    }
}