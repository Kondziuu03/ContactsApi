using Contacts.Entities;
using FluentValidation;
using System.Linq;

namespace Contacts.Models.Validators
{
    public class CreateCompanyDtoValidator : AbstractValidator<CreateCompanyDto>
    {
        private readonly ApplicationDbContext _context;

        public CreateCompanyDtoValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Name).Must(ValidCompanyName).WithMessage("Company with this name exists");

            RuleFor(x => x.Description)
                .MaximumLength(200);

            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.Street)
                .NotEmpty();
            RuleFor(x => x.PostalCode)
                .NotEmpty();
            
        }

        private bool ValidCompanyName(string Name)
        {
            if (_context.Companies.Any(x => x.Name == Name)) return false;
            else return true;
        }
    }
}
