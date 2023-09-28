using FluentValidation;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceValidator : AbstractValidator<CreateCarWorkshopServiceCommand>
    {
        public CreateCarWorkshopServiceValidator()
        {
            RuleFor(x => x.Cost).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.CarWorkshopEncodedName).NotEmpty().NotNull();
        }
    }
}
