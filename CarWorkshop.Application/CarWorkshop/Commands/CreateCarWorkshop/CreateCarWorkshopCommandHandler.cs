using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using CDE = CarWorkshop.Domain.Entities;
namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;

public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;

    public CreateCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = _mapper.Map<CDE.CarWorkshop>(request);
        carWorkshop.EncodeName();
        await _carWorkshopRepository.Create(carWorkshop);

        return Unit.Value;
    }
}
