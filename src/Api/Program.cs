using Andreani.Arq.WebHost.Extension;
using Andreani.Arq.Observability.Extensions;
//using Api.Services;
using Microsoft.AspNetCore.Builder;
using dotnet_quehuar_worker.Application.Boopstrap;
using dotnet_quehuar_worker.Infrastructure.Boopstrap;
using Microsoft.Extensions.DependencyInjection;
using dotnet_quehuar_worker.Infrastructure.EventHandler;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniWorkerServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Host.AddObservability();
//builder.Services.AddScoped<IScopedService, ScopedService>();
//builder.Services.AddHostedService<WorkerServices>();
//builder.Services.AddHostedService<Subscriber>();

var app = builder.Build();

app.UseObservability();
app.ConfigureAndreaniWorker();

app.Run();

