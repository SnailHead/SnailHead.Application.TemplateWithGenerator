namespace Service.TemplateController.AdminPanel.Models;

public class ResultWrapper<T> 
{
    public ResultWrapper(bool isSuccessful, T message)
    {
        IsSuccessful = isSuccessful;
        Message = message;
    }
    public bool IsSuccessful { get; set; }
    public ErrorViewModel Error { get; set; }
    public T Message { get; set; }
}