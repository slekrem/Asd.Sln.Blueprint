namespace Asd.Infra.Data.UoW
{
    using Asd.Domain.Core.Commands;
    using Asd.Domain.Interfaces;
    using Asd.Infra.Data.Context;
    using System;

    public class AsdUnitOfWork<T> : IAsdUnitOfWork where T : AsdSqlContext
    {
        private readonly T _context;

        public AsdUnitOfWork(T context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AsdCommandResponse Commit()
        {
            return _context.SaveChanges() > 0 ? AsdCommandResponse.Ok : AsdCommandResponse.Fail;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}