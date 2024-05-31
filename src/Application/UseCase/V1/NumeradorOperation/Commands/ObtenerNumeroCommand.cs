using Andreani.Arq.Pipeline.Clases;
using dotnet_quehuar_worker.Application.Common.Interfaces;
using dotnet_quehuar_worker.Domain.Common;
using dotnet_quehuar_worker.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Application.UseCase.V1.NumeradorOperation.Commands
{

    public class ObtenerNumeroCommand : IRequest<Response<int>>
    {
        public required int centroEmisor { get; set; }
    }

    public class ObtenerNumeroHandler(ICommandSqlServer repository, IQuerySqlServer query, ILogger<ObtenerNumeroHandler> logger) : IRequestHandler<ObtenerNumeroCommand, Response<int>>
    {
        public async Task<Response<int>> Handle(ObtenerNumeroCommand request, CancellationToken cancellationToken)
        {
            Numerador numerador = await query.GetByCentroEmisorAsync(request.centroEmisor);
            var response = new Response<int>();
            if (numerador is null)
            {
                response.AddNotification("#3123", "Numerador", $"No se ha encontrado un registro con el id {request.centroEmisor} en el numerador.-");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                return response;
            }

            numerador.ultimoNumero++;
            numerador.fechaHoraUltimoNumero = DateTime.Now;

            repository.Update(numerador);
            await repository.SaveChangeAsync();

            logger.LogInformation("Se ha generado el número {n} a las {h}.-", numerador.ultimoNumero, numerador.fechaHoraUltimoNumero);

            return response;
        }

    }
}
