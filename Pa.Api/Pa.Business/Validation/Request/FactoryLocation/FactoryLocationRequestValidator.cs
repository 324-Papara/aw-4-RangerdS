using FluentValidation;
using Pa.Base.Schema;
using Pa.Schema.FactoryLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pa.Business.Validation.Request.FactoryLocation
{
    public class FactoryLocationRequestValidator : AbstractValidator<FactoryLocationRequest>
    {
        public FactoryLocationRequestValidator()
        {
            RuleFor(x => x.LocationName)
                    .NotEmpty().WithMessage("Location Name is required")
                    .MaximumLength(100).WithMessage("Location Name must not exceed 100 characters");

            RuleFor(x => x.Country)
                    .NotEmpty().WithMessage("Country is required")
                    .MaximumLength(30).WithMessage("Country must not exceed 30 characters");

            RuleFor(x => x.City)
                    .NotEmpty().WithMessage("City is required")
                    .MaximumLength(30).WithMessage("City must not exceed 30 characters");

            RuleFor(x => x.District)
                    .NotEmpty().WithMessage("District is required")
                    .MaximumLength(30).WithMessage("District must not exceed 30 characters");

            RuleFor(x => x.Address)
                    .NotEmpty().WithMessage("Address is required")
                    .MaximumLength(250).WithMessage("Address must not exceed 250 characters");

            RuleFor(x => x.PostalCode)
                    .NotEmpty().WithMessage("Postal Code is required")
                    .MaximumLength(6).WithMessage("Postal Code must not exceed 6 characters");
        }
    }
}
