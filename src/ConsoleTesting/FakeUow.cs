using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Interfaces;
using System;

namespace ConsoleTesting
{
    public class FakeUow : IUnitOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
