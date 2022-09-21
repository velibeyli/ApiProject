using ApiProject.DTO;
using FluentValidation;

namespace ApiProject.Validation
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username can not be empty!")
                .NotNull().WithMessage("Username can not be null!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password can not be empty!")
                .NotNull().WithMessage("Password can not be null!");
        }
    }
}
