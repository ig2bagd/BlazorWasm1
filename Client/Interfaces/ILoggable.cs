using Microsoft.AspNetCore.Components;

namespace BlazorWasm1.Client.Interfaces;

public interface ILoggable : IComponent
{
    public void Log();
}