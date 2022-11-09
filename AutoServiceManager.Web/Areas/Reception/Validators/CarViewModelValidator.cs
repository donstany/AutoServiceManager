using AutoServiceManager.Web.Areas.Reception.Models;
using FluentValidation;

namespace AutoServiceManager.Web.Areas.Reception.Validators
{
    public class CarViewModelValidator : AbstractValidator<CarViewModel>
    {
        public CarViewModelValidator()
        {
            RuleFor(p => p.Make)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Color)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
        }
    }
}