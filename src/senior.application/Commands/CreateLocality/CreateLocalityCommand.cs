using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.CreateLocality;

public class CreateLocalityCommand : ICommand
{
    public CreateLocalityCommand(
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
