using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task EnviarComando<T>(T theCommand) where T : Command;
        Task PublicarEvento<T>(T theEvent) where T : Event;
    }
}
