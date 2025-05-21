namespace CountYourWords.Output;

public class ConsoleOutputWriter : IOutputWriter
{
    private readonly IWordScrambler _wordScrambler;

    public ConsoleOutputWriter(IWordScrambler wordScrambler)
    {
        _wordScrambler = wordScrambler;
    }

    public void Write(string[] sortedWords, Dictionary<string, int> countedWords)
    {
        Console.WriteLine($"Number of words: {countedWords.Sum(pair => pair.Value)}");
        Console.WriteLine("");

        foreach (string word in sortedWords)
        {
            int wordCount = countedWords[word];
            Console.WriteLine($"{_wordScrambler.Encode(word)}: {wordCount}");
        }
    }
}
