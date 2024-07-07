using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System.Reflection;

namespace BlazorWasm1.Client.Pages;
public partial class MultiSelect
{
    [Inject] IJSRuntime js { get; set; }
    [Inject] NavigationManager navMgr { get; set; }

    private IJSObjectReference? jsModule;

    private List<Product> Products { get; set; }
    private List<int> SelectedProductIDs = new() { 2 };
    private int Id1 { get; set; } = 3;
    private int Id2 { get; set; } = 5;

    /*
    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await js.InvokeVoidAsync("setState");

        //The ParameterView instance can no longer be read because it has expired. ParameterView can only be read synchronously and must not be stored for later use.
        //await base.SetParametersAsync(parameters);
    }
    */

    protected override void OnInitialized()
    {
        //string baseUri = navMgr.BaseUri;
        //js.InvokeVoidAsync("setState", baseUri);

        navMgr.LocationChanged += HandleLocationChanged;

        Products = new List<Product>();

        for (int i = 1; i <= 10; i++)
        {
            Products.Add(new Product()
            {
                Id = i,
                Name = "Product " + i
            });
        }

        base.OnInitialized();
    }

    private void HandleLocationChanged(object sender, LocationChangedEventArgs e)
    {
        //var previousUrl = e.OldLocation;
        // Do something with the previous URL
        var previousUrl = e.Location;
        Console.WriteLine($"HandleLocationChanged - previousUrl: {previousUrl}");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            jsModule = await js.InvokeAsync<IJSObjectReference>("import", "./Pages/MultiSelect.razor.js");
        }
        await base.OnAfterRenderAsync(firstRender);
    }
    private void SelectItems()
    {
        // reset object reference to trigger re-render
        SelectedProductIDs = new List<int>() { Id1, Id2 };
    }

    private void ClearSelection()
    {
        SelectedProductIDs = new List<int>();
    }
    
    private async Task GetPreviousUrl()
    {
        //var pageReferrer = await js.InvokeAsync<string>("getPageReferrer");

        //var pageReferrer = await jsModule.InvokeAsync<string>("getPageReferrer");
        //var pageReferrer = await jsModule.InvokeAsync<string>("getLocationHref");
        var pageReferrer = await jsModule.InvokeAsync<string>("getPrevUrl");
        Console.WriteLine($"GetPreviousUrl - pageReferrer: {pageReferrer}");
    }
    
    private async Task GoBack()
    {
        await js.InvokeVoidAsync("history.back");
    }

    private void Validate()
    {
        Console.WriteLine("SelectedProductIDs: " + string.Join("|", SelectedProductIDs));
    }

    private void OnMultiValueChanged(List<int> newValues)
    {
        SelectedProductIDs = newValues;
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
