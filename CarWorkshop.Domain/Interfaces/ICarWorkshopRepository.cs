﻿namespace CarWorkshop.Domain.Interfaces;

public interface ICarWorkshopRepository
{
    Task Create(Entities.CarWorkshop carWorkshop);
    Task<Entities.CarWorkshop?> GetByName(string value);
    Task<IEnumerable<Entities.CarWorkshop>> GetAll();
    Task<Entities.CarWorkshop> GetByEncodedName(string encededName);
    Task Commit();
}
