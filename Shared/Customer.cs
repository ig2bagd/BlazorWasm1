using System.ComponentModel.DataAnnotations;

namespace BlazorWasm1.Shared;

public class Customer
{
    [Required]
    public string Name { get; set; }

    [Required]
    [OrganizationValidation(ErrorMessage = "Invalid customer log-in.", ValidOrganizationName = "Microsoft")]
    public string Organization { get; set; }
}
