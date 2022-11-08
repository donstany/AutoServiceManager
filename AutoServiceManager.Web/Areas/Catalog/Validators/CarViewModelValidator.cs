using AutoServiceManager.Web.Areas.Catalog.Models;
using FluentValidation;

namespace AutoServiceManager.Web.Areas.Catalog.Validators
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

            //TODO Stan  -> for BG Plate number has 8 is maximum length ex. CA1445CR
        }
    }
}