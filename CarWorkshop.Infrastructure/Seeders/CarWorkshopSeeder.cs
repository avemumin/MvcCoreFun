using CarWorkshop.Infrastructure.Persistence;

namespace CarWorkshop.Infrastructure.Seeders;

public class CarWorkshopSeeder
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if (await _dbContext.Database.CanConnectAsync())
        {
            if (!_dbContext.CarWorkshops.Any())
            {
                var autos = new Domain.Entities.CarWorkshop()
                {
                    Name = "Nissan",
                    Description = "Servis Nissan",
                    ContactDetails = new()
                    {
                        City = "Gdańsk",
                        Street = "Grunwaldzka",
                        PostalCode = "80-228",
                        PhoneNumber = "56882131"
                    }
                };
                autos.EncodeName();
                _dbContext.CarWorkshops.Add(autos);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
