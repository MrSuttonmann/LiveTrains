using System.Reflection;
using Azure.Identity;
using LiveTrains.Components;
using LiveTrains.Models;
using LiveTrains.Models.Config;
using LiveTrains.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", false, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true)
    .AddUserSecrets(Assembly.GetExecutingAssembly())
    .AddEnvironmentVariables();

string? keyVaultUrl = builder.Configuration["KeyVault:Url"];
if (!string.IsNullOrEmpty(keyVaultUrl))
{
    var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions
    {
        ManagedIdentityClientId = Environment.GetEnvironmentVariable("AZURE_CLIENT_ID")
    });
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), credential);
}

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRailDataConfig(configuration);

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient();

builder.Services.TryAddTransient<RailDataService>();
builder.Services.TryAddSingleton<StationListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseWebSockets();
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();