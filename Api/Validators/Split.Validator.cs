using FluentValidation;
using SwimmingAppBackend.Api.DTOs;

namespace SwimmingAppBackend.Api.Validators
{
    public class CreateSplitReqValidator : AbstractValidator<CreateSplitReqDTO>
    {
        public CreateSplitReqValidator()
        {
            RuleFor(sp => sp.IntervalTime)
                .GreaterThan(0)
                .NotNull();
            RuleFor(sp => sp.IntervalDistance)
                .GreaterThan(0)
                .LessThanOrEqualTo(1500)
                .NotNull();

            RuleFor(sp => sp.IntervalStrokeRate)
                .GreaterThan(0)
                .LessThanOrEqualTo(200)
                .When(sp => sp.IntervalStrokeRate.HasValue);

            RuleFor(sp => sp.IntervalStrokeCount)
                .GreaterThan(0)
                .LessThanOrEqualTo(200)
                .When(sp => sp.IntervalStrokeCount.HasValue);
        }
    }
}