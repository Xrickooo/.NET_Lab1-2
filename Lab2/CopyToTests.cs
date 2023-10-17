using MyLib;

public class CopyToTests
{
    [Fact]
    public void CopyTo_CopiesElementsToArrayStartingAtIndex()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(2, "Value2");
        dictionary.Add(3, "Value3");
        var array = new KeyValuePair<int, string>[5];

        // Act
        dictionary.CopyTo(array, 2);

        // Assert
        Assert.Equal(default(KeyValuePair<int, string>), array[0]); // Первые два элемента должны быть пустыми
        Assert.Equal(new KeyValuePair<int, string>(1, "Value1"), array[2]);
        Assert.Equal(new KeyValuePair<int, string>(2, "Value2"), array[3]);
        Assert.Equal(new KeyValuePair<int, string>(3, "Value3"), array[4]);
    }

    [Fact]
    public void CopyTo_ThrowsArgumentNullExceptionForNullArray()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        var array = default(KeyValuePair<int, string>[]); // Передаем null

        // Act and Assert
        Assert.Throws<ArgumentNullException>(() => dictionary.CopyTo(array, 0));
    }

    [Fact]
    public void CopyTo_ThrowsArgumentOutOfRangeExceptionForNegativeArrayIndex()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        var array = new KeyValuePair<int, string>[1];

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(array, -1));
    }

    [Fact]
    public void CopyTo_ThrowsArgumentOutOfRangeExceptionForArrayIndexOutOfBounds()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        var array = new KeyValuePair<int, string>[1];

        // Act and Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(array, 1));
    }
}
