using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;


//Blazor Power Hour: Logging with Wasm
//https://www.youtube.com/watch?v=2aDlSA_-rSg&t=1371s
//github.com/EdCharbeneau/BlazorPowerHour
internal class InMemoryLoggerProvider : ILoggerProvider
{
    private readonly ConcurrentDictionary<string, InMemoryLogger> _loggers =
        new ConcurrentDictionary<string, InMemoryLogger>();
    private readonly InMemoryLoggerConfiguration _config;

    public InMemoryLog Log { get; }
    public InMemoryLoggerProvider(InMemoryLog log, InMemoryLoggerConfiguration config) 
    { 
        Log = log;
        _config = config;
    }

    public ILogger CreateLogger(string categoryName) =>
        _loggers.GetOrAdd(categoryName, name => new(name, Log, _config));

    public void Dispose() => _loggers.Clear();

}