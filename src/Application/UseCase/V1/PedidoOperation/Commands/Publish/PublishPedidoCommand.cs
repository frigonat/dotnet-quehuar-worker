using Andreani.Arq.AMQStreams.Interface;
using Andreani.Arq.Pipeline.Clases;
using dotnet_quehuar_worker.Application.Common.Interfaces;
using dotnet_quehuar_worker.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Application.UseCase.V1.PedidoOperation.Commands.Publish
{
    public class PublishPedidoCommand : IRequest<Response<PublishPedidoResponse>>
    {
        public required Andreani.Scheme.Onboarding.Pedido pedidoParaPublicar { get; set; }
    }

    public class PublishPedidoCommandHandler(ICommandSqlServer repository, ILogger<PublishPedidoCommandHandler> logger, Andreani.Arq.AMQStreams.Interface.IPublisher publisher) : IRequestHandler<PublishPedidoCommand, Response<PublishPedidoResponse>>
    {
        public async Task<Response<PublishPedidoResponse>> Handle(PublishPedidoCommand request, CancellationToken cancellationToken)
        {
            Andreani.Scheme.Onboarding.Pedido p = new Andreani.Scheme.Onboarding.Pedido()
            {
                id = request.pedidoParaPublicar.id.ToString(),
                codigoDeContratoInterno = request.pedidoParaPublicar.codigoDeContratoInterno,
                cuando = request.pedidoParaPublicar.cuando.ToString(),
                estadoDelPedido = request.pedidoParaPublicar.estadoDelPedido.ToString(),
                numeroDePedido = request.pedidoParaPublicar.numeroDePedido,
                cuentaCorriente = request.pedidoParaPublicar.cuentaCorriente,
                cicloDelPedido = request.pedidoParaPublicar.cicloDelPedido
            };

            try
            {
                await publisher.To(p, "OnboardingBackendFernando-Andreani.Scheme.Onboarding.PedidoAsignado");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Response<PublishPedidoResponse>
            {
                Content = new PublishPedidoResponse
                {
                    pedidoId = new Guid(request.pedidoParaPublicar.id),
                    message = $"Pedido {request.pedidoParaPublicar.numeroDePedido} publicado satisfactoriamente.-"
                },
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}
