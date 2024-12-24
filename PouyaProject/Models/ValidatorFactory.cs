using Domain.ViewModels.City;
using Domain.ViewModels.Dealer;
using FluentValidation;
using PouyaProject.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PouyaProject.Models
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();
        static ValidatorFactory()
        {
            validators.Add(typeof(IValidator<CreateCityVM>), new CreateCityValidator());
            validators.Add(typeof(IValidator<UpdateCityVM>), new UpdateCityValidator());
            validators.Add(typeof(IValidator<CreateDealerVM>), new CreateDealerValidator());
            validators.Add(typeof(IValidator<UpdateDealerVM>), new UpdateDealerValidator());

        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;
            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }
            return validator;
        }
    }
}