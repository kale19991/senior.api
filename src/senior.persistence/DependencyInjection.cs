using Microsoft.Extensions.DependencyInjection;
using senior.domain.Abstractions;
using senior.domain.Abstractions.Repositories;
using senior.persistence.Repositories;

namespace senior.persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection service)
    {
        service.AddScoped<ILocalityRepository, LocalityRepository>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        return service;
    }
}
