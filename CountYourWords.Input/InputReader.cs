using Microsoft.Extensions.Logging;

namespace CountYourWords.Input;

public class InputReader : IInputReader
{
    private const string FileName = "input.txt";

    private readonly IPathResolver _pathResolver;
    private readonly ILogger<InputReader> _logger;

    public InputReader(IPathResolver pathResolver, ILogger<InputReader> logger)
    {
        _pathResolver = pathResolver;
        _logger = logger;
    }

    public async Task<string> ReadAsync()
    {
        _logger.LogTrace("Start FileInputReader.Read");

        string filePath = _pathResolver.ResolvePath(FileName);

        if (!File.Exists(FileName)) throw new FileNotFoundException("File not found.", FileName);

        string text = await File.ReadAllTextAsync(filePath);

        _logger.LogTrace("File contents read successfully");

        return text;
    }
}
