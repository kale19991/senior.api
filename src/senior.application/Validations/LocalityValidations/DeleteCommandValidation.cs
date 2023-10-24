using FluentValidation;
using senior.application.Commands.LocalityCommands;

namespace senior.application.Validations.LocalityValidations;

public class DeleteCommandValidation : AbstractValidator<DeleteLocalityCommand>
{
	public DeleteCommandValidation()
	{
        RuleFor(c => c.IbgeCode.Value)
            .NotEmpty()
                .WithErrorCode("EDC001")
                .WithMessage("O código IBGE da cidade é obrigatório")
            .Length(7)
                .WithErrorCode("EDC002")
                .WithMessage("O código IBGE deve ter o tamanho de 7 caracteres");
    }
}
