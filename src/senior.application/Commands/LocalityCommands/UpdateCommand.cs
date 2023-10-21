﻿using senior.domain.Abstractions.Messaging;
using senior.domain.ValueObjects;

namespace senior.application.Commands.LocalityCommands;

public class UpdateCommand : ICommand
{
    public UpdateCommand(
        IbgeCode ibgeCode,
        string name,
        string state)
    {
        IbgeCode = ibgeCode;
        Name = name;
        State = state;        
    }

    public IbgeCode IbgeCode { get; private set; }
    public string Name { get; private set; }
    public string State { get; private set; }
}
