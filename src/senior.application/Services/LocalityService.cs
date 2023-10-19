using senior.application.Abstractions;
using senior.application.Commands;
using senior.application.Commands.LocalityCommands;

namespace senior.application.Services;

public class LocalityService : ILocalityService
{
    private readonly LocalityCommandHandler _commandHandler;    
    
    public LocalityService(LocalityCommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public async Task<CommandResult> Create(
        CreateCommand command, 
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> Delete(
        DeleteCommand command, 
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> Update(
        UpdateCommand command, 
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _commandHandler.Handle(command, cancelationToken);
    }
}
