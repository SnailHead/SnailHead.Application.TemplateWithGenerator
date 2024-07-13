using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;
using MudBlazor;
using Service.TemplateController.AdminPanel.Application.Services.Interfaces;
using Service.TemplateController.AdminPanel.Models.Account;

namespace Service.TemplateController.AdminPanel.UI.Pages.Account;

public partial class Authorize
{
    [Inject] private IConfiguration Configuration { get; set; } = null!;

    [Inject] private IMemoryCache MemoryCache { get; set; } = null!;

    [Inject] private ILocalStorageService LocalStorage { get; set; } = null!;

    [Inject] private AuthenticationStateProvider AuthState { get; set; } = null!;
    [Inject] private INotificationService NotificationService { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;

    private MudForm _form;
    private LoginViewModel _model = new();

    protected override async Task OnInitializedAsync()
    {
    }

    private async Task Submit()
    {
        NavigationManager.NavigateTo("/");
    }

}