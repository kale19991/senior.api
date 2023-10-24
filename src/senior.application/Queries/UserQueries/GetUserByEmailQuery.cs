namespace senior.application.Queries.UserQueries;

public class GetUserByEmailQuery
{
    public GetUserByEmailQuery(string email)
        => Email = email;

    public string Email { get; }
}
