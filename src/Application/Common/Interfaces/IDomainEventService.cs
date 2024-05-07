using dotnet_quehuar_worker.Domain.Common;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
