namespace Asd.Infra.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using Asd.Domain.Core.Events;
    using Asd.Infra.Data.Interfaces;
    using Asd.Infra.Data.Context;
    using System.Linq;

    public class AsdEventStoreSqlRepository : IAsdEventStoreRepository
    {
        private readonly AsdEventStoreSqlContext _context;

        public AsdEventStoreSqlRepository(AsdEventStoreSqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<AsdStoredEvent> AllByAggregateId(Guid aggregateId)
        {
            if (aggregateId == Guid.Empty)
                throw new ArgumentNullException(nameof(aggregateId));
            return _context.StoredEvents.Where(x => x.AggregateId == aggregateId);
        }

        public IEnumerable<AsdStoredEvent> AllByAsdEntityId(Guid asdEntityId)
        {
            if (asdEntityId == Guid.Empty)
                throw new ArgumentNullException(nameof(asdEntityId));
            return _context.StoredEvents.Where(x => x.AsdEntityId == asdEntityId);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Store(AsdStoredEvent storedEvent)
        {
            if (storedEvent == null)
                throw new ArgumentNullException(nameof(storedEvent));
            _context.StoredEvents.Add(storedEvent);
            _context.SaveChanges();
        }
    }
}