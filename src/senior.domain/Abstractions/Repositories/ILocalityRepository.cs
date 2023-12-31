﻿using senior.domain.Entites;
using senior.domain.ValueObjects;

namespace senior.domain.Abstractions.Repositories;

public interface ILocalityRepository
{
    void Create(Locality locality);
    void Update(Locality locality);
    void Delete(Locality locality);

    Task<IEnumerable<Locality>> GetByIbgeAsync(IbgeCode ibgeCode);
    Task<IEnumerable<Locality>> GetByCityNameAsync(CityName city);
    Task<IEnumerable<Locality>> GetByStateAsync(CityState state);
}
