using BlazorWasm1.Shared;

namespace BlazorWasm1.Client.Pages;

public partial class CustomValidation
{
    private Customer _product = new Customer();
    public void Submit() =>
        Console.WriteLine($"{_product.Name}, {_product.Organization}");
}
