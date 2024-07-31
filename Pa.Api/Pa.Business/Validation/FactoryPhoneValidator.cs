using FluentValidation;
using Pa.Data.Domain;

namespace Pa.Api.Validation
{
    public class FactoryPhoneValidator: AbstractValidator<FactoryPhone>
    {
        public FactoryPhoneValidator()
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
