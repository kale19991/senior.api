using senior.domain.Entites;
using senior.domain.ValueObjects;

namespace senior.domain.Abstractions.Repositories;

public interface ILocalityRepository
{
    void Create(Locality locality);
    void Update(Locality locality);
    void Delete(Locality locality);

    Task<Locality?> GetByIbgeAsync(string ibgeCode);
    Task<IEnumerable<Locality>> GetByCityNameAsync(CityName city);
    Task<IEnumerable<Locality>> GetAllByStateAsync(CityState state);
}
