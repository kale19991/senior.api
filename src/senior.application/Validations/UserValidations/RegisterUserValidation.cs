using FluentValidation;
using senior.application.Commands.UserCommands;

namespace senior.application.Validations.UserValidations;

public class RegisterUserValidation : AbstractValidator<RegisterUserCommand>
{
	public RegisterUserValidation()
	{
        RuleFor(c => c.Name)
            .NotEmpty()
                .WithErrorCode("ECC020")
                .WithMessage("O nome é obrigatório")
            .Length(5, 150)
                .WithErrorCode("ECC021")
                .WithMessage("O nome deve ter o tamanho entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Email)
            .NotEmpty()
                .WithErrorCode("ECC024")
                .WithMessage("O email é obrigatório")
            .EmailAddress()
                .WithErrorCode("ECC025")
                .WithMessage("Email inválido");
    }
}
