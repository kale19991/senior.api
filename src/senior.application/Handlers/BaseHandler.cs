using FluentValidation;
using FluentValidation.Results;
using senior.application.Abstractions.Messages;
using senior.application.ViewModels;
using senior.domain.Abstractions.Messaging;
using System.Text.Json;

namespace senior.application.Handlers;

public abstract class BaseHandler
{
    private readonly IValidationMessage _validationMessage;

    protected BaseHandler(IValidationMessage validationMessage)
    {
        _validationMessage = validationMessage;
    }

    protected void SetError(string errorCode, string errorMessage)
    {
        _validationMessage.Handle(new ErrorMessageViewModel(errorCode, errorMessage));
    }

    protected void SetError(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            SetError(error.ErrorCode, error.ErrorMessage);
        }
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE command) where TV : AbstractValidator<TE> where TE : ICommand
    {
        var validator = validation.Validate(command);

        if (validator.IsValid) return true;

        SetError(validator);

        return false;
    }
}
