namespace Asd.Domain.Interfaces
{
    using Asd.Domain.Core.Commands;
    using System;

    public interface IAsdUnitOfWork : IDisposable
    {
        AsdCommandResponse Commit();
    }
}