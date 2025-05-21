using System.Globalization;

namespace CountYourWords.Sorting;

public class InsertionSortRoutine : ISortRoutine
{
    public string[] Sort(string[] input)
    {
        int elementCount = input.Length;
        for (int i = 1; i < elementCount; i++)
        {
            int j = i - 1;
            string element = input[i];
            string key = input[i];
            string compareKey = input[j];
            while (j >= 0 && CompareStrings(compareKey, key) > 0)
            {
                input[j + 1] = input[j];
                j -= 1;
                if (j >= 0) compareKey = input[j];
            }

            input[j + 1] = element;
        }

        return input;
    }

    private int CompareStrings(string compareKey, string key) =>
        string.Compare(compareKey, key, true, CultureInfo.InvariantCulture);
}
