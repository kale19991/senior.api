using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.UserCommands;

public class LoginCommand : ICommand
{
    public LoginCommand(
        string email, 
        string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; }
    public string Password { get; }
}
