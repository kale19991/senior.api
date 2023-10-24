namespace senior.application.ViewModels;

public class ErrorMessageViewModel
{
    public ErrorMessageViewModel(
        string code, 
        string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }
    public string Message { get; }
}
