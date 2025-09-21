namespace BlazorWasm1.Client.Mappings;

public class Destination
{
    public string Name { get; set; }
    public string Id { get; set; }
    public List<LdrItem2> Ldrs { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Id: {Id}, Ldrs: [{string.Join(", ", Ldrs.Select(l => $"{l.Name}:{l.YesNo}:{l.Amount}"))}]";
    }
}