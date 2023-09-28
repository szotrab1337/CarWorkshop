using CarWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistence
{
    public class CarWorkshopDbContext : IdentityDbContext
    {
        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }
        public DbSet<CarWorkshopService> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Domain.Entities.CarWorkshop>()
                .OwnsOne(x => x.ContactDetails);

            builder.Entity<Domain.Entities.CarWorkshop>()
                .HasMany(x => x.Services)
                .WithOne(y => y.CarWorkshop)
                .HasForeignKey(c => c.CarWorkshopId);
        }
    }
}
