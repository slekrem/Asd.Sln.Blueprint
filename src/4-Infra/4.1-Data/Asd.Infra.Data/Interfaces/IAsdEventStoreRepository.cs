namespace Asd.Infra.Data.Interfaces
{
    using Asd.Domain.Core.Events;
    using System;
    using System.Collections.Generic;

    public interface IAsdEventStoreRepository : IDisposable
    {
        void Store(AsdStoredEvent storedEvent);

        IEnumerable<AsdStoredEvent> AllByAggregateId(Guid aggregateId);

        IEnumerable<AsdStoredEvent> AllByAsdEntityId(Guid asdEntityId);
    }
}