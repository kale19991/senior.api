using senior.domain.Abstractions;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;

namespace senior.application.Commands.LocalityCommands;

public class LocalityCommandHandler :
    IHandler<CreateCommand>,
    IHandler<DeleteCommand>,
    IHandler<UpdateCommand>
{
    private readonly ILocalityRepository _localityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LocalityCommandHandler(
        ILocalityRepository localityRepository,
        IUnitOfWork unitOfWork)
    {
        _localityRepository = localityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICommandResult> Handle(
        CreateCommand command,
        CancellationToken cancelationToken)
    {
        //fazer a validação(se tiver válido)
        var locality = new Locality(
            command.IbgeCode,
            command.Name,
            command.State);

        _localityRepository.Create(locality);

        await _unitOfWork.CommitAsync(cancelationToken);
        //se deu tudo certo para salvar
        return new CommandResult(true, "Localização criada com sucesso", locality);
    }

    public async Task<ICommandResult> Handle(
        DeleteCommand command,
        CancellationToken cancelationToken)
    {
        //fazer a validação(se tiver válido)
        var locality = await _localityRepository.GetByIbgeAsync(command.IbgeCode);
        if (locality == null)
            return new CommandResult(false, $"A localização com Ibge: {command.IbgeCode} não foi encontrada", command);

        _localityRepository.Delete(locality);

        await _unitOfWork.CommitAsync(cancelationToken);
        //se deu tudo certo para salvar
        return new CommandResult(true, "Localização excluída com sucesso", locality);
    }

    public async Task<ICommandResult> Handle(
        UpdateCommand command,
        CancellationToken cancelationToken)
    {
        //validação do command

        var locality = await _localityRepository.GetByIbgeAsync(command.IbgeCode);

        if (locality == null)
            return new CommandResult(false, "A localização a atualizar não foi encontrada no cadastro", command);

        locality.AlterCity(command.Name);
        locality.AlterState(command.State);

        _localityRepository.Update(locality);

        await _unitOfWork.CommitAsync(cancelationToken);

        //se tudo ok
        return new CommandResult(true, "Alteração realizada", command);
    }
}
