using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.ClothesId).NotEmpty();
            RuleFor(o => o.CustomerId).NotEmpty();
            RuleFor(o => o.ShipperId).NotEmpty();
            RuleFor(o => o.OrderDate).NotEmpty();
        }
    }
}
