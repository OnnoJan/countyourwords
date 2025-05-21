using CountYourWords.Tests.Common;

namespace CountYourWords.Words.Tests;

public class WordExtractorTests
{
    [Fact]
    public void Extract_WithInputString_ReturnsCorrectAmountOfWords()
    {
        // Arrange
        string input = "... this is a test !! test";
        string[] expectedOutput = ["this", "is", "a", "test", "test"];
        IWordExtractor extractor = new WordExtractor();

        // Act
        string[] words = extractor.Extract(input);

        // Assert
        Assert.NotNull(words);
        Assert.NotEmpty(words);
        Assert.True(words.Equal(expectedOutput));
    }
}
