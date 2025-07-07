using FluentValidation;
using SwimmingAppBackend.Api.DTOs;
namespace SwimmingAppBackend.Api.Validators
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(q => q.NameContains).NotEmpty().Length(3, 30);
            RuleFor(q => q.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(q => q.PageSize).InclusiveBetween(10, 20);
        }
    }


    public class CreateUserReqValidator : AbstractValidator<CreateUserReqDTO>
    {
        public CreateUserReqValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .Length(3, 30);
            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\+\d{10,15}$");
            RuleFor(u => u.DateOfBirth)
                .NotEmpty()
                .NotNull()
                .LessThan(DateTime.UtcNow);
            RuleFor(u => u.Height)
                .GreaterThan(30)
                .LessThan(300);
            RuleFor(u => u.Email)
                .EmailAddress();
            RuleFor(u => u.UserType)
                .NotEmpty()
                .NotNull();


        }
    }

    public class UpdateUserReqValidator : AbstractValidator<UpdateUserReqDTO>
    {
        public UpdateUserReqValidator()
        {
            RuleFor(u => u.Name)
                .Length(3, 30);
            RuleFor(u => u.DateOfBirth)
                .LessThan(DateTime.UtcNow);
            RuleFor(u => u.Height)
                .GreaterThan(30)
                .LessThan(300);
            RuleFor(u => u.Email)
                .EmailAddress();
        }
    }
}