using senior.domain.ValueObjects;

namespace senior.domain.Entites;

public class User
{
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    protected User() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    public User(
        string name,
        Email email)
    {
        Name = name;
        Email = email;
        PasswordHash = string.Empty;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public string PasswordHash { get; private set;}

    public void AlterName(string name)
        => Name = name;

    public void AlterPassword(string passwordHash) 
        => PasswordHash = passwordHash;
}
