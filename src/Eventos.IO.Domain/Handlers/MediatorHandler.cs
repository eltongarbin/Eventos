using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task EnviarComando<T>(T comando) where T : Command
        {
            return Publicar(comando);
        }

        public Task PublicarEvento<T>(T evento) where T : Event
        {
            return Publicar(evento);
        }

        private Task Publicar<T>(T mensagem) where T : Message
        {
            return _mediator.Publish(mensagem);
        }
    }
}
