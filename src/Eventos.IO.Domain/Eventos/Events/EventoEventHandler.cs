using Eventos.IO.Domain.Eventos.Events;
using MediatR;
using System;

namespace Eventos.IO.Domain.Eventos.EventHandlers
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Registrado com sucesso");
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Atualizado com sucesso");
        }

        public void Handle(EventoExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Evento Excluido com sucesso");
        }

        public void Handle(EnderecoEventoAdicionadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Endereco do evento adicionado com sucesso");
        }

        public void Handle(EnderecoEventoAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Endereco do evento atualizado com sucesso");
        }
    }
}
