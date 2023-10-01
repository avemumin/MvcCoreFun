using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;

public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;
    private readonly IMapper _mapper;

    public EditCarWorkshopCommandHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
    {
        _carWorkshopRepository = carWorkshopRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
    {
        var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);

        carWorkshop.Description = request.Description;
        carWorkshop.About = request.About;

        carWorkshop.ContactDetails.City = request.City;
        carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
        carWorkshop.ContactDetails.Street = request.Street;
        carWorkshop.ContactDetails.PostalCode = request.PostalCode;

       await _carWorkshopRepository.Commit();

        return Unit.Value;
    }
}
