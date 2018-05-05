namespace Asd.Domain.Core.Events
{
    using System;

    public class AsdStoredEvent : AsdEvent
    {
        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }

        public Guid AsdEntityId { get; private set; }

        public AsdStoredEvent(AsdEvent @event, string data, string user)
        {
            if (@event == null)
                throw new ArgumentNullException(nameof(@event));
            if (@event.AsdEntity == null)
                throw new NullReferenceException(nameof(@event.AsdEntity));
            if (@event.AsdEntity.Id == Guid.Empty)
                throw new NullReferenceException(nameof(@event.AsdEntity.Id));
            if (@event.AggregateId == Guid.Empty)
                throw new NullReferenceException(nameof(@event.AggregateId));
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentNullException(nameof(data));
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentNullException(nameof(user));

            Id = Guid.NewGuid();
            AggregateId = @event.AggregateId;
            MessageType = @event.MessageType;
            AsdEntityId = @event.AsdEntity.Id;
            Data = data;
            User = user;
        }

        protected AsdStoredEvent() { }
    }
}