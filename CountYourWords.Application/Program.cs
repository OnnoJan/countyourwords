using CountYourWords.Input;
using CountYourWords.Output;
using CountYourWords.Sorting;
using CountYourWords.Words;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CountYourWords.Application;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ServiceCollection serviceCollection = new();

        serviceCollection.AddTransient<IPathResolver, PathResolver>();
        serviceCollection.AddTransient<IInputReader, InputReader>();

        serviceCollection.AddTransient<IWordExtractor, WordExtractor>();
        serviceCollection.AddTransient<IWordCounter, WordCounter>();

        serviceCollection.AddTransient<ISortRoutine, InsertionSortRoutine>();
        serviceCollection.AddTransient<IWordSorter, WordSorter>();

        serviceCollection.AddTransient<IOutputWriter, ConsoleOutputWriter>();
        serviceCollection.AddTransient<IWordScrambler, WordScrambler>();

        serviceCollection.AddTransient<ICountYourWordsApplication, CountYourWordsApplication>();

        serviceCollection.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevelReader(args));
        });

        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        ICountYourWordsApplication app = serviceProvider.GetRequiredService<ICountYourWordsApplication>();

        await app.RunAsync();
    }

    private static LogLevel LogLevelReader(string[] args)
    {
        string logLevelArg = args.Length > 0 ? args[0] : "";
        return logLevelArg switch
        {
            "trace" => LogLevel.Trace,
            "debug" => LogLevel.Debug,
            "information" => LogLevel.Information,
            "warning" => LogLevel.Warning,
            "error" => LogLevel.Error,
            "critical" => LogLevel.Critical,
            _ => LogLevel.None
        };
    }
}
