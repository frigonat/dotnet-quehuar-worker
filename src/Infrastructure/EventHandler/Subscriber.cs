using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Andreani.Scheme.Onboarding;
using Andreani.Arq.AMQStreams;
using Andreani.Arq.AMQStreams.Interface;
using Andreani.Arq.AMQStreams.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MediatR;
using Andreani.Arq.AMQStreams.Class;
using Microsoft.Extensions.Hosting;
using System.Threading;
using dotnet_quehuar_worker.Application.UseCase.V1.NumeradorOperation.Commands;
using dotnet_quehuar_worker.Domain.Enums;
using dotnet_quehuar_worker.Application.UseCase.V1.PedidoOperation.Commands.Publish;


namespace dotnet_quehuar_worker.Infrastructure.EventHandler
{
    public class Subscriber : BackgroundService, ISubscriber
    {
        private readonly IConfiguration _configuration;
        private readonly ISender _mediator;
        private readonly ILogger<Subscriber> _logger;

        public Subscriber(ILogger<Subscriber> logger, ISender mediator, IConfiguration configuration)
        {
            _configuration = configuration;
            _mediator = mediator;
            _logger = logger;
        }

        public Task ReceiveCustomEvent(Pedido @event, ConsumerMetadata metaData)
        {
            _logger.LogInformation("Se ha recibido el pedido {id}.", @event.id);

            Console.WriteLine(@event.id);
            Console.WriteLine(@event.numeroDePedido);

            Random r = new Random();
            int numeroDePedido = r.Next();

            Pedido pedidoParaPublicar = new Pedido()
            {
                 cicloDelPedido = @event.cicloDelPedido,
                 cuando =  @event.cuando,
                 codigoDeContratoInterno =  @event.codigoDeContratoInterno,
                 cuentaCorriente = @event.cuentaCorriente,
                 id = @event.id,
                 estadoDelPedido = EstadosDePedidos.Asignado.ToString(),
                 numeroDePedido = numeroDePedido,
            };

            _mediator.Send(new PublishPedidoCommand() { pedidoParaPublicar = pedidoParaPublicar });

            //int id = System.Convert.ToInt32(_configuration["Numerador:id"]);
            //_mediator.Send(new ObtenerNumeroCommand() { centroEmisor = id });

            return null;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            throw new NotImplementedException();
        }
    }


}
