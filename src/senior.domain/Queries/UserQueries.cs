using senior.domain.Entites;
using senior.domain.ValueObjects;
using System.Linq.Expressions;

namespace senior.domain.Queries;

public abstract class UserQueries
{
    public static Expression<Func<User, bool>> GetUserByEmail(Email email)
    {
        return x => x.Email == email;
    }    
}
