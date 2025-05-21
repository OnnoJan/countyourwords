namespace CountYourWords.Words.Tests;

public class WordCounterTests
{
    [Fact]
    public void Count_WithInput_ReturnsCorrectResult()
    {
        // Arrange
        IWordCounter counter = new WordCounter();
        string[] input = ["test", "this", "is", "a", "test"];
        Dictionary<string, int> expectedOutputDictionary = new() { { "this", 1 }, { "is", 1 }, { "a", 1 }, { "test", 2 } };

        // Act
        Dictionary<string, int> result = counter.Count(input);

        // Output
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Equal(2, expectedOutputDictionary["test"]);
    }
}
