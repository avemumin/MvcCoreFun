using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;

public class EditCarWorkshopCommandValidator :AbstractValidator<EditCarWorkshopCommand>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;

    public EditCarWorkshopCommandValidator(ICarWorkshopRepository carWorkshopRepository)
    {
        RuleFor(v => v.Description)
       .NotEmpty().WithMessage("Please enter description");

        RuleFor(v => v.PhoneNumber)
            .MinimumLength(8)
        .MaximumLength(12);
        _carWorkshopRepository = carWorkshopRepository;
    }

}
