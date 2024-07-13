using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace Service.TemplateController.AdminPanel.UI.Components;

public partial class ImageUpload
{
    private bool _showUploadButton;
    [Parameter, EditorRequired] public EventCallback<IBrowserFile> OnFileUploaded { get; set; }
    [Parameter] public string? ImageUrl { get; set; }
    [Parameter] public string NoImageUrl { get; set; } = "/images/stock/avatar.svg";
    [Parameter] public string Alt { get; set; } = string.Empty;
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public int Width { get; set; }
    [Parameter] public int Height { get; set; }
    [Parameter] public ObjectFit ObjectFit { get; set; }
    [Parameter] public string AcceptExtensions { get; set; } = ".png, .jpeg, .jpg, .bmp, .gif, .webp";

    private void ShowUploadButton()
    {
        if (Disabled) return;
        _showUploadButton = true;
    }

    private void HideUploadButton()
    {
        if (Disabled) return;
        _showUploadButton = false;
    }
}