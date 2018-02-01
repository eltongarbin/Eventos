﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Organizadores.Events
{
    public class OrganizadorEventHandler :
        INotificationHandler<OrganizadorRegistradoEvent>
    {
        public Task Handle(OrganizadorRegistradoEvent message, CancellationToken cancellationToken)
        {
            // TODO: Enviar um email?
            return Task.CompletedTask;
        }
    }
}