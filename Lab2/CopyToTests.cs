using MyLib;

public class CopyToTests
{
    [Theory]
    [InlineData(1, "Value1")]
    [InlineData(2, "Value2")]
    [InlineData(3, "Value3")]
    public void CopyTo_CopiesElementsToArrayStartingAtIndex(int key,string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        var array = new KeyValuePair<int, string>[5];
        
        dictionary.CopyTo(array, 2);
        
        Assert.Equal(default(KeyValuePair<int, string>), array[0]); // Первые два элемента должны быть пустыми
        Assert.Equal(new KeyValuePair<int, string>(key, value), array[2]);
    }

    [Theory]
    [InlineData(1, "Value1")]
    public void CopyTo_ThrowsArgumentNullExceptionForNullArray(int key, string value)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        var array = default(KeyValuePair<int, string>[]); 
        
        Assert.Throws<ArgumentNullException>(() => dictionary.CopyTo(array, 0));
    }

    [Theory]
    [InlineData(1, "Value1", -1)]
    public void CopyTo_ThrowsArgumentOutOfRangeExceptionForNegativeArrayIndex(int key, string value,int negIndex)
    {
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(key, value);
        var array = new KeyValuePair<int, string>[1];
        
        Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(array, negIndex));
    }
}
