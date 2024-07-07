public class InMemoryLog
{
    public event Action OnChange;
    public List<string> Log { get; set; } = new();

    public void LogItem(string item)
    {
        Log.Add(item);
        OnChange?.Invoke();
    }
}

