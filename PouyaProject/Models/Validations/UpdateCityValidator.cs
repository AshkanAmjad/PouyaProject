using Domain.ViewModels.City;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PouyaProject.Models.Validations
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityVM>
    {
        public UpdateCityValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Name).NotEmpty()
                                .WithMessage("مقدار مناسبی  وارد کنید")
                                .Matches(@"^[\u0600-\u06FF\s]+$")
                                .WithMessage("مقدار ورودی  نام معتبر نیست.")
                                .MaximumLength(50)
                                .WithMessage("حداکثر ورودی نام شهر 50 کارکتر است");

        }
    }
}