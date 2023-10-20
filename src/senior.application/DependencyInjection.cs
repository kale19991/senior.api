using Microsoft.Extensions.DependencyInjection;
using senior.application.Abstractions;
using senior.application.Commands.LocalityCommands;
using senior.application.Services;

namespace senior.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {        
        service.AddTransient<ILocalityService, LocalityService>();
        service.AddTransient<LocalityCommandHandler, LocalityCommandHandler>();       

        return service;
    }
}
