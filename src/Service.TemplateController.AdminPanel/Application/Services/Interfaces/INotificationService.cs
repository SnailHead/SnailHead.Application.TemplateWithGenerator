using FluentValidation.Results;
using Service.TemplateController.AdminPanel.Models;

namespace Service.TemplateController.AdminPanel.Application.Services.Interfaces;

public interface INotificationService
{
    /// <summary>
    /// Show notification message if api result is not successful
    /// </summary>
    /// <param name="result"></param>
    void Show(HttpResponseMessage? result);

    /// <summary>
    /// Show success message
    /// </summary>
    /// <param name="title">Title of message</param>
    /// <param name="message">Message of message</param>
    void Message(string title, string message);
    /// <summary>
    /// Show error message
    /// </summary>
    /// <param name="error"></param>
    void Error(ErrorViewModel error);
    /// <summary>
    /// Show error message
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    void Error(string title, string message);
    /// <summary>
    /// Show validation errors using array of strings
    /// </summary>
    /// <param name="errors"></param>
    void ValidationError(string[] errors);
    /// <summary>
    /// Show validation error
    /// </summary>
    /// <param name="title"></param>
    /// <param name="message"></param>
    void ValidationError(string title, string message);
    /// <summary>
    /// Show validation error message from validation result
    /// </summary>
    /// <param name="result"></param>
    void ValidationError(ValidationResult result);
}