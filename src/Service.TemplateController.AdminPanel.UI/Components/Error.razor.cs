using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Service.TemplateController.AdminPanel.UI.Components;

public partial class Error
{
    [Inject] private NavigationManager Navigation { get; set; } = null!;
    [Parameter, EditorRequired] public ErrorBoundary Boundary { get; set; } = null!;
    [Parameter, EditorRequired] public Exception Exception { get; set; } = null!;

    protected override void OnInitialized()
    {
        //Explicitly disable preloader
        ChangeIsLoading?.Invoke(false);
    }

    private void HandleSubmitClick()
    {
        //Remove exception from boundary
        Boundary.Recover();
        //Navigate to home page
        Navigation.NavigateTo("/");
    }
}