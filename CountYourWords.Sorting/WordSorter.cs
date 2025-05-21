namespace CountYourWords.Sorting;

public class WordSorter : IWordSorter
{
    private readonly ISortRoutine _sortRoutine;

    public WordSorter(ISortRoutine sortRoutine)
    {
        _sortRoutine = sortRoutine;
    }

    public string[] Sort(string[] words)
    {
        string[] result = _sortRoutine.Sort(words);

        return result;
    }
}
