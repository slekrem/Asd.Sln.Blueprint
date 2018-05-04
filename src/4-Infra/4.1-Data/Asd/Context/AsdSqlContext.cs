namespace Asd.Infra.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    public abstract class AsdSqlContext : DbContext
    {
        public AsdSqlContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
