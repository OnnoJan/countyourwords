using System.Text.RegularExpressions;

namespace CountYourWords.Words;

public class WordExtractor : IWordExtractor
{
    public string[] Extract(string text)
    {
        MatchCollection matches = Regex.Matches(text, @"\b[^\d\W]+\b");
        return matches.Select(m => m.Value).ToArray();
    }
}
