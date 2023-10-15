using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using senior.persistence.Context;

namespace senior.persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        //var connectionString = configuration.GetConnectionString("DefaultConnection");

        //service.AddDbContext<SeniorDbContext>(opt => 
        //    opt.UseSqlServer(connectionString));

        return service;
    }
}
