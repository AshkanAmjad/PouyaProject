using Domain.ViewModels.Dealer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PouyaProject.Models.Validations
{
    public class CreateDealerValidator : AbstractValidator<CreateDealerVM>
    {
        public CreateDealerValidator()
        {
            RuleFor(p => p.Name).NotNull()
                                .WithMessage("مقدار مناسبی وارد کنید.")
                                .Matches(@"^[\u0600-\u06FF\s]+$")
                                .WithMessage("مقدار ورودی  نام معتبر نیست.");

            RuleFor(p => p.Status).NotNull()
                                  .WithMessage("مقدار مناسبی  وارد کنید");

            RuleFor(p => p.CityId).NotNull()
                                  .WithMessage("مقدار مناسبی وارد کنید.");
        }
    }
}