using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipperValidator :AbstractValidator<Shipper>
    {
        public ShipperValidator()
        {
            RuleFor(s => s.ShipperName).NotEmpty();
            RuleFor(s => s.ShipperName).MinimumLength(2);
            RuleFor(s => s.Freight).NotEmpty();
        }
    }
}
