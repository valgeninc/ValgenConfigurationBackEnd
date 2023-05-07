using Microsoft.EntityFrameworkCore;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// DbContext class.
    /// </summary>
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public virtual DbSet<LoginDetails> LoginDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.userName).IsRequired();
                entity.Property(e => e.userPassword).IsRequired();
            });
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
