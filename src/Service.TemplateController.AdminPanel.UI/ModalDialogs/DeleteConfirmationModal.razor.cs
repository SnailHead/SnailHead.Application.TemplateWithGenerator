using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Service.TemplateController.AdminPanel.UI.ModalDialogs;

public partial class DeleteConfirmationModal
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }

    [Parameter] public string ContentText { get; set; }

    [Parameter] public string ButtonText { get; set; }

    [Parameter] public Color Color { get; set; }
    [Parameter] public Guid EntityId { get; set; }

    void Submit() => MudDialog.Close(DialogResult.Ok(EntityId));
    void Cancel() => MudDialog.Cancel();
}