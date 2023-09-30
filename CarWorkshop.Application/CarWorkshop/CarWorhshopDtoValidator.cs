using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop;

public class CarWorhshopDtoValidator : AbstractValidator<CarWorkshopDto>
{

    public CarWorhshopDtoValidator()
    {
        RuleFor(v => v.Name)
            .MinimumLength(2).WithMessage("Name should have atleast 2 characters")
            .MaximumLength(30).WithMessage("Name should have maximum 30 characters")
            .NotEmpty();

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Please enter description");

        RuleFor(v => v.PhoneNumber)
            .MinimumLength(8)
            .MaximumLength(12);
    }
}
