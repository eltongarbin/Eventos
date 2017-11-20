using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Infra.Data.Repository
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
