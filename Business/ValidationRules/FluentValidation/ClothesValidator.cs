using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ClothesValidator : AbstractValidator<Clothes>
    {
        public ClothesValidator()
        {
            RuleFor(c => c.ClothesName).NotEmpty();
            RuleFor(c => c.ClothesName).MinimumLength(2);
            RuleFor(c => c.UnitPrice).NotEmpty();
            RuleFor(c => c.UnitPrice).GreaterThan(0);

        }
    }
}
