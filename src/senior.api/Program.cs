using senior.persistence;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services
    .AddPersistence(builder.Configuration);

app.MapGet("/", () => "Hello World!");

app.Run();
