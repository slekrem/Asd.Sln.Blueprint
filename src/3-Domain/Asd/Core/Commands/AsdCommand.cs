namespace Asd.Domain.Core.Commands
{
    using Asd.Domain.Core.Events;
    using FluentValidation.Results;
    using System;

    public abstract class AsdCommand : AsdMessage
    {
        public DateTime TimestampUtc { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        protected AsdCommand()
        {
            TimestampUtc = DateTime.UtcNow;
        }

        public abstract bool IsValid();
    }
}