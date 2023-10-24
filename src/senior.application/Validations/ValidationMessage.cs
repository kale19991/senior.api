using senior.application.Abstractions.Messages;
using senior.application.ViewModels;

namespace senior.application.Validations;

public class ValidationMessage : IValidationMessage
{
    private List<ErrorMessageViewModel> _errorMessage;

    public ValidationMessage()
    {
        _errorMessage = new();
    }

    public bool AnyMessage()
    {
        return _errorMessage.Any();
    }

    public List<ErrorMessageViewModel> GetErrorMessages()
    {
        return _errorMessage;
    }

    public void Handle(ErrorMessageViewModel errorMessage)
    {
        _errorMessage.Add(errorMessage);
    }
}
