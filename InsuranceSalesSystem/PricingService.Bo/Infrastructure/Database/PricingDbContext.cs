using Microsoft.EntityFrameworkCore;
using PricingService.Bo.Domain;

namespace PricingService.Bo.Infrastructure.Database
{
    public class PricingDbContext : DbContext
    {
        public virtual DbSet<CoverPrice> CoverPrice { get; set; }
        public virtual DbSet<Tariff> Tariff { get; set; }
        public virtual DbSet<TariffVersion> TariffVersion { get; set; }

        public PricingDbContext(DbContextOptions<PricingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tariff>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Code)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.HasMany(x => x.TariffVersions).WithOne();

                entity.HasData(SeedData.Tariffs());
            });

            modelBuilder.Entity<TariffVersion>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CoverFrom)
                    .IsRequired();

                entity.Property(x => x.CoverTo);

                entity.HasMany(x => x.CoverPrices);

                entity.HasData(SeedData.TariffVersions());
            });

            modelBuilder.Entity<CoverPrice>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Code)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.Property(x => x.AgeFrom)
                    .IsRequired();

                entity.Property(x => x.AgeTo)
                    .IsRequired();

                entity.Property(x => x.Price)
                    .HasColumnType("decimal(19,4)")
                    .IsRequired();

                entity.HasData(SeedData.CoverPrices());
            });
        }
    }
}
