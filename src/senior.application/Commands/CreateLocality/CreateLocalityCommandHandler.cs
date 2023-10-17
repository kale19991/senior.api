using senior.domain.Abstractions;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;

namespace senior.application.Commands.CreateLocality;

public class CrateLocalityCommandHandler : IHandler<CreateLocalityCommand>
{
    private readonly ILocalityRepository _localityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrateLocalityCommandHandler(
        ILocalityRepository localityRepository, 
        IUnitOfWork unitOfWork)
    {
        _localityRepository = localityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ICommandResult> Handle(
        CreateLocalityCommand command, 
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
}
