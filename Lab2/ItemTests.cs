using MyLib; 
using Xunit;

public class ItemTests
{
    [Theory]
    [InlineData(42, "TestValue")]
    public void ItemConstructor_SetsKeyAndValue(int key, string value)
    {
        var item = new Item<int, string>(key, value);
        
        Assert.Equal(key, item.Key);
        Assert.Equal(value, item.Value);
    }

    [Theory]
    [InlineData(42, "TestValue")]
    public void GetHashCode_ReturnsKeyHashCode(int key, string value)
    {
        var item = new Item<int, string>(key, value);
        
        int hashCode = item.GetHashCode();
        
        Assert.Equal(key.GetHashCode(), hashCode);
    }

    [Theory]
    [InlineData(42, "TestValue")]
    public void ToString_ReturnsValueString(int key, string value)
    {
        var item = new Item<int, string>(key, value);
        
        string stringValue = item.ToString();
        
        Assert.Equal(value, stringValue);
    }

    [Theory]
    [InlineData(42, "TestValue")]
    public void Equals_ReturnsFalseForEqualItems(int key, string value)
    {
        var item1 = new Item<int, string>(key, value);
        var item2 = new Item<int, string>(key, value);
        
        bool areEqual = item1.Equals(item2);
        
        Assert.False(areEqual);
    }
}