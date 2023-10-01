﻿using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories;

public class CarWorkshopRepository : ICarWorkshopRepository
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopRepository(CarWorkshopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
    {
        _dbContext.Add(carWorkshop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
    {
        return await _dbContext.CarWorkshops.ToListAsync();
    }

    public async Task<Domain.Entities.CarWorkshop?> GetByName(string value)
    {
        return await _dbContext.CarWorkshops
            .FirstOrDefaultAsync(c => c.Name.ToLower() == value.ToLower());

    }

    public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
    {
        return await _dbContext.CarWorkshops.FirstAsync(c => c.EncodedName == encodedName);
    }
}
