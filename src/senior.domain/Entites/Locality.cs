using senior.domain.ValueObjects;

namespace senior.domain.Entites;

public class Locality
{
#pragma warning disable CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
    protected Locality() { }
#pragma warning restore CS8618 // O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.

    public Locality(
        string ibgeCodigo,
        CityName cityName,
        CityState cityState)
    {
        Id = ibgeCodigo;
        City = cityName;
        State = cityState;
    }
    
    public string Id { get; private set; }
    
    public CityName City { get; private set; }

    public CityState State { get; private set; }

    public void AlterCity(CityName city)
        => City = city;

    public void AlterState(CityState state)
        => State = state;
}
