namespace Asd.Domain.Core.Events
{
    using Asd.Domain.Core.Models;
    using System;

    public abstract class AsdEvent : AsdMessage
    {
        private readonly AsdEntity _entity;

        public DateTime TimestampUtc { get; private set; }

        public AsdEntity AsdEntity => _entity;

        public AsdEvent(AsdEntity entity, Guid aggregateId)
            : this()
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            AggregateId = aggregateId != Guid.Empty ? aggregateId : throw new ArgumentNullException(nameof(aggregateId));
        }

        protected AsdEvent()
        {
            TimestampUtc = DateTime.UtcNow;
        }
    }
}