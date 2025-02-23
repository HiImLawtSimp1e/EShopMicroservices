global using Carter;
global using Mapster;
global using MediatR;
global using Marten;
global using FluentValidation;
global using BuidingBlocks.CQRS;
global using BuidingBlocks.Behaviors;
global using BuidingBlocks.Exceptions;
global using BuidingBlocks.Exceptions.Handler;  
global using EShop.Service.CatalogAPI.Domain.Entities;
global using EShop.Service.CatalogAPI.Exceptions;
using EShop.Service.CatalogAPI.Initialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);


// Add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); //CQRS Validation Middleware
    config.AddOpenBehavior(typeof(LoggingBehavior<,>)); //CQRS Logging Middleware
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

//Seeding data in Development environment
if (builder.Environment.IsDevelopment()) 
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}
    
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

//Configure the HTTPs request pineline

app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();