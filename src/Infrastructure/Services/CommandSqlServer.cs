using Andreani.Arq.Cqrs.Command;
using Andreani.Arq.Cqrs.Interfaces;
using dotnet_quehuar_worker.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_quehuar_worker.Infrastructure.Services
{
    public class CommandSqlServer([FromKeyedServices("default")] ITransactionalConfiguration config) : TransactionalRepository(config), ICommandSqlServer
    {
    }
}
