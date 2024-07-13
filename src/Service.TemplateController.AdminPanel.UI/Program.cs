using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Service.TemplateController.AdminPanel.Application.Services.Interfaces;
using Service.TemplateController.AdminPanel.UI;
using Service.TemplateController.AdminPanel.UI.Application;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<INotificationService, SnackbarNotificationService>();
builder.Services.AddScoped<AuthenticationHttpMessageHandler>();
//builder.Services.AddValidatorsFromAssemblyContaining<UserCreationModel>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<CustomAuthStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var app =  builder.Build();
await app.RunAsync();