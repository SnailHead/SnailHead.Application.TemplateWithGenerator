using MudBlazor;
using Service.TemplateController.AdminPanel.Application.Services.Interfaces;
using Service.TemplateController.AdminPanel.Models;
using Service.TemplateController.AdminPanel.UI.Components;
using Severity = MudBlazor.Severity;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Service.TemplateController.AdminPanel.UI.Application;

/// <summary>
/// Notification service implementation that using snackbar
/// </summary>
public sealed class SnackbarNotificationService : INotificationService
{
    private readonly ISnackbar _snackbar;

    public SnackbarNotificationService(ISnackbar snackbar)
    {
        _snackbar = snackbar;
    }

    public void Show(HttpResponseMessage? result)
    {
        if (result is null || result.StatusCode == 0)
        {
            UnhandledError();
            return;
        }
        
        if (result.IsSuccessStatusCode)
        {
            return;
        }
        
        Error("title", "message");
    }

    public void Message(string title, string message)
    {
        ShowInternal(title, message, Severity.Info);
    }

    public void Error(ErrorViewModel error)
    {
        ShowInternal(error.Title, error.Message, Severity.Error);
    }

    public void Error(string title, string message)
    {
        ShowInternal(title, message, Severity.Error);
    }

    public void ValidationError(string[] errors)
    {
        ShowInternal("Ошибка валидации", string.Empty, Severity.Error, "validation-message");
        foreach (var error in errors)
        {
            ShowInternal(error, "", Severity.Error, "validation-message");
        }
    }

    public void ValidationError(string title, string message)
    {
        ShowInternal(title, message, Severity.Error, "validation-message");
    }
   
    public void ValidationError(ValidationResult result)
    {
        ShowInternal("Ошибка валидации", string.Empty, Severity.Error, "validation-message");
        foreach (var error in result.Errors)
        {
            ShowInternal(error.PropertyName, error.ErrorMessage, Severity.Error, "validation-message");
        }
    }

    /// <summary>
    /// Show internally snackbar message using custom component 
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    /// <param name="severity"></param>
    /// <param name="messageClass">Css class to modify snackbar message</param>
    private void ShowInternal(string title, string message, Severity severity, string? messageClass = null!)
    {
        _snackbar.Add<SnackbarMessage>(new Dictionary<string, object>()
        {
            ["Title"] = title,
            ["Message"] = message,
        }, severity, cfg =>
        {
            if (messageClass is not null)
            {
                cfg.SnackbarTypeClass = messageClass;
            }
        });
    }
    private void UnhandledError()
    {
        ShowInternal("Необработанное исключение от сервера", string.Empty, Severity.Error, "critical-message");
    }
}