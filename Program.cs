using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlantAppClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient to call API with the /api prefix
builder.Services.AddScoped(sp =>
{
    var apiUrl = builder.HostEnvironment.IsDevelopment()
        ? "http://localhost:5005/api/"  // Development URL (HTTP)
        : "https://api.yourdomain.com/api/";  // Production URL (HTTPS)

    return new HttpClient { BaseAddress = new Uri(apiUrl) };
});

await builder.Build().RunAsync();
