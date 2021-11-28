using FluentValidation;
using Employees.Core.Dtos;

namespace Employees.ServiceInterface.Validators.Others
{
    class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            //RuleFor(x => x.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);
        }
    }
}
