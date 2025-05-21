using CountYourWords.Tests.Common;

namespace CountYourWords.Sorting.Tests;

public class InsertionSortRoutineTests
{
    [Fact]
    public void Sort_WithArrayOfStrings_ShouldReturnCorrectResult()
    {
        // Arrange
        string[] input = ["fox", "brown", "the", "over", "thE", "Brown"];
        string[] expectedOutput = ["brown", "Brown", "fox", "over", "the", "thE"];

        InsertionSortRoutine routine = new();

        // Act
        string[] result = routine.Sort(input);

        // Assert
        Assert.True(expectedOutput.Equal(result));
    }
}
