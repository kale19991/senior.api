using FluentValidation;
using senior.application.Commands.LocalityCommands;

namespace senior.application.Validations.LocalityValidations;

public class UpdateCommandValidation : AbstractValidator<UpdateLocalityCommand>
{
	public UpdateCommandValidation()
	{
        RuleFor(c => c.Name)
            .NotEmpty()
                .WithErrorCode("EUC003")
                .WithMessage("O nome da cidade é obrigatório")
            .Length(2, 80)
                .WithErrorCode("EUC004")
                .WithMessage("O nome da cidade deve ter um tamanho entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.State)
            .NotEmpty()
                .WithErrorCode("EUC005")
                .WithMessage("A sigla do estado é obrigatório")
            .Length(2)
                .WithErrorCode("EUC006")
                .WithMessage("A sigla do estado deve ter o tamanho de 2 caracteres");
    }
}
