namespace CountYourWords.Output.Tests;

public class ScrambleRoutineTests
{
    [Fact]
    public void Encode_WithMultipleInputs_ShouldReturnEncodedStringForAll()
    {
        // Arrange
        string[][] inputValues =
        [
            ["jumped", "dEpMuJ"],
            ["brown", "nWoRb"],
            ["dog", "gOd"],
            ["fox", "xOf"],
            ["number", "rEbMuN"]
        ];

        IWordScrambler scrambleRoutine = new WordScrambler();

        foreach (string[] inputValue in inputValues)
        {
            // Act
            string result = scrambleRoutine.Encode(inputValue[0]);

            // Assert
            Assert.Equal(inputValue[1], result);
        }
    }
}
