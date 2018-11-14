using Microsoft.EntityFrameworkCore;
using PolicyService.Bo.Domain;

namespace PolicyService.Bo.Infrastructure.Database
{
    public class PolicyDbContext : DbContext
    {
        public virtual DbSet<PolicyHolder> PolicyHolder { get; set; }
        public virtual DbSet<PolicyCover> PolicyCover { get; set; }
        public virtual DbSet<PolicyVersion> PolicyVersion { get; set; }
        public virtual DbSet<Policy> Policy { get; set; }
        public virtual DbSet<OfferCover> OfferCover { get; set; }
        public virtual DbSet<Offer> Offer { get; set; }

        public PolicyDbContext(DbContextOptions<PolicyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PolicyHolder>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.LastName)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(x => x.Pesel)
                    .HasMaxLength(11)
                    .IsRequired();
            });

            modelBuilder.Entity<PolicyCover>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CoverCode)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.CoverFrom)
                    .IsRequired();

                entity.Property(x => x.CoverTo)
                    .IsRequired();

                entity.Property(x => x.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<PolicyVersion>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.PolicyNumber)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.PolicyFrom)
                    .IsRequired();

                entity.Property(x => x.PolicyTo)
                    .IsRequired();

                entity.Property(x => x.PolicyStatus)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.ProductCode)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.TotalPremium)
                    .IsRequired();

                entity.Property(x => x.VersionFrom)
                    .IsRequired();

                entity.Property(x => x.VersionTo)
                    .IsRequired();

                entity.Property(x => x.VersionNumber)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.HasOne(x => x.Policy)
                    .WithMany(x => x.PolicyVersions);

                entity.HasMany(x => x.Covers);

                entity.HasOne(x => x.PolicyHolder);
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.ProductCode)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.PolicyNumber)
                    .HasMaxLength(25)
                    .IsRequired();

            }); //.HasBaseType<Offer>();

            modelBuilder.Entity<OfferCover>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CoverCode)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.CoverFrom)
                    .IsRequired();

                entity.Property(x => x.CoverTo)
                    .IsRequired();

                entity.Property(x => x.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.OfferNumber)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.PolicyFrom)
                    .IsRequired();

                entity.Property(x => x.PolicyTo)
                    .IsRequired();

                entity.Property(x => x.OfferStatus)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.ProductCode)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.TotalPrice)
                    .IsRequired();

                entity.Property(x => x.ValidTo)
                    .IsRequired();

                entity.HasMany(x => x.Covers);

                entity.HasOne(x => x.PolicyHolder);
            });
        }
    }
}
