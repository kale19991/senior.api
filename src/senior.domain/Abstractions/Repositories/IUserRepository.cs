using senior.domain.Entites;
using senior.domain.ValueObjects;

namespace senior.domain.Abstractions.Repositories;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);

    Task<User?> GetUserByEmailAsync(Email email);
}
