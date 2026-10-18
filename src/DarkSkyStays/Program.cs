using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DarkSkyStays;
using DarkSkyStays.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<SampleStayService>();
builder.Services.AddScoped<SampleTourService>();
builder.Services.AddScoped<PrototypeNavigation>();

await builder.Build().RunAsync();
