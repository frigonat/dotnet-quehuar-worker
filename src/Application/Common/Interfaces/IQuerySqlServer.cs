using Andreani.Arq.Core.Interface;
using dotnet_quehuar_worker.Domain.Entities;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Application.Common.Interfaces
{
    public interface IQuerySqlServer: IReadOnlyQuery
    {
        public Task<Person> GetPersonByNameAsync(string name);
    }
}
