namespace CountYourWords.Words;

public class WordCounter : IWordCounter
{
    public Dictionary<string, int> Count(string[] words)
    {
        Dictionary<string, int> countedWords = words.Select(word => word.ToLower()).GroupBy(word => word)
            .ToDictionary(group => group.Key, group => group.Count());

        return countedWords;
    }
}
