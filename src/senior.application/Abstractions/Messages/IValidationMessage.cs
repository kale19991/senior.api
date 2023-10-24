using senior.application.ViewModels;

namespace senior.application.Abstractions.Messages;

public interface IValidationMessage
{
    bool AnyMessage();
    List<ErrorMessageViewModel> GetErrorMessages();
    void Handle(ErrorMessageViewModel errorMessage);
}
