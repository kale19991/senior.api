using FluentValidation;
using senior.application.Commands.LocalityCommands;

namespace senior.application.Validations.LocalityValidations;

public class CrateCommandValidation : AbstractValidator<CreateLocalityCommand>
{
	public CrateCommandValidation()
	{
        RuleFor(c => c.IbgeCode)
            .NotEmpty()
                .WithErrorCode("ECC001")
                .WithMessage("O código IBGE da cidade é obrigatório")
            .Length(7)
                .WithErrorCode("ECC002")
                .WithMessage("O código IBGE deve ter o tamanho de 7 caracteres");

        RuleFor(c => c.Name)
            .NotEmpty()
                .WithErrorCode("ECC003")
                .WithMessage("O nome da cidade é obrigatório")
            .Length(2, 80)
                .WithErrorCode("ECC004")
                .WithMessage("O nome da cidade deve ter um tamanho entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.State)
            .NotEmpty()
                .WithErrorCode("ECC005")
                .WithMessage("A sigla do estado é obrigatório")
            .Length(2)
                .WithErrorCode("ECC006")
                .WithMessage("A sigla do estado deve ter o tamanho de 2 caracteres");
    }
}
