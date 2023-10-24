using senior.application.Abstractions.Messages;
using senior.application.Commands;
using senior.application.Commands.LocalityCommands;
using senior.application.Validations.LocalityValidations;
using senior.application.ViewModels.Locality;
using senior.domain.Abstractions;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;

namespace senior.application.Handlers;

public class LocalityCommandHandler :
    BaseHandler,
    ICommandHandler<CreateLocalityCommand>,
    ICommandHandler<DeleteLocalityCommand>,
    ICommandHandler<UpdateLocalityCommand>,
    ICommandHandler<UploadCsvCommand>
{
    private readonly ILocalityRepository _localityRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidationMessage _validationMessage;

    public LocalityCommandHandler(
        ILocalityRepository localityRepository,
        IUnitOfWork unitOfWork,
        IValidationMessage validationMessage) : base(validationMessage)
    {
        _localityRepository = localityRepository;
        _unitOfWork = unitOfWork;
        _validationMessage = validationMessage;
    }

    public async Task<ICommandResult> Handle(
        CreateLocalityCommand command,
        CancellationToken cancelationToken)
    {        
        if (!ExecuteValidation(new CrateCommandValidation(), command))
        {
            return new CommandResult(
                false, 
                "Errors de validações", 
                _validationMessage.GetErrorMessages());
        }

        var locality = new Locality(
            command.IbgeCode,
            command.Name,
            command.State);

        _localityRepository.Create(locality);

        await _unitOfWork.CommitAsync(cancelationToken);

        return new CommandResult(
            true, 
            "IBGE criado com sucesso", 
            command);
    }

    public async Task<ICommandResult> Handle(
        DeleteLocalityCommand command,
        CancellationToken cancelationToken)
    {
        if (!ExecuteValidation(new DeleteCommandValidation(), command))
        {
            return new CommandResult(
                false,
                "Erros de validações",
                _validationMessage.GetErrorMessages());
        }

        var locality = (await _localityRepository.GetByIbgeAsync(command.IbgeCode)).FirstOrDefault();
        
        if (locality == null)
            return new CommandResult(
                false, 
                $"Ibge {command.IbgeCode} não encontrado",
                command);

        _localityRepository.Delete(locality);

        await _unitOfWork.CommitAsync(cancelationToken);

        return new CommandResult(
            true,
            "IBGE excluído com sucesso", 
            new ListIbgeViewModel
            {
                IbgeCode = locality.Id.Value,
                Name = locality.City.Value,
                State = locality.State.Value
            });
    }

    public async Task<ICommandResult> Handle(
        UpdateLocalityCommand command,
        CancellationToken cancelationToken)
    {
        if (!ExecuteValidation(new UpdateCommandValidation(), command))
        {
            return new CommandResult(
                false,
                "Erros de validações",
                _validationMessage.GetErrorMessages());
        }

        var locality = (await _localityRepository.GetByIbgeAsync(command.IbgeCode)).FirstOrDefault();

        if (locality == null)
            return new CommandResult(
                false,
                $"Ibge {command.IbgeCode} não encontrado",
                command);

        locality.AlterCity(command.Name);
        locality.AlterState(command.State);

        _localityRepository.Update(locality);

        await _unitOfWork.CommitAsync(cancelationToken);

        return new CommandResult(
            true,
            "IBGE alterado com sucesso",
            new ListIbgeViewModel
            {
                IbgeCode = locality.Id.Value,
                Name = locality.City.Value,
                State = locality.State.Value
            }); 
    }

    public async Task<ICommandResult> Handle(
        UploadCsvCommand command, 
        CancellationToken cancelationToken)
    {
        var file = command.UploadFile;
        if (file == null || file.Length == 0)
        {
            return new CommandResult(
                false,
                $"Problemas no upload do arquivo",
                new { Upload = $"{command.UploadFile?.FileName}" });
        }

        if (!Path.GetExtension(file.FileName.ToLower()).Contains(".csv"))
        {
            return new CommandResult(
                false,
                $"Problemas no upload do arquivo",
                new { Upload = $"A extensão do arquivo precisa ser .csv" });
        }

        return new CommandResult(
                true,
                $"Problemas no upload do arquivo",
                new { Upload = $"{command.UploadFile?.FileName}" });
    }
}
