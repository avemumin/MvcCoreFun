using CarWorkshop.Domain.Interfaces;
using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop;

public class CarWorhshopDtoValidator : AbstractValidator<CarWorkshopDto>
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;

    public CarWorhshopDtoValidator(ICarWorkshopRepository carWorkshopRepository)
    {
        RuleFor(v => v.Name)
            .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
            .MaximumLength(30).WithMessage("Name should have maximum 30 characters")
            .NotEmpty()
            .Custom(
                 (value, context) =>
                {
                    var carWorkName = _carWorkshopRepository?.GetByName(value).Result;
                    if(carWorkName != null)
                    {
                        context.AddFailure($"{value} is not unique name for car workshop");
                    }
                });

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Please enter description");

        RuleFor(v => v.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
        _carWorkshopRepository = carWorkshopRepository;
    }
}
