using senior.application.Commands;
using senior.application.Commands.UserCommands;

namespace senior.application.Abstractions;

public interface IUserService
{
    Task<CommandResult> Register(RegisterUserCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Update(UpdateUserCommand command, CancellationToken cancelationToken);
    Task<CommandResult> Login(LoginCommand command, CancellationToken cancelationToken);
}
