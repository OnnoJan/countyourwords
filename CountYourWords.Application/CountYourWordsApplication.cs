using CountYourWords.Input;
using CountYourWords.Output;
using CountYourWords.Sorting;
using CountYourWords.Words;
using Microsoft.Extensions.Logging;

namespace CountYourWords.Application;

public class CountYourWordsApplication : ICountYourWordsApplication
{
    private readonly IInputReader _inputReader;
    private readonly ILogger<CountYourWordsApplication> _logger;
    private readonly IOutputWriter _outputWriter;
    private readonly IWordCounter _wordCounter;
    private readonly IWordExtractor _wordExtractor;
    private readonly IWordSorter _wordSorter;

    public CountYourWordsApplication(IInputReader inputReader, IWordExtractor wordExtractor, IWordCounter wordCounter,
        IWordSorter wordSorter, IOutputWriter outputWriter, ILogger<CountYourWordsApplication> logger)
    {
        _inputReader = inputReader;
        _wordExtractor = wordExtractor;
        _wordCounter = wordCounter;
        _wordSorter = wordSorter;
        _outputWriter = outputWriter;
        _logger = logger;
    }

    public async Task RunAsync()
    {
        _logger.LogInformation("Starting CountYourWords");

        try
        {
            string text = await _inputReader.ReadAsync();

            _logger.LogDebug("Input read");

            string[] words = _wordExtractor.Extract(text);

            _logger.LogDebug("Words extracted");

            Dictionary<string, int> countedWords = _wordCounter.Count(words);

            _logger.LogDebug("Words sorted");

            string[] sortedWords = _wordSorter.Sort(countedWords.Select(w => w.Key).ToArray());

            _outputWriter.Write(sortedWords, countedWords);

            _logger.LogInformation("CountYourWords finished and completed with success");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }
}
