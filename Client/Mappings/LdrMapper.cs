using Riok.Mapperly.Abstractions;

namespace BlazorWasm1.Client.Mappings;

[Mapper]
public static partial class LdrMapper
{
    public static List<LdrItem> MapToList(string source)
    {
        return ParseLdrItems(source);
    }

    public static string MapToString(List<LdrItem> items)
    {
        return SerializeLdrItems(items);
    }

    // Forward mapping: string → List<LdrItem>
    private static List<LdrItem> ParseLdrItems(string source)
    {
        return source
            .Split('|', StringSplitOptions.RemoveEmptyEntries)
            .Select(part =>
            {
                var tokens = part.Split("::");
                return new LdrItem
                {
                    Name = tokens[0],
                    Amount = decimal.Parse(tokens[1])
                };
            })
            .ToList();
    }

    // Reverse mapping: List<LdrItem> → string
    private static string SerializeLdrItems(List<LdrItem> items)
    {
        return string.Join("|", items.Select(i => $"{i.Name}::{i.Amount}"));
    }
}