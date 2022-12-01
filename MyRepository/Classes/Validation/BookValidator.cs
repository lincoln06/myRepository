using FluentValidation;
using System;

namespace MyRepository.Classes
{
    public class BookValidator:AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().Length(3, 15);
            RuleFor(x => x.LastName).NotNull().NotEmpty().Length(3, 20);
            RuleFor(x => x.Year).LessThanOrEqualTo(ushort.Parse(DateTime.Now.ToString("YYYY")));
            RuleFor(x => x.Title).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Genre).NotNull().NotEmpty().MinimumLength(5);
        }
    }
}
