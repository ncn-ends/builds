using System.Collections;
using Api.Endpoints;
using Database;
using Database.DataAccess;

var builder = WebApplication.CreateBuilder();

foreach (DictionaryEntry entry in Environment.GetEnvironmentVariables())
{
    Console.WriteLine($"{entry.Key} {entry.Value}");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IBuildsDataAccess, BuildsDataAccessAccess>();
var app = builder.Build();

/* Middleware Pipeline */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

MappingRules.SetRules();
app.UseHttpsRedirection();

app.ConfigureHealthEndpoints();
app.ConfigureBuildsEndpoints();

app.Run();