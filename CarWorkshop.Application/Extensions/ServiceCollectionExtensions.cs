using CarWorkshop.Application.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCarWorkshopCommand).Assembly));
            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));
            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
