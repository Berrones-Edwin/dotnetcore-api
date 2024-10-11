using System;
using FluentValidation;
using TodoApi.DTO;

namespace TodoApi.Validations;

public class BeerUpdateValidation : AbstractValidator<BeerUpdateDTO>
{

    public BeerUpdateValidation()
    {

        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required :s");
        RuleFor(x => x.Name).Length(2, 20).WithMessage("Name must be between 2 and 20 characters");
        RuleFor(x => x.BrandID).NotNull().WithMessage("Brand Required");
        RuleFor(x => x.BrandID).GreaterThan(0);
        RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => "{PropertyName} must be greater than 0");

    }
}
