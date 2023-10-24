using FluentValidation;
using senior.application.Commands.UserCommands;

namespace senior.application.Validations.UserValidations;

public class LoginValidation : AbstractValidator<LoginCommand>
{
	public LoginValidation()
	{
        RuleFor(c => c.Email)
            .NotEmpty()
                .WithErrorCode("LOG031")
                .WithMessage("O email é obrigatório")
            .EmailAddress()
                .WithErrorCode("LOG032")
                .WithMessage("Email inválido");

        RuleFor(c => c.Password)
            .NotEmpty()
                .WithErrorCode("LOG033")
                .WithMessage("A senha é obrigatória");
    }
}
