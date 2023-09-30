using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;

using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection sercvice)
    {
        sercvice.AddMediatR(typeof(CreateCarWorkshopCommand));

        sercvice.AddAutoMapper(typeof(CarWorkshopMappingProfile));

        sercvice.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
