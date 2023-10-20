namespace senior.domain.Abstractions.Messaging;

public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command, CancellationToken cancelationToken);
}
