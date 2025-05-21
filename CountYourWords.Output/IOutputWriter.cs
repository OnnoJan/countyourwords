namespace CountYourWords.Output;

public interface IOutputWriter
{
    void Write(string[] sortedWords, Dictionary<string, int> countedWords);
}
