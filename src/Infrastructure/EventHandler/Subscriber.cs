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


namespace dotnet_quehuar_worker.Infrastructure.EventHandler
{
    public class Subscriber : ISubscriber
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

        public Task ReceiveCustomEvent(Pedido @event)
        {
            _logger.LogInformation("Se ha recibido el pedido {}.", @event.id);
            @event.numeroDePedido = 36;

            return null;
        }
    }


}
