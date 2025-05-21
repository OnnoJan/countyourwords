namespace CountYourWords.Words;

public interface IWordCounter
{
    Dictionary<string, int> Count(string[] words);
}
