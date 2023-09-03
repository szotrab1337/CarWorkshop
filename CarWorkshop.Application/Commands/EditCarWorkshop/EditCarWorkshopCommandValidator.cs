using FluentValidation;

namespace CarWorkshop.Application.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(x => x.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
