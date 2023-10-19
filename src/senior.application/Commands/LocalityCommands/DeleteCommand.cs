using senior.domain.Abstractions.Messaging;

namespace senior.application.Commands.LocalityCommands;

public class DeleteCommand : ICommand
{
    public DeleteCommand(string ibgeCode)
    {
        IbgeCode = ibgeCode;
    }

    public string IbgeCode { get; private set; }
}
