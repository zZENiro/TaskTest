using System.Reflection;
using Application;
using Persistance.Repository;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets(Assembly.GetAssembly(typeof(Program))!);

builder.Services
    .AddProblemDetails()
    .AddExceptionHandler<GlobalExceptionHandler>()
    .RegisterInfrastructureServices(builder.Configuration)
    .AddApplication()
    .AddValidators()
    .RegisterMappingConfig()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

app
    .UseExceptionHandler()
    .UseSwagger()
    .UseSwaggerUI();

app.MapControllers();

app.Run();