using FluentValidation;
using SwimmingAppBackend.Api.DTOs;

namespace SwimmingAppBackend.Api.Validators
{
    public class GetSwimsQueryValidator : AbstractValidator<GetSwimsQuery>
    {
        public GetSwimsQueryValidator()
        {
            RuleFor(q => q.Page)
                .GreaterThanOrEqualTo(1);
            RuleFor(q => q.PageSize)
                .InclusiveBetween(1, 100);
            RuleFor(q => q.OnlyPersonalBest)
                .Must((q, OnlyPersonalBest) => !(q.OnlyGoalSwim && OnlyPersonalBest));
        }
    }

    public class CreateSwimReqValidator : AbstractValidator<CreateSwimReqDTO>
    {
        public CreateSwimReqValidator()
        {
            RuleFor(s => s.PerceivedExertion)
                .InclusiveBetween(1, 10)
                .When(s => s.PerceivedExertion.HasValue);
            RuleFor(s => s.Splits)
                .NotEmpty();

            RuleForEach(s => s.Splits)
                .SetValidator(new CreateSplitReqValidator());
        }
    }

    public class UpdateSwimReqValidator : AbstractValidator<UpdateSwimReqDTO>
    {
        public UpdateSwimReqValidator()
        {
            RuleFor(s => s.Event)
                .IsInEnum()
                .When(s => s.Event.HasValue);
            RuleFor(s => s.PerceivedExertion)
                .InclusiveBetween(1, 10)
                .When(s => s.PerceivedExertion.HasValue);
            RuleFor(s => s.GoalSwim)
                .NotNull();
        }
    }
}