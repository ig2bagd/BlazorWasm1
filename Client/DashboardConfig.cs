namespace BlazorWasm1.Client;

public class DashboardConfig
{
    public List<Panel> Panels { get; set; }
}

public class Panel
{
    public string Title { get; set; }
    public string Component { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = new();
}