namespace BlazorWasm1.Client.Pages;

public class FormData
{
    public string InputValue { get; set; } = "John Smith";
    public DateTime SelectedDate { get; set; } = DateTime.Today;
    public string SelectedOption { get; set; } = "Option1";
    public List<string> Options { get; set; } = new List<string>() { "Option1", "Option2", "Option3", "Option4", "Option5" };
}
