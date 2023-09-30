using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CDE = CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;

namespace CarWorkshop.Application.Services;

public class CarWorkshopService : ICarWorkshopService
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;

    public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task Create(CarWorkshopDto carWorkshopDto)
    {
        var carWorkshop = _mapper.Map<CDE.CarWorkshop>(carWorkshopDto);
        carWorkshop.EncodeName();
        await _carWorkshopRepository.Create(carWorkshop);
    }
}
