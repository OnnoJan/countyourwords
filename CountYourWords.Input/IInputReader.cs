namespace CountYourWords.Input;

public interface IInputReader
{
    Task<string> ReadAsync();
}
