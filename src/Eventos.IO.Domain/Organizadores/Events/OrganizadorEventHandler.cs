using MediatR;

namespace Eventos.IO.Domain.Organizadores.Events
{
    public class OrganizadorEventHandler :
        INotificationHandler<OrganizadorRegistradoEvent>
    {
        public void Handle(OrganizadorRegistradoEvent message)
        {
            // TODO: Enviar um email?
        }
    }
}
