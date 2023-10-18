using MyLib;

public class CountTests
{
    [Fact]
    public void Count_ReturnsZeroForEmptyDictionary()
    {
        var dictionary = new MyDictionary<int, string>();
        
        var count = dictionary.Count;
        
        Assert.Equal(0, count);
    }
}