using MyLib;

public class GetEnumeratorTests
{
    [Theory]
    [InlineData(1, "Value1")]
    public void GetEnumerator_ReturnsValidEnumerator(int key, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        
        var enumerator = dictionary.GetEnumerator();
        
        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        int expected = dictionary.Count();

        Assert.Equal(expected, count);
    }
}