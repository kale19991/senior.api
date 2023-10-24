using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.UserCommands;

public class RegisterUserCommand : ICommand
{
    public RegisterUserCommand(
        string name, 
        string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; }
    public string Email { get; }
}
