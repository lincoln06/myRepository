using FluentValidation;
using MyRepository.Classes.Model;


namespace MyRepository.Classes.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 15);
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 20);
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}
