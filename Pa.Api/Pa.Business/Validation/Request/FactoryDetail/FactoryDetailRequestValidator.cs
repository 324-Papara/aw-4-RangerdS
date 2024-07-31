using FluentValidation;
using Pa.Base.Schema;
using Pa.Schema.FactoryDetail;

namespace Pa.Business.Validation.Request.FactoryDetail
{
    public class FactoryDetailRequestValidator : AbstractValidator<FactoryDetailRequest>
    {
        public FactoryDetailRequestValidator()
        {
            RuleFor(x => x.FactoryProfile)
                    .NotEmpty().WithMessage("Factory Profile is required")
                    .MaximumLength(500).WithMessage("Factory Profile must not exceed 500 characters");

            RuleFor(x => x.FactoryHistory)
                    .NotEmpty().WithMessage("Factory History is required")
                    .MaximumLength(500).WithMessage("Factory History must not exceed 500 characters");

            RuleFor(x => x.FactoryMission)
                    .NotEmpty().WithMessage("Factory Mission is required")
                    .MaximumLength(500).WithMessage("Factory Mission must not exceed 500 characters");

            RuleFor(x => x.FactoryVision)
                    .NotEmpty().WithMessage("Factory Vision is required")
                    .MaximumLength(500).WithMessage("Factory Vision must not exceed 500 characters");

            RuleFor(x => x.FactoryValues)
                    .NotEmpty().WithMessage("Factory Values is required")
                    .MaximumLength(500).WithMessage("Factory Values must not exceed 500 characters");

            RuleFor(x => x.FactoryQualityPolicy)
                    .NotEmpty().WithMessage("Factory Quality Policy is required")
                    .MaximumLength(500).WithMessage("Factory Quality Policy must not exceed 500 characters");

            RuleFor(x => x.FactoryCertificates)
                    .NotEmpty().WithMessage("Factory Certificates is required")
                    .MaximumLength(500).WithMessage("Factory Certificates must not exceed 500 characters");
        }
    }
}
