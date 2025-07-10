using FluentValidation;
using SwimmingAppBackend.Api.DTOs;
using SwimmingAppBackend.Domain.Helpers;

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

            RuleFor(s => s)
                .Custom((swim, context) =>
                {
                    int eventDistance = EventHelper.GetDistance(swim.Event);

                    foreach (var (split, index) in swim.Splits.Select((s, i) => (s, i)))
                    {
                        int splitDistance = split.IntervalDistance;

                        if (!IsValidSplitDistance(eventDistance, splitDistance))
                        {
                            context.AddFailure($"Splits[{index}].IntervalDistance",
                                $"Invalid split distance {splitDistance}m for {eventDistance}m event.");
                        }

                        if (!EventHelper.IsStrokeValid(split.Stroke, swim.Event))
                        {
                            context.AddFailure($"Splits[{index}].Stroke",
                                $"Invalid split stroke {split.Stroke} for {swim.Event} event");
                        }
                    }
                });
        }

        private bool IsValidSplitDistance(int eDist, int sDist)
        {
            if (sDist > eDist)
            {
                return false;
            }

            if (eDist <= 100)
                return sDist % 5 == 0;
            else if (eDist <= 400)
                return sDist % 25 == 0;
            else
                return sDist % 50 == 0;
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