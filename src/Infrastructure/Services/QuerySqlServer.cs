using Andreani.Arq.Cqrs.Interfaces;
using Andreani.Arq.Cqrs.Queries;
using dotnet_quehuar_worker.Application.Common.Interfaces;
using dotnet_quehuar_worker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using dotnet_quehuar_worker.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Infrastructure.Services
{
    public class QuerySqlServer : ReadOnlyQuery, IQuerySqlServer
    {
        private readonly ApplicationDbContext _context;
        public QuerySqlServer([FromKeyedServices("default")] IReadOnlyQueryConfiguration config,
            [FromKeyedServices("default")] ApplicationDbContext context) : base(config)
        {
          _context = context;
        }

        public async Task<Person> GetPersonByNameAsync(string name)
        {
          return await _context.Person.FirstAsync(x => x.Nombre == name);
        }

        public async Task<Numerador> GetByCentroEmisorAsync(int centroEmisorBuscador)
        {
            return await _context.Numerador.FirstAsync(x => x.centroEmisor == centroEmisorBuscador);
        }

    }
}
