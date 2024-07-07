internal class InMemoryLogger : ILogger
{
    private readonly string _name;
    private readonly InMemoryLoggerConfiguration _config;
    public InMemoryLog Memory { get; }
    public InMemoryLogger(string name, InMemoryLog memory, InMemoryLoggerConfiguration config)
    {
        _name = name;
        Memory = memory;
        _config = config;
    }
    
    public IDisposable BeginScope<TState>(TState state) => default;

    public bool IsEnabled(LogLevel logLevel) => logLevel == _config.LogLevel;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;

        //Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}] {name} - {formatter(state, exception)}");
        Memory.LogItem($"[{eventId.Id,2}: {logLevel,-12}] {_name} - {formatter(state, exception)}");
    }
}