using FluentValidation;
using Pa.Base.Schema;
using Pa.Schema.Factory;

namespace Pa.Business.Validation.Request.Factory
{
    public class FactoryRequestValidator : AbstractValidator<FactoryRequest>
    {
        public FactoryRequestValidator(){

            RuleFor(x => x.FactoryName)
                    .NotEmpty().WithMessage("Factory Name is required")
                    .MaximumLength(100).WithMessage("Factory Name must not exceed 100 characters");

            RuleFor(x => x.Capacity)
                    .NotEmpty().WithMessage("Capacity is required")
                    .GreaterThan(0).WithMessage("Capacity must be greater than 0");

            RuleFor(x => x.EmployeeCount)
                    .NotEmpty().WithMessage("Employee Count is required")
                    .GreaterThan(0).WithMessage("Capacity must be greater than 0");

            RuleFor(x => x.EstablishedDate)
                    .NotEmpty().WithMessage("Established Date is required");

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required")
                    .MaximumLength(100).WithMessage("Email must not exceed 100 characters")
                    .EmailAddress().WithMessage("Invalid Email");

            RuleFor(x => x.TaxNumber)
                    .NotEmpty().WithMessage("Tax Number is required")
                    .MaximumLength(50).WithMessage("Tax Number must not exceed 50 characters");
        }
    }
}
