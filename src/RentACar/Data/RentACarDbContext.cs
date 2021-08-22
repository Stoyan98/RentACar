using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Data.Models;

namespace RentACar.Data
{
    public class RentACarDbContext : IdentityDbContext<User>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }

        public DbSet<Category> Categories { get; init; }

        public DbSet<Dealer> Dealers { get; init; }

        public DbSet<Rent> Rents { get; init; }

        public DbSet<Comment> Comments { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Car>()
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Rent>()
                .HasOne(c => c.Car)
                .WithMany(r => r.Rents)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Comment>()
                .HasOne(c => c.Car)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Dealer>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Rent>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Rent>(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Comment>()
            //    .HasOne<User>()
            //    .WithOne()
            //    .HasForeignKey<Comment>(r => r.UserId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
