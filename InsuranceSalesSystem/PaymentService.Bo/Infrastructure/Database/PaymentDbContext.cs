using Microsoft.EntityFrameworkCore;
using PaymentService.Bo.Domain;

namespace PaymentService.Bo.Infrastructure.Database
{
    public class PaymentDbContext : DbContext
    {
        public virtual DbSet<PolicyAccount> PolicyAccount { get; set; }
        public virtual DbSet<AccountOperation> AccountOperation { get; set; }
        
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PolicyAccount>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.PolicyNumber)
                    .HasMaxLength(25)
                    .IsRequired();

                entity.HasMany(x => x.AccountOperations);
            });

            modelBuilder.Entity<AccountOperation>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Amount)
                    .HasColumnType("decimal(19,4)")
                    .IsRequired();

                entity.Property(x => x.EffectiveDate)
                    .IsRequired();

                entity.Property(x => x.RegistrationDate)
                    .IsRequired();
            });

            modelBuilder.Entity<RegisteredPayment>();
            modelBuilder.Entity<ExpectedPayment>();
            modelBuilder.Entity<Refund>();
        }
    }
}
