using Andreani.Arq.AMQStreams.Interface;
using Andreani.Arq.Cqrs.Extension;
using dotnet_quehuar_worker.Application.Common.Interfaces;
using dotnet_quehuar_worker.Infrastructure.EventHandler;
using dotnet_quehuar_worker.Infrastructure.Persistence;
using dotnet_quehuar_worker.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_quehuar_worker.Infrastructure.Boopstrap;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS(configuration)
        .Configure<ApplicationDbContext>();

        services.AddScoped<ICommandSqlServer, CommandSqlServer>();
        services.AddScoped<IQuerySqlServer, QuerySqlServer>();
        services.AddScoped<ISubscriber, Subscriber>();

        return services;
    }
}