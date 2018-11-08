﻿using Microsoft.EntityFrameworkCore;
using PricingService.Bo.Domain;

namespace PricingService.Bo.Infrastructure.Database
{
    public class PricingDbContext : DbContext
    {
        public virtual DbSet<CoverPrice> CoverPrice { get; set; }
        public virtual DbSet<PolicyHolder> PolicyHolder { get; set; }
        public virtual DbSet<PolicyPrice> PolicyPrice { get; set; }
        public virtual DbSet<Tariff> Tariff { get; set; }
        public virtual DbSet<TariffVersion> TariffVersion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MCHROBAK-NB1\MSSQLSERVER2012;Database=ISS;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                    .IsRequired();
            });

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

            modelBuilder.Entity<PolicyPrice>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.ProductCode)
                    .HasMaxLength(25)
                    .IsRequired();

                //entity.HasOne(x => x.PolicyHolder);

                //entity.HasMany(x => x.SelectedCovers);
            });

            modelBuilder.Entity<Tariff>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Code)
                    .HasMaxLength(25)
                    .IsRequired();

                //entity.HasMany(x => x.TariffVersions);
            });

            modelBuilder.Entity<TariffVersion>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CoverFrom)
                    .IsRequired();

                entity.Property(x => x.CoverTo);

                //entity.HasMany(x => x.CoverPrices);
            });
        }
    }
}
