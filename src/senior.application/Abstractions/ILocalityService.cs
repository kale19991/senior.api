using senior.application.Commands;
using senior.application.Commands.LocalityCommands;
using senior.application.Queries.LocalityQueries;
using senior.application.ViewModels.Locality;

namespace senior.application.Abstractions;

public interface ILocalityService
{
    Task<CommandResult> Create(CreateLocalityCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Delete(DeleteLocalityCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Update(UpdateLocalityCommand command, CancellationToken cancelationToken);
    Task<CommandResult> UploadCsvFile(UploadCsvCommand command, CancellationToken cancelationToken);

    Task<ListIbgeViewModel?> GetIbgeByCode(GetByIbgeCodeQuery query, CancellationToken cancelationToken);
    Task<IEnumerable<ListIbgeViewModel>?> GetIbgeByCityName(GetByCityNameQuery query, CancellationToken cancelationToken);
    Task<IEnumerable<ListIbgeViewModel>?> GetIbgeByCityState(GetByCityStateQuery query, CancellationToken cancelationToken);
}
