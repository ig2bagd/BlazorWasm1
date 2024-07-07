using BlazorWasm1.Client;
using BlazorWasm1.Client.FluentValidation;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

#region Logging
InMemoryLog mLog = new();
builder.Services.AddSingleton(mLog);

builder.Logging.SetMinimumLevel(LogLevel.Warning);
builder.Logging.AddProvider(new InMemoryLoggerProvider(mLog,
                                new InMemoryLoggerConfiguration()
                                {
                                    LogLevel = LogLevel.Warning
                                }
                            ));
#endregion

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<StateContainer>();

// Register the Telerik services.
builder.Services.AddTelerikBlazor();

await builder.Build().RunAsync();
