using MediatR;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        INotificationHandler<EventoRegistradoEvent>,
        INotificationHandler<EventoAtualizadoEvent>,
        INotificationHandler<EventoExcluidoEvent>,
        INotificationHandler<EnderecoEventoAdicionadoEvent>,
        INotificationHandler<EnderecoEventoAtualizadoEvent>
    {
        public void Handle(EventoRegistradoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(EventoExcluidoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(EnderecoEventoAdicionadoEvent message)
        {
            // TODO: Disparar alguma ação
        }

        public void Handle(EnderecoEventoAtualizadoEvent message)
        {
            // TODO: Disparar alguma ação
        }
    }
}