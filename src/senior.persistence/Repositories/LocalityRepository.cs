﻿using Microsoft.EntityFrameworkCore;
using senior.domain.Abstractions.Repositories;
using senior.domain.Entites;
using senior.domain.Queries;
using senior.domain.ValueObjects;
using senior.persistence.Context;

namespace senior.persistence.Repositories;

public sealed class LocalityRepository : ILocalityRepository
{
    private readonly SeniorDbContext _context;

    public LocalityRepository(SeniorDbContext context)
        => _context = context;

    public void Create(Locality locality)
        => _context.Localitys.Add(locality);

    public void Delete(Locality locality)
        => _context.Localitys.Remove(locality);

    public void Update(Locality locality)
        => _context.Localitys.Update(locality);

    public async Task<IEnumerable<Locality>> GetByIbgeAsync(IbgeCode ibgeCode)
    {
        return await _context.Localitys
            .Where(LocalityQueries.GetLocalityByIbgeCode(ibgeCode))
            .ToListAsync();
    }

    public async Task<IEnumerable<Locality>> GetByStateAsync(CityState state)
    {
        return await _context.Localitys
            .Where(LocalityQueries.GetLocalityByState(state))
            .ToListAsync();
    }

    public async Task<IEnumerable<Locality>> GetByCityNameAsync(CityName city)
    {
        return await _context.Localitys
            .Where(LocalityQueries.GetLocalityByCityName(city))
            .ToListAsync();
    }    
}
