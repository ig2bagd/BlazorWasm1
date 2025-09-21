using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace BlazorWasm1.Client.Mappings;

[Mapper]
public partial class Ldr2Mapper
{
    public partial Destination Map(Source source);
    public partial Source Map(Destination destination);

    // Custom logic for parsing
    // Mapperly uses convention-based mapping and method signatures to integrate custom logic methods
    // 	 Matching Signatures and Types: Mapperly looks for static methods in your mapper class whose signatures match the source and destination property types.
    public static List<LdrItem2> StringToList(string input)
    {
        var ldrItems = new List<LdrItem2>();
        if (string.IsNullOrWhiteSpace(input)) return ldrItems;

        var items = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
        foreach (var item in items)
        {
            var parts = item.Split("::");
            if (parts.Length == 3)
            {
                decimal amount = 0m;
                var rawAmount = parts[2];
                if (!decimal.TryParse(rawAmount, NumberStyles.Number, CultureInfo.InvariantCulture, out amount))
                {
                    // If value is "N/A" or unparsable, keep amount as 0
                }

                ldrItems.Add(new LdrItem2
                {
                    Name = parts[0],
                    YesNo = parts[1],
                    Amount = amount
                });
            }
        }
        return ldrItems;
    }

    // Custom logic for serialization
    public static string ListToString(List<LdrItem2> ldrItems)
    {
        if (ldrItems == null || ldrItems.Count == 0) return string.Empty;

        var itemStrings = ldrItems.Select(item =>
        {
            var amountStr = item.Amount == 0m ? "N/A" : item.Amount.ToString(CultureInfo.InvariantCulture);
            return $"{item.Name}::{item.YesNo}::{amountStr}";
        });
        return string.Join("|", itemStrings);
    }
}


