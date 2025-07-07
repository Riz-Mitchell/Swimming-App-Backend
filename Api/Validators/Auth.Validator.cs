using FluentValidation;

namespace SwimmingAppBackend.Api.Validators
{
    public class OTPReqValidator : AbstractValidator<OTPReqDTO>
    {
        public OTPReqValidator()
        {
            RuleFor(req => req.PhoneNum)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\+\d{10,15}$")
                .WithMessage("Phone number must be in the format +XXXXXXXXXX");
        }
    }

    public class LoginReqValidator : AbstractValidator<LoginReqDTO>
    {
        public LoginReqValidator()
        {
            RuleFor(req => req.PhoneNum)
                .NotEmpty()
                .NotNull()
                .Matches(@"^\+\d{10,15}$")
                .WithMessage("Phone number must be in the format +XXXXXXXXXX");

            RuleFor(req => req.OTP)
                .NotEmpty()
                .NotNull()
                .Length(6)
                .WithMessage("OTP must be exactly 6 digits");
        }
    }
}