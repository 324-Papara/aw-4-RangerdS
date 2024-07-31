using FluentValidation;
using Pa.Base.Schema;
using Pa.Schema.FactoryPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Validation.Request.FactoryDetail
{
    public class FactoryPhoneRequestValidator : AbstractValidator<FactoryPhoneRequest>
    {
        public FactoryPhoneRequestValidator()
        {
            RuleFor(x => x.IsPrimary)
                    .NotEmpty().WithMessage("Is Primary is required");

            RuleFor(x => x.CountryCode)
                    .NotEmpty().WithMessage("Country Code is required")
                    .MaximumLength(3).WithMessage("Country Code must not exceed 3 characters");

            RuleFor(x => x.PhoneNumber)
                    .NotEmpty().WithMessage("Phone Number is required")
                    .MaximumLength(15).WithMessage("Phone Number must not exceed 15 characters");
        }
    }
}
