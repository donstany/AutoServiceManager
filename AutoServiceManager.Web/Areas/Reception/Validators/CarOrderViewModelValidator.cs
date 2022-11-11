using AutoServiceManager.Web.Areas.Reception.Models;
using FluentValidation;

namespace AutoServiceManager.Web.Areas.Reception.Validators
{
    public class CarOrderViewModelValidator : AbstractValidator<CarOrderViewModel>
    {
        public CarOrderViewModelValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(5).WithMessage("{PropertyName} must greather than 5 characters.")
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed 300 characters.");

            RuleFor(p => p.CarId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        }
    }
}