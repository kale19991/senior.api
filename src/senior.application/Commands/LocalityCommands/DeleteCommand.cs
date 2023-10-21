using senior.domain.Abstractions.Messaging;
using senior.domain.ValueObjects;

namespace senior.application.Commands.LocalityCommands;

public class DeleteCommand : ICommand
{
    public DeleteCommand(IbgeCode ibgeCode)
    {
        IbgeCode = ibgeCode;
    }

    public IbgeCode IbgeCode { get; private set; }
}
