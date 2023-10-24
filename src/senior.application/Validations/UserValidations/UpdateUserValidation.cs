using FluentValidation;
using senior.application.Commands.UserCommands;

namespace senior.application.Validations.UserValidations;

public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
{
	public UpdateUserValidation()
	{
        RuleFor(c => c.Name)
            .NotEmpty()
                .WithErrorCode("EUC020")
                .WithMessage("O nome é obrigatório")
            .Length(5, 150)
                .WithErrorCode("EUC021")
                .WithMessage("O nome deve ter o tamanho entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Email)
            .NotEmpty()
                .WithErrorCode("EUC024")
                .WithMessage("O email é obrigatório")
            .EmailAddress()
                .WithErrorCode("EUC025")
                .WithMessage("Email inválido");

        RuleFor(c => c.Password)
            .NotEmpty()
                .WithErrorCode("EUC022")
                .WithMessage("A senha é obrigatória");
    }
}
