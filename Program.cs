using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LogTailBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<LogTailBlazor.App>("#app");

builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<SettingsService>();
builder.Services.AddScoped<LogParserService>();

await builder.Build().RunAsync();
