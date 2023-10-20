namespace senior.domain.Abstractions;

public interface IUnitOfWork
{    
    Task CommitAsync(CancellationToken cancelationToken);
    void Rollback();
}
