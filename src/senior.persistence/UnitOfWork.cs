using senior.domain.Abstractions;
using senior.persistence.Context;

namespace senior.persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SeniorDbContext _context;

    public UnitOfWork(SeniorDbContext context)
        => _context = context;

    public async Task CommitAsync(CancellationToken cancelationToken)
        => await _context.SaveChangesAsync(cancelationToken);

    public void Rollback() { }
}
