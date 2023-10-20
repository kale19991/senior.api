using senior.application.Commands;
using senior.application.Commands.LocalityCommands;

namespace senior.application.Abstractions;

public interface ILocalityService
{
    Task<CommandResult> Create(CreateCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Delete(DeleteCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Update(UpdateCommand command, CancellationToken cancelationToken);
}
