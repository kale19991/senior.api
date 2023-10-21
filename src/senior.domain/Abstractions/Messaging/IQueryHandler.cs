namespace senior.domain.Abstractions.Messaging;

public interface IQueryHandler<T> where T : IQuery
{
    Task<IEnumerable<IQueryResult>> Handle(T query, CancellationToken cancelationToken);
}
