using Microsoft.AspNetCore.Mvc;
using senior.application;
using senior.application.Abstractions;
using senior.application.Commands.LocalityCommands;
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


app.MapPost("api/v1/localidade", async (
    [FromBody]CreateCommand model,
    [FromServices]ILocalityService localityService) =>
{
    var result = await localityService.Create(model, new CancellationToken());
    return result;
});

app.Run();
