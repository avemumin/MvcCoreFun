using CarWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistence;

public class CarWorkshopDbContext : DbContext
{
    
    public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var cn = "Server=minisforum\\MSSQLSERVER2022; Database = CarWorkshop; User Id = sa; Password = 5432!qaz; Trusted_Connection = True; Encrypt = False; TrustServerCertificate = True;";
        optionsBuilder.UseSqlServer(cn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.CarWorkshop>()
            .OwnsOne(c => c.ContactDetails);
    }
}
