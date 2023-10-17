using MyLib;

public class GetEnumeratorTests
{
    [Fact]
    public void GetEnumerator_ReturnsValidEnumerator()
    {
        // Arrange
        var dictionary = new MyDictionary<int, string>();
        dictionary.Add(1, "Value1");
        dictionary.Add(2, "Value2");
        dictionary.Add(3, "Value3");

        // Act
        var enumerator = dictionary.GetEnumerator();

        // Assert
        int count = 0;
        while (enumerator.MoveNext())
        {
            count++;
        }

        Assert.Equal(3, count); // В этом примере ожидаем, что итератор вернет 3 элемента
    }
}