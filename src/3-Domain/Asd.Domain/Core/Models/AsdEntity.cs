namespace Asd.Domain.Core.Models
{
    using System;

    public abstract class AsdEntity
    {
        public Guid Id { get; protected set; }

        public bool Deleted { get; set; }
    }
}