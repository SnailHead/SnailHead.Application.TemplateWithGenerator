using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Service.TemplateController.AdminPanel.UI.Application;

public abstract class DisposablePage : ComponentBase, IDisposable
{
    private protected CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
    [Inject]
    private protected ISnackbar _snackbar { get; set; }
    [CascadingParameter]
    public Action<bool> ChangeIsLoading { get; set; }
    [CascadingParameter(Name = "Breakpoint")]
    public Breakpoint Breakpoint { get; set; }
    [Inject]
    private protected NavigationManager _navigationManager { get; set; }

    public void Dispose()
    {
        CancellationTokenSource.Cancel();
        CancellationTokenSource.Dispose();
    }

    protected override async Task OnInitializedAsync()
    {
        var interfaces = this.GetType().GetProperties().Select(i => i.PropertyType.IsInterface);
        

    }
}