using MyLib;
public class ClearTests
{
    [Theory]
    [InlineData(0, "hey2")]
    [InlineData(250, "hey3")]
    [InlineData(26.1, "hey4")]
    [InlineData(26.1, "hey4")]
    public void ClearDictionary(int key, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key,value);
        
        dictionary.Clear();
        
        Assert.Empty(dictionary);
    }
}