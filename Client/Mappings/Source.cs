namespace BlazorWasm1.Client.Mappings;

public class Source
{
    public string Name { get; set; }
    public string Id { get; set; }
    // incoming raw string like:
    // "Bank of America::No::N/A|Carlyle::Yes::25000000|Nestle::Yes::500000000"
    public string Ldrs { get; set; }
}