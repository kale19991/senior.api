using Microsoft.Extensions.DependencyInjection;
using senior.application.Abstractions;
using senior.application.Configurations;
using senior.application.Handlers;
using senior.application.Services;

namespace senior.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {        
        service.AddTransient<ILocalityService, LocalityService>();
        service.AddTransient<LocalityCommandHandler, LocalityCommandHandler>();
        service.AddTransient<LocalityQueryHandler, LocalityQueryHandler>();
        service.AddAutoMapper(typeof(AutoMapperConfig));

        return service;
    }
}
