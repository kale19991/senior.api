using senior.application.Abstractions;
using senior.application.Commands;
using senior.application.Commands.UserCommands;
using senior.application.Handlers;
using senior.domain.Abstractions.Repositories;

namespace senior.application.Services;

public class UserService : IUserService
{
    private readonly UserCommandHandler _userCommandHandler;

    public UserService(UserCommandHandler userCommandHandler)
        => _userCommandHandler = userCommandHandler;

    public async Task<CommandResult> Login(
        LoginCommand command, 
        CancellationToken cancelationToken)
    {
        return(CommandResult)await _userCommandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> Register(
        RegisterUserCommand command, 
        CancellationToken cancelationToken)
    {
        return(CommandResult)await _userCommandHandler.Handle(command, cancelationToken);
    }

    public async Task<CommandResult> Update(
        UpdateUserCommand command, 
        CancellationToken cancelationToken)
    {
        return (CommandResult)await _userCommandHandler.Handle(command, cancelationToken);
    } 
}
