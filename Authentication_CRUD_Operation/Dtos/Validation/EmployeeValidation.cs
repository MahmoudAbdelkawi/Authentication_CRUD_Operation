using FluentValidation;

namespace Authentication_CRUD_Operation.Dtos.Validation
{
    public class EmployeeValidation : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid Email Address");
            RuleFor(x => x.Salary).LessThan(10000).GreaterThan(0).WithMessage("Salary in range 0 - 10000");
        }
    }
}
