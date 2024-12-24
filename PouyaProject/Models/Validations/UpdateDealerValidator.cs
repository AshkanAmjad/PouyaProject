using Domain.ViewModels.Dealer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PouyaProject.Models.Validations
{
    public class UpdateDealerValidator : AbstractValidator<UpdateDealerVM>
    {
        public UpdateDealerValidator()
        {
            RuleFor(p => p.Name).NotNull()
                                .WithMessage("مقدار مناسبی وارد کنید.")
                                .Matches(@"^[\u0600-\u06FF\s]+$")
                                .WithMessage("مقدار ورودی  نام معتبر نیست.");

            RuleFor(p => p.Status).NotNull()
                                  .WithMessage("مقدار مناسبی  وارد کنید");

        }
    }
}