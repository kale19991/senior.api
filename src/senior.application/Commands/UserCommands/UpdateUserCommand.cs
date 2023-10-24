using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.UserCommands;

public class UpdateUserCommand : ICommand
{
    public UpdateUserCommand(
        string name, 
        string email,
        string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public string Name { get; }
    public string Email { get; }
    public string Password { get; }
}
