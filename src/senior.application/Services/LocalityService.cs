using senior.application.Abstractions;
using senior.application.Commands;
using senior.application.Commands.LocalityCommands;
using senior.application.Handlers;
using senior.application.Queries.LocalityQueries;
using senior.application.ViewModels.Locality;

namespace senior.application.Services;

public class LocalityService : ILocalityService
{
    private readonly LocalityCommandHandler _commandHandler;
    private readonly LocalityQueryHandler _queryHandler;

    public LocalityService(
        LocalityCommandHandler commandHandler, 
        LocalityQueryHandler queryHandler)
    {
        _commandHandler = commandHandler;
        _queryHandler = queryHandler;
    }

    public async Task<CommandResult> Create(
        CreateLocalityCommand command, 
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> Delete(
        DeleteLocalityCommand command,
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }
    
    public async Task<CommandResult> Update(
        UpdateLocalityCommand command,
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> UploadCsvFile(UploadCsvCommand command, CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(UploadCsvCommand, cancelationToken);
    }

    public async Task<ListIbgeViewModel?> GetIbgeByCode(
        GetByIbgeCodeQuery query, 
        CancellationToken cancelationToken)
    {
        return (await _queryHandler.Handle(query, cancelationToken)).FirstOrDefault() as ListIbgeViewModel;
    }

    public async Task<IEnumerable<ListIbgeViewModel>?> GetIbgeByCityName(
        GetByCityNameQuery query, 
        CancellationToken cancelationToken)
    {
        return await _queryHandler.Handle(query, cancelationToken) as IEnumerable<ListIbgeViewModel>;
    }

    public async Task<IEnumerable<ListIbgeViewModel>?> GetIbgeByCityState(
        GetByCityStateQuery query, 
        CancellationToken cancelationToken)
    {
        return await _queryHandler.Handle(query, cancelationToken) as IEnumerable<ListIbgeViewModel>;
    }
}
