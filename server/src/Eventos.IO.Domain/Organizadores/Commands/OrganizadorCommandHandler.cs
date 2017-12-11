using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Handlers;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Domain.Organizadores.Events;
using Eventos.IO.Domain.Organizadores.Repository;
using MediatR;
using System.Linq;

namespace Eventos.IO.Domain.Organizadores.Commands
{
    public class OrganizadorCommandHandler : CommandHandler,
        INotificationHandler<RegistrarOrganizadorCommand>
    {
        private readonly IMediatorHandler _mediator;
        private readonly IOrganizadorRepository _organizadorRepository;

        public OrganizadorCommandHandler(IUnitOfWork uow,
                                         IMediatorHandler mediator,
                                         INotificationHandler<DomainNotification> notifications,
                                         IOrganizadorRepository organizadorRepository)
            : base(uow, mediator, notifications)
        {
            _mediator = mediator;
            _organizadorRepository = organizadorRepository;
        }

        public void Handle(RegistrarOrganizadorCommand message)
        {
            var organizador = new Organizador(message.Id, message.Nome, message.CPF, message.Email);

            if (!organizador.EhValido())
            {
                NotificarValidacoesErro(organizador.ValidationResult);
                return;
            }

            var organizadorExistente = _organizadorRepository.Buscar(o => o.CPF == organizador.CPF || o.Email == organizador.Email);
            if (organizadorExistente.Any())
                _mediator.PublicarEvento(new DomainNotification(message.MessageType, "CPF ou E-mail já utilizados"));

            _organizadorRepository.Adicionar(organizador);

            if (Commit())
                _mediator.PublicarEvento(new OrganizadorRegistradoEvent(organizador.Id, organizador.Nome, organizador.CPF, organizador.Email));
        }
    }
}
