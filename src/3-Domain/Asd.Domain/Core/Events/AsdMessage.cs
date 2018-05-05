namespace Asd.Domain.Core.Events
{
    using System;

    public abstract class AsdMessage
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        protected AsdMessage()
        {
            MessageType = GetType().Name;
        }
    }
}