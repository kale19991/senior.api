using Microsoft.EntityFrameworkCore;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;
using senior.domain.Queries;
using senior.domain.ValueObjects;
using senior.persistence.Context;

namespace senior.persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly SeniorDbContext _context;

    public UserRepository(SeniorDbContext context)
        => _context = context;

    public void Create(User user)
        => _context.Users.Add(user);

    public void Update(User user)
        => _context.Users.Update(user);    

    public Task<User?> GetUserByEmailAsync(Email email)
    {
        var user = _context.Users
            .Where(UserQueries.GetUserByEmail(email))
            .FirstOrDefaultAsync();

        return user;
    }    
}
