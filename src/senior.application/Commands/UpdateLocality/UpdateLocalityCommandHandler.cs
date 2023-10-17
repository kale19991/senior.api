using senior.domain.Abstractions;
using senior.domain.Abstractions.Messaging;
using senior.domain.Abstractions.Repositories;

namespace senior.application.Commands.UpdateLocality
{
    public class UpdateLocalityCommandHandler : IHandler<UpdateLocalityCommand>
    {
        private readonly ILocalityRepository _localityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLocalityCommandHandler(
            ILocalityRepository localityRepository, 
            IUnitOfWork unitOfWork)
        {
            _localityRepository = localityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult> Handle(UpdateLocalityCommand command, CancellationToken cancelationToken)
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
}
