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

        public virtual DbSet<Subscriptions> Subscriptions { get; set; }

        public virtual DbSet<SubscriptionServices> SubscriptionServices { get; set; }

        public virtual DbSet<APIEndPoints> APIEndPoints { get; set; }
        
        public virtual DbSet<APILogs> APILogs { get; set; }

        public virtual DbSet<ServicesTracking> ServicesTrackings { get; set; }
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
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
            });
            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.Property(e => e.SubscriptionId).IsRequired();
                entity.Property(e => e.SubscriberId).IsRequired();
                entity.Property(e => e.Token);
                entity.Property(e => e.StartDate).IsRequired(false);
                entity.Property(e => e.EndDate).IsRequired(false);
                entity.Property(e => e.isActive);
            });
            modelBuilder.Entity<SubscriptionServices>(entity =>
            {
                entity.ToTable("Services");
                entity.Property(e => e.ServiceId);
                entity.Property(e => e.SubscriptionId).IsRequired();
                entity.Property(e => e.ConfigJson);
                entity.Property(e => e.EndPointId);
            });

            modelBuilder.Entity<Subscribers>(entity =>
            {
                entity.ToTable("Subscribers", tb => tb.HasTrigger("UpdateModifiedDate"));
            });
            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.ToTable("Subscriptions", tb => tb.HasTrigger("UPDATESUBSCRIPTIONMODIFIEDDATE"));
            });
            modelBuilder.Entity<APIEndPoints>(entity =>
            {
                entity.Property(e => e.EndPointId);
                entity.Property(e => e.EndPointDesc);
            });
            modelBuilder.Entity<APILogs>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.OwnerId);
                entity.Property(e => e.MessageType);
            });
            modelBuilder.Entity<ServicesTracking>()
                .HasKey(a => new { a.SubscriptionId, a.EndPointId, a.RecordType });
            modelBuilder.Entity<ServicesTracking>(entity =>
            {
                entity.ToTable("ServicesTracking");
                entity.Property(e => e.SubscriptionId);
                entity.Property(e => e.EndPointId);
                entity.Property(e => e.RecordType);
                entity.Property(e => e.TotalRecordsFetched);
                entity.Property(e => e.RecordsId);
                entity.Property(e => e.UpdatedOn);
            });
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}
