﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_quehuar_worker.Application.UseCase.V1.PedidoOperation.Commands.Publish
{
    public record struct PublishPedidoResponse(Guid pedidoId, string message) { }
}
