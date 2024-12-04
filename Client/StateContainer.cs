namespace BlazorWasm1.Client
{
    public class StateContainer
    {
        private string? savedString;

        public string Property
        {
            get => savedString ?? string.Empty;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();


        // Blazor Tutorial: Propagating an Event Callback from a Nested Component to Its Ancestor
        // https://www.youtube.com/watch?v=66NBdpu1Nig
        public event Action<string>? OnChildClick;

        public void ChildClicked(string text)
        {
            OnChildClick?.Invoke(text);
        }
    }
}
