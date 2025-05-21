using Microsoft.Extensions.Logging;
using Moq;

namespace CountYourWords.Input.Tests;

public class InputReaderTests
{
    [Fact]
    public async Task ReadAsync_WithCorrectPathAndFileName_ReturnsText()
    {
        // Arrange
        Mock<ILogger<InputReader>> mockLogger = new();
        IInputReader inputReader = new InputReader(new PathResolver(), mockLogger.Object);

        // Act
        string text = await inputReader.ReadAsync();

        // Assert
        Assert.NotNull(text);
        Assert.NotEmpty(text);
    }

    [Fact]
    public async Task ReadAsync_WithNonExistingFile_ThrowsFileNotFoundException()
    {
        // Arrange
        Mock<ILogger<InputReader>> mockLogger = new();
        Mock<IPathResolver> pathResolverMock = new();
        pathResolverMock.Setup(resolver => resolver.ResolvePath(It.IsAny<string>())).Returns(@"C:\input.txt");
        IInputReader inputReader = new InputReader(pathResolverMock.Object, mockLogger.Object);

        // Act / Assert
        await Assert.ThrowsAsync<FileNotFoundException>(async () => await inputReader.ReadAsync());
    }
}
