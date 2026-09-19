using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StarWarsPlanets.Blazor;
using StarWarsPlanets.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient {
        BaseAddress = new Uri("https://localhost:7097/") // API URL
});

builder.Services.AddScoped<PlanetService>();

await builder.Build().RunAsync();
