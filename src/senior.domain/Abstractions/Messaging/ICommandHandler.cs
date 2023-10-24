namespace senior.domain.Abstractions.Messaging;

public interface ICommandHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command, CancellationToken cancelationToken);
}
