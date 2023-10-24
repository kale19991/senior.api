using Microsoft.Extensions.DependencyInjection;
using senior.application.Abstractions;
using senior.application.Abstractions.Messages;
using senior.application.Configurations;
using senior.application.Handlers;
using senior.application.Services;
using senior.application.Validations;

namespace senior.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {        
        service.AddTransient<ILocalityService, LocalityService>();
        service.AddTransient<IUserService, UserService>();

        service.AddTransient<LocalityCommandHandler, LocalityCommandHandler>();
        service.AddTransient<UserCommandHandler, UserCommandHandler>();

        service.AddTransient<LocalityQueryHandler, LocalityQueryHandler>();

        service.AddTransient<TokenService>();

        service.AddScoped<IValidationMessage, ValidationMessage>();
        
        service.AddAutoMapper(typeof(AutoMapperConfig));

        return service;
    }
}
