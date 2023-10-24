using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using senior.api.Configurations;
using senior.application;
using senior.application.Abstractions;
using senior.application.Commands.LocalityCommands;
using senior.application.Commands.UserCommands;
using senior.application.Extensions;
using senior.application.Queries.LocalityQueries;
using senior.application.ViewModels.Account;
using senior.application.ViewModels.Locality;
using senior.persistence;
using senior.persistence.Context;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SeniorDbContext>();

builder.Services
    .AddPersistence()
    .AddApplication();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SettingsExtension.JwtKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMeSwagger();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();


#region LOCALITY

app.MapPost("api/v1/ibge", async (
    [FromBody]CreateIbgeViewModel model,
    [FromServices]ILocalityService localityService) =>
{
    CreateLocalityCommand command = new(
        model.IbgeCode, 
        model.Name, 
        model.State);

    var result = await localityService.Create(
        command, 
        new CancellationToken());

    return result;
}).RequireAuthorization();

app.MapDelete("api/v1/ibge/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromServices] ILocalityService localityService) =>
{
    DeleteLocalityCommand command = new(ibgeCode);
    
    var result = await localityService.Delete(
        command, 
        new CancellationToken());

    return result;
}).RequireAuthorization();

app.MapPut("api/v1/ibge/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromBody] EditIbgeViewModel model,
    [FromServices] ILocalityService localityService) =>
{
    UpdateLocalityCommand command = new(ibgeCode, model.Name, model.State);
    
    var result = await localityService.Update(
        command,
        new CancellationToken());

    return result;
}).RequireAuthorization();

app.MapGet("api/v1/ibge/code/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromServices] ILocalityService localityService) =>
{
    GetByIbgeCodeQuery query = new(ibgeCode);
    
    var result = await localityService.GetIbgeByCode(
        query,
        new CancellationToken());
    
    return result;
}).RequireAuthorization();

app.MapGet("api/v1/ibge/name/{cityName}", async (
    [FromRoute] string cityName,
    [FromServices] ILocalityService localityService) =>
{
    GetByCityNameQuery query = new(cityName);
    var result = await localityService.GetIbgeByCityName(
        query, 
        new CancellationToken());
    
    return result;
}).RequireAuthorization();

app.MapGet("api/v1/ibge/state/{cityState}", async (
    [FromRoute] string cityState,
    [FromServices] ILocalityService localityService) =>
{
    GetByCityStateQuery query = new(cityState);
    var result = await localityService.GetIbgeByCityState(
        query, 
        new CancellationToken());

    return result;
}).RequireAuthorization();

app.MapPost("api/v1/ibge/uploadcsv", async (
    IFormFile arquivo,
    [FromServices] ILocalityService localityService) =>
{
    if (arquivo == null || arquivo.Length == 0) return;

    var extension = Path.GetExtension(arquivo.FileName);
}).RequireAuthorization();


#endregion

#region ACCOUNTS

app.MapPost("api/v1/account", async (
    [FromBody] RegisterViewModel account,
    [FromServices] IUserService userService) =>
{
    RegisterUserCommand command = new(
        account.Name,
        account.Email);

    var result = await userService.Register(
        command, 
        new CancellationToken());
    
    return result;
});

app.MapPut("api/v1/account", async (
    [FromBody] AlterUserNameViewModel account,
    [FromServices] IUserService userService) =>
{
    UpdateUserCommand command = new(
        account.NewName,
        account.Email,
        account.Password);

    var result = await userService.Update(
        command,
        new CancellationToken());

    return result;
}).RequireAuthorization();

app.MapPost("api/v1/account/login", async (
    [FromBody] LoginViewModel login,
    [FromServices] IUserService userService) =>
{
    LoginCommand command = new(
        login.Email, 
        login.Password);

    var result = await userService.Login(
        command, 
        new CancellationToken());

    return result;
});

#endregion

app.Run();
