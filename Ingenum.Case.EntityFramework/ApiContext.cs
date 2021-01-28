namespace Ingenum.Case.EntityFramework
{
    using Microsoft.EntityFrameworkCore;

    using Ingenum.Case.Model.Database;

    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Table> Tables { get; set; }

        public DbSet<TodoTask> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>()
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
