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

        public virtual DbSet<Subscribers> Subscribers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginDetails>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.userName).IsRequired();
                entity.Property(e => e.userPassword).IsRequired();
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Token);
                entity.Property(e => e.StartDate).IsRequired(false);
                entity.Property(e => e.EndDate).IsRequired(false);
                entity.Property(e => e.ConfigJSON);
            });
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
