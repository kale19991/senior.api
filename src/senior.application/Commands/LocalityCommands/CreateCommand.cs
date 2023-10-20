using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.LocalityCommands;

public class CreateCommand : ICommand
{
    public CreateCommand(
        string ibgeCode,
        string name,
        string state)
    {
        IbgeCode = ibgeCode;
        Name = name;
        State = state;
    }

    public string IbgeCode { get; private set; }
    public string Name { get; private set; }
    public string State { get; private set; }
}
