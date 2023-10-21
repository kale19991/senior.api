using Microsoft.AspNetCore.Mvc;
using senior.application;
using senior.application.Abstractions;
using senior.application.Commands.LocalityCommands;
using senior.application.Queries.LocalityQueries;
using senior.application.ViewModels.Locality;
using senior.persistence;
using senior.persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SeniorDbContext>();
builder.Services
    .AddPersistence()
    .AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

#region LOCALITY

app.MapPost("api/v1/ibge", async (
    [FromBody]CreateIbgeViewModel model,
    [FromServices]ILocalityService localityService) =>
{
    CreateCommand command = new(model.IbgeCode, model.Name, model.State);
    var result = await localityService
        .Create(command, new CancellationToken());

    return result;
});

app.MapDelete("api/v1/ibge/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromServices] ILocalityService localityService) =>
{
    DeleteCommand command = new(ibgeCode);
    var result = await localityService
        .Delete(command, new CancellationToken());

    return result;
});

app.MapPut("api/v1/ibge/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromBody] EditIbgeViewModel model,
    [FromServices] ILocalityService localityService) =>
{
    UpdateCommand command = new(ibgeCode, model.Name, model.State);
    var result = await localityService
        .Update(command, new CancellationToken());

    return result;
});

app.MapGet("api/v1/ibge/code/{ibgeCode}", async (
    [FromRoute] string ibgeCode,
    [FromServices] ILocalityService localityService) =>
{
    GetByIbgeCodeQuery query = new(ibgeCode);
    var result = await localityService
        .GetIbgeByCode(query, new CancellationToken());
    
    return result;
});

app.MapGet("api/v1/ibge/name/{cityName}", async (
    [FromRoute] string cityName,
    [FromServices] ILocalityService localityService) =>
{
    GetByCityNameQuery query = new(cityName);
    var result = await localityService
        .GetIbgeByCityName(query, new CancellationToken());
    
    return result;
});

app.MapGet("api/v1/ibge/name/{cityState}", async (
    [FromRoute] string cityState,
    [FromServices] ILocalityService localityService) =>
{
    GetByCityStateQuery query = new(cityState);
    var result = await localityService
        .GetIbgeByCityState(query, new CancellationToken());

    return result;
});


#endregion

app.Run();
