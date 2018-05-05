namespace Asd.Infra.Data.Context
{
    using Asd.Domain.Core.Events;
    using Microsoft.EntityFrameworkCore;

    public class AsdEventStoreSqlContext : DbContext
    {
        public DbSet<AsdStoredEvent> StoredEvents { get; set; }

        public AsdEventStoreSqlContext(DbContextOptions<AsdEventStoreSqlContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}